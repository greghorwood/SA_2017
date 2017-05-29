use SA_2017_Files

begin tran
update StudentAddresses_2017
	set Boarding_X = isnull(sc.boarder_flag, 'N')
from StudentAddresses_2017 sa
inner join shsqlstage01.cis.dbo.student_details sd on sa.Student_Details_ID_X = sd.student_details_id
inner join shsqlstage01.cis.dbo.student_characteristics sc on sc.student_details_id = sd.student_details_id

commit
where
	sa.Verified = 1


select * from shsqlstage01.cis.dbo.student_characteristics