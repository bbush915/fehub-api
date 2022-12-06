using System.Collections.Generic;

using FEHub.Api.Models;
using FEHub.Api.Services.Interfaces;
using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Common.Helpers;

using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace FEHub.Api.GraphQL;

internal sealed class GqlEnumerations : ObjectGraphType
{
    public GqlEnumerations()
    {
        this.Name = "Enumerations";
        this.Description = "The constants representing various enumerable types.";

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(AccessoryTypes))
            .Description(DisplayHelpers.GetDescription<AccessoryTypes>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<AccessoryTypes>>();
                    return enumerationService.GetAll();
                }
            );

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(AllySupportRanks))
            .Description(DisplayHelpers.GetDescription<AllySupportRanks>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<AllySupportRanks>>();
                    return enumerationService.GetAll();
                }
            );

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(Colors))
            .Description(DisplayHelpers.GetDescription<Colors>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<Colors>>();
                    return enumerationService.GetAll();
                }
            );

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(CombatTypes))
            .Description(DisplayHelpers.GetDescription<CombatTypes>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<CombatTypes>>();
                    return enumerationService.GetAll();
                }
            );

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(DamageTypes))
            .Description(DisplayHelpers.GetDescription<DamageTypes>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<DamageTypes>>();
                    return enumerationService.GetAll();
                }
            );

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(Elements))
            .Description(DisplayHelpers.GetDescription<Elements>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<Elements>>();
                    return enumerationService.GetAll();
                }
            );

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(FavoriteMarks))
            .Description(DisplayHelpers.GetDescription<FavoriteMarks>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<FavoriteMarks>>();
                    return enumerationService.GetAll();
                }
            );

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(Genders))
            .Description(DisplayHelpers.GetDescription<Genders>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<Genders>>();
                    return enumerationService.GetAll();
                }
            );

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(Languages))
            .Description(DisplayHelpers.GetDescription<Languages>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<Languages>>();
                    return enumerationService.GetAll();
                }
            );

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(LegendaryHeroBoostTypes))
            .Description(DisplayHelpers.GetDescription<LegendaryHeroBoostTypes>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<LegendaryHeroBoostTypes>>();
                    return enumerationService.GetAll();
                }
            );

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(MovementTypes))
            .Description(DisplayHelpers.GetDescription<MovementTypes>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<MovementTypes>>();
                    return enumerationService.GetAll();
                }
            );

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(MythicHeroBoostTypes))
            .Description(DisplayHelpers.GetDescription<MythicHeroBoostTypes>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<MythicHeroBoostTypes>>();
                    return enumerationService.GetAll();
                }
            );

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(SkillTypes))
            .Description(DisplayHelpers.GetDescription<SkillTypes>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<SkillTypes>>();
                    return enumerationService.GetAll();
                }
            );

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(Statistics))
            .Description(DisplayHelpers.GetDescription<Statistics>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<Statistics>>();
                    return enumerationService.GetAll();
                }
            );

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(SummonerSupportRanks))
            .Description(DisplayHelpers.GetDescription<SummonerSupportRanks>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<SummonerSupportRanks>>();
                    return enumerationService.GetAll();
                }
            );

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(WeaponEffectivenessTypes))
            .Description(DisplayHelpers.GetDescription<WeaponEffectivenessTypes>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<WeaponEffectivenessTypes>>();
                    return enumerationService.GetAll();
                }
            );

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(WeaponRefineTypes))
            .Description(DisplayHelpers.GetDescription<WeaponRefineTypes>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<WeaponRefineTypes>>();
                    return enumerationService.GetAll();
                }
            );

        this
            .Field<ListGraphType<GqlEnumerationValue>, List<EnumerationValue>>(nameof(Weapons))
            .Description(DisplayHelpers.GetDescription<Weapons>())
            .Resolve(
                (context) =>
                {
                    var enumerationService = context.RequestServices.GetRequiredService<IEnumerationService<Weapons>>();
                    return enumerationService.GetAll();
                }
            );
    }
}
