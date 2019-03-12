using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BowlingScoreCalculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Calculator_GivenValidOpenFrames_Succeeds()
        {
            var frames = new List<Frame>
            {
                new NonTenthFrame(1, 5),
                new NonTenthFrame(6, 3),
                new NonTenthFrame(0, 2)
            };

            var calculator = new BowlingScoreCalculator();
            var sut = calculator.GetFrameScores(frames);

            Assert.AreEqual(17, sut.Sum());
        }

        [TestMethod]
        public void Calculator_GivenValidSpareAndOpenFrames_Succeeds()
        {
            var frames = new List<Frame>
            {
                new NonTenthFrame(4, 6),
                new NonTenthFrame(6, 3),
                new NonTenthFrame(0, 2)
            };

            var calculator = new BowlingScoreCalculator();
            var sut = calculator.GetFrameScores(frames);

            Assert.AreEqual(27, sut.Sum());
        }

        [TestMethod]
        public void Calculator_GivenValidStrikeAndOpenFrames_Succeeds()
        {
            var frames = new List<Frame>
            {
                new NonTenthFrame(10),
                new NonTenthFrame(6, 3),
                new NonTenthFrame(0, 2)
            };

            var calculator = new BowlingScoreCalculator();
            var sut = calculator.GetFrameScores(frames);

            Assert.AreEqual(30, sut.Sum());
        }

        [TestMethod]
        public void Calculator_GivenValidVariousFrames1_Succeeds()
        {
            var frames = new List<Frame>
            {
                new NonTenthFrame(10),
                new NonTenthFrame(6, 3),
                new NonTenthFrame(0, 2),
                new NonTenthFrame(2, 0),
                new NonTenthFrame(10),
                new NonTenthFrame(4, 2),
                new NonTenthFrame(4, 6),
                new NonTenthFrame(1, 0),
                new NonTenthFrame(9, 0)
            };

            var calculator = new BowlingScoreCalculator();
            var sut = calculator.GetFrameScores(frames);

            Assert.AreEqual(75, sut.Sum());
        }

        [TestMethod]
        public void Calculator_GivenValidVariousFrames2_Succeeds()
        {
            var frames = new List<Frame>
            {
                new NonTenthFrame(10),
                new NonTenthFrame(6, 3),
                new NonTenthFrame(0, 2),
                new NonTenthFrame(2, 3),
                new NonTenthFrame(5, 5),
                new NonTenthFrame(10),
                new NonTenthFrame(0, 6),
                new NonTenthFrame(8, 0),
                new NonTenthFrame(10),
                new TenthFrame(9, 0)
            };

            var calculator = new BowlingScoreCalculator();
            var sut = calculator.GetFrameScores(frames);

            Assert.AreEqual(113, sut.Sum());
        }

        [TestMethod]
        public void Calculator_GivenValidVariousFrames3_Succeeds()
        {
            var frames = new List<Frame>
            {
                new NonTenthFrame(10),
                new NonTenthFrame(6, 3),
                new NonTenthFrame(0, 2),
                new NonTenthFrame(2, 3),
                new NonTenthFrame(5, 5),
                new NonTenthFrame(10),
                new NonTenthFrame(0, 6),
                new NonTenthFrame(8, 0),
                new NonTenthFrame(10),
                new TenthFrame(10, 4, 0)
            };

            var calculator = new BowlingScoreCalculator();
            var sut = calculator.GetFrameScores(frames);

            Assert.AreEqual(123, sut.Sum());
        }

        [TestMethod]
        public void Calculator_GivenValidVariousFrames4_Succeeds()
        {
            var frames = new List<Frame>
            {
                new NonTenthFrame(10),
                new NonTenthFrame(6, 3),
                new NonTenthFrame(0, 2),
                new NonTenthFrame(2, 3),
                new NonTenthFrame(5, 5),
                new NonTenthFrame(10),
                new NonTenthFrame(0, 6),
                new NonTenthFrame(8, 0),
                new NonTenthFrame(10),
                new TenthFrame(10, 10, 6)
            };

            var calculator = new BowlingScoreCalculator();
            var sut = calculator.GetFrameScores(frames);

            Assert.AreEqual(141, sut.Sum());
        }

        [TestMethod]
        public void Calculator_GivenValidVariousFrames5_Succeeds()
        {
            var frames = new List<Frame>
            {
                new NonTenthFrame(10),
                new NonTenthFrame(6, 3),
                new NonTenthFrame(0, 2),
                new NonTenthFrame(2, 3),
                new NonTenthFrame(5, 5),
                new NonTenthFrame(10),
                new NonTenthFrame(0, 6),
                new NonTenthFrame(8, 0),
                new NonTenthFrame(10),
                new TenthFrame(4, 6, 9)
            };

            var calculator = new BowlingScoreCalculator();
            var sut = calculator.GetFrameScores(frames);

            Assert.AreEqual(124, sut.Sum());
        }

        [TestMethod]
        public void Calculator_GivenValidVariousFrames6_Succeeds()
        {
            var frames = new List<Frame>
            {
                new NonTenthFrame(10),
                new NonTenthFrame(6, 3),
                new NonTenthFrame(0, 2),
                new NonTenthFrame(2, 3),
                new NonTenthFrame(5, 5),
                new NonTenthFrame(10),
                new NonTenthFrame(0, 6),
                new NonTenthFrame(8, 0),
                new NonTenthFrame(10),
                new TenthFrame(10, 0, 7)
            };

            var calculator = new BowlingScoreCalculator();
            var sut = calculator.GetFrameScores(frames);

            Assert.AreEqual(122, sut.Sum());
        }

        [TestMethod]
        public void Calculator_GivenValidVariousFrames7_Succeeds()
        {
            var frames = new List<Frame>
            {
                new NonTenthFrame(10),
                new NonTenthFrame(6, 3),
                new NonTenthFrame(0, 2),
                new NonTenthFrame(2, 3),
                new NonTenthFrame(5, 5),
                new NonTenthFrame(10),
                new NonTenthFrame(0, 6),
                new NonTenthFrame(8, 0),
                new NonTenthFrame(10),
                new TenthFrame(3, 7, 2)
            };

            var calculator = new BowlingScoreCalculator();
            var sut = calculator.GetFrameScores(frames);

            Assert.AreEqual(117, sut.Sum());
        }
    }
}
