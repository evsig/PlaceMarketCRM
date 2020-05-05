drop procedure if exists dbo.MostlySalesProduct
go
create proc [dbo].[MostlySalesProduct]

AS
BEGIN
select c.Name as City, 
(select top 1 ModelId from Product 
join Order_Product on [Order_Product].GoodId = Product.Id
join [Order] on OrderId = [Order].Id 
join CityOrTypeOfPoint on Id = CityOrTypeOfPoint.Id
where Product.Id  = c.Id
group by ModelId 
order by SUM(CountOfGood) DESC) as Product
from CityOrTypeOfPoint c;

END