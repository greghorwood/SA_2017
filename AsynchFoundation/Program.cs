using AsynchFoundation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestingAsync
{
    class Program
    {
        static volatile bool flag = false;
        static bool hasUnitNo = false;

        static void Main(string[] args)
        {
            var ctx = new SA_2017Context();
            var dSet = ctx.StudentAddresses2017.Where(a => a.Verified == false);
            string finalAddress = string.Empty;
            decimal student_details_id = 0L;
            foreach (var addressElement in dSet)
            {
                hasUnitNo = false;
                finalAddress = addressElement.UnitNoX + "," +
                               addressElement.HouseNoX + "," +
                               addressElement.StreetNameX + "," +
                               addressElement.StreetTypeX + "," +
                               addressElement.SuburbX + "," +
                               addressElement.PostCodeX;

                if (addressElement.UnitNoX != null)
                {
                    hasUnitNo = true;
                }

                student_details_id = addressElement.StudentDetailsIdX;
                var requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(finalAddress.TrimStart(',')) + "&key=AIzaSyBLiFKNSzVxEjm9Sexj5qxTDKejN3TEHvc");
                Send(requestUri, student_details_id);
            }

            //Console.WriteLine("Press Enter to exit");
            //Console.ReadLine();
        }

        private static void Send(string address, decimal studentDetailsId)
        {
            flag = false;
            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> responseTask = client.GetAsync(address);
            responseTask.ContinueWith(x => WriteToDB(x, studentDetailsId));
            while(!flag)
            {

            }
            Console.WriteLine("Finished");
        }

        private static void WriteToDB(Task<HttpResponseMessage> httpTask, decimal studentDetailsID)
        {
            try
            {
                Task<string> task = httpTask.Result.Content.ReadAsStringAsync();

                Task continuation = task.ContinueWith(t =>
                {
                    Console.WriteLine("Result: " + t.Result); //Write to dB here.

                    XDocument xml = XDocument.Parse(t.Result);

                    var status = xml.Descendants("status").FirstOrDefault().Value;
                                 
                    Console.WriteLine(status.ToString());

                    if (status == "OK")
                    {
                        try
                        {
                            string UnitNo = null;

                            if (hasUnitNo)
                            {
                                UnitNo = (from xFi in xml.Descendants("address_component")
                                              where xFi.Element("type").Value == "subpremise"
                                              select xFi.Element("long_name")).FirstOrDefault().Value;
                            }
                            else
                            {
                                UnitNo = null;
                            }

                            var streetNumber = (from xFi in xml.Descendants("address_component")
                                                where xFi.Element("type").Value == "street_number"
                                                select xFi.Element("long_name")).FirstOrDefault().Value;

                            var streetName = (from xFi in xml.Descendants("address_component")
                                              where xFi.Element("type").Value == "route"
                                              select xFi.Element("long_name")).FirstOrDefault().Value;

                            var streetNameOnly = streetName.Remove(streetName.LastIndexOf(" "));

                            var streetType = streetName.Split(' ').Last();

                            var Suburb = (from xFi in xml.Descendants("address_component")
                                          where xFi.Element("type").Value == "locality"
                                          select xFi.Element("long_name")).FirstOrDefault().Value;

                            var State = (from xFi in xml.Descendants("address_component")
                                         where xFi.Element("type").Value == "administrative_area_level_1"
                                         select xFi.Element("short_name")).FirstOrDefault().Value;

                            using (SA_2017Context db = new SA_2017Context())
                            {
                                var changedAddress = db.StudentAddresses2017.Where(d => d.StudentDetailsIdX == studentDetailsID).First();
                                if (hasUnitNo)
                                {
                                    changedAddress.UnitNoX = UnitNo;
                                }
                                changedAddress.HouseNoX = streetNumber;
                                changedAddress.StreetNameX = streetNameOnly;
                                changedAddress.StreetTypeX = streetType;
                                changedAddress.SuburbX = Suburb;
                                changedAddress.StateX = State;
                                changedAddress.Verified = true;
                                db.SaveChanges();
                                Console.WriteLine("Changes writtent to DB");
                            }
                        }
                        catch (NullReferenceException)
                        {
                            flag = true;
                            return;
                        }
                        catch (System.ArgumentOutOfRangeException)
                        {
                            flag = true;
                            return;
                        }
                    }
                    flag = true;
                    Console.WriteLine("Finished Writing Out Result");
                });
            }
            catch (Exception e)
            {
                flag = true;
                Console.Write(e.Message);
            }
        }
    }
}