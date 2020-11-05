CREATE PROCEDURE [dbo].[SkillWeaponType_GetBySkillIds]
	@SkillIds [dbo].[GuidList] READONLY
AS
	SELECT 
		SWT.[Id],
		SWT.[SkillId],
		SWT.[Color],
		SWT.[Weapon]
	FROM 
		[dbo].[SkillWeaponTypes] SWT
	WHERE
		1 = 1
		AND (SWT.[SkillId] IN ( SELECT [Value] FROM @SkillIds ))
RETURN 0
