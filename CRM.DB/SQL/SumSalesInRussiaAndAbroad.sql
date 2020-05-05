drop procedure if exists dbo.GetIncomeFromRussiaAndFromForeignCountries
go
create proc [dbo].[GetIncomeFromRussiaAndFromForeignCountries]
as
begin
    select
        [0] as 'Russia',
        [1] as 'abroad'
    from (
        select sum(p.Price*op.GoodId) as total,
        po.CountryID
        from dbo.Product p
        inner join dbo.Order_Product op on op.GoodId = p.Id
        inner join dbo.[Order] o on o.Id = op.OrderId
        inner join dbo.Point po on po.Id = o.PointId
        where po.CountryID is not null
        group by po.CountryID) as s
   pivot
    (avg(total) for po.CountryID IN ([0], [1])) as PivotTable;
end;