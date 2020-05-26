DROP PROC IF EXISTS dbo.Product_NeverSale
GO

CREATE PROC dbo.Product_NeverSale
AS
begin
	select p.[Name], p.Price from Product p 
	left join Order_Product op on op.ProductId=P.Id 
	where op.ProductId is null;
end
