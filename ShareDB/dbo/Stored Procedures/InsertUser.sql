Create procedure [dbo].[InsertUser]

@ID as int =NULL,
@Username as nvarchar,
@Password as nvarchar,
@Email as nvarchar,
@Fullname as nvarchar
as


Insert Into  Users ( Users.Username,Users.Password,Users.Email,Users.Fullname ) values (@Username,@Password,@Email,@Fullname )