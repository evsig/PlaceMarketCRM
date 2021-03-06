drop proc if exists dbo.Product_CashInPoint
go

create proc [dbo].Product_CashInPoint
AS
BEGIN
	SELECT sum (pr.Price*pp.Quantity) TotalMoney, p.Id, p.[Name]
	FROM dbo.Product pr
	inner join dbo.Point_Product pp on pp.ProductId = pr.Id
	inner join dbo.Point p on pp.PointId=p.Id
	group by  p.Id, p.[Name]
END