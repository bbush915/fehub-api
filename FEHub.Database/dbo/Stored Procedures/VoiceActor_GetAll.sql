CREATE PROCEDURE [dbo].[VoiceActor_GetAll]
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
RETURN 0
