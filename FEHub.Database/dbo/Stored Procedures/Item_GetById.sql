CREATE PROCEDURE [dbo].[Item_GetById]
	@Id uniqueidentifier
AS
	SELECT 
		I.[Id],
		I.[CreatedAt],
		I.[CreatedBy],
		I.[ModifiedAt],
		I.[ModifiedBy],
		I.[Version],
		I.[Name],
		I.[Description]
	FROM 
		[dbo].[Items] I
	WHERE
		1 = 1
		AND (I.[Id] = @Id)
RETURN 0
