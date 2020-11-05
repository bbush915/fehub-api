CREATE PROCEDURE [dbo].[SkillWeaponEffectiveness_GetBySkillIds]
	@SkillIds [dbo].[GuidList] READONLY
AS
	SELECT 
		SWE.[Id],
		SWE.[SkillId],
		SWE.[WeaponEffectivenessType],
		SWE.[DamageType],
		SWE.[MovementType],
		SWE.[Weapon]
	FROM 
		[dbo].[SkillWeaponEffectivenesses] SWE
	WHERE
		1 = 1
		AND (SWE.[SkillId] IN ( SELECT [Value] FROM @SkillIds ))
RETURN 0
