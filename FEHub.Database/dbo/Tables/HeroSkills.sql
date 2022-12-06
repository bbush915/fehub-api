CREATE TABLE [dbo].[HeroSkills] (
    [Id]            INT              IDENTITY (1, 1) NOT NULL,
    [HeroId]        UNIQUEIDENTIFIER NOT NULL,
    [SkillId]       UNIQUEIDENTIFIER NOT NULL,
    [SkillPosition] INT              NOT NULL,
    [DefaultRarity] INT              NULL,
    [UnlockRarity]  INT              NOT NULL,
    CONSTRAINT [PK_HeroSkills] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_HeroSkills_Heroes_HeroId] FOREIGN KEY ([HeroId]) REFERENCES [dbo].[Heroes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_HeroSkills_Skills_SkillId] FOREIGN KEY ([SkillId]) REFERENCES [dbo].[Skills] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_HeroSkills_HeroId]
    ON [dbo].[HeroSkills]([HeroId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_HeroSkills_SkillId]
    ON [dbo].[HeroSkills]([SkillId] ASC);

