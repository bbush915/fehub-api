using System;
using System.Collections.Generic;

using FEHub.Api.GraphQL.Inputs;
using FEHub.Api.Models;
using FEHub.Api.Services.Interfaces;
using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Models;

using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace FEHub.Api.GraphQL;

internal sealed class GqlQuery : ObjectGraphType
{
    public GqlQuery()
    {
        this
            .Field<ListGraphType<GqlAccessory>, List<Accessory>>("accessories")
            .ResolveAsync(
                (context) =>
                {
                    var accessoryService = context.RequestServices.GetRequiredService<IAccessoryService>();
                    return accessoryService.GetAllAsync();
                }
            );

        this
            .Field<GqlAccessory, Accessory>("accessory")
            .Argument<NonNullGraphType<GuidGraphType>>("id")
            .ResolveAsync(
                (context) =>
                {
                    var id = context.GetArgument<Guid>("id");

                    var accessoryService = context.RequestServices.GetRequiredService<IAccessoryService>();
                    return accessoryService.GetByIdAsync(id);
                }
            );

        this
            .Field<ListGraphType<GqlArtist>, List<Artist>>("artists")
            .ResolveAsync(
                (context) =>
                {
                    var artistService = context.RequestServices.GetRequiredService<IArtistService>();
                    return artistService.GetAllAsync();
                }
            );

        this
            .Field<GqlArtist, Artist>("artist")
            .Argument<NonNullGraphType<IntGraphType>>("id")
            .ResolveAsync(
                (context) =>
                {
                    var id = context.GetArgument<int>("id");

                    var artistService = context.RequestServices.GetRequiredService<IArtistService>();
                    return artistService.GetByIdAsync(id);
                }
            );

        this
            .Field<GqlEnumerations>("enumerations")
            .Resolve(x => new { });

        this
            .Field<ListGraphType<GqlHero>, List<Hero>>("heroes")
            .ResolveAsync(
                (context) =>
                {
                    var heroService = context.RequestServices.GetRequiredService<IHeroService>();
                    return heroService.GetAllAsync();
                }
            );

        this
            .Field<GqlHero, Hero>("hero")
            .Argument<NonNullGraphType<GuidGraphType>>("id")
            .ResolveAsync(
                (context) =>
                {
                    var id = context.GetArgument<Guid>("id");

                    var heroService = context.RequestServices.GetRequiredService<IHeroService>();
                    return heroService.GetByIdAsync(id);
                }
            );

        this
            .Field<ListGraphType<GqlHero>, List<Hero>>("queryHeroesByName")
            .Argument<NonNullGraphType<StringGraphType>>("name")
            .ResolveAsync(
                (context) =>
                {
                    var name = context.GetArgument<string>("name");

                    var heroService = context.RequestServices.GetRequiredService<IHeroService>();
                    return heroService.QueryByNameAsync(name);
                }
            );

        this
            .Field<ListGraphType<GqlItem>, List<Item>>("items")
            .ResolveAsync(
                (context) =>
                {
                    var itemService = context.RequestServices.GetRequiredService<IItemService>();
                    return itemService.GetAllAsync();
                }
            );

        this
            .Field<GqlItem, Item>("item")
            .Argument<NonNullGraphType<GuidGraphType>>("id")
            .ResolveAsync(
                (context) =>
                {
                    var id = context.GetArgument<Guid>("id");

                    var itemService = context.RequestServices.GetRequiredService<IItemService>();
                    return itemService.GetByIdAsync(id);
                }
            );

        this
            .Field<ListGraphType<GqlSkill>, List<Skill>>("skills")
            .ResolveAsync(
                (context) =>
                {
                    var skillService = context.RequestServices.GetRequiredService<ISkillService>();
                    return skillService.GetAllAsync();
                }
            );

        this
            .Field<GqlSkill, Skill>("skill")
            .Argument<NonNullGraphType<GuidGraphType>>("id")
            .ResolveAsync(
                (context) =>
                {
                    var id = context.GetArgument<Guid>("id");

                    var skillService = context.RequestServices.GetRequiredService<ISkillService>();
                    return skillService.GetByIdAsync(id);
                }
            );

        this
            .Field<ListGraphType<GqlSkill>, List<Skill>>("querySkillsByNameAndSkillType")
            .Argument<NonNullGraphType<StringGraphType>>("name")
            .Argument<IntGraphType>("skillType")
            .ResolveAsync(
                (context) =>
                {
                    var name = context.GetArgument<string>("name");
                    var skillType = context.GetArgument<SkillTypes?>("skillType");

                    var skillService = context.RequestServices.GetRequiredService<ISkillService>();
                    return skillService.QueryByNameAndSkillTypeAsync(name, skillType);
                }
            );

        this
            .Field<GqlStatisticValues, StatisticValues>("calculateHeroStatistics")
            .Argument<GqlStatisticValueContext>("statisticValueContext")
            .Resolve(
                (context) =>
                {
                    var statisticValueContext = context.GetArgument<StatisticValueContext>("statisticValueContext");

                    var statisticService = context.RequestServices.GetRequiredService<IStatisticService>();
                    return statisticService.GetValues(statisticValueContext);
                }
            );

        this
            .Field<IntGraphType, int>("calculateHeroStatistic")
            .Argument<GqlStatisticValueContext>("statisticValueContext")
            .Argument<IntGraphType>("statistic")
            .Resolve(
                (context) =>
                {
                    var statisticValueContext = context.GetArgument<StatisticValueContext>("statisticValueContext");
                    var statistic = context.GetArgument<Statistics>("statistic");

                    var statisticService = context.RequestServices.GetRequiredService<IStatisticService>();
                    return statisticService.GetValue(statisticValueContext, statistic);
                }
            );

        this
            .Field<ListGraphType<GqlVoiceActor>, List<VoiceActor>>("voiceActors")
            .ResolveAsync(
                (context) =>
                {
                    var voiceActorService = context.RequestServices.GetRequiredService<IVoiceActorService>();
                    return voiceActorService.GetAllAsync();
                }
            );

        this
            .Field<GqlVoiceActor, VoiceActor>("voiceActor")
            .Argument<NonNullGraphType<IntGraphType>>("id")
            .ResolveAsync(
                (context) =>
                {
                    var id = context.GetArgument<int>("id");

                    var voiceActorService = context.RequestServices.GetRequiredService<IVoiceActorService>();
                    return voiceActorService.GetByIdAsync(id);
                }
            );
    }
}
