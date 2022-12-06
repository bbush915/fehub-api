CREATE PROCEDURE [dbo].[HeroSkill_GetByHeroIds]
	@HeroIds [dbo].[GuidList] READONLY
AS
	SELECT 
		HS.[Id],
		HS.[HeroId],
		HS.[SkillId],
		HS.[SkillPosition],
		HS.[DefaultRarity],
		HS.[UnlockRarity]
	FROM 
		[dbo].[HeroSkills] HS
	WHERE
		1 = 1
		AND (HS.[HeroId] IN ( SELECT [Value] FROM @HeroIds ))
RETURN 0
