using NSubstitute;

namespace KpoHW1.Tests;

/// <summary>
/// Тесты для стандартной ветеринарной клиники
/// </summary>
public class StandardVetClinicTests
{
    [Theory]
    [InlineData(0, false)]
    [InlineData(5, false)]
    [InlineData(6, true)]
    [InlineData(10, true)]
    public void IsAnimalHeathy_Call_ShouldReturnExpectedValue(int health, bool expected)
    {
        // Arrange
        var clinic = new StandardVetClinic();
        
        var animal = Substitute.For<Animal>();
        animal.Health.Returns(health);
        
        // Act & Assert
        Assert.Equal(expected, clinic.IsAnimalHealthy(animal));
    }
}