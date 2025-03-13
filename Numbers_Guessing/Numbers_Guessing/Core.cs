using Numbers_Guessing.Enums;
using Numbers_Guessing.Models;
using Numbers_Guessing.Utils;
using Spectre.Console;

namespace Numbers_Guessing;

public class Core
{
    public Game Game { get; private set; }
    
    void BuildGame()
    {
        AnsiConsole.Markup("🎲 [green]Welcome to the Number Guessing Game[/] 🎲\n");
        var rule = new Rule();
        AnsiConsole.Write(rule);
        AnsiConsole.Markup("I'm thinking of a number between 1 and 100..\n");
        AnsiConsole.Console.Markup("You have 5 chances to guess the correct number..\n");
        AnsiConsole.Write(rule);
        var dificulty = Utility.GetDifficultyLevel();
        AnsiConsole.WriteLine("Let's start the game!");
        
         Game = new Game(
            difficulty: dificulty,
            player: new Player
            {
                Chances = Utility.GetChances(dificulty)
            }
        );
    }

    public void Play()
    {
        BuildGame();
        bool continueGame = true;
        
        while (continueGame)
        {
            Game.Start();
            continueGame = AnsiConsole.Prompt(
                new SelectionPrompt<bool>()
                    .Title("Do you want to play again?")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to select)[/]")
                    .AddChoices(true, false));
            if (continueGame)
            {
                BuildGame();
            }
            else
            {
                AnsiConsole.Markup("[green]Thank you for playing![/]");
            }
        }
    }
}