CREATE TABLE [dbo].[Items] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt]   DATETIME2 (7)    NOT NULL,
    [CreatedBy]   NVARCHAR (100)   NOT NULL,
    [ModifiedAt]  DATETIME2 (7)    NOT NULL,
    [ModifiedBy]  NVARCHAR (100)   NOT NULL,
    [Version]     INT              NOT NULL,
    [Name]        NVARCHAR (100)   NOT NULL,
    [Description] NVARCHAR (250)   NOT NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([Id] ASC)
);

