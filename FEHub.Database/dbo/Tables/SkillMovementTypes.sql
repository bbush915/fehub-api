CREATE TABLE [dbo].[SkillMovementTypes] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [SkillId]      UNIQUEIDENTIFIER NOT NULL,
    [MovementType] INT              NOT NULL,
    CONSTRAINT [PK_SkillMovementTypes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_SkillMovementTypes_MovementType_Enum_Constraint] CHECK ([MovementType]=(4) OR [MovementType]=(3) OR [MovementType]=(2) OR [MovementType]=(1)),
    CONSTRAINT [FK_SkillMovementTypes_Skills_SkillId] FOREIGN KEY ([SkillId]) REFERENCES [dbo].[Skills] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_SkillMovementTypes_SkillId]
    ON [dbo].[SkillMovementTypes]([SkillId] ASC);

