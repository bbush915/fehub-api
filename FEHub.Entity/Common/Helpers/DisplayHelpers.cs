using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FEHub.Entity.Common.Helpers;

public static class DisplayHelpers
{
    public static string GetName<T>()
    {
        var name = typeof(T)
            .GetCustomAttribute<DisplayAttribute>()
            ?.GetName();

        return name;
    }

    public static string GetName<T>(string propertyName)
    {
        var name = typeof(T)
            .GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance)
            ?.GetCustomAttribute<DisplayAttribute>()
            ?.GetName();

        return name;
    }

    public static string GetDescription<T>()
    {
        var description = typeof(T)
            .GetCustomAttribute<DisplayAttribute>()
            ?.GetDescription();

        return description;
    }

    public static string GetDescription<T>(string propertyName)
    {
        var description = typeof(T)
            .GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance)
            ?.GetCustomAttribute<DisplayAttribute>()
            ?.GetDescription();

        return description;
    }
}
