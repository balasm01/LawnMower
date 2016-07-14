using LawnMower;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LawnMowerTests
{
    [TestClass]
    public class ValidationTests
    {
        private const string NegativeLawnInput = "-1 -1";
        private const string AlphaLawnInput = "allkasd asdllk asd";
        private const string InvalidMowerPosition = "121 31 n 12";
        private const string ValidMowerPosition = "121 31 n";
        private const string InvalidMowerParam = "lasd ads 11";
        private const string ValidMowerInstruction = "lrrmmmmm";
        private readonly IValidationHelper _validationHelper = new ValidationHelper();
        //Though not ideal using multiple asserts to avoid creating a lot of test methods
        [TestMethod]
        public void Ensure_Validation_Of_Input_Parameters_For_Lawn()
        {
            Assert.AreEqual(_validationHelper.IsValidLawnParam(NegativeLawnInput), false);
            Assert.AreEqual(_validationHelper.IsValidLawnParam(AlphaLawnInput), false);
        }

        [TestMethod]
        public void Ensure_Validation_Of_Input_Parameters_For_Mower()
        {
            Assert.AreEqual(_validationHelper.IsValidMowerParam(InvalidMowerPosition), false);
            Assert.AreEqual(_validationHelper.IsValidMowerParam(ValidMowerPosition), true);
        }

        [TestMethod]
        public void Ensure_Validation_Of_Input_Parameters_For_Mowing()
        {
            Assert.AreEqual(_validationHelper.IsValidMowerInstruction(InvalidMowerParam), false);
            Assert.AreEqual(_validationHelper.IsValidMowerInstruction(ValidMowerInstruction), true);
        }
    }
}