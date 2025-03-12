namespace Numbers_Guessing.Models;

public class ValidationResult
{
     public bool IsSuccess { get; set; }
     public string Message { get; set; }
     
     public static ValidationResult Error(string Message)
     {
         return new ValidationResult
         {
             IsSuccess = false,
             Message = Message
         };
     }
     
        public static ValidationResult Success()
        {
            return new ValidationResult
            {
                IsSuccess = true,
                Message = "!"
            };
        }
}