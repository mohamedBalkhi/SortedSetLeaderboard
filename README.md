# Leaderboard Application

A simple console application to demonstrate a real-world use case of Sorted Sets in C#.

## About

This application implements a game leaderboard system using C#'s `SortedSet` collection to efficiently maintain players in sorted order. The leaderboard ranks players based on their level (descending), score (descending), and player ID (for uniqueness).

## Features

- Register new players with unique IDs
- Update scores for existing players
- View the full leaderboard
- View top N players
- Console-based user interface with color formatting

## Implementation Details

The application consists of the following components:

- **Player**: Represents a player with ID, name, and score information
- **Score**: A record that holds a player's score value and level
- **Leaderboard**: Manages the collection of players using a `SortedSet` for automatic sorting
- **Program**: Contains the main application logic and user interface

## How It Works

The `SortedSet` collection automatically maintains players in sorted order based on the `IComparable<Player>` implementation. This provides efficient insertion, removal, and retrieval of players in their correct ranking order.

## Usage

Run the application and follow the on-screen menu:

1. Register new player
2. Register new score for existing player
3. Show full leaderboard
4. Show top N players
5. Exit

## Requirements

- .NET 6.0 or later


## License
This project is licensed under the MIT License - see the LICENSE file for details.
