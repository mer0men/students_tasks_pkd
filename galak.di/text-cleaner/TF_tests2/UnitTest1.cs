using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace text_cleaner
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TextFormatter tf = new TextFormatter(false, false, false, "", "");
            string actual = tf.format("test тес");
            string expected = "";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod2()
        {
            TextFormatter tf = new TextFormatter(true, false, false, "", "");
            string actual = tf.format("   test тест   ");
            string expected = "test";
            Assert.AreEqual(expected, actual);
        }
    }
}
