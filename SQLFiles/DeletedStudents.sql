use SA_2017_Files

begin tran
delete from StudentAddresses_2017 where Student_Details_ID_X in (
select
	sd.student_details_id
from shsqlprime01.cis.dbo.student_details sd
inner join shsqlprime01.cis.dbo.student_characteristics sc on sc.student_details_id = sd.student_details_id
inner join shsqlprime01.cis.dbo.school s on s.schl_id = sd.schl_id
inner join StudentAddresses_2017 sa2017 on sa2017.Student_Details_ID_X = sd.student_details_id
where
	sc.year = '2017'
	and sc.left_school_flag = 'n'
	and s.ceo_emplr_no = 'e1188'
	and sd.student_id in  ('5532', '5712'))

--commit


begin tran
delete from StudentAddresses_2017 where Student_Details_ID_X in (
select
	sd.student_details_id
from shsqlprime01.cis.dbo.student_details sd
inner join shsqlprime01.cis.dbo.student_characteristics sc on sc.student_details_id = sd.student_details_id
inner join shsqlprime01.cis.dbo.school s on s.schl_id = sd.schl_id
where
	sc.year = '2017'
	and sc.left_school_flag = 'n'
	and s.ceo_emplr_no = 'e1316'
	and sd.student_id in  ('6095', '6431', '6453', '6628', '6643'))

--commit



begin tran
delete from StudentAddresses_2017 where Student_Details_ID_X in (
select
	sd.student_details_id
from shsqlprime01.cis.dbo.student_details sd
inner join shsqlprime01.cis.dbo.student_characteristics sc on sc.student_details_id = sd.student_details_id
inner join shsqlprime01.cis.dbo.school s on s.schl_id = sd.schl_id
where
	sc.year = '2017'
	and sc.left_school_flag = 'n'
	and s.ceo_emplr_no = 'e4037'
	and sd.student_id in  ('23508', '25192'))

--commit


begin tran
delete from StudentAddresses_2017 where Student_Details_ID_X in (
select
	sd.student_details_id
from shsqlprime01.cis.dbo.student_details sd
inner join shsqlprime01.cis.dbo.student_characteristics sc on sc.student_details_id = sd.student_details_id
inner join shsqlprime01.cis.dbo.school s on s.schl_id = sd.schl_id
where
	sc.year = '2017'
	and sc.left_school_flag = 'n'
	and s.ceo_emplr_no = 'e1312'
	and sd.student_id in  ('101952', '102118'))

--commit




begin tran
delete from StudentAddresses_2017 where Student_Details_ID_X in (
select
	sd.student_details_id
from shsqlprime01.cis.dbo.student_details sd
inner join shsqlprime01.cis.dbo.student_characteristics sc on sc.student_details_id = sd.student_details_id
inner join shsqlprime01.cis.dbo.school s on s.schl_id = sd.schl_id
where
	sc.year = '2017'
	and sc.left_school_flag = 'n'
	and s.ceo_emplr_no = 'e1231'
	and sd.student_id in  ('201260'))

--commit


begin tran
delete from StudentAddresses_2017 where Student_Details_ID_X in (
select
	sd.student_details_id
from shsqlprime01.cis.dbo.student_details sd
inner join shsqlprime01.cis.dbo.student_characteristics sc on sc.student_details_id = sd.student_details_id
inner join shsqlprime01.cis.dbo.school s on s.schl_id = sd.schl_id
where
	sc.year = '2017'
	and sc.left_school_flag = 'n'
	and s.ceo_emplr_no = 'e1223'
	and sd.student_id in  ('209894', '212887'))

commit