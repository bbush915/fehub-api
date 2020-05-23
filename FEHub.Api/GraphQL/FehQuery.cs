//-----------------------------------------------------------------------------
// <copyright file="FehQuery.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using FEHub.Api.Services;
using FEHub.Entity;
using FEHub.Entity.Models;

using GraphQL;
using GraphQL.Types;

namespace FEHub.Api.GraphQL
{
    internal sealed class FehQuery : ObjectGraphType
    {
        #region Constructors
        public FehQuery(FehContextFactory dbContextFactory)
        {
            this
                .Field<ListGraphType<GqlAccessory>, List<Accessory>>()
                .Name("accessories")
                .ResolveAsync(
                    (context) =>
                    {
                        var service = new AccessoryService(dbContextFactory.CreateDbContext());

                        return service.GetAllAsync();
                    }
                );

            this
                .Field<GqlAccessory, Accessory>()
                .Name("accessory")
                .Argument<NonNullGraphType<GuidGraphType>>("id")
                .ResolveAsync(
                    (context) =>
                    {
                        var id = context.GetArgument<Guid>("id");

                        var service = new AccessoryService(dbContextFactory.CreateDbContext());

                        return service.GetByIdAsync(id);
                    }
                );

            this
                .Field<ListGraphType<GqlArtist>, List<Artist>>()
                .Name("artists")
                .ResolveAsync(
                    (context) =>
                    {
                        var service = new ArtistService(dbContextFactory.CreateDbContext());

                        return service.GetAllAsync();
                    }
                );

            this
                .Field<GqlArtist, Artist>()
                .Name("artist")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .ResolveAsync(
                    (context) =>
                    {
                        var id = context.GetArgument<int>("id");

                        var service = new ArtistService(dbContextFactory.CreateDbContext());

                        return service.GetByIdAsync(id);
                    }
                );

            this
                .Field<GqlEnumerations>()
                .Name("enumerations")
                .Resolve(x => new { });

            this
                .Field<ListGraphType<GqlHero>, List<Hero>>()
                .Name("heroes")
                .ResolveAsync(
                    (context) =>
                    {
                        var service = new HeroService(dbContextFactory.CreateDbContext());

                        return service.GetAllAsync();
                    }
                );

            this
                .Field<GqlHero, Hero>()
                .Name("hero")
                .Argument<NonNullGraphType<GuidGraphType>>("id")
                .ResolveAsync(
                    (context) =>
                    {
                        var id = context.GetArgument<Guid>("id");

                        var service = new HeroService(dbContextFactory.CreateDbContext());

                        return service.GetByIdAsync(id);
                    }
                );

            this
                .Field<ListGraphType<GqlItem>, List<Item>>()
                .Name("items")
                .ResolveAsync(
                    (context) =>
                    {
                        var service = new ItemService(dbContextFactory.CreateDbContext());

                        return service.GetAllAsync();
                    }
                );

            this
                .Field<GqlItem, Item>()
                .Name("item")
                .Argument<NonNullGraphType<GuidGraphType>>("id")
                .ResolveAsync(
                    (context) =>
                    {
                        var id = context.GetArgument<Guid>("id");

                        var service = new ItemService(dbContextFactory.CreateDbContext());

                        return service.GetByIdAsync(id);
                    }
                );

            this
                .Field<ListGraphType<GqlSkill>, List<Skill>>()
                .Name("skills")
                .ResolveAsync(
                    (context) =>
                    {
                        var service = new SkillService(dbContextFactory.CreateDbContext());

                        return service.GetAllAsync();
                    }
                );

            this
                .Field<GqlSkill, Skill>()
                .Name("skill")
                .Argument<NonNullGraphType<GuidGraphType>>("id")
                .ResolveAsync(
                    (context) =>
                    {
                        var id = context.GetArgument<Guid>("id");

                        var service = new SkillService(dbContextFactory.CreateDbContext());

                        return service.GetByIdAsync(id);
                    }
                );

            this
                .Field<ListGraphType<GqlVoiceActor>, List<VoiceActor>>()
                .Name("voiceActors")
                .ResolveAsync(
                    (context) =>
                    {
                        var service = new VoiceActorService(dbContextFactory.CreateDbContext());

                        return service.GetAllAsync();
                    }
                );

            this
                .Field<GqlVoiceActor, VoiceActor>()
                .Name("voiceActor")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .ResolveAsync(
                    (context) =>
                    {
                        var id = context.GetArgument<int>("id");

                        var service = new VoiceActorService(dbContextFactory.CreateDbContext());

                        return service.GetByIdAsync(id);
                    }
                );
        }
        #endregion
    }
}
