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
        [TestMethod]
        public void TestMethod3()
        {
            TextFormatter tf = new TextFormatter(true, true, true, "", "");
            string actual = tf.format("   test тест   ");
            string expected = "test тест";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod4()
        {
            TextFormatter tf = new TextFormatter(true, true, false, "0", "") ;
            string actual = tf.format("   test тест   0123  ");
            string expected = "test тест 0";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod5()
        {
            TextFormatter tf = new TextFormatter(true, true, false, "", "");
            string actual = tf.format(" ");
            string expected = "";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod6()
        {
            TextFormatter tf = new TextFormatter(false, false, false, "12", "");
            string actual = tf.format("    test 1234   тест");
            string expected = "12";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod7()
        {
            TextFormatter tf = new TextFormatter(true, true, true, "123", "");
            string actual = tf.format("    test 1234   тест           ");
            string expected = "test 1234 тест";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod8()
        {
            TextFormatter tf = new TextFormatter(true, true, false, "", "");
            string actual = tf.format("0123456789");
            string expected = "";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod9()
        {
            TextFormatter tf = new TextFormatter(false, true, false, "", "");
            string actual = tf.format("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaБ");
            string expected = "Б";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod10()
        {
            TextFormatter tf = new TextFormatter(false, false, false, "test", "");
            string actual = tf.format("     test ");
            string expected = "test";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod11()
        {
            TextFormatter tf = new TextFormatter(false, true, true, "a", "");
            string actual = tf.format("aaabbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccca");
            string expected = "aaaa";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod12()
        {
            TextFormatter tf = new TextFormatter(false, true, true, "a", "");
            string actual = tf.format("aaabbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccТЕСТccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccca");
            string expected = "aaaТЕСТa";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod13()
        {
            TextFormatter tf = new TextFormatter(false, true, true, "a", "");
            string actual = tf.format("aaabbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccТЕСТcccccccccccccccccccc0c1ccc2cccc3ccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccca");
            string expected = "aaaТЕСТ0123a";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod14()
        {
            TextFormatter tf = new TextFormatter(false, false, false, "", "");
            string actual = tf.format("!.,?");
            string expected = "!.,?";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod15()
        {
            TextFormatter tf = new TextFormatter(false, false, false, "", "");
            string actual = tf.format("úøä");
            string expected = "úøä";
            Assert.AreEqual(expected, actual);
        }
    }
}
