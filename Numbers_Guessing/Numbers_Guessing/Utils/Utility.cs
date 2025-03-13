using Numbers_Guessing.Enums;
using Spectre.Console;

namespace Numbers_Guessing.Utils;

public static class Utility
{
    public static int GetChances(DifficultyLevel difficulty)
    {
        return difficulty switch
        {
            DifficultyLevel.Easy => 10,
            DifficultyLevel.Medium => 5,
            DifficultyLevel.Hard => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(difficulty), difficulty, null)
        };
    }

    public static DifficultyLevel GetDifficultyLevel()
    {
        var opt = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Please select the [green]difficulty level[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to select)[/]")
                .AddChoices("1. Easy (10 chances)", "2. Medium (5 chances)", "3. Hard (3 chances)"));
        
        AnsiConsole.WriteLine($"Great! You have selected {opt} difficulty level.");
        
        return opt switch
        {
            "1. Easy (10 chances)" => DifficultyLevel.Easy,
            "2. Medium (5 chances)" => DifficultyLevel.Medium,
            "3. Hard (3 chances)" => DifficultyLevel.Hard,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}