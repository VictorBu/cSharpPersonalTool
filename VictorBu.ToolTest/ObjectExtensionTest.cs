using Microsoft.VisualStudio.TestTools.UnitTesting;
using VictorBu.Tool.Class;

namespace VictorBu.ToolTest
{
    [TestClass]
    public class ObjectExtensionTest
    {
        [TestMethod]
        public void Cast()
        {
            SourceClass source = new SourceClass()
            {
                Name = "User Name",
                Password = "User Password",
            };

            TargetClass target = source.Cast<TargetClass>();

            Assert.AreEqual(source.Name, target.Name);
        }

        [TestMethod]
        public void SetDefaultToProperties()
        {
            TestClass testClass = new TestClass();
           
            Assert.AreEqual(testClass.TestProperty, string.Empty);
        }
    }

    class SourceClass
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }

    class TargetClass
    {
        public string Name { get; set; }
    }

    class TestClass
    {
        public TestClass()
        {
            ObjectExtension.SetDefaultToProperties(this);
        }

        public string TestProperty { get; set; }
    }
}
