CREATE PROCEDURE [dbo].[Accessory_GetAll]
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
RETURN 0
