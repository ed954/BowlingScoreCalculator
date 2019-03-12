using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoreCalculator
{
    public class InputValidatorResult
    {
        public bool IsSuccessful { get; }

        public string ErrorMessage { get; set; } = string.Empty;

        public InputValidatorResult(bool isSuccessful = false, string errorMessage = null)
        {
            IsSuccessful = isSuccessful;
            ErrorMessage = errorMessage ?? string.Empty;
        }
    }
}
