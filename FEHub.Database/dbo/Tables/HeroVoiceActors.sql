CREATE TABLE [dbo].[HeroVoiceActors] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [HeroId]       UNIQUEIDENTIFIER NOT NULL,
    [VoiceActorId] INT              NOT NULL,
    [Language]     INT              NOT NULL,
    [Sort]         INT              NOT NULL,
    CONSTRAINT [PK_HeroVoiceActors] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_HeroVoiceActors_Language_Enum_Constraint] CHECK ([Language]=(2) OR [Language]=(1)),
    CONSTRAINT [FK_HeroVoiceActors_Heroes_HeroId] FOREIGN KEY ([HeroId]) REFERENCES [dbo].[Heroes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_HeroVoiceActors_VoiceActors_VoiceActorId] FOREIGN KEY ([VoiceActorId]) REFERENCES [dbo].[VoiceActors] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_HeroVoiceActors_HeroId]
    ON [dbo].[HeroVoiceActors]([HeroId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_HeroVoiceActors_VoiceActorId]
    ON [dbo].[HeroVoiceActors]([VoiceActorId] ASC);

