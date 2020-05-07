drop proc if exists dbo.Order_SelectById
go

create proc dbo.Order_SelectById	
  @Id int
as
begin
	select 
		o.Id,
		o.[Date],
		po.Id,
		po.[Name],
		od.Id,
		od.OrderID,
		od.[Count], 
		od.Price, 
		p.Id, 
		p.Brand,
		p.Model,
		c.Id,
		c.[Name]
from dbo.[Order] o
	join dbo.Point po on po.Id = o.PointId
	left join dbo.OrderDetails od on od.OrderID = o.Id
	join dbo.Product p on p.Id = od.ProductId
	join dbo.Category c on c.Id = p.SubcategoryId
where o.Id = @Id
end 