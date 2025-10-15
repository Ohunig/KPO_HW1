using Xunit;

namespace KpoHW1.Tests;

/// <summary>
/// Тесты для волка
/// </summary>
public class WolfTests
{
    [Fact]
    public void Health_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var wolf = new Wolf(10, "", 0, 10);
        
        // Act & Assert
        Assert.Equal(10, wolf.Health);
    }
    
    [Fact]
    public void Name_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var wolf = new Wolf(10, "Aboba", 0, 10);
        
        // Act & Assert
        Assert.Equal("Aboba", wolf.Name);
    }
    
    [Fact]
    public void ID_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var wolf = new Wolf(10, "Aboba", 5, 10);
        
        // Act & Assert
        Assert.Equal(5, wolf.Number);
    }
    
    [Fact]
    public void Food_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var wolf = new Wolf(10, "Aboba", 5, 9);
        
        // Act & Assert
        Assert.Equal(9, wolf.Food);
    }
    
    [Fact]
    public void Type_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var wolf = new Wolf(10, "Aboba", 5, 10);
        
        // Act & Assert
        Assert.Equal(AnimalType.Wolf, wolf.Type);
    }
}