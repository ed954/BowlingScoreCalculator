using System;
using System.Text.RegularExpressions;

namespace BowlingScoreCalculator
{
    public class InputValidator
    {
        private Regex _digit0to10 = new Regex(@"^(\d{1}|10)$");

        public InputValidatorResult ValidateNonTenthThrowInput(string firstThrowInput, string secondThrowInput = null)
        {
            if (firstThrowInput == null)
                return Error("First throw input is required");

            if (!_digit0to10.IsMatch(firstThrowInput))
                return Error("First throw must be a number from 0 - 10");

            int firstThrowNumber = Convert.ToInt32(firstThrowInput);

            if (secondThrowInput != null)
            {
                if (firstThrowNumber == 10)
                    return Error("A number cannot be supplied for the second throw if the first throw was 10");

                if (!_digit0to10.IsMatch(secondThrowInput))
                    return Error($"Second throw must be a number");

                int secondThrowNumber = Convert.ToInt32(secondThrowInput);
                if (firstThrowNumber + secondThrowNumber > 10)
                    return Error($"Second throw must be a number from 0 - {10 - firstThrowNumber}");
            }

            return Success();
        }

        public InputValidatorResult ValidateTenthThrowInput(string firstThrowInput, string secondThrowInput = null, string thirdThrowInput = null)
        {
            if (firstThrowInput == null)
                return Error("First throw input is required");

            if (!_digit0to10.IsMatch(firstThrowInput))
                return Error("First throw must be a number from 0 - 10");

            int firstThrowNumber = Convert.ToInt32(firstThrowInput);

            if (secondThrowInput != null)
            {
                if (!_digit0to10.IsMatch(secondThrowInput))
                    return Error($"Second throw must be a number");

                int secondThrowNumber = Convert.ToInt32(secondThrowInput);
                if (firstThrowNumber != 10 && (firstThrowNumber + secondThrowNumber > 10))
                    return Error($"Second throw must be a number from 0 - {10 - firstThrowNumber}");

                if (thirdThrowInput != null)
                {
                    if (!_digit0to10.IsMatch(thirdThrowInput))
                        return Error($"Third throw must be a number");

                    int thirdThrowNumber = Convert.ToInt32(thirdThrowInput);
                    if ((firstThrowNumber == 10 && secondThrowNumber != 10) && (secondThrowNumber + thirdThrowNumber > 10))
                        return Error($"Third throw must be a number from 0 - {10 - firstThrowNumber}");
                }
            }

            return Success();
        }

        private InputValidatorResult Success()
        {
            return new InputValidatorResult(true);
        }

        private InputValidatorResult Error(string errorMessage)
        {
            return new InputValidatorResult(false, errorMessage);
        }
    }
}