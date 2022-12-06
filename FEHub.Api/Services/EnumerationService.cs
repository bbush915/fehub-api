using System;
using System.Collections.Generic;
using System.Linq;

using FEHub.Api.Models;
using FEHub.Api.Services.Interfaces;

namespace FEHub.Api.Services;

public sealed class EnumerationService<T> : IEnumerationService<T>
{
    public List<EnumerationValue> GetAll()
    {
        var enumerationValues = Enum
            .GetValues(typeof(T))
            .Cast<Enum>()
            .Select(x => new EnumerationValue(x))
            .ToList();

        return enumerationValues;
    }
}
