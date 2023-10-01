Create procedure [dbo].[GetUser]

@ID as int
as

Select * from Users where ID=@ID

