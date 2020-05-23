//-----------------------------------------------------------------------------
// <copyright file="GqlEnumerations.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Collections.Generic;

using FEHub.Api.Services;
using FEHub.Api.Services.Common;
using FEHub.Entity.Common.Enumerations;

using GraphQL.Types;

namespace FEHub.Api.GraphQL
{
    internal sealed class GqlEnumerations : ObjectGraphType
    {
        #region Constructors
        public GqlEnumerations()
        {
            this.Name = "Enumerations";

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(AccessoryTypes))
                .Resolve(
                    (context) =>
                    {
                        var service = new EnumerationService<AccessoryTypes>();
                        return service.GetAll();
                    }
                );

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(AllySupportRanks))
                .Resolve(
                    (context) =>
                    {
                        var service = new EnumerationService<AllySupportRanks>();
                        return service.GetAll();
                    }
                );

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(Colors))
                .Resolve(
                    (context) =>
                    {
                        var service = new EnumerationService<Colors>();
                        return service.GetAll();
                    }
                );

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(CombatTypes))
                .Resolve(
                    (context) =>
                    {
                        var service = new EnumerationService<CombatTypes>();
                        return service.GetAll();
                    }
                );

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(DamageTypes))
                .Resolve(
                    (context) =>
                    {
                        var service = new EnumerationService<DamageTypes>();
                        return service.GetAll();
                    }
                );

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(Elements))
                .Resolve(
                    (context) =>
                    {
                        var service = new EnumerationService<Elements>();
                        return service.GetAll();
                    }
                );

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(FavoriteMarks))
                .Resolve(
                    (context) =>
                    {
                        var service = new EnumerationService<FavoriteMarks>();
                        return service.GetAll();
                    }
                );

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(Genders))
                .Resolve(
                    (context) =>
                    {
                        var service = new EnumerationService<Genders>();
                        return service.GetAll();
                    }
                );

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(Languages))
                .Resolve(
                    (context) =>
                    {
                        var service = new EnumerationService<Languages>();
                        return service.GetAll();
                    }
                );

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(LegendaryHeroBoostTypes))
                .Resolve(
                    (context) =>
                    {
                        var service = new EnumerationService<LegendaryHeroBoostTypes>();
                        return service.GetAll();
                    }
                );

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(MovementTypes))
                .Resolve(
                    (context) =>
                    {
                        var service = new EnumerationService<MovementTypes>();
                        return service.GetAll();
                    }
                );

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(MythicHeroBoostTypes))
                .Resolve(
                    (context) =>
                    {
                        var service = new EnumerationService<MythicHeroBoostTypes>();
                        return service.GetAll();
                    }
                );

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(SkillTypes))
                .Resolve(
                    (context) =>
                    {
                        var service = new EnumerationService<SkillTypes>();
                        return service.GetAll();
                    }
                );

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(Statistics))
                .Resolve(
                    (context) =>
                    {
                        var service = new EnumerationService<Statistics>();
                        return service.GetAll();
                    }
                );

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(SummonerSupportRanks))
                .Resolve(
                    (context) =>
                    {
                        var service = new SummonerSupportRankService();
                        return service.GetAll();
                    }
                );

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(WeaponEffectivenessTypes))
                .Resolve(
                    (context) =>
                    {
                        var service = new EnumerationService<WeaponEffectivenessTypes>();
                        return service.GetAll();
                    }
                );

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(WeaponRefineTypes))
                .Resolve(
                    (context) =>
                    {
                        var service = new EnumerationService<WeaponRefineTypes>();
                        return service.GetAll();
                    }
                );

            this
                .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>()
                .Name(nameof(Weapons))
                .Resolve(
                    (context) =>
                    {
                        var service = new EnumerationService<Weapons>();
                        return service.GetAll();
                    }
                );
        }
        #endregion
    }
}
