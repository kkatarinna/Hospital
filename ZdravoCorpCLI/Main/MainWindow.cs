

using ZdravoCorpCLI.UIHandler;

class MainWindow
{
    public static void Main(string[] args)
    {
        MainMenuUIHandler mainUIHandler = new MainMenuUIHandler();
        mainUIHandler.handleMainMenu();
    }
}
