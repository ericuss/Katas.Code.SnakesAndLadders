using FluentAssertions;

using SnakesAndLadders.Domain;

using System.Linq;

using Xunit;

namespace SnakesAndLadders.UnitTests.Game;

public class GameInitializeTests
{
    private readonly GameService _gameService;
    public GameInitializeTests()
    {
        _gameService = new GameService();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void Initialize_Game_With_Players_When_Call_To_Initialize_Multiples_Times(int numberOfPlayers)
    {
        _gameService.Initialize(numberOfPlayers);
        _gameService.Initialize(numberOfPlayers);

        _gameService.Players.Count.Should().Be(numberOfPlayers);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void Position_Is_Moved_When_Call_To_Move_The_First_Player(int move)
    {
        _gameService.Initialize(1);
        _gameService.Move(_gameService.Players.First().Id, move);

        _gameService.Players.First().Position.Should().Be(move + 1);
    }

    [Fact]
    public void Position_Is_Moved_To_8_When_Call_To_Move_Twice()
    {
        const int expected_position = 8;
        _gameService.Initialize(1);
        _gameService.Move(_gameService.Players.First().Id, 3);
        _gameService.Move(_gameService.Players.First().Id, 4);

        _gameService.Players.First().Position.Should().Be(expected_position);
    }
}