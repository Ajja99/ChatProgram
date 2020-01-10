CREATE PROCEDURE [dbo].[get_user_by_id]
	@Id NVARCHAR(128)

AS
BEGIN
	SET NOCOUNT ON
	SELECT [Id], [Username], [FirstName], [LastName], [EmailAddress], [CreatedDate]
	FROM [dbo].[chat_user]
	WHERE [Id] = @Id;
END
