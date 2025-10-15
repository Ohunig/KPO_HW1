using KpoHW1.Screens;
using NSubstitute;

namespace KpoHW1.Tests.PresentationTests;

/// <summary>
/// Экран с отчётом о животных
/// </summary>
public class AnimalReportScreenTests
{
    [Fact]
    public void Render_Call_ShouldPrintReportWithAllAnimals()
    {
        // Arrange
        var builder = Substitute.For<IReportBuilder>();
        var consoleManager = Substitute.For<IConsoleManager>();

        var vetClinic = Substitute.For<IVetClinic>();
        vetClinic.IsAnimalHealthy(Arg.Any<Animal>()).Returns(true);

        var zoo = new Zoo(vetClinic);
        zoo.AddAnimal(new Monkey(10, "Aboba", 1, 3, 5));
        zoo.AddAnimal(new Tiger(9, "Biba", 2, 7));

        var screen = new AnimalReportScreen(builder, consoleManager, zoo);

        // Act
        screen.Render();

        // Assert
        builder.Received().PushLine(Arg.Is<string>(s => s.Contains("Aboba")));
        builder.Received().PushLine(Arg.Is<string>(s => s.Contains("Biba")));
        builder.Received().PushLine(Arg.Is<string>(s => s.Contains("Всего животных: 2")));

        consoleManager.Received().Print(Arg.Any<string>());
    }
}