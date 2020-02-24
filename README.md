# Tic Tac Toe

The classic Match Three game of Xs and Os - Tic Tac Toe! Two players take turns marking spaces on the board, trying to be the first to mark three consecutive spaces (horizontally, vertically, or diagonally). This version of the game allows to human players to play through a command line app.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

To run the tests and play the game, you'll need to download the .NET core SDK [from Microsoft](https://dotnet.microsoft.com/download). To confirm it's installed, run the following command in the terminal:

```
$ dotnet
```
When successfully installed, you should see information on how to use dotnet.

### Installing

Fork and clone a copy of this repo onto your local machine

Navigate to the TicTacToe directory

```
$ cd tic-tac-toe-csharp/TicTacToe
```

And run the app using the command:

```
$ dotnet run
```

The game begins by asking each player for their names, then alternating turns until there is a winner, or board is full and the game ends in a draw.

## Running the tests

Tests are contained in the `tic-tac-toe-csharp/TicTacToe.Tests` directory.

### Running Unit Tests

From the top level directory `tic-tac-toe-csharp` run tests with the command:

```
dotnet test
```

## Built With

* [xUnit](https://xunit.net/docs/getting-started/netcore/cmdline) - Unit testing for .NET core apps

## Authors

* **Matt Readout** - *Initial work* - [digitopolis](https://github.com/digitopolis)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
