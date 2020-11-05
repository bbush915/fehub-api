CREATE PROCEDURE [dbo].[Artist_GetAll]
AS
	SELECT 
		A.[Id],
		A.[CreatedAt],
		A.[CreatedBy],
		A.[ModifiedAt],
		A.[ModifiedBy],
		A.[Version],
		A.[Name],
		A.[NameKanji],
		A.[Company]
	FROM 
		[dbo].[Artists] A
RETURN 0
