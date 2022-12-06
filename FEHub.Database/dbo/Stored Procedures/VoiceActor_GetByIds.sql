CREATE PROCEDURE [dbo].[VoiceActor_GetByIds]
	@Ids [dbo].[IntList] READONLY
AS
	SELECT 
		VA.[Id],
		VA.[CreatedAt],
		VA.[CreatedBy],
		VA.[ModifiedAt],
		VA.[ModifiedBy],
		VA.[Version],
		VA.[Name],
		VA.[NameKanji]
	FROM 
		[dbo].[VoiceActors] VA
	WHERE
		1 = 1
		AND (VA.[Id] IN ( SELECT [Value] FROM @Ids ))
RETURN 0
