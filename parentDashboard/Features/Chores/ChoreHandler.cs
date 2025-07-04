using ParentDashboard.Data;
using ParentDashboard.Data.Models;

namespace ParentDashboard.Features.Chores
{
    public class ChoreHandler
    {
        public void Handler()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Chore Manager ===");
                Console.WriteLine("1. View Chores");
                Console.WriteLine("2. Add Chore");
                Console.WriteLine("3. Complete Chore");
                Console.WriteLine("4. Delete Chore");
                Console.WriteLine("5. Back");
                Console.Write("Select an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewChores();
                        break;
                    case "2":
                        AddChore();
                        break;
                    case "3":
                        CompleteChore();
                        break;
                    case "4":
                        DeleteChore();
                        break;
                    case "5":
                        return; // exits this menu
                    default:
                        Console.WriteLine("Invalid input. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void ViewChores()
        {
            using var db = new AppDbContext();
            var chores = db.Chores.ToList();

            Console.Clear();
            Console.WriteLine("=== Chore List ===");
            if (chores.Any())
            {
                foreach (var chore in chores)
                {
                    Console.WriteLine($"{chore.Id}. {chore.Name} - Assigned to: {chore.AssignedTo} - Completed: {chore.IsCompleted}");
                }
            }
            else
            {
                Console.WriteLine("No chores found.");
            }
            Console.WriteLine("\nPress Enter to return.");
            Console.ReadLine();
        }

        private void AddChore()
        {
            Console.Clear();
            Console.WriteLine("=== Add a Chore ===");

            Console.Write("Chore name: ");
            var name = Console.ReadLine();

            Console.Write("Assigned to: ");
            var assignedTo = Console.ReadLine();

            Console.Write("Category: ");
            var category = Console.ReadLine();

            var newChore = new Chore
            {
                Name = name,
                AssignedTo = assignedTo,
                Category = category,
                IsCompleted = false,
                CreatedAt = DateTime.Now
            };

            using var db = new AppDbContext();
            db.Chores.Add(newChore);
            db.SaveChanges();

            Console.WriteLine("Chore added! Press Enter to return.");
            Console.ReadLine();
        }

        private void CompleteChore()
        {
            using var db = new AppDbContext();
            var chores = db.Chores.Where(c => !c.IsCompleted).ToList();

            Console.Clear();
            Console.WriteLine("=== Complete a Chore ===");

            if (!chores.Any())
            {
                Console.WriteLine("No incomplete chores to complete.");
                Console.WriteLine("\nPress Enter to return.");
                Console.ReadLine();
                return;
            }

            foreach (var chore in chores)
            {
                Console.WriteLine($"{chore.Id}. {chore.Name} - Assigned to: {chore.AssignedTo}");
            }

            Console.Write("Enter the ID of the chore to mark as completed: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var choreToComplete = db.Chores.FirstOrDefault(c => c.Id == id);
                if (choreToComplete != null)
                {
                    choreToComplete.IsCompleted = true;
                    db.SaveChanges();
                    Console.WriteLine("Chore marked as completed!");
                }
                else
                {
                    Console.WriteLine("Chore not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            Console.WriteLine("\nPress Enter to return.");
            Console.ReadLine();
        }

        private void DeleteChore()
        {
            using var db = new AppDbContext();
            var chores = db.Chores.ToList();

            Console.Clear();
            Console.WriteLine("=== Delete a Chore ===");

            if (!chores.Any())
            {
                Console.WriteLine("No chores available to delete.");
                Console.WriteLine("\nPress Enter to return.");
                Console.ReadLine();
                return;
            }

            foreach (var chore in chores)
            {
                Console.WriteLine($"{chore.Id}. {chore.Name} - Assigned to: {chore.AssignedTo} - Completed: {chore.IsCompleted}");
            }

            Console.Write("Enter the ID of the chore to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var choreToDelete = db.Chores.FirstOrDefault(c => c.Id == id);
                if (choreToDelete != null)
                {
                    db.Chores.Remove(choreToDelete);
                    db.SaveChanges();
                    Console.WriteLine("Chore deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Chore not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            Console.WriteLine("\nPress Enter to return.");
            Console.ReadLine();
        }
    }
}
