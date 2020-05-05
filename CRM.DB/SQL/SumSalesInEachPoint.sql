drop procedure if exists dbo.SalesInSomeCountry
go
create proc [dbo].[SalesInSomeCountry]
@CityId int
AS
BEGIN
	select SUM(p.Price) from [Order_Product] op 
	join [Order] O on op.OrderId = O.Id 
	join dbo.Product p on p.Id = op.GoodId
	join CityOrTypeOfPoint s on s.[Name] = s.Id
	where s.Id = @CityId;
END