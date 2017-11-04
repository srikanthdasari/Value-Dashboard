using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dashboard.Core.Extensions;
using Dashboard.Mocks;

namespace Dashboard.Core.Tests
{
    [TestClass]
    public class BooleanExtensionsIfTrueTests
    {
        [TestMethod]
        public void IfTrue_WithFalse_DoNotCallAction()
        {
            false.IfTrue(() => Assert.Fail());
        }


        [TestMethod]
        public void IfTrue_WithTrue_CallAction()
        {
            var actionCalled = false;

            true.IfTrue(() => actionCalled = true);

            Assert.IsTrue(actionCalled);
        }


        [TestMethod]
        public void IfTrue_WithFalse_DoNotCallActionBool()
        {
            false.IfTrue(x => Assert.Fail());
        }


        [TestMethod]
        public void IfTrue_WithTrue_CallActionBool()
        {
            var actionCalled = false;

            true.IfTrue(x => actionCalled = x);

            Assert.IsTrue(actionCalled);
        }


        [TestMethod]
        public void IfTrue_WithFalse_DoNotCallFuncT()
        {
            MockClass1 result = false.IfTrue(x => { Assert.Fail(); return new MockClass1(); });
        }


        [TestMethod]
        public void IfTrue_WithTrue_CallFunctT()
        {
            MockClass1 result = true.IfTrue(x => new MockClass1());

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IfTrue_WithFalse_DoNotCallFunctT_ReturnDefaultT()
        {
            MockClass1 result = false.IfTrue(x => new MockClass1());

            Assert.IsTrue(result == default(MockClass1));
        }
    }



    [TestClass]
    public class BooleanExtensionsIfFalseTests
    {
        [TestMethod]
        public void IfFalse_WithTrue_DoNotCallAction()
        {
            true.IfFalse(() => Assert.Fail());
        }


        [TestMethod]
        public void IfFalse_WithFalse_CallAction()
        {
            var actionCalled = false;

            false.IfFalse(() => actionCalled = true);

            Assert.IsTrue(actionCalled);
        }


        [TestMethod]
        public void IfFalse_WithTrue_DoNotCallActionBool()
        {
            true.IfFalse(x => Assert.Fail());
        }


        [TestMethod]
        public void IfFalse_WithFalse_CallActionBool()
        {
            var actionCalled = true;

            false.IfFalse(x => actionCalled = x);

            Assert.IsFalse(actionCalled);
        }


        [TestMethod]
        public void IfFalse_WithTrue_DoNotCallFuncT()
        {
            MockClass1 result = true.IfFalse(x => { Assert.Fail(); return new MockClass1(); });
        }


        [TestMethod]
        public void IfFalse_WithFalse_CallFunctT()
        {
            MockClass1 result = false.IfFalse(x => new MockClass1());

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void IfFalse_WithTrue_CallFunctT_ReturnDefault()
        {
            MockClass1 result = true.IfFalse(x => new MockClass1());

            Assert.IsTrue(result == default(MockClass1));
        }
    }
}
