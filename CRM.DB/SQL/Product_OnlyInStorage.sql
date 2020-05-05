drop procedure if exists dbo.Product_OnlyInStorage
go
create proc [dbo].[Product_OnlyInStorage]
@CountryID int

as
begin
	select distinct p.[Name] from Point_Product pp
	join Product p on pp.GoodId = p.Id
	join Point po on pp.PointId = po.Id
	where pp.GoodId not in 
		(select pp.GoodId from Point_Product pp 
		join Point po on pp.PointId = po.Id
		join CityOrTypeOfPoint c on c.Id = po.CountryID
		where po.CountryID = @CountryID);
end
