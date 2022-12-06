CREATE PROCEDURE [dbo].[Item_GetAll]
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
RETURN 0
