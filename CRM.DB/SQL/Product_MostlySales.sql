
drop proc if exists dbo.Product_MostlySales
go

create proc [dbo].[Product_MostlySales]	
as
begin	
select p.[Name], 
(select top 1 pr.Id from dbo.Product pr
join dbo.Order_Product op on op.ProductId = pr.Id
join [Order] o on op.OrderId = o.Id 
join Point p1 on p.Id = o.PointId
where p.Id  = o.Id
group by ModelId 
order by SUM(op.[Count]) DESC) as Product
from Point p
where p.Id != 5
end 
