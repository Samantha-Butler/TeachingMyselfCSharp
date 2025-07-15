using ParentDashboard.Menu;

namespace ChoreDashboard;

internal class Program
{
    static void Main(string[] args)
    {
        var menu = new MainMenu();
        menu.ShowMainMenu();
    }
}

