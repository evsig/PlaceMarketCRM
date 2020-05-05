drop procedure if exists dbo.SelectCashInEachPoint
go
create proc [dbo].[SelectCashInEachPoint]
as
begin
	select
		po.Name as 'Point',
		sum(p.Price*pp.CountOfGood) as 'Cash'
	from
		dbo.Product p
		inner join dbo.Point_Product pp on pp.GoodId = p.Id
		inner join dbo.Point po on pp.PointId = po.Id
	group by po.Name
end;