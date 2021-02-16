create procedure [dbo].[expense_create]
@title nvarchar(50),
@category_id int ,
@from DATETIME,
@to DATETIME , 
@cost DATETIME , 
as
INSERT INTO [dbo].[Expense]
           ([title]
           ,[category_id]
           ,[from]
           ,[to]
           ,[cose]
           )
     VALUES
           (@title
           ,@category_id
           ,@from
           ,@to
           ,@cost
           )
select SCOPE_IDENTITY()


