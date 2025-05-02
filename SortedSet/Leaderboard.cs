namespace SortedSet;

/// <summary>
/// Represents a leaderboard that tracks players and their scores.
/// </summary>
public class Leaderboard
{
    private readonly SortedSet<Player> _players;
    private readonly Dictionary<string, Player> _playersMap;

    /// <summary>
    /// Initializes a new empty leaderboard.
    /// </summary>
    public Leaderboard()
    {
        _players = new SortedSet<Player>();
        _playersMap = new Dictionary<string, Player>();
    }

    /// <summary>
    /// Initializes a new leaderboard with the specified collection of players.
    /// </summary>
    /// <param name="players">The initial collection of players.</param>
    public Leaderboard(IEnumerable<Player> players)
    {
        var collection = players as Player[] ?? players.ToArray();
        _players = new SortedSet<Player>(collection);
        _playersMap = collection.ToDictionary(p => p.Id, p => p);
    }

    // Add or update a player in the leaderboard
    /// <summary>
    /// Adds a new player or updates an existing player in the leaderboard.
    /// </summary>
    /// <param name="player">The player to add or update.</param>
    public void AddOrUpdate(Player player)
    {
        if (_playersMap.TryGetValue(player.Id, out var existing))
        {
            _players.Remove(existing);
        }
        _players.Add(player);
        _playersMap[player.Id] = player;
    }

    // Get top N players (ordered descending)
    /// <summary>
    /// Gets the top N players from the leaderboard.
    /// </summary>
    /// <param name="count">The number of players to return.</param>
    /// <returns>A collection of the top players.</returns>
    public IEnumerable<Player> GetTopPlayers(int count)
    {
        return _players.Take(count);
    }

    /// <summary>
    /// Returns a formatted string representation of the leaderboard.
    /// </summary>
    /// <returns>A string containing the formatted leaderboard.</returns>
    public string GetFormattedLeaderboard(int limit)
    {
        var result = new System.Text.StringBuilder("Leaderboard:\n");
        int i = 1;
        
        foreach (var player in _players)
        {
            if (limit != -1 && i > limit)
                break;
            result.AppendLine($"{i++}. {player}");
        }
        return result.ToString();
    }

    /// <summary>
    /// Prints the leaderboard to the console.
    /// </summary>
    public void PrintLeaderboard(int limit = -1)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(GetFormattedLeaderboard(limit));
        Console.ResetColor();
    }

    /// <summary>
    /// Gets a player by their ID.
    /// </summary>
    /// <param name="id">The ID of the player to find.</param>
    /// <returns>The player if found; otherwise, null.</returns>
    public Player? GetPlayerById(string id)
    {
        return _playersMap.TryGetValue(id, out var player) ? player : null;
    }
}