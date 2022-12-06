CREATE PROCEDURE [dbo].[Skill_GetAll]
AS
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
RETURN 0
