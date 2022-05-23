using System;
using NUnit.Framework;
using TextCleaner;
namespace TextCleaner_Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            TextFormatter cleaner = new TextFormatter(true,true,true);
            string source = "asdf 0123 фыва";
            string target = "asdf 0123 фыва";
            Assert.AreEqual(source,target);
        }
    }
}