// See https://aka.ms/new-console-template for more information

using Spectre.Console;
AnsiConsole.Markup("🎲 [green]Welcome to the Number Guessing Game[/] 🎲\n");
var rule = new Rule("[red]RULES[/]");
rule.LeftJustified();
AnsiConsole.Write(rule);
AnsiConsole.Markup("I'm thinking of a number between 1 and 100..\n");
AnsiConsole.Console.Markup("You have 5 chances to guess the correct number..\n");
var opt = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Please select the difficulty level")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to select)[/]")
        .AddChoices("1. Easy (10 chances)", "2. Medium (5 chances)", "3. Hard (3 chances)"));


AnsiConsole.WriteLine($"Great! You have selected {opt} difficulty level.");
