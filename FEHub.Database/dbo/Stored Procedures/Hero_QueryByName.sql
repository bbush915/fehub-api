CREATE PROCEDURE [dbo].[Hero_QueryByName]
	@Name nvarchar(max)
AS
	SELECT 
		H.[Id],
		H.[CreatedAt],
		H.[CreatedBy],
		H.[ModifiedAt],
		H.[ModifiedBy],
		H.[Version],
		H.[Name],
		H.[Title],
		H.[Description],
		H.[Origin],
		H.[Gender],
		H.[AdditionDate],
		H.[ReleaseDate],
		H.[ArtistId],
		H.[IsLegendaryHero],
		H.[IsMythicHero],
		H.[Element],
		H.[LegendaryHeroBoostType],
		H.[MythicHeroBoostType],
		H.[IsDuoHero],
		H.[IsResplendentHero],
		H.[Color],
		H.[Weapon],
		H.[MovementType],
		H.[BVID],
		H.[BaseHitPoints],
		H.[HitPointsGrowthRate],
		H.[BaseAttack],
		H.[AttackGrowthRate],
		H.[BaseSpeed],
		H.[SpeedGrowthRate],
		H.[BaseDefense],
		H.[DefenseGrowthRate],
		H.[BaseResistance],
		H.[ResistanceGrowthRate],
		H.[Tag]
	FROM 
		[dbo].[Heroes] H
	WHERE
		1 = 1
		AND (H.[Name] LIKE '%' + @Name + '%')
RETURN 0
