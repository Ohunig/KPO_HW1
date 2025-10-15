using KpoHW1.Screens;
using NSubstitute;

namespace KpoHW1.Tests.PresentationTests;

/// <summary>
/// Экран отчёта о добрых животных
/// </summary>
public class FriendlyAnimalReportScreenTests
{
    [Fact]
    public void Render_Call_ShouldIncludeOnlyFriendlyAnimals()
    {
        // Arrange
        var builder = Substitute.For<IReportBuilder>();
        var consoleManager = Substitute.For<IConsoleManager>();
        var vetClinic = Substitute.For<IVetClinic>();
        vetClinic.IsAnimalHealthy(Arg.Any<Animal>()).Returns(true);

        var zoo = new Zoo(vetClinic);

        // Добавляем животных
        var friendlyMonkey = new Monkey(10, "Pipi", 1, 3, 8);
        var unfriendlyRabbit = new Rabbit(9, "Pupu", 2, 2, 3);
        var tiger = new Tiger(9, "Popo", 3, 5);

        zoo.AddAnimal(friendlyMonkey);
        zoo.AddAnimal(unfriendlyRabbit);
        zoo.AddAnimal(tiger);

        var screen = new FriendlyAnimalReportScreen(builder, consoleManager, zoo);

        // Act
        screen.Render();

        // Assert
        // Должен попасть только дружелюбный травоядный (Bonny)
        builder.Received().PushLine(Arg.Is<string>(s => s.Contains("Pipi")));
        builder.DidNotReceive().PushLine(Arg.Is<string>(s => s.Contains("Pupu")));
        builder.DidNotReceive().PushLine(Arg.Is<string>(s => s.Contains("Popo")));
        builder.Received().PushLine(Arg.Is<string>(s => s.Contains("Всего дружелюбных животных: 1")));

        consoleManager.Received().Print(Arg.Any<string>());
    }
}