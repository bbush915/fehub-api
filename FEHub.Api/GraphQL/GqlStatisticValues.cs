using FEHub.Api.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL;

internal sealed class GqlStatisticValues : ObjectGraphType<StatisticValues>
{
    public GqlStatisticValues()
    {
        this.Name = nameof(StatisticValues);
        this.Description = "The statistic values associated with a hero.";

        this.Field(nameof(StatisticValues.HitPoints), x => x.HitPoints);
        this.Field(nameof(StatisticValues.Attack), x => x.Attack);
        this.Field(nameof(StatisticValues.Speed), x => x.Speed);
        this.Field(nameof(StatisticValues.Defense), x => x.Defense);
        this.Field(nameof(StatisticValues.Resistance), x => x.Resistance);
    }
}
