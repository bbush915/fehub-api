using System.ComponentModel.DataAnnotations;

using FEHub.Api.Services;

using Xunit;

namespace FEHub.Tests.Unit.Api.Services;

public sealed class EnumerationServiceTests
{
    private enum Fruits
    {
        APPLE,
        [Display(Name = "Orange", Description = "A tangy citrus fruit.")]
        ORANGE,
        GRAPE
    }

    [Fact]
    public void GetAll_Fruits_ReturnsAllEnumerationValues()
    {
        // Arrange

        var enumerationService = new EnumerationService<Fruits>();

        // Act

        var enumerationValues = enumerationService.GetAll();

        // Assert

        Assert.Equal(3, enumerationValues.Count);
    }

    [Fact]
    public void GetAll_Fruits_ReturnsOrangeEnumerationValue()
    {
        // Arrange

        var enumerationService = new EnumerationService<Fruits>();

        // Act

        var enumerationValues = enumerationService.GetAll();

        // Assert

        var enumerationValue = enumerationValues.Find(x => x.Name == "ORANGE");

        Assert.NotNull(enumerationValue);

        Assert.Equal(1, enumerationValue.Value);
        Assert.Equal("Orange", enumerationValue.DisplayValue);
        Assert.Equal("A tangy citrus fruit.", enumerationValue.Description);
    }

    [Fact]
    public void GetAll_Fruits_HandlesMissingDisplayInformation()
    {
        // Arrange

        var enumerationService = new EnumerationService<Fruits>();

        // Act

        var enumerationValues = enumerationService.GetAll();

        // Assert

        var enumerationValue = enumerationValues.Find(x => x.Name == "GRAPE");

        Assert.NotNull(enumerationValue);

        Assert.Equal(2, enumerationValue.Value);
        Assert.Null(enumerationValue.DisplayValue);
        Assert.Null(enumerationValue.Description);
    }
}
