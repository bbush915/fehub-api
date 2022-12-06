using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Common.Helpers;

using Xunit;

namespace FEHub.Tests.Unit.Entity.Common.Helpers;

public sealed class DisplayHelpersTests
{
    [Display(Name = "Bar", Description = "Baz")]
    private class Foo
    {
        [Display(Name = "Corge", Description = "Grault")]
        public string Qux { get; set; }
    }

    private class Garply
    {
        public string Waldo { get; set; }
    }

    [Fact]
    public void GetName_Class_GetsName()
    {
        // Arrange

        // Act

        var name = DisplayHelpers.GetName<Foo>();

        // Assert

        Assert.Equal("Bar", name);
    }

    [Fact]
    public void GetName_Class_NoAttribute()
    {
        // Arrange

        // Act

        var name = DisplayHelpers.GetName<Garply>();

        // Assert

        Assert.Null(name);
    }

    [Fact]
    public void GetName_Property_GetsName()
    {
        // Arrange

        // Act

        var name = DisplayHelpers.GetName<Foo>(nameof(Foo.Qux));

        // Assert

        Assert.Equal("Corge", name);
    }

    [Fact]
    public void GetName_Property_NoAttribute()
    {
        // Arrange

        // Act

        var name = DisplayHelpers.GetName<Garply>(nameof(Garply.Waldo));

        // Assert

        Assert.Null(name);
    }

    [Fact]
    public void GetName_Property_NoProperty()
    {
        // Arrange

        // Act

        var name = DisplayHelpers.GetName<Garply>("Bob");

        // Assert

        Assert.Null(name);
    }

    [Fact]
    public void GetDescription_Class_GetsDescription()
    {
        // Arrange

        // Act

        var description = DisplayHelpers.GetDescription<Foo>();

        // Assert

        Assert.Equal("Baz", description);
    }

    [Fact]
    public void GetDescription_Class_NoAttribute()
    {
        // Arrange

        // Act

        var name = DisplayHelpers.GetDescription<Garply>();

        // Assert

        Assert.Null(name);
    }

    [Fact]
    public void GetDescription_Property_GetsDescription()
    {
        // Arrange

        // Act

        var description = DisplayHelpers.GetDescription<Foo>(nameof(Foo.Qux));

        // Assert

        Assert.Equal("Grault", description);
    }

    [Fact]
    public void GetDescription_Property_NoProperty()
    {
        // Arrange

        // Act

        var name = DisplayHelpers.GetDescription<Garply>("Bob");

        // Assert

        Assert.Null(name);
    }

    [Fact]
    public void GetDescription_Property_NoAttribute()
    {
        // Arrange

        // Act

        var name = DisplayHelpers.GetDescription<Garply>(nameof(Garply.Waldo));

        // Assert

        Assert.Null(name);
    }
}
