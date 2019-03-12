
namespace BowlingScoreCalculator
{
    public class TenthFrame : Frame
    {
        public int? ThirdThrowNumberOfPins { get; set; }

        public bool IsFirstThrowStrike
        {
            get
            {
                return (FirstThrowNumberOfPins == 10);
            }
        }

        public bool IsSecondThrowStrike
        {
            get
            {
                return (IsFirstThrowStrike && SecondThrowNumberOfPins == 10);
            }
        }

        public bool IsSecondThrowSpare
        {
            get
            {
                return (FirstThrowNumberOfPins != 10 && (FirstThrowNumberOfPins + SecondThrowNumberOfPins == 10));
            }
        }

        public TenthFrame(int? firstThrowNumberOfPins = null, int? secondThrowNumberOfPins = null, int? thirdThrowNumberOfPins = null)
        {
            FirstThrowNumberOfPins = firstThrowNumberOfPins;
            SecondThrowNumberOfPins = secondThrowNumberOfPins;
            ThirdThrowNumberOfPins = thirdThrowNumberOfPins;
        }
    }
}
