drop proc if exists dbo.CategoriesMoreFiveProducts
go
create proc [dbo].[CategoriesMoreFiveProducts]
as
begin
	select
		count(p.CategoryId) as CountOfProducts,
		c.Id, c.Name
	from dbo.Category c
		inner join dbo.Product p on p.CategoryId=c.Id
		inner join dbo.Category ct on ct.Id = c.Id
	group by
		c.Name,
		c.Id,
		ct.Name
	having
		count(p.CategoryId) > 5
end;