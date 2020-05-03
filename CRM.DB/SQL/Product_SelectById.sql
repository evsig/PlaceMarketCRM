drop proc if exists dbo.SelectById 
go 
 
create proc [dbo].[SelectById]
@Id int
	 
as 
begin 
select [Id]
      ,[Name]
      ,[Price]
      ,[TradeMarkId]
      ,[ModelId]
      ,[CategoryId]
      ,[SubcategoryId]
  from [DevEduHomeWork].[dbo].[Product]
  where Id = @Id
end 