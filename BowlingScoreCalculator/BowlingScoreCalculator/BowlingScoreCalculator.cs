using System.Collections.Generic;
using System.Linq;

namespace BowlingScoreCalculator
{
    public class BowlingScoreCalculator
    {
        public List<int> GetFrameScores(List<Frame> frames)
        {
            var frameScores = new List<int>();

            for (int frameIndex = 0; frameIndex < frames.Count(); frameIndex++)
            {
                int currentFrameScore = 0;

                if (frames[frameIndex] is TenthFrame)
                {
                    var currentFrame = (TenthFrame)frames[frameIndex];

                    if (currentFrame.IsFirstThrowStrike)
                    {
                        // get the next two throws' scores for the first throw's score
                        int firstThrowScore = (10 + currentFrame.SecondThrowNumberOfPins.Value + currentFrame.ThirdThrowNumberOfPins.Value);
                        currentFrameScore += firstThrowScore;
                    }
                    else if (currentFrame.IsSecondThrowSpare)
                    {
                        currentFrameScore += (10 + currentFrame.ThirdThrowNumberOfPins.Value);
                    }
                    else
                    {
                        currentFrameScore += (currentFrame.FirstThrowNumberOfPins.Value + currentFrame.SecondThrowNumberOfPins.Value);
                    }
                }
                else
                {
                    var currentFrame = (NonTenthFrame)frames[frameIndex];
                    if (currentFrame.IsStrike)
                    {
                        // try to get next two scores
                        if ((frameIndex + 1) < frames.Count())
                        {
                            Frame nextFrame = frames[frameIndex + 1];
                            int nextScore = nextFrame.FirstThrowNumberOfPins.Value;
                            int scoreAfterNext = 0;

                            // if it was an open frame or spare, use the second throw as the second score, 
                            // otherwise try to grab the frame after
                            if (nextFrame.SecondThrowNumberOfPins != null)
                            {
                                scoreAfterNext = nextFrame.SecondThrowNumberOfPins.Value;
                            }
                            else if ((frameIndex + 2) < frames.Count())
                            {
                                Frame frameAfterNext = frames[frameIndex + 2];
                                scoreAfterNext = frameAfterNext.FirstThrowNumberOfPins.Value;
                            }

                            currentFrameScore = (10 + nextScore + scoreAfterNext);
                        }
                        else
                        {
                            currentFrameScore = 10;
                        }
                    }
                    else if (currentFrame.IsSpare)
                    {
                        // try to get next score
                        if ((frameIndex + 1) < frames.Count())
                        {
                            Frame nextFrame = frames[frameIndex + 1];
                            int nextScore = nextFrame.FirstThrowNumberOfPins.Value;
                            currentFrameScore = (10 + nextScore);
                        }
                        else
                        {
                            currentFrameScore = 10;
                        }
                    }
                    else
                    {
                        currentFrameScore = (currentFrame.FirstThrowNumberOfPins.Value + currentFrame.SecondThrowNumberOfPins.Value);
                    }
                }

                frameScores.Add(currentFrameScore);
            }

            return frameScores;
        }
    }
}
