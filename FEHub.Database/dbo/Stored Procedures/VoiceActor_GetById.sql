CREATE PROCEDURE [dbo].[VoiceActor_GetById]
	@Id int
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
		AND (VA.[Id] = @Id)
RETURN 0
