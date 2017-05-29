use SA_2017_Files

select
	sa2017.ClientNumber_X
	,sa2017.CampusNo_X
	,sa2017.Student_Details_ID_X
	,sa2017.LotNo_X
	,sa2017.UnitNo_X
	,sa2017.HouseNo_X
	,sa2017.PropertyName_X
	,sa2017.StreetName_X
	,sa2017.StreetType_X
	,sa2017.Suburb_X
	,sa2017.PostCode_X
	,sa2017.State_X
	,sa2017.Comments_X
	,sa2017.ShlType_X
	,sa2017.Boarding_X
from StudentAddresses_2017 sa2017
where
	sa2017.Suburb_X is not null
