drop proc if exists dbo.SumSalesBetweenDates
go
create proc [dbo].[SumSalesBetweenDates]
@start datetime, 
@end datetime 
as
begin
	select
		po.Name as 'Point', sum(op.GoodId * p.Price) as 'Sum'
	from
		dbo.[Order] o
		inner join Point po on po.Id = o.PointId
		inner join dbo.Order_Product op on o.Id = op.OrderId
		inner join dbo.Product p on p.Id = op.GoodId
    where
		o.OnsaleDate between @start and @end
	group
		by po.Name
end;