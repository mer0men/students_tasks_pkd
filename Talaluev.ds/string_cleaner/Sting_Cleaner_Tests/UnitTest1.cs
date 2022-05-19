using Microsoft.VisualStudio.TestTools.UnitTesting;
using fefu;
namespace Sting_Cleaner_Tests
{
    [TestClass]
    public class String_Cleaner_Test
    {
        [TestMethod]
        public void Test1()
        {
            StringCleaner stringCleaner = new StringCleaner(false, true, false, "", "");
            string Str = "�FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11111111111111111111111111111111";
            Assert.AreEqual(stringCleaner.Clean(Str), "�");
        }
        [TestMethod]
        public void Test2()
        {
            StringCleaner stringCleaner = new StringCleaner(true, false, false, "", "");
            string Str = "      English language is good ������� ���� ������  111111    ! !!!!!���";
            Assert.AreEqual(stringCleaner.Clean(Str), "English language is good");
        }
        [TestMethod]
        public void Test3()
        {
            StringCleaner stringCleaner = new StringCleaner(false, false, true, "", "");
            string Str = "      1234567890    fasdasd ������� <><]] 123 123  12 3";
            Assert.AreEqual(stringCleaner.Clean(Str), "1234567890 123 123 12 3");
        }
        [TestMethod]
        public void Test4()
        {
            StringCleaner stringCleaner = new StringCleaner(true, true, false, "<>?!", "");
            string Str = "                        <h1>                 Kaif                 <h1>            ����!!!!  123 12 321 31 ";
            Assert.AreEqual(stringCleaner.Clean(Str), "<h> Kaif <h> ����!!!!");
        }
        [TestMethod]
        public void Test5()
        {
            StringCleaner stringCleaner = new StringCleaner(true, true, false, "?][}{", "������");
            string Str = "                )))))))((( � ������� angliski 1231231231";
            Assert.AreEqual(stringCleaner.Clean(Str), "� angliski");
        }
        [TestMethod]
        public void Test6()
        {
            StringCleaner stringCleaner = new StringCleaner(false, false, false, "!?><,.", "");
            string Str = "<H1> 12123123? <H1> ???!!..,";
            Assert.AreEqual(stringCleaner.Clean(Str), "<> ? <> ???!!..,");
        }
        [TestMethod]
        public void Test7()
        {
            StringCleaner stringCleaner = new StringCleaner(false, true, true, "!?", "123");
            string Str = "    1234567890 >?<    ����������  fasd fsad fas df    ";
            Assert.AreEqual(stringCleaner.Clean(Str), "4567890 ? ����������");
        }
        [TestMethod]
        public void Test8()
        {
            StringCleaner stringCleaner = new StringCleaner(true, true, true, "", "");
            string Str = "faskdjf lkjs dlfkj alsjdf l salkdj flasjdlk j  sjdalfjlasjdlfkj fjaskldjf <><?><!@#>?<?!@<#?!><@#? ?>@#< !?@<?# <!@? <#!?>@<   #!@ #<!  fdas fsad f! @#!>?<@ #!>< ?>";
            Assert.AreEqual(stringCleaner.Clean(Str), "faskdjf lkjs dlfkj alsjdf l salkdj flasjdlk j sjdalfjlasjdlfkj fjaskldjf fdas fsad f");
        }
        [TestMethod]
        public void Test9()
        {
            StringCleaner stringCleaner = new StringCleaner(false, true, false, "?!", "?!");
            string Str = "kfjsadl;fj kls ajdf;l jsdlk jfslka jdfl jasd;lkjf !?!??!??!?!?!?!?!? ����� !@!@#?!?>?#>!@?#>#?<!@?>< fsa dfsdf asdf sd ";
            Assert.AreEqual(stringCleaner.Clean(Str), "�����");
        }
        [TestMethod]
        public void Test10()
        {
            StringCleaner stringCleaner = new StringCleaner(false, true, true, "", "");
            string Str = "sad fsla djflkj sadl;kjf lk123           312 3 312312 312 312 3 ������ ������� ������ ������ ������  >?!>?> @! #!@?> ?#!>@? >?> @!#jfhadskh fjksh h kjshdf                 kl asd           312 3123 12";
            Assert.AreEqual(stringCleaner.Clean(Str), "123 312 3 312312 312 312 3 ������ ������� ������ ������ ������ 312 3123 12");
        }
    }
}