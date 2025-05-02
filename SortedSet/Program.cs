namespace SortedSet;


public class Program
{
    public static void Main(string[] args)
    {
        var players = new List<Player>
        {
            new Player("1", "Alice", new Score(100, 2)),
            new Player("2", "Bob", new Score(200, 2)),
            new Player("3", "Charlie", new Score(150, 1)),
            new Player("4", "David", new Score(200, 3))
        };
        // Genera
        var leaderboard = new Leaderboard(players);

        string? lastMessage = null;
        Console.Clear();

        while (true)
        {
            Console.Clear();
            PrintHeader();
            leaderboard.PrintLeaderboard(limit: 5);
            if (!string.IsNullOrEmpty(lastMessage))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n{lastMessage}");
                Console.ResetColor();
                lastMessage = null;
            }
            PrintMenu();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nSelect an option: ");
            Console.ResetColor();
            var input = Console.ReadLine()?.Trim();

            switch (input)
            {
                case "1":
                    lastMessage = RegisterPlayer(leaderboard);
                    break;
                case "2":
                    lastMessage = RegisterScore(leaderboard);
                    break;
                case "3":
                    lastMessage = ShowFullLeaderboard(leaderboard);
                    break;
                case "4":
                    lastMessage = ShowTopPlayers(leaderboard);
                    break;
                case "5":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Goodbye!");
                    Console.ResetColor();
                    return;
                default:
                    lastMessage = "Invalid option. Please try again.";
                    break;
            }
        }
    }

    static void PrintHeader()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===== LEADERBOARD APP =====\n");
        Console.ResetColor();
    }

    static void PrintMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n==== Menu ====");
        Console.ResetColor();
        Console.WriteLine("1. Register new player");
        Console.WriteLine("2. Register new score for existing player");
        Console.WriteLine("3. Show full leaderboard");
        Console.WriteLine("4. Show top N players");
        Console.WriteLine("5. Exit");
    }

    static string RegisterPlayer(Leaderboard leaderboard)
    {
        Console.Clear();
        PrintHeader();
        Console.WriteLine(leaderboard.GetFormattedLeaderboard(5));
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nRegister New Player");
        Console.ResetColor();

        Console.Write("Enter player ID: ");
        var id = Console.ReadLine()?.Trim();
        Console.Write("Enter player name: ");
        var name = Console.ReadLine()?.Trim();
        Console.Write("Enter level: ");
        if (!int.TryParse(Console.ReadLine(), out var level))
        {
            return "Invalid level.";
        }
        Console.Write("Enter score: ");
        if (!int.TryParse(Console.ReadLine(), out var score))
        {
            return "Invalid score.";
        }

        var player = new Player(id, name, new Score(score, level));
        leaderboard.AddOrUpdate(player);

        return $"Player '{name}' registered successfully!";
    }

    static string RegisterScore(Leaderboard leaderboard)
    {
        Console.Clear();
        PrintHeader();
        Console.WriteLine(leaderboard.GetFormattedLeaderboard(5));
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nRegister New Score for Existing Player");
        Console.ResetColor();

        Console.Write("Enter player ID: ");
        var id = Console.ReadLine()?.Trim();

        var player = leaderboard.GetPlayerById(id);
        if (player == null)
        {
            return "Player not found.";
        }
        
        Console.Write("Enter new level: ");
        if (!int.TryParse(Console.ReadLine(), out var level))
        {
            return "Invalid level.";
        }
        Console.Write("Enter new score: ");
        if (!int.TryParse(Console.ReadLine(), out var score))
        {
            return "Invalid score.";
        }

        var updatedPlayer = new Player(player.Id, player.Name, new Score(score, level));
        leaderboard.AddOrUpdate(updatedPlayer);

        return $"Score for '{player.Name}' updated successfully!";
    }

    static string ShowTopPlayers(Leaderboard leaderboard)
    {
        Console.Clear();
        PrintHeader();
        Console.WriteLine(leaderboard.GetFormattedLeaderboard(5));
        Console.Write("\nHow many top players to show? ");
        if (!int.TryParse(Console.ReadLine(), out var n))
        {
            return "Invalid number.";
        }
        var topPlayers = leaderboard.GetTopPlayers(n).ToList();
        if (!topPlayers.Any())
        {
            return "No players to display.";
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nTop {n} Players:");
        Console.ResetColor();
        int i = 1;
        foreach (var player in topPlayers)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{i++}. {player}");
            Console.ResetColor();
        }
        Console.WriteLine("\nPress Enter to return to menu...");
        Console.ReadLine();
        return null;
    }

    static string ShowFullLeaderboard(Leaderboard leaderboard)
    {
        Console.Clear();
        PrintHeader();
        Console.WriteLine(leaderboard.GetFormattedLeaderboard(limit: -1));
        Console.WriteLine("\nPress Enter to return to menu...");
        Console.ReadLine();
        return null;
    }
}