using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentValidationTen.Models
{
    public class SubscriptionLevels
    {
        public static IReadOnlyCollection<string> All 
            = new[] { Basic, Plus, Platinum };
        
        public const string Basic = nameof(Basic);
        public const string Plus = nameof(Plus);
        public const string Platinum = nameof(Platinum);

        public static bool Is(string subscriptionLevel)
        {
            return 
                !string.IsNullOrWhiteSpace(subscriptionLevel) && 
                All.Contains(subscriptionLevel, StringComparer.InvariantCultureIgnoreCase);
        }
    }
}