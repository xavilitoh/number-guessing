using Numbers_Guessing.Models;

namespace Numbers_Guessing.Utils;

public class Validator
{
    public static ValidationResult ValidateGuess(int guess, int number)
    {
        if (guess < number)
        {
            return ValidationResult.Error($"Incorrect! The number is greater than {guess}");
        }
        else if (guess > number)
        {
            return ValidationResult.Error($"Incorrect! The number is less than {guess}");
        }
        else
        {
            return ValidationResult.Success();
        }
    }
}