using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace FluentValidationTen.Models.FluentValidationModels
{
    public class UserRegistrationRequest
    {
        public string Username { get; set; }
        
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }

        public string SubscriptionLevel { get; set; }
            = SubscriptionLevels.Basic;
    }

    // ReSharper disable once UnusedType.Global
    public class UserRegistrationRequestValidator : AbstractValidator<UserRegistrationRequest>
    {
        public UserRegistrationRequestValidator(Database database)
        {
            RuleFor(m => m.Username).MustAsync(async (username, cancellationToken) =>
            {
                var exists = await database
                    .Users
                    .AnyAsync(u => username == u.Username, cancellationToken);
                
                return !exists;
            });

            RuleFor(m => m.Username).NotEmpty();
            RuleFor(m => m.Password).NotEmpty();
            RuleFor(m => m.PasswordConfirmation).Matches(m => m.Password);
            RuleFor(m => m.SubscriptionLevel).Must(BeInSubscriptionLevels);
        }

        private bool BeInSubscriptionLevels(string arg) => SubscriptionLevels.Is(arg);
    }
}