using KpoHW1.Domain.Entities.Things.Types;

namespace KpoHW1.Tests;

/// <summary>
/// Тесты для компьютера как предмета инвентаря
/// </summary>
public class ComputerTests
{
    [Fact]
    public void ID_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var computer = new Computer(123);
        
        // Act & Assert
        Assert.Equal(123, computer.Number);
    }
    
    [Fact]
    public void Type_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var computer = new Computer(123);
        
        // Act & Assert
        Assert.Equal(ThingType.Computer, computer.Type);
    }
}