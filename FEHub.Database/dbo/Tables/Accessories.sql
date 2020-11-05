CREATE TABLE [dbo].[Accessories] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt]     DATETIME2 (7)    NOT NULL,
    [CreatedBy]     NVARCHAR (100)   NOT NULL,
    [ModifiedAt]    DATETIME2 (7)    NOT NULL,
    [ModifiedBy]    NVARCHAR (100)   NOT NULL,
    [Version]       INT              NOT NULL,
    [Name]          NVARCHAR (100)   NOT NULL,
    [Description]   NVARCHAR (250)   NOT NULL,
    [AccessoryType] INT              NOT NULL,
    [Tag]           NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_Accessories] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_Accessories_AccessoryType_Enum_Constraint] CHECK ([AccessoryType]=(4) OR [AccessoryType]=(3) OR [AccessoryType]=(2) OR [AccessoryType]=(1))
);

