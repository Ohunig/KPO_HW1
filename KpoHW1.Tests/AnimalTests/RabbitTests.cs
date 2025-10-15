using Xunit;

namespace KpoHW1.Tests;

/// <summary>
/// Тесты для кролика
/// </summary>
public class RabbitTests
{
    [Fact]
    public void Health_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var rabbit = new Rabbit(10, "", 0, 10, 10);
        
        // Act & Assert
        Assert.Equal(10, rabbit.Health);
    }
    
    [Fact]
    public void Name_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var rabbit = new Rabbit(10, "Aboba", 0, 10, 10);
        
        // Act & Assert
        Assert.Equal("Aboba", rabbit.Name);
    }
    
    [Fact]
    public void ID_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var rabbit = new Rabbit(10, "Aboba", 5, 10, 10);
        
        // Act & Assert
        Assert.Equal(5, rabbit.Number);
    }
    
    [Fact]
    public void Food_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var rabbit = new Rabbit(10, "Aboba", 5, 9, 10);
        
        // Act & Assert
        Assert.Equal(9, rabbit.Food);
    }
    
    [Fact]
    public void Kindness_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var rabbit = new Rabbit(10, "Aboba", 5, 10, 8);
        
        // Act & Assert
        Assert.Equal(8, rabbit.Kindness);
    }
    
    [Fact]
    public void Type_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var rabbit = new Rabbit(10, "Aboba", 5, 10, 8);
        
        // Act & Assert
        Assert.Equal(AnimalType.Rabbit, rabbit.Type);
    }
}