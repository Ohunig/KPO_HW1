using System.Runtime.InteropServices.JavaScript;
using KpoHW1.DI;
using KpoHW1.Screens;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace KpoHW1.Tests.PresentationTests;

/// <summary>
/// Тесты стандартного менеджера экранов
/// </summary>
public class StandardScreenManagerTests
{
    [Fact]
    public void Pop_WhenCalledAfterPush_ShouldReturnPushedScreenType()
    {
        // Arrange
        var consoleManager = Substitute.For<IConsoleManager>();
        IScreen[] screens = new IScreen[6];
        screens[(int)ScreenType.MainScreen] = new MainScreen(consoleManager);

        var screenManager = new StandardScreenManager(screens, ScreenType.MainScreen);
        var screenToPush = ScreenType.MainScreen;

        // Act
        screenManager.Push(screenToPush);
        var poppedScreen = screenManager.Pop();

        // Assert
        Assert.Equal(screenToPush, poppedScreen);
    }
    
    [Fact]
    public void Push_Call_ShouldAddScreensInOrder()
    {
        // Arrange
        var consoleManager = Substitute.For<IConsoleManager>();
        var inventoryManager = Substitute.For<IInventoryNumberManager>();
        var clinic = Substitute.For<IVetClinic>();
        var zoo = new Zoo(clinic);

        var screens = new IScreen[6];
        screens[(int)ScreenType.MainScreen] = new MainScreen(consoleManager);
        screens[(int)ScreenType.AddAnimalScreen] = new AddAnimalScreen(inventoryManager, consoleManager, zoo);

        var screenManager = new StandardScreenManager(screens, ScreenType.MainScreen);

        var firstScreen = ScreenType.MainScreen;
        var secondScreen = ScreenType.AddAnimalScreen;

        // Act
        screenManager.Push(firstScreen);
        screenManager.Push(secondScreen);

        // Assert
        Assert.Equal(secondScreen, screenManager.Pop());
        Assert.Equal(firstScreen, screenManager.Pop());
    }
    
    [Fact]
    public void Render_Call_ShouldGoToNextScreen()
    {
        // Arrange
        var screen1 = Substitute.For<IScreen>();
        var screen2 = Substitute.For<IScreen>();

        var screens = new IScreen[6];
        screens[(int)ScreenType.MainScreen] = screen1;
        screens[(int)ScreenType.AddAnimalScreen] = screen2;

        var manager = new StandardScreenManager(screens, ScreenType.MainScreen);
        
        screen1.HandleScreenAction().Returns(ScreenAction.Next(ScreenType.AddAnimalScreen));
        
        screen2.HandleScreenAction().Returns(ScreenAction.Exit());

        // Act
        manager.Render();

        // Assert
        Received.InOrder(() =>
        {
            screen1.Render();
            screen2.Render();
        });
    }

}