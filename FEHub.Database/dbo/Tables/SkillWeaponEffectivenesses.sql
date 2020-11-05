CREATE TABLE [dbo].[SkillWeaponEffectivenesses] (
    [Id]                      INT              IDENTITY (1, 1) NOT NULL,
    [SkillId]                 UNIQUEIDENTIFIER NOT NULL,
    [WeaponEffectivenessType] INT              NOT NULL,
    [DamageType]              INT              NULL,
    [MovementType]            INT              NULL,
    [Weapon]                  INT              NULL,
    CONSTRAINT [PK_SkillWeaponEffectivenesses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_SkillWeaponEffectivenesses_WeaponEffectivenessType_Enum_Constraint] CHECK ([WeaponEffectivenessType]=(3) OR [WeaponEffectivenessType]=(2) OR [WeaponEffectivenessType]=(1)),
    CONSTRAINT [FK_SkillWeaponEffectivenesses_Skills_SkillId] FOREIGN KEY ([SkillId]) REFERENCES [dbo].[Skills] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_SkillWeaponEffectivenesses_SkillId]
    ON [dbo].[SkillWeaponEffectivenesses]([SkillId] ASC);

