﻿// See https://aka.ms/new-console-template for more information
using System;

using Cocona;

using SnakesAndLadders.Domain;


class Program
{
    private static GameService _gameService = new();

    private static int _nextPlayerIndex = 0;
    private static Random _random = new Random();


    static void Main(string[] args)
    {
        CoconaApp.Run<Program>(args);
    }

    public void Regular(int players)
    {
        _gameService.Initialize(players);

        this.ShowPlayers();

        Console.WriteLine("Exit to close");
        string? command;

        do
        {
            int movement;
            command = Console.ReadLine()?.ToLowerInvariant();
            if (command == "random")
            {
                movement = _random.Next(1, 6);
            }
            else if (command?.StartsWith("move") == true)
            {
                // should be validated
                movement = int.Parse(command.Split("move")[1]);
            }
            else
            {
                continue;
            }

            Console.WriteLine($"movement: {movement}");
            _gameService.Move(_gameService.Players[_nextPlayerIndex].Id, movement);
            this.CalculateNexPlayer();
            this.ShowPlayers();
        } while(command != "exit" && !_gameService.Players.Any(x => x.Winner));
    }

    public void CalculateNexPlayer()
    {
        _nextPlayerIndex++;
        if (_nextPlayerIndex >= _gameService.Players.Count) _nextPlayerIndex = 0;
    }
    public void ShowPlayers()
    {
        Console.WriteLine("Players:");
        Console.WriteLine();
        _gameService.Players.ForEach(x => Console.WriteLine(x));

        var winner = _gameService.Players.FirstOrDefault(x => x.Winner);
        if (winner == null) Console.WriteLine($"Next player: {_nextPlayerIndex + 1}");
        else Console.WriteLine($"Player {winner.Id} won the game");
    }
}
