using FEHub.Entity.Common.Helpers;
using FEHub.Entity.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL;

internal sealed class GqlAccessory : ObjectGraphType<Accessory>
{
    public GqlAccessory()
    {
        this.Name = nameof(Accessory);
        this.Description = DisplayHelpers.GetDescription<Accessory>();

        this
            .Field(nameof(Accessory.AccessoryType), x => (int)x.AccessoryType)
            .Description(DisplayHelpers.GetDescription<Accessory>(nameof(Accessory.AccessoryType)));

        this
            .Field(nameof(Accessory.CreatedAt), x => x.CreatedAt, type: typeof(DateTimeGraphType))
            .Description(DisplayHelpers.GetDescription<Accessory>(nameof(Accessory.CreatedAt)));

        this
            .Field(nameof(Accessory.CreatedBy), x => x.CreatedBy)
            .Description(DisplayHelpers.GetDescription<Accessory>(nameof(Accessory.CreatedBy)));

        this
            .Field(nameof(Accessory.Description), x => x.Description)
            .Description(DisplayHelpers.GetDescription<Accessory>(nameof(Accessory.Description)));

        this
            .Field(nameof(Accessory.Id), x => x.Id)
            .Description(DisplayHelpers.GetDescription<Accessory>(nameof(Accessory.Id)));

        this
            .Field(nameof(Accessory.ModifiedAt), x => x.ModifiedAt, type: typeof(DateTimeGraphType))
            .Description(DisplayHelpers.GetDescription<Accessory>(nameof(Accessory.ModifiedAt)));

        this
            .Field(nameof(Accessory.ModifiedBy), x => x.ModifiedBy)
            .Description(DisplayHelpers.GetDescription<Accessory>(nameof(Accessory.ModifiedBy)));

        this
            .Field(nameof(Accessory.Name), x => x.Name)
            .Description(DisplayHelpers.GetDescription<Accessory>(nameof(Accessory.Name)));

        this
            .Field(nameof(Accessory.Tag), x => x.Tag)
            .Description(DisplayHelpers.GetDescription<Accessory>(nameof(Accessory.Tag)));

        this
            .Field(nameof(Accessory.Version), x => x.Version)
            .Description(DisplayHelpers.GetDescription<Accessory>(nameof(Accessory.Version)));
    }
}
