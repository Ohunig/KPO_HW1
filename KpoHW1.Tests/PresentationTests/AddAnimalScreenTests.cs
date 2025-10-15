using KpoHW1.Screens;
using NSubstitute;

namespace KpoHW1.Tests.PresentationTests;

/// <summary>
/// Тесты экрана добавления животных
/// </summary>
public class AddAnimalScreenTests
{
    [Fact]
    public void Render_Call_ShouldPrintAnimalList()
    {
        // Arrange
        var consoleManager = Substitute.For<IConsoleManager>();
        var inventory = Substitute.For<IInventoryNumberManager>();
        var zoo = new Zoo(Substitute.For<IVetClinic>());

        var screen = new AddAnimalScreen(inventory, consoleManager, zoo);

        // Act
        screen.Render();

        // Assert
        consoleManager.Received(1).Print(Arg.Is<string>(s => s.Contains("Monkey") && s.Contains("Rabbit") && s.Contains("Tiger") && s.Contains("Wolf")));
    }
    
    [Fact]
    public void HandleScreenAction_Call_ShouldReturnPreviousWhenAnimalSuccessfullyAdded()
    {
        // Arrange
        var consoleManager = Substitute.For<IConsoleManager>();
        var zoo = Substitute.For<Zoo>(Substitute.For<IVetClinic>());
        var inventory = Substitute.For<IInventoryNumberManager>();
        inventory.GetNumber().Returns(42);
        
        consoleManager.GetIntResponse(Arg.Any<string>()).Returns(1, 6, 10, 3, 7);
        consoleManager.GetStringResponse(Arg.Any<string>()).Returns("Aboba");
        zoo.AddAnimal(Arg.Any<Animal>()).Returns(true);

        var screen = new AddAnimalScreen(inventory, consoleManager, zoo);

        // Act
        var result = screen.HandleScreenAction();

        // Assert
        Assert.Equal(ScreenActionType.Previous, result.ActionType);
        zoo.Received(1).AddAnimal(Arg.Is<Animal>(a =>
            a.Name == "Aboba" &&
            a.Health == 6 &&
            a.Food == 3
        ));
    }
    
    [Fact]
    public void HandleScreenAction_Call_ShouldReturnNothingWhenZooRejectsAnimal()
    {
        // Arrange
        var consoleManager = Substitute.For<IConsoleManager>();
        var zoo = new Zoo(Substitute.For<IVetClinic>());
        var inventory = Substitute.For<IInventoryNumberManager>();

        consoleManager.GetIntResponse(Arg.Any<string>()).Returns(1, 5, 10, 3, 7);
        consoleManager.GetStringResponse(Arg.Any<string>()).Returns("Aboba");
        zoo.AddAnimal(Arg.Any<Animal>()).Returns(false);

        var screen = new AddAnimalScreen(inventory, consoleManager, zoo);

        // Act
        var result = screen.HandleScreenAction();

        // Assert
        Assert.Equal(ScreenActionType.Nothing, result.ActionType);
        consoleManager.Received(1).Print(Arg.Is<string>(s => s.Contains("не было добавлено")));
        consoleManager.Received(1).WaitButtonPress();
    }
    
    [Fact]
    public void HandleScreenAction_Call_ShouldReturnNothingWhenInvalidHealth()
    {
        // Arrange
        var consoleManager = Substitute.For<IConsoleManager>();
        consoleManager.GetIntResponse(Arg.Any<string>()).Returns(1, (int?)null);

        var screen = new AddAnimalScreen(
            Substitute.For<IInventoryNumberManager>(),
            consoleManager,
            new Zoo(Substitute.For<IVetClinic>())
        );

        // Act
        var result = screen.HandleScreenAction();

        // Assert
        Assert.Equal(ScreenActionType.Nothing, result.ActionType);
        consoleManager.Received(1).PrintError(Arg.Any<string>());
        consoleManager.Received(1).WaitButtonPress();
    }
}