CREATE PROCEDURE [dbo].[insert_user]
	@Id NVARCHAR(128),
	@UserName NVARCHAR(100),
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@EmailAddress NVARCHAR(100)

AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO [dbo].[chat_user](Id, Username, FirstName, LastName, EmailAddress)

	VALUES (@Id, @UserName , @FirstName, @LastName,  @EmailAddress)
END