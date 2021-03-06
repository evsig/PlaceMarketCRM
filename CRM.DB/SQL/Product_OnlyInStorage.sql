drop proc if exists dbo.Product_OnlyInStorage
go

create proc dbo.Product_OnlyInStorage	
AS
begin
	select distinct p.[Name] from Point_Product pp
	join Product p on pp.ProductId = p.Id
	join Point po on pp.PointId = po.Id
	where pp.ProductId not in 
		(select pp.ProductId from Point_Product pp 
		join Point po on pp.PointId = po.Id
		join CityOrTypeOfPoint c on c.Id = po.CountryID
		where po.CountryID = @CountryID);
end


	
