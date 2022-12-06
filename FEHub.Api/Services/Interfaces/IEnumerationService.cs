using System.Collections.Generic;

using FEHub.Api.Models;

namespace FEHub.Api.Services.Interfaces;

public interface IEnumerationService<T>
{
    List<EnumerationValue> GetAll();
}
