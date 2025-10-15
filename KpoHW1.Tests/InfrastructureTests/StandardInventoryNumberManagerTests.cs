namespace KpoHW1.Tests.InfrastructureTests;

/// <summary>
/// Тесты для генератора уникальных ID
/// </summary>
public class StandardInventoryNumberManagerTests
{
    [Fact]
    public void GetNumber_Call_ShouldReturnDifferentNumbers()
    {
        // Arrange
        var numberManager = new StandardInventoryNumberManager();
        
        // Act
        int id1 = numberManager.GetNumber();
        int id2 = numberManager.GetNumber();
        
        // Assert
        Assert.NotEqual(id1, id2);
    }
}