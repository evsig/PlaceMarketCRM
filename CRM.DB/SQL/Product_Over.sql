drop proc if exists dbo.Product_Over
go

create proc dbo.Product_Over
AS
begin
	select DISTINCT p.Id, p.[Name]
	from Order_Product op
	join Product p on p.Id=op.ProductId
	left join Point_Product pp on pp.ProductId = p.Id
end