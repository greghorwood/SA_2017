use SA_2017_Files

begin tran
delete from  StudentAddresses_2017
from StudentAddresses_2017 sa
inner join shsqlprime01.cis.dbo.student_details sd on sa.Student_Details_ID_X = sd.student_details_id
inner join shsqlprime01.cis.dbo.student_characteristics sc on sc.student_details_id = sd.student_details_id
where
	sd.Student_On_Extended_Leave = 'y'

