

using Numbers_Guessing.Enums;
using Numbers_Guessing.Utils;
using Spectre.Console;

namespace Numbers_Guessing.Models;


public class Game
{
    
    private readonly Random _random = new Random();
    public int SecrectNumber { get; private set; }
    public DifficultyLevel Difficulty { get; private set; }
    public Player Player { get; set; }
    
    public Game(DifficultyLevel difficulty, Player player)
    {
        
        SecrectNumber = _random.Next(1, 100);
        Difficulty = difficulty;
        Player = player;
    }
    
    public void Start()
    {
        bool isValid = false;
        while (!isValid && Player.Chances > 0)
        {
            var guess = AnsiConsole.Prompt(
                new TextPrompt<int>("What's the secret number?"));
            var validationResult = Validator.ValidateGuess(guess, SecrectNumber);
        
            if (validationResult.IsSuccess)
            {
                AnsiConsole.Markup("[green]Congratulations! You guessed the number![/]\n");
                isValid = true;
            }
            else
            {
                Player.Chances--;
                if (Player.Chances == 0)
                {
                    AnsiConsole.Markup("[red]Game Over! You have used all your chances.[/]\n");
                    AnsiConsole.Markup($"The correct number was [green]{SecrectNumber}[/]\n");
                }
                else
                {
                    AnsiConsole.Markup($"[red]{validationResult.Message}[/]\n");
                    AnsiConsole.Markup($"[yellow]You have {SecrectNumber} chances left.[/]\n");
                }
            }
        }
    }
}

