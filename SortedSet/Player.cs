namespace SortedSet;

public class Player : IComparable<Player>
{
    /// <summary>
    /// Gets the unique identifier for the player.
    /// </summary>
    public string Id { get; }
    /// <summary>
    /// Gets the display name of the player.
    /// </summary>
    public string Name { get; }
    /// <summary>
    /// Gets the player's score information.
    /// </summary>
    public Score Score { get; }

    /// <summary>
    /// Initializes a new player with the specified ID, name, and score.
    /// </summary>
    /// <param name="id">The player's unique identifier.</param>
    /// <param name="name">The player's display name.</param>
    /// <param name="score">The player's score information.</param>
    public Player(string id, string name, Score score)
    {
        Id = id;
        Name = name;
        Score = score;
    }

    // Sort: Level DESC, Score DESC, then Id for uniqueness
    /// <summary>
    /// Compares this player with another player for sorting purposes.
    /// Players are sorted by level (descending), then score (descending), then ID.
    /// </summary>
    /// <param name="other">The player to compare with.</param>
    /// <returns>A value indicating the relative order of the objects being compared.</returns>
    public int CompareTo(Player? other)
    {
        if (other == null) return -1;

        // Compare by level (descending), then score (descending), then ID (ascending)
        var levelComparison = other.Score.Level.CompareTo(Score.Level);
        if (levelComparison != 0) return levelComparison;

        var scoreComparison = other.Score.Value.CompareTo(Score.Value);
        if (scoreComparison != 0) return scoreComparison;

        return string.Compare(Id, other.Id, StringComparison.Ordinal);
    }

    /// <summary>
    /// Returns a string representation of the player.
    /// </summary>
    /// <returns>A string containing the player's details.</returns>
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Level: {Score.Level}, Score: {Score.Value}";
    }
}