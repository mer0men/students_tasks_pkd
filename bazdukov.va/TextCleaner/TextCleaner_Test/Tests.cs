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
            string result = cleaner.FormatString(source);
            Assert.AreEqual(result,target);
        }

        [Test]
        public void Test2()
        {
            TextFormatter cleaner = new TextFormatter(true,false,true);
            string source = "Hello друг";
            string target = "друг";
            string result = cleaner.FormatString(source);
            Assert.AreEqual(target,result);
        }
        
        [Test]
        public void Test3()
        {
            TextFormatter cleaner = new TextFormatter(false,true,true);
            string source = "zero is 0 или ноль это 0";
            string target = "0 или ноль это 0";
            string result = cleaner.FormatString(source);
            Assert.AreEqual(target,result);
        }
        
        [Test]
        public void Test4()
        {
            TextFormatter cleaner = new TextFormatter(false,false,false);
            string source = "    Hello    ";
            string target = "";
            string result = cleaner.FormatString(source);
            Assert.AreEqual(target,result);
        }
        [Test]
        public void Test5()
        {
            TextFormatter cleaner = new TextFormatter(true,false,true);
            string source = "  Space  Пробел  0123   ";
            string target = "Space 0123";
            string result = cleaner.FormatString(source);
            Assert.AreEqual(target,result);
        }
        [Test]
        public void Test6()
        {
            TextFormatter cleaner = new TextFormatter(true,false,true);
            string source = "";
            string target = "";
            string result = cleaner.FormatString(source);
            Assert.AreEqual(target,result);
        }
        
        [Test]
        public void Test7()
        {
            TextFormatter cleaner = new TextFormatter(false,true,false);
            string source = "lorem0   текст рыба";
            string target = "текст рыба";
            string result = cleaner.FormatString(source);
            Assert.AreEqual(target,result);
        }
        
        [Test]
        public void Test8()
        {
            TextFormatter cleaner = new TextFormatter(false,true,false);
            string source = "strоkа";
            string target = "strk";
            string result = cleaner.FormatString(source);
            Assert.AreEqual(target,result);
        }
        
        [Test]
        public void Test9()
        {
            TextFormatter cleaner = new TextFormatter(false,true,false);
            string source = "00 00 00";
            string target = "";
            string result = cleaner.FormatString(source);
            Assert.AreEqual(target,result);
        }
        
        [Test]
        public void Test10()
        {
            TextFormatter cleaner = new TextFormatter(true,true,true);
            string source = "arr0имя1";
            string target = "arr0имя1";
            string result = cleaner.FormatString(source);
            Assert.AreEqual(target,result);
        }
    }
}