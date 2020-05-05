drop procedure if exists dbo.Product_NeverSale
go
create proc [dbo].[Product_NeverSale]

as
begin
	select p.[Name], p.Price from Product p 
	left join Order_Product op on op.GoodId=P.Id 
	where op.GoodId is null;
end