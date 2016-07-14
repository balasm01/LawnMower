using LawnMower;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LawnMowerTests
{
    [TestClass]
    public class LawnMowerTest
    {
        private const string LawnInput = "5 5";
        private const string MowerInput = "1 2 n";
        private ILawnMower LawnMower { get; set; }

        [TestInitialize]
        public void SetUpTest()
        {
            var container = new UnityContainer();
            container.RegisterType<IValidationHelper, ValidationHelper>();
            container.RegisterType<IReader, Reader>();
            container.RegisterType<IInputHelper, InputHelper>();
            container.RegisterType<ILawnMower, LawnMower.LawnMower>();
            LawnMower = container.Resolve<ILawnMower>();
        }

        [TestMethod]
        public void Ensure_Returns_Lawn_For_Valid_Input()
        {
            var lawn = LawnMower.CreateLawn(LawnInput);
            Assert.AreEqual(lawn.ToString(), LawnInput);
        }

        [TestMethod]
        public void Ensure_Returns_Mower_For_Valid_Input()
        {
            var lawn = LawnMower.CreateLawn(LawnInput);
            var mower = LawnMower.CreateMower(MowerInput, lawn);
            Assert.AreEqual(mower.ToString(), "1 2 N");
        }
    }
}