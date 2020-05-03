drop proc if exists dbo.Lead_SelectAll 
go 
 
create proc [dbo].[Lead_SelectAll]	 
	 
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
end 