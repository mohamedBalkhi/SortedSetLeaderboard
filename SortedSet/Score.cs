namespace SortedSet;

/// <summary>
/// Represents a player's score with a value and level.
/// </summary>
/// <param name="Value">The numeric score value.</param>
/// <param name="Level">The level at which the score was achieved.</param>
public record Score(int Value, int Level);