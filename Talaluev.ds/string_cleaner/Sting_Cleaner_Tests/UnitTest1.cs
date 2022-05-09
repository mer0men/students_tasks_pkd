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
            String_Cleaner rule = new String_Cleaner(true, false, true, "!,<>()");
            string str = "аFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11111111111111111111111111111111";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "а");
        }

        [TestMethod]
        public void Test2()
        {
            String_Cleaner rule = new String_Cleaner(false, true, false, "");
            string str = "             my father        like банан     20    123";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "my father like 20 123");
        }
        [TestMethod]
        public void Test3()
        {
            String_Cleaner rule = new String_Cleaner(true, true, true, "");
            string str = "          <>!/-      html file is not включен в работу мозга?     ";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "<>!/- ?");
        }
        [TestMethod]
        public void Test4()
        {
            String_Cleaner rule = new String_Cleaner(false, false, true, "<>!.?/");
            string str = "20 рублей за <булку      хлеба?> у тебя Sovest' есть?";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "рублей за булку хлеба у тебя Sovest' есть");
        }
        [TestMethod]
        public void Test5()
        {
            String_Cleaner rule = new String_Cleaner(false, true, false, "");
            string str = "              My sister фвадол лаыфв    шаывафыдвлао";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "My sister");
        }
        [TestMethod]
        public void Test6()
        {
            String_Cleaner rule = new String_Cleaner(false, true, false, "<>}{!@#)");
            string str = "index html <h1>Я са             йт<h1> {who кто}                 ";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "index html h1 h1 who");
        }
        [TestMethod]
        public void Test7()
        {
            String_Cleaner rule = new String_Cleaner(true, false, true, "");
            string str = "111111111111111111111111 1  1  1  1   1  1  1 1 1  1 1 1 OPOIPOIOIPOIPOIOIP fasdlkjjljfsa      Я узбек                   ";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "Я узбек");
        }
        [TestMethod]
        public void Test8()
        {
            String_Cleaner rule = new String_Cleaner(true, true, true, "");
            string str = "POEIOZDJKFD РОЛРУЛОРАЛОРФЫЛОВРД ЛО ФЫЛДО Ф  ДЫЛВОФД 19283 12312  31 2 12 3ЗЮБЮp{}<>?";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "{}<>?");
        }
        [TestMethod]
        public void Test9()
        {
            String_Cleaner rule = new String_Cleaner(false, false, true, "");
            string str = "      123123841-29-0192-42-401824901249012841          Nice              играешь 12312 >                      ";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "---- Nice играешь >");
        }
        [TestMethod]
        public void Test10()
        {
            String_Cleaner rule = new String_Cleaner(false, false, false, "");
            string str = "Ia igral v dotu 2 Женя спит ему все нипочем 30 бананов <>:!@#";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "Ia igral v dotu 2 Женя спит ему все нипочем 30 бананов <>:!@#");
        }
        [TestMethod]
        public void Test11()
        {
            String_Cleaner rule = new String_Cleaner(true, true, false, "");
            string str = "IA fasjdl              asdfl      j       asd f оаыдфлвоа д  фыв о фыд влао  дфыов дало/'123 <> / ' ] [ p121213121";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "/'123 <> / ' ] [ 121213121");
        }
        [TestMethod]
        public void Test12()
        {
            String_Cleaner rule = new String_Cleaner(true, false, true, "");
            string str = "dasfdasfaskdlfjskadjfklasjdfhasgdkjfgsjdfdshbfsybadtfuysgadyfgsnadgfhsagdkfhasdyf          fsadgfashdg f          asdhgfjsadgf              лорыфлвоарыфловпа ырпвоаыпфв нгпа ыфнгвпафырва лоыфвалоыпва ынвп а                     пфыоваофвы п                   31231231423hfj234213h4fhjfhf1234ghfjhf2134fhj";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "лорыфлвоарыфловпа ырпвоаыпфв нгпа ыфнгвпафырва лоыфвалоыпва ынвп а пфыоваофвы п");
        }
        [TestMethod]
        public void Test13()
        {
            String_Cleaner rule = new String_Cleaner(true, false, true, "");
            string str = "                 123 12         asdf              qeruoi        hkja            123   897  00 --- --- --- /' /' /' /'][LJLKJLKASD";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "--- --- --- /' /' /' /'][");
        }
        [TestMethod]
        public void Test14()
        {
            String_Cleaner rule = new String_Cleaner(false, false, true, "");
            string str = "раз два три четы            ре пять вы шел zaichik pogulat' 123        123          312        3123123             89765";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "раз два три четы ре пять вы шел zaichik pogulat'");
        }
        [TestMethod]
        public void Test15()
        {
            String_Cleaner rule = new String_Cleaner(true, false, true, "");
            string str = "                                  только            русский              язык                        1231          312        qwjlkfjas           qwe           1231           fjkaslj fla ";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "только русский язык");
        }
        [TestMethod]
        public void Test16()
        {
            String_Cleaner rule = new String_Cleaner(false, true, true, "");
            string str = "                          only        english             language                    аждлыофв длдлыова дло  213         олрлофвыр алыорв лад                 ";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "only english language");
        }
        [TestMethod]
        public void Test17()
        {
            String_Cleaner rule = new String_Cleaner(true, true, false, "");
            string str = "   ыфвадл оыфдл  длфыова дофы дло фыдвлао                  123                  123                312            123    долфыв аолдфыо длао        длыфо дао          дылов адф ";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "123 123 312 123");
        }
        [TestMethod]
        public void Test18()
        {
            String_Cleaner rule = new String_Cleaner(false, false, true, "./'[]руский");
            string str = "  /'[]        english русский язык крутой       . /'[]      ";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "english язы то");
        }
        [TestMethod]
        public void Test19()
        {
            String_Cleaner rule = new String_Cleaner(false, false, false, "абвгдabcdefg");
            string str = "       123    абвгдеёжз abcdefgklmnopq                   1             2               3       ";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "123 еёжз klmnopq 1 2 3");
        }
        [TestMethod]
        public void Test20()
        {
            String_Cleaner rule = new String_Cleaner(false, false, false, "<>/'[123");
            string str = "12345678910 sad language опять за дело 20 тест";
            string str1 = String_Cleaner.Clean(str, rule);
            Assert.AreEqual(str1, "4567890 sad language опять за дело 0 тест");
        }
    }
}