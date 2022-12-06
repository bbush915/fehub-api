CREATE TABLE [dbo].[Artists] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [CreatedAt]  DATETIME2 (7)  NOT NULL,
    [CreatedBy]  NVARCHAR (100) NOT NULL,
    [ModifiedAt] DATETIME2 (7)  NOT NULL,
    [ModifiedBy] NVARCHAR (100) NOT NULL,
    [Version]    INT            NOT NULL,
    [Name]       NVARCHAR (100) NOT NULL,
    [NameKanji]  NVARCHAR (100) NULL,
    [Company]    NVARCHAR (100) NULL,
    CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED ([Id] ASC)
);

