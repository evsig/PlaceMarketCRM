drop proc if exists dbo.OrderDetails_Add
go

create proc dbo.OrderDetails_Add	
  @OrderId int, 
  @ProductId int,
  @Count int,
  @Price money
as
begin
	insert into dbo.OrderDetails (OrderId, ProductId, [Count], Price)
	values (@OrderId , @ProductId, @Count, @Price)
	SELECT  SCOPE_IDENTITY()
end 
