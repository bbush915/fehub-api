using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FEHub.Api.Models;

public sealed class EnumerationValue
{
    public EnumerationValue(Enum value)
    {
        this.Name = value.ToString();
        this.Value = Convert.ToInt32(value);

        var displayInfo = value
            .GetType()
            .GetMember(value.ToString())[0]
            .GetCustomAttribute<DisplayAttribute>();

        this.Description = displayInfo?.GetDescription();
        this.DisplayValue = displayInfo?.GetName();
    }

    public string Name { get; }
    public string Description { get; }
    public string DisplayValue { get; }
    public int Value { get; }
}
