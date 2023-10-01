Create procedure [dbo].[LogIn]
(
@Username as nvarchar(50),
@Password as nvarchar(50)
)
as

SELECT *
FROM Users  WHERE ( Users.Username=@Username)
      and Users.Password=@Password