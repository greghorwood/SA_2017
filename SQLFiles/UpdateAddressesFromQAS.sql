use SA_2017_Files

select
	*
from StudentAddress_AUG

begin tran
update StudentAddresses_2017
	set [LotNo_X] = aug.[LotNo_Xout],
	[UnitNo_X] = aug.[UnitNo_X],
	[HouseNo_X] = aug.[HouseNo_Xout],
	[PropertyName_X] = aug.[PropertyName_X],
	[StreetName_X] = aug.[StreetName_Xout],
	[StreetType_X] = aug.[StreetType_Xout],
	[Suburb_X] = aug.[Suburb_Xout],
	[PostCode_X] = aug.[Postcode_Xout],
	[State_X] = aug.[State_Xout]
from StudentAddresses_2017 sa
inner join StudentAddress_AUG aug on aug.Student_Details_ID_X = sa.Student_Details_ID_X
where	
	aug.[suburb_Xout] is not null
	and aug.Student_Details_ID_X = sa.Student_Details_ID_X


commit
rollback tran


select
	*
from StudentAddresses_2017