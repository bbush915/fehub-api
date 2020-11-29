CREATE PROCEDURE [dbo].[Skill_QueryByName]
	@Name nvarchar(max),
	@SkillType int = NULL
AS
	IF @SkillType = 7
		SELECT 
			S.[Id],
			S.[CreatedAt],
			S.[CreatedBy],
			S.[ModifiedAt],
			S.[ModifiedBy],
			S.[Version],
			S.[Name],
			S.[GroupName],
			S.[Description],
			S.[IsExclusive],
			S.[IsAvailableAsSacredSeal],
			S.[SkillPoints],
			S.[SkillType],
			S.[WeaponRefineType],
			S.[Might],
			S.[Range],
			S.[Cooldown],
			S.[HitPointsModifier],
			S.[AttackModifier],
			S.[SpeedModifier],
			S.[DefenseModifier],
			S.[ResistanceModifier],
			S.[Tag]
		FROM 
			[dbo].[Skills] S
		WHERE
			1 = 1
			AND (CONVERT(varchar, S.[Name]) COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%' + @Name + '%')
			AND ((@SkillType = 7) OR (S.[IsAvailableAsSacredSeal] = 1))
	ELSE
		SELECT 
			S.[Id],
			S.[CreatedAt],
			S.[CreatedBy],
			S.[ModifiedAt],
			S.[ModifiedBy],
			S.[Version],
			S.[Name],
			S.[GroupName],
			S.[Description],
			S.[IsExclusive],
			S.[IsAvailableAsSacredSeal],
			S.[SkillPoints],
			S.[SkillType],
			S.[WeaponRefineType],
			S.[Might],
			S.[Range],
			S.[Cooldown],
			S.[HitPointsModifier],
			S.[AttackModifier],
			S.[SpeedModifier],
			S.[DefenseModifier],
			S.[ResistanceModifier],
			S.[Tag]
		FROM 
			[dbo].[Skills] S
		WHERE
			1 = 1
			AND (CONVERT(varchar, S.[Name]) COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%' + @Name + '%')
			AND ((@SkillType IS NULL) OR (S.[SkillType] = @SkillType))
RETURN 0
