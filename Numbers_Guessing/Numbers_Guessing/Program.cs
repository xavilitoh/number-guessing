// See https://aka.ms/new-console-template for more information

using Numbers_Guessing.Utils;
using Spectre.Console;
AnsiConsole.Markup("🎲 [green]Welcome to the Number Guessing Game[/] 🎲\n");
var rule = new Rule();
AnsiConsole.Write(rule);
AnsiConsole.Markup("I'm thinking of a number between 1 and 100..\n");
AnsiConsole.Console.Markup("You have 5 chances to guess the correct number..\n");
AnsiConsole.Write(rule);
var opt = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Please select the [green]difficulty level[/]")
        
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to select)[/]")
        .AddChoices("1. Easy (10 chances)", "2. Medium (5 chances)", "3. Hard (3 chances)"));


AnsiConsole.WriteLine($"Great! You have selected {opt} difficulty level.");
AnsiConsole.WriteLine("Let's start the game!");

var random = new Random();
int number = random.Next(1, 100);

int chances = 0;
bool isValid = false;
switch (opt)
{
    case "1. Easy (10 chances)":
        chances = 10;
        break;
    case "2. Medium (5 chances)":
        chances = 5;
        break;
    case "3. Hard (3 chances)":
        chances = 3;
        break;
}


while (!isValid && chances > 0)
{
    var guess = AnsiConsole.Prompt(
        new TextPrompt<int>("What's the secret number?"));
    var validationResult = Validator.ValidateGuess(guess, number);

    if (validationResult.IsSuccess)
    {
        AnsiConsole.Markup("[green]Congratulations! You guessed the number![/]\n");
        isValid = true;
    }
    else
    {
        chances--;
        if (chances == 0)
        {
            AnsiConsole.Markup("[red]Game Over! You have used all your chances.[/]\n");
            AnsiConsole.Markup($"The correct number was [green]{number}[/]\n");
        }
        else
        {
            AnsiConsole.Markup($"[red]{validationResult.Message}[/]\n");
            AnsiConsole.Markup($"[yellow]You have {chances} chances left.[/]\n");
        }
    }
}

