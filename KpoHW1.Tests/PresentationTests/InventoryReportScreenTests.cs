using KpoHW1.Domain.Entities.Things.Types;
using KpoHW1.Screens;
using NSubstitute;

namespace KpoHW1.Tests.PresentationTests;

/// <summary>
/// Экран отчёта о инвентаре
/// </summary>
public class InventoryReportScreenTests
{
    [Fact]
    public void Render_Call_ShouldPrintAllAnimalsAndThings()
    {
        // Arrange
        var builder = Substitute.For<IReportBuilder>();
        var consoleManager = Substitute.For<IConsoleManager>();
        var vetClinic = Substitute.For<IVetClinic>();
        vetClinic.IsAnimalHealthy(Arg.Any<Animal>()).Returns(true);

        var zoo = new Zoo(vetClinic);

        // Добавляем животных
        var monkey = new Monkey(10, "Aboba", 1, 3, 9);
        var tiger = new Tiger(9, "Boba", 2, 5);
        zoo.AddAnimal(monkey);
        zoo.AddAnimal(tiger);

        // Добавляем предметы
        var table = new Table(3);
        var computer = new Computer(4);
        zoo.AddThing(table);
        zoo.AddThing(computer);

        var screen = new InventoryReportScreen(builder, consoleManager, zoo);

        // Act
        screen.Render();

        // Assert
        builder.Received().PushLine("Животные:");
        builder.Received().PushLine(Arg.Is<string>(s => s.Contains("Aboba")));
        builder.Received().PushLine(Arg.Is<string>(s => s.Contains("Boba")));
        builder.Received().PushLine("Предметы:");
        builder.Received().PushLine(Arg.Is<string>(s => s.Contains("Table")));
        builder.Received().PushLine(Arg.Is<string>(s => s.Contains("Computer")));
        builder.Received().PushLine(Arg.Is<string>(s => s.Contains("Всего инвентаря: 4")));

        consoleManager.Received().Print(Arg.Any<string>());
    }
    
}