using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace FluentValidationTen.Models.DataAnnotationsModels
{
    public class DataAnnotationsUserRegistrationRequest
    {
        [Required, UniqueUsername]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string PasswordConfirmation { get; set; }

        [SubscriptionLevelsValidation]
        public string SubscriptionLevel { get; set; }
            = SubscriptionLevels.Basic;
    }

    public class SubscriptionLevelsValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return SubscriptionLevels.Is(value as string);
        }
    }

    public class UniqueUsername : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var database = validationContext.GetRequiredService<Database>();
            var username = value as string;
            
            var exists =  database
                .Users
                .Any(u => username == u.Username);

            return exists 
                ? new("username must be unique") 
                : ValidationResult.Success ;
        }
    }
}