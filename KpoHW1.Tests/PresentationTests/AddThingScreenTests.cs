using KpoHW1.Domain.Entities.Things;
using KpoHW1.Domain.Entities.Things.Types;
using KpoHW1.Screens;
using NSubstitute;

namespace KpoHW1.Tests.PresentationTests;

/// <summary>
/// Экран добавления вещи
/// </summary>
public class AddThingScreenTests
{
    [Fact]
    public void Render_Call_ShouldPrintAllThingTypes()
    {
        // Arrange
        var console = Substitute.For<IConsoleManager>();
        var screen = new AddThingScreen(
            Substitute.For<IInventoryNumberManager>(),
            console,
            new Zoo(Substitute.For<IVetClinic>())
        );

        // Act
        screen.Render();

        // Assert
        console.Received(1).Print(Arg.Is<string>(msg =>
            msg.Contains("Table") && msg.Contains("Computer")));
    }

    [Fact] public void HandleScreenAction_Call_ShouldReturnNothingWhenInvalidInput()
    {
        // Arrange
        var console = Substitute.For<IConsoleManager>();
        console.GetIntResponse(Arg.Any<string>()).Returns((int?)null);

        var screen = new AddThingScreen(
            Substitute.For<IInventoryNumberManager>(),
            console,
            new Zoo(Substitute.For<IVetClinic>())
        );

        // Act
        var result = screen.HandleScreenAction();

        // Assert
        Assert.Equal(ScreenActionType.Nothing, result.ActionType);
        console.Received(1).PrintError(Arg.Any<string>());
        console.Received(1).WaitButtonPress();
    }
}