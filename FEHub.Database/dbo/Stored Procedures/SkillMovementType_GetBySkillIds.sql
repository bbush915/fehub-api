CREATE PROCEDURE [dbo].[SkillMovementType_GetBySkillIds]
	@SkillIds [dbo].[GuidList] READONLY
AS
	SELECT 
		SMT.[Id],
		SMT.[SkillId],
		SMT.[MovementType]
	FROM 
		[dbo].[SkillMovementTypes] SMT
	WHERE
		1 = 1
		AND (SMT.[SkillId] IN ( SELECT [Value] FROM @SkillIds ))
RETURN 0
