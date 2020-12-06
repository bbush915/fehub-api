//-----------------------------------------------------------------------------
// <copyright file="Constants.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

namespace FEHub.Entity.Common
{
    public static class Constants
    {
        public const string DefaultUser = "SYSTEM";

        public const int MaxLevel = 40;

        public static class Database
        {
            public static class StoredProcedures
            {
                public static class Accessory
                {
                    public const string GetAll = "[dbo].[Accessory_GetAll]";
                    public const string GetById = "[dbo].[Accessory_GetById]";
                }

                public static class Artist
                {
                    public const string GetAll = "[dbo].[Artist_GetAll]";
                    public const string GetByIds = "[dbo].[Artist_GetByIds]";
                    public const string GetById = "[dbo].[Artist_GetById]";
                }

                public static class Hero
                {
                    public const string GetAll = "[dbo].[Hero_GetAll]";
                    public const string GetById = "[dbo].[Hero_GetById]";
                    public const string QueryByName = "[dbo].[Hero_QueryByName]";
                }

                public static class HeroSkill
                {
                    public const string GetByHeroIds = "[dbo].[HeroSkill_GetByHeroIds]";
                }

                public static class HeroVoiceActor
                {
                    public const string GetByHeroIdsAndLanguage = "[dbo].[HeroVoiceActor_GetByHeroIdsAndLanguage]";
                }

                public static class Item
                {
                    public const string GetAll = "[dbo].[Item_GetAll]";
                    public const string GetById = "[dbo].[Item_GetById]";
                }

                public static class Skill
                {
                    public const string GetAll = "[dbo].[Skill_GetAll]";
                    public const string GetByIds = "[dbo].[Skill_GetByIds]";
                    public const string GetById = "[dbo].[Skill_GetById]";
                    public const string QueryByNameAndSkillType = "[dbo].[Skill_QueryByNameAndSkillType]";
                }

                public static class SkillMovementType
                {
                    public const string GetBySkillIds = "[dbo].[SkillMovementType_GetBySkillIds]";
                }

                public static class SkillWeaponEffectiveness
                {
                    public const string GetBySkillIds = "[dbo].[SkillWeaponEffectiveness_GetBySkillIds]";
                }

                public static class SkillWeaponType
                {
                    public const string GetBySkillIds = "[dbo].[SkillWeaponType_GetBySkillIds]";
                }

                public static class VoiceActor
                {
                    public const string GetAll = "[dbo].[VoiceActor_GetAll]";
                    public const string GetByIds = "[dbo].[VoiceActor_GetByIds]";
                    public const string GetById = "[dbo].[VoiceActor_GetById]";
                }
            };

            public static class UserDefinedTableTypes
            {
                public const string GuidList = "[dbo].[GuidList]";
                public const string IntList = "[dbo].[IntList]";
            };
        }

        public static class Faker
        {
            public const int NullableIntDefault = -1;

            public const string NullableStringDefault = "__default";
        }
    }
}
