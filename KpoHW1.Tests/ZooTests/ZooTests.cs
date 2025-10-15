using KpoHW1.Domain.Entities.Things;
using NSubstitute;

namespace KpoHW1.Tests;

/// <summary>
/// Тесты зоопарка
/// </summary>
public class ZooTests
{
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void AddAnimal_Call_ShouldReturnExpectedResult(bool animalIsHealth)
    {
        // Arrange
        var clinic = Substitute.For<IVetClinic>();
        clinic.IsAnimalHealthy(Arg.Any<Animal>()).Returns(animalIsHealth);
        var animal = Substitute.For<Animal>();
        var zoo = new Zoo(clinic);
        
        // Act & Assert
        Assert.Equal(animalIsHealth, zoo.AddAnimal(animal));
    }

    [Fact]
    public void AddAnimal_Call_ShouldAddAnimal()
    {
        // Arrange
        var clinic = Substitute.For<IVetClinic>();
        clinic.IsAnimalHealthy(Arg.Any<Animal>()).Returns(true);
        var animal = Substitute.For<Animal>();
        var zoo = new Zoo(clinic);
        
        // Act
        zoo.AddAnimal(animal);
        
        // Assert
        Assert.Single(zoo.Animals);
        Assert.Equal(animal, zoo.Animals[0]);
    }

    [Fact]
    public void AddAnimal_Call_ShouldNotAddAnimal()
    {
        // Arrange
        var clinic = Substitute.For<IVetClinic>();
        clinic.IsAnimalHealthy(Arg.Any<Animal>()).Returns(false);
        var animal = Substitute.For<Animal>();
        var zoo = new Zoo(clinic);
        
        // Act
        zoo.AddAnimal(animal);
        
        // Assert
        Assert.Empty(zoo.Animals);
    }

    [Fact]
    public void AddThing_Call_ShouldAddThing()
    {
        // Arrange
        var clinic = Substitute.For<IVetClinic>();
        var thing = Substitute.For<Thing>();
        var zoo = new Zoo(clinic);
        
        // Act
        zoo.AddThing(thing);
        
        // Assert
        Assert.Single(zoo.Things);
        Assert.Equal(thing, zoo.Things[0]);
    }
}