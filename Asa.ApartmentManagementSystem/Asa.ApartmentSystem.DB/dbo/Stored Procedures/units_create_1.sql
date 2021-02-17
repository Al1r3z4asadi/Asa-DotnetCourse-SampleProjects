CREATE PROCEDURE [dbo].[units_create]
	@number int ,
	@buildingId int , 
    @area Decimal(5,5),
    @description varchar(100)
AS

  Insert Into [dbo].[Units]
            (
              [number]  
             ,[building_id]
             ,[area]
             ,[description]
            )
            values
            (
                @number
                ,@buildingId
                ,@area
                ,@description
            )
    Select SCOPE_IDENTITY()