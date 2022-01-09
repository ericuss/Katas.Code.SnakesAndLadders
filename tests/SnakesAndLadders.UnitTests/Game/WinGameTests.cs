using FluentAssertions;

using SnakesAndLadders.Domain;

using Xunit;

namespace SnakesAndLadders.UnitTests.Game;

public class WinGameTests
{
    private readonly GameService _gameService;
    public WinGameTests()
    {
        _gameService = new GameService();
    }

    [Fact]
    public void Player_Won_The_Game_When_Is_Placed_In_97_And_Move_3_Positions()
    {
        var expected_position_first = 97;
        var expected_position_last = 100;
        var first_movement = 96;
        var second_movement = 3;

        _gameService.Initialize(2);
        _gameService.Move(_gameService.Players[0].Id, first_movement);
        _gameService.Players[0].Position.Should().Be(expected_position_first);
        _gameService.Move(_gameService.Players[0].Id, second_movement);
        _gameService.Players[0].Position.Should().Be(expected_position_last);

        _gameService.Players[0].Winner.Should().BeTrue();
    }

    [Fact]
    public void Player_Not_Moved_When_Is_Placed_In_97_And_Try_To_Move_4_Positions()
    {
        var expected_position_first = 97;
        var expected_position_last = 97;
        var first_movement = 96;
        var second_movement = 4;

        _gameService.Initialize(2);
        _gameService.Move(_gameService.Players[0].Id, first_movement);
        _gameService.Players[0].Position.Should().Be(expected_position_first);
        _gameService.Move(_gameService.Players[0].Id, second_movement);
        _gameService.Players[0].Position.Should().Be(expected_position_last);

        _gameService.Players[0].Winner.Should().BeFalse();
    }
}