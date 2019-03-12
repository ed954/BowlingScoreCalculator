using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BowlingScoreCalculator.Tests
{
    [TestClass]
    public class InputValidatorTests
    {
        [TestMethod]
        public void InputValidator_GivenValidInputForNonTenthFrame_Succeeds()
        {
            string[] throws = { "4", "5" };

            var validator = new InputValidator();
            var sut = validator.ValidateNonTenthThrowInput(throws[0], throws[1]);

            Assert.IsTrue(sut.IsSuccessful);
        }

        [TestMethod]
        public void InputValidator_GivenBadInputForNonTenthFrame1_Fails()
        {
            string[] throws = { null };

            var validator = new InputValidator();
            var sut = validator.ValidateNonTenthThrowInput(throws[0]);

            Assert.IsFalse(sut.IsSuccessful);
        }


        [TestMethod]
        public void InputValidator_GivenBadInputForNonTenthFrame2_Fails()
        {
            string[] throws = { "-5" };

            var validator = new InputValidator();
            var sut = validator.ValidateNonTenthThrowInput(throws[0]);

            Assert.IsFalse(sut.IsSuccessful);
        }

        [TestMethod]
        public void InputValidator_GivenBadInputForNonTenthFrame3_Fails()
        {
            string[] throws = { "hello" };

            var validator = new InputValidator();
            var sut = validator.ValidateNonTenthThrowInput(throws[0]);

            Assert.IsFalse(sut.IsSuccessful);
        }

        [TestMethod]
        public void InputValidator_GivenBadInputForNonTenthFrame4_Fails()
        {
            string[] throws = { "6", "7" };

            var validator = new InputValidator();
            var sut = validator.ValidateNonTenthThrowInput(throws[0], throws[1]);

            Assert.IsFalse(sut.IsSuccessful);
        }

        [TestMethod]
        public void InputValidator_GivenBadInputForNonTenthFrame5_Fails()
        {
            string[] throws = { "10", "0" };

            var validator = new InputValidator();
            var sut = validator.ValidateNonTenthThrowInput(throws[0], throws[1]);

            Assert.IsFalse(sut.IsSuccessful);
        }

        [TestMethod]
        public void InputValidator_GivenBadInputForNonTenthFrame6_Fails()
        {
            string[] throws = { "10", "test" };

            var validator = new InputValidator();
            var sut = validator.ValidateNonTenthThrowInput(throws[0], throws[1]);

            Assert.IsFalse(sut.IsSuccessful);
        }

        [TestMethod]
        public void InputValidator_GivenValidInputForTenthFrame_Succeeds()
        {
            string[] throws = { "0", "10", "7" };

            var validator = new InputValidator();
            var sut = validator.ValidateTenthThrowInput(throws[0], throws[1], throws[2]);

            Assert.IsTrue(sut.IsSuccessful);
        }

        [TestMethod]
        public void InputValidator_GivenBadInputForTenthFrame1_Fails()
        {
            string[] throws = { "0", "10", "241" };

            var validator = new InputValidator();
            var sut = validator.ValidateTenthThrowInput(throws[0], throws[1], throws[2]);

            Assert.IsFalse(sut.IsSuccessful);
        }

        [TestMethod]
        public void InputValidator_GivenBadInputForTenthFrame2_Fails()
        {
            string[] throws = { "10", "4", "8" };

            var validator = new InputValidator();
            var sut = validator.ValidateTenthThrowInput(throws[0], throws[1], throws[2]);

            Assert.IsFalse(sut.IsSuccessful);
        }

        [TestMethod]
        public void InputValidator_GivenBadInputForTenthFrame3_Fails()
        {
            string[] throws = { "8", "4", "8" };

            var validator = new InputValidator();
            var sut = validator.ValidateTenthThrowInput(throws[0], throws[1], throws[2]);

            Assert.IsFalse(sut.IsSuccessful);
        }

        [TestMethod]
        public void InputValidator_GivenBadInputForTenthFrame4_Fails()
        {
            string[] throws = { "8", "2", "11" };

            var validator = new InputValidator();
            var sut = validator.ValidateTenthThrowInput(throws[0], throws[1], throws[2]);

            Assert.IsFalse(sut.IsSuccessful);
        }
    }
}
