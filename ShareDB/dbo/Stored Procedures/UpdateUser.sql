Create procedure [dbo].[UpdateUser]

@ID as int,
@Username as nvarchar,
@Password as nvarchar,
@Email as nvarchar,
@Fullname as nvarchar
as

UPDATE  Users  set Users.Username =@Username,Users.Password =@Password,Users.Email =@Email , Users.Fullname =@Fullname where Users.ID = @ID

