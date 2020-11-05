CREATE PROCEDURE [dbo].[Artist_GetByIds]
	@Ids [dbo].[IntList] READONLY
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
	WHERE
		1 = 1
		AND (A.[Id] IN ( SELECT [Value] FROM @Ids ))
RETURN 0
