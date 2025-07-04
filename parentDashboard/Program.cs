using ParentDashboard.Menu;

namespace ParentDashboard;

internal class Program
{
    static void Main(string[] args)
    {
        var menu = new MainMenu();
        menu.ShowMainMenu();
    }
}

