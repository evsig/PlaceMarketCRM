drop proc if exists dbo.Orders_Add
go

create proc dbo.Orders_Add	
   @PointId int
as
begin	
	insert into dbo.[Order]  ([Date], PointId)
	values (GETDATE(), @PointId)
	select  SCOPE_IDENTITY()
end 
