CREATE TABLE [dbo].[SkillWeaponTypes] (
    [Id]      INT              IDENTITY (1, 1) NOT NULL,
    [SkillId] UNIQUEIDENTIFIER NOT NULL,
    [Color]   INT              NOT NULL,
    [Weapon]  INT              NOT NULL,
    CONSTRAINT [PK_SkillWeaponTypes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_SkillWeaponTypes_Color_Enum_Constraint] CHECK ([Color]=(4) OR [Color]=(3) OR [Color]=(2) OR [Color]=(1)),
    CONSTRAINT [CK_SkillWeaponTypes_Weapon_Enum_Constraint] CHECK ([Weapon]=(9) OR [Weapon]=(8) OR [Weapon]=(7) OR [Weapon]=(6) OR [Weapon]=(5) OR [Weapon]=(4) OR [Weapon]=(3) OR [Weapon]=(2) OR [Weapon]=(1)),
    CONSTRAINT [FK_SkillWeaponTypes_Skills_SkillId] FOREIGN KEY ([SkillId]) REFERENCES [dbo].[Skills] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_SkillWeaponTypes_SkillId]
    ON [dbo].[SkillWeaponTypes]([SkillId] ASC);

