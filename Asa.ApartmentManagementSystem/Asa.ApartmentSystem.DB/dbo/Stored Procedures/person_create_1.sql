CREATE PROCEDURE [dbo].[person_create]
	@full_name nvarchar(50),
	@phone_number varchar(15)
AS
	
    Insert Into [dbo].[person]
            (
               [full_name]
               ,[phone_number]
            )
        values 
        (
        
            @full_name,
            @phone_number
        )
Select SCOPE_IDENTITY()