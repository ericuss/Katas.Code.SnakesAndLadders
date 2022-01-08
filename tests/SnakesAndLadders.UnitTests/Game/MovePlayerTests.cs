using FluentAssertions;

using SnakesAndLadders.Domain;

using Xunit;

namespace SnakesAndLadders.UnitTests.Game;

public class MovePlayerTests
{
    private readonly GameService _gameService;
    public MovePlayerTests()
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
}