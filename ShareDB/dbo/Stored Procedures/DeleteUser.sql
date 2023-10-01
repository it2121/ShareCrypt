Create procedure [dbo].[DeleteUser]

@ID as int
as

Delete from Users where ID=@ID

