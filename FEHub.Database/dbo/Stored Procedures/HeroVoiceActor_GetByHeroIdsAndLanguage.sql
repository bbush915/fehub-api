CREATE PROCEDURE [dbo].[HeroVoiceActor_GetByHeroIdsAndLanguage]
	@HeroIds [dbo].[GuidList] READONLY,
	@Language int
AS
	SELECT 
		HVA.[Id],
		HVA.[HeroId],
		HVA.[VoiceActorId],
		HVA.[Language],
		HVA.[Sort]
	FROM 
		[dbo].[HeroVoiceActors] HVA
	WHERE
		1 = 1
		AND (HVA.[HeroId] IN ( SELECT [Value] FROM @HeroIds ))
		AND (HVA.[Language] = @Language)
RETURN 0
