namespace KpoHW1.Tests.InfrastructureTests;

/// <summary>
/// Тесты стандартного билдера отчётов
/// </summary>
public class StandardReportBuilderTests
{
    [Theory]
    [InlineData("")]
    [InlineData("Aboba")]
    public void Push_Call_ShouldAddMessageToReport(String message)
    {
        // Arrange
        var reportBuilder = new StandardReportBuilder();
        
        // Act
        reportBuilder.Push(message);
        
        // Assert
        Assert.Equal(message + "Конец отчёта\n", reportBuilder.Build());
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("Aboba")]
    public void Push_Call_ShouldAddLineToReport(String line)
    {
        // Arrange
        var reportBuilder = new StandardReportBuilder();
        
        // Act
        reportBuilder.PushLine(line);
        
        // Assert
        Assert.Equal(line + "\n" + "Конец отчёта\n", reportBuilder.Build());
    }
}