
namespace BowlingScoreCalculator
{
    public class NonTenthFrame : Frame
    {
        public bool IsStrike
        {
            get
            {
                return (FirstThrowNumberOfPins == 10);
            }
        }

        public bool IsSpare
        {
            get
            {
                return (FirstThrowNumberOfPins != 10 && (FirstThrowNumberOfPins + SecondThrowNumberOfPins == 10));
            }
        }

        public NonTenthFrame(int? firstThrowNumberOfPins = null, int? secondThrowNumberOfPins = null)
        {
            FirstThrowNumberOfPins = firstThrowNumberOfPins;
            SecondThrowNumberOfPins = secondThrowNumberOfPins;
        }
    }
}
