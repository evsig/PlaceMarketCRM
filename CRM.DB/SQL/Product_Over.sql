drop procedure if exists dbo.Product_Over
go
create proc [dbo].[Product_Over]

as
begin
	select DISTINCT p.Id, p.[Name]
	from Order_Product op
	join Product p on p.Id=op.GoodId
	left join Point_Product pp on pp.GoodId = p.Id
end