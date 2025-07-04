using ParentDashboard.Features.Chores;

namespace ParentDashboard.Menu
{
    public class MainMenu
    {
        public void ShowMainMenu()
        {
            Console.WriteLine("=== ChoreHandler ===");
            Console.WriteLine("1. Manage Chores");
            Console.WriteLine("2. Exit");
            Console.Write("Select an option: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    new ChoreHandler().Handler();
                    break;
                default:
                    Console.WriteLine("Invalid input. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
            
        }
        
        
    }
}