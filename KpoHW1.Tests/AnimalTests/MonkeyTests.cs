using Xunit;

namespace KpoHW1.Tests;

/// <summary>
/// Тесты для обезьяны
/// </summary>
public class MonkeyTests
{
    [Fact]
    public void Health_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var monkey = new Monkey(10, "", 0, 10, 10);
        
        // Act & Assert
        Assert.Equal(10, monkey.Health);
    }
    
    [Fact]
    public void Name_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var monkey = new Monkey(10, "Aboba", 0, 10, 10);
        
        // Act & Assert
        Assert.Equal("Aboba", monkey.Name);
    }
    
    [Fact]
    public void ID_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var monkey = new Monkey(10, "Aboba", 5, 10, 10);
        
        // Act & Assert
        Assert.Equal(5, monkey.Number);
    }
    
    [Fact]
    public void Food_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var monkey = new Monkey(10, "Aboba", 5, 9, 10);
        
        // Act & Assert
        Assert.Equal(9, monkey.Food);
    }
    
    [Fact]
    public void Kindness_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var monkey = new Monkey(10, "Aboba", 5, 10, 8);
        
        // Act & Assert
        Assert.Equal(8, monkey.Kindness);
    }
    
    [Fact]
    public void Type_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var monkey = new Monkey(10, "Aboba", 5, 10, 8);
        
        // Act & Assert
        Assert.Equal(AnimalType.Monkey, monkey.Type);
    }
}