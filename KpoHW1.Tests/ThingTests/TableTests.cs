using KpoHW1.Domain.Entities.Things.Types;

namespace KpoHW1.Tests;

/// <summary>
/// Тесты для стола как предмета инвентаря
/// </summary>
public class TableTests
{
    [Fact]
    public void ID_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var table = new Table(123);
        
        // Act & Assert
        Assert.Equal(123, table.Number);
    }
    
    [Fact]
    public void Type_Read_ShouldReturnExpectedValue()
    {
        // Arrange
        var table = new Table(123);
        
        // Act & Assert
        Assert.Equal(ThingType.Table, table.Type);
    }
}