﻿CREATE TABLE [dbo].[Skills] (
    [Id]                      UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt]               DATETIME2 (7)    NOT NULL,
    [CreatedBy]               NVARCHAR (100)   NOT NULL,
    [ModifiedAt]              DATETIME2 (7)    NOT NULL,
    [ModifiedBy]              NVARCHAR (100)   NOT NULL,
    [Version]                 INT              NOT NULL,
    [Name]                    NVARCHAR (100)   NOT NULL,
    [GroupName]               NVARCHAR (100)   NOT NULL,
    [Description]             NVARCHAR (1000)  NULL,
    [IsExclusive]             BIT              NOT NULL,
    [IsAvailableAsSacredSeal] BIT              NOT NULL,
    [SkillPoints]             INT              NOT NULL,
    [SkillType]               INT              NOT NULL,
    [WeaponRefineType]        INT              NULL,
    [Might]                   INT              NULL,
    [Range]                   INT              NULL,
    [Cooldown]                INT              NULL,
    [HitPointsModifier]       INT              NULL,
    [AttackModifier]          INT              NULL,
    [SpeedModifier]           INT              NULL,
    [DefenseModifier]         INT              NULL,
    [ResistanceModifier]      INT              NULL,
    [Tag]                     NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_Skills] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_Skills_SkillType_Enum_Constraint] CHECK ([SkillType]=(7) OR [SkillType]=(6) OR [SkillType]=(5) OR [SkillType]=(4) OR [SkillType]=(3) OR [SkillType]=(2) OR [SkillType]=(1))
);

