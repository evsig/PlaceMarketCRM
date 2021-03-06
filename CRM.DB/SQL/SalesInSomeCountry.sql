drop procedure if exists dbo.SalesInSomeCountry
go
create proc [dbo].[SalesInSomeCountry]
@PointId int
as
BEGIN
	select SUM(p.Price) from [Order_Product] op 
	join [Order] O on op.OrderId = O.Id 
	join dbo.Product p on p.Id = op.ProductId
	join Point po on po.[Name] = po.Id
	where po.Id = @PointId;
END
