using LawnMower;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LawnMowerTests
{
    [TestClass]
    public class InputTest
    {
        private const string InputString = "Some random string";
        private IInputHelper InputHelper { get; set; }

        [TestInitialize]
        public void SetUpTest()
        {
            var container = new UnityContainer();
            container.RegisterType<IValidationHelper, ValidationHelper>();
            container.RegisterType<IReader, Reader>();
            container.RegisterType<IInputHelper, InputHelper>();

            var mockValidator = new Mock<IValidationHelper>();
            var mockReader = new Mock<IReader>();

            mockValidator.Setup(v => v.IsValidLawnParam(It.IsAny<string>())).Returns(true);
            mockValidator.Setup(v => v.IsValidMowerParam(It.IsAny<string>())).Returns(true);
            mockValidator.Setup(v => v.IsValidMowerInstruction(It.IsAny<string>())).Returns(true);
            mockReader.Setup(r => r.ReadInput()).Returns(InputString);

            var validator = mockValidator.Object;
            var reader = mockReader.Object;
            InputHelper = new InputHelper(validator, reader);
        }

        //Though not ideal using multiple asserts to avoid creating a lot of test methods
        [TestMethod]
        public void Ensure_Returns_String_For_Valid_Input()
        {
            var lawnInput = InputHelper.ReadLawnInput();
            Assert.AreEqual(lawnInput, InputString);
            Assert.AreEqual(InputHelper.ReadMowerInput(), InputString);
            Assert.AreEqual(InputHelper.ReadMowerInstructions(), InputString);
        }

        [TestMethod]
        public void Ensure_Entering_X_Exists_Code()
        {
            var mockValidator = new Mock<IValidationHelper>();
            var mockReader = new Mock<IReader>();

            mockValidator.Setup(v => v.IsValidMowerParam(It.IsAny<string>())).Returns(false);
            mockReader.Setup(r => r.ReadInput()).Returns("X");
            var inputHelper = new InputHelper(mockValidator.Object, mockReader.Object);
            Assert.AreEqual(inputHelper.ReadMowerInput(), "X");
        }
    }
}