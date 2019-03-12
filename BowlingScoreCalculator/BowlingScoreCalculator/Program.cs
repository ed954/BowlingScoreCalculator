using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingScoreCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bowling Score Calculator!");
            Console.WriteLine();

            List<Frame> frames = GetFrameScoresFromInput();
            var calculator = new BowlingScoreCalculator();
            List<int> frameScores = calculator.GetFrameScores(frames);

            Console.WriteLine();
            Console.WriteLine("Here are your scores as of each frame:");
            Console.WriteLine();
            int currentFrameNumber = 0;
            int totalScore = 0;
            foreach (var score in frameScores)
            {
                currentFrameNumber++;
                totalScore += score;
                Console.WriteLine($"Frame {currentFrameNumber}: {totalScore}");
            }
            Console.WriteLine();
            Console.WriteLine($"Your total score is: {frameScores.Sum()}");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static List<Frame> GetFrameScoresFromInput()
        {
            Console.WriteLine("For each frame, enter the number of pins knocked down and press the 'Enter' key. If you");
            Console.WriteLine("are entering scores for an incomplete game, when you have finished entering scores, ");
            Console.WriteLine("enter 'Done' and press the 'Enter' key. If you enter a score for the first throw, ");
            Console.WriteLine("but enter 'Done' for the second or third throw, the frame will not count.");
            Console.WriteLine();

            // read the scores for each frame
            var frames = new List<Frame>();
            bool hasFinishedEnteringScores = false;
            var validator = new InputValidator();

            for (int i = 1; i <= 10; i++)
            {
                if (hasFinishedEnteringScores)
                    break;

                if (i < 10)
                {
                    var currentFrame = new NonTenthFrame();

                    bool hasEnteredValidFirstThrow = false;

                    while (!hasEnteredValidFirstThrow)
                    {
                        Console.Write($"Frame {i},  Throw 1: ");
                        var enteredText = Console.ReadLine();
                        enteredText = enteredText.Trim();

                        if (enteredText.ToLower() == "done")
                        {
                            hasFinishedEnteringScores = true;
                            break;
                        }
                        else
                        {
                            var validationResult = validator.ValidateNonTenthThrowInput(enteredText);
                            if (!validationResult.IsSuccessful)
                            {
                                ShowInvalidInputMessage(validationResult.ErrorMessage);
                            }
                            else
                            {
                                hasEnteredValidFirstThrow = true;
                                currentFrame.FirstThrowNumberOfPins = Convert.ToInt32(enteredText);
                            }
                        }
                    }

                    if (hasFinishedEnteringScores)
                        break;

                    if (currentFrame.FirstThrowNumberOfPins == 10)
                    {
                        frames.Add(currentFrame);
                        continue;
                    }

                    bool hasEnteredValidSecondThrow = false;

                    while (!hasEnteredValidSecondThrow)
                    {
                        Console.Write($"          Throw 2: ");
                        var enteredText = Console.ReadLine();
                        enteredText = enteredText.Trim();

                        if (enteredText.ToLower() == "done")
                        {
                            hasFinishedEnteringScores = true;
                            break;
                        }
                        else
                        {
                            var validationResult = validator.ValidateNonTenthThrowInput(currentFrame.FirstThrowNumberOfPins.ToString(), enteredText);
                            if (!validationResult.IsSuccessful)
                            {
                                ShowInvalidInputMessage(validationResult.ErrorMessage);
                            }
                            else
                            {
                                hasEnteredValidSecondThrow = true;
                                currentFrame.SecondThrowNumberOfPins = Convert.ToInt32(enteredText);
                            }
                        }
                    }

                    if (hasFinishedEnteringScores)
                        break;

                    frames.Add(currentFrame);
                }
                else
                {
                    var currentFrame = new TenthFrame();

                    bool hasEnteredValidFirstThrow = false;

                    while (!hasEnteredValidFirstThrow)
                    {
                        Console.Write($"Frame {i}, Throw 1: ");
                        var enteredText = Console.ReadLine();
                        enteredText = enteredText.Trim();

                        if (enteredText.ToLower() == "done")
                        {
                            hasFinishedEnteringScores = true;
                            break;
                        }
                        else
                        {
                            var validationResult = validator.ValidateTenthThrowInput(enteredText);
                            if (!validationResult.IsSuccessful)
                            {
                                ShowInvalidInputMessage(validationResult.ErrorMessage);
                            }
                            else
                            {
                                hasEnteredValidFirstThrow = true;
                                currentFrame.FirstThrowNumberOfPins = Convert.ToInt32(enteredText);
                            }
                        }
                    }

                    if (hasFinishedEnteringScores)
                        break;

                    bool hasEnteredValidSecondThrow = false;

                    while (!hasEnteredValidSecondThrow)
                    {
                        Console.Write($"          Throw 2: ");
                        var enteredText = Console.ReadLine();
                        enteredText = enteredText.Trim();

                        if (enteredText.ToLower() == "done")
                        {
                            hasFinishedEnteringScores = true;
                            break;
                        }
                        else
                        {
                            var validationResult = validator.ValidateTenthThrowInput(currentFrame.FirstThrowNumberOfPins.ToString(), enteredText);
                            if (!validationResult.IsSuccessful)
                            {
                                ShowInvalidInputMessage(validationResult.ErrorMessage);
                            }
                            else
                            {
                                hasEnteredValidSecondThrow = true;
                                currentFrame.SecondThrowNumberOfPins = Convert.ToInt32(enteredText);
                            }
                        }
                    }

                    if (hasFinishedEnteringScores)
                        break;

                    if (currentFrame.IsFirstThrowStrike || currentFrame.IsSecondThrowStrike || currentFrame.IsSecondThrowSpare)
                    {
                        bool hasEnteredValidThirdThrow = false;

                        while (!hasEnteredValidThirdThrow)
                        {
                            Console.Write($"          Throw 3: ");
                            var enteredText = Console.ReadLine();
                            enteredText = enteredText.Trim();

                            if (enteredText.ToLower() == "done")
                            {
                                hasFinishedEnteringScores = true;
                                break;
                            }
                            else
                            {
                                var validationResult = validator.ValidateTenthThrowInput(currentFrame.FirstThrowNumberOfPins.ToString(),
                                    currentFrame.SecondThrowNumberOfPins.ToString(), enteredText);
                                if (!validationResult.IsSuccessful)
                                {
                                    ShowInvalidInputMessage(validationResult.ErrorMessage);
                                }
                                else
                                {
                                    hasEnteredValidThirdThrow = true;
                                    currentFrame.ThirdThrowNumberOfPins = Convert.ToInt32(enteredText);
                                }
                            }
                        }
                    }

                    frames.Add(currentFrame);
                }
            }

            return frames;
        }

        private static void ShowInvalidInputMessage(string errorMessage)
        {
            Console.WriteLine($"          Invalid input. {errorMessage}. Please try again.");
        }
    }
}
