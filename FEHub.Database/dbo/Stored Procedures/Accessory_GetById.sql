CREATE PROCEDURE [dbo].[Accessory_GetById]
	@Id uniqueidentifier
AS
	SELECT 
		A.[Id],
		A.[CreatedAt],
		A.[CreatedBy],
		A.[ModifiedAt],
		A.[ModifiedBy],
		A.[Version],
		A.[Name],
		A.[Description],
		A.[AccessoryType],
		A.[Tag]
	FROM 
		[dbo].[Accessories] A
	WHERE
		1 = 1
		AND (A.[Id] = @Id)
RETURN 0
