using KpoHW1;
using KpoHW1.Screens;

StandardVetClinic clinic = new StandardVetClinic();
Zoo zoo = new Zoo(clinic);

StandardConsoleManager consoleManager = new StandardConsoleManager();
StandardInventoryNumberManager inventoryNumberManager = new StandardInventoryNumberManager();
StandardReportBuilder reportBuilder = new StandardReportBuilder();
IScreen[] screens = [
    new MainScreen(consoleManager),
    new AddAnimalScreen(inventoryNumberManager, consoleManager, zoo),
    new AddThingScreen(inventoryNumberManager, consoleManager, zoo),
    new AnimalReportScreen(reportBuilder, consoleManager, zoo),
    new FriendlyAnimalReportScreen(reportBuilder, consoleManager, zoo),
    new InventoryReportScreen(reportBuilder, consoleManager, zoo)
];
StandardScreenManager screenManager = new StandardScreenManager(screens, ScreenType.MainScreen);
screenManager.Render();