using Xunit;

namespace KpoHW1.Tests;

/// <summary>
/// Тесты для тигра
/// </summary>
public class TigerTests
{
    [Fact]
    public void Health_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var tiger = new Tiger(10, "", 0, 10);
        
        // Act & Assert
        Assert.Equal(10, tiger.Health);
    }
    
    [Fact]
    public void Name_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var tiger = new Tiger(10, "Aboba", 0, 10);
        
        // Act & Assert
        Assert.Equal("Aboba", tiger.Name);
    }
    
    [Fact]
    public void ID_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var tiger = new Tiger(10, "Aboba", 5, 10);
        
        // Act & Assert
        Assert.Equal(5, tiger.Number);
    }
    
    [Fact]
    public void Food_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var tiger = new Tiger(10, "Aboba", 5, 9);
        
        // Act & Assert
        Assert.Equal(9, tiger.Food);
    }
    
    [Fact]
    public void Type_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var tiger = new Tiger(10, "Aboba", 5, 10);
        
        // Act & Assert
        Assert.Equal(AnimalType.Tiger, tiger.Type);
    }
}