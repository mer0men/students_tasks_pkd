using System;
using System.Text;
using System.Diagnostics;

namespace fefu
{
    internal class RubbishEraser
    {
        public class MainClass
        {
            public struct config
            {
                public config(bool tempEng, bool tempRus, bool tempDig, string tempWhitelist, string tempBlacklist)
                {
                    eng = tempEng;
                    rus = tempRus;
                    dig = tempDig;
                    whiteList = tempWhitelist;
                    blackList = tempBlacklist;
                }

                public bool eng;
                public bool rus;
                public bool dig;
                public string whiteList;
                public string blackList;
            }

            private static config Dictionary;

            private List <char> english = new List <char> () {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                                                              'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                                                              'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                                                              'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

            private List <char> russian = new List <char> () {'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й',
                                                              'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф',
                                                              'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я',
                                                              'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й',
                                                              'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф',
                                                              'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'};

            private List <char> digits = new List <char> () {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            private List <char> dict = new List <char> ();
            private List<char> dictBlack = new List<char>();
            public MainClass(bool eng, bool rus, bool dig, string whiteList, string blackList)
            {
                Dictionary = new config(eng, rus, dig, whiteList, blackList);
                if (Dictionary.eng)
                {
                    dict.AddRange(english);
                }
                if (Dictionary.rus)
                {
                    dict.AddRange(russian);
                }
                if (Dictionary.dig)
                {
                    dict.AddRange(digits);
                }
                if (Dictionary.whiteList != "")
                {
                    dict.AddRange(Dictionary.whiteList);
                }
                if (Dictionary.blackList != "")
                {
                    dictBlack.AddRange(Dictionary.blackList);
                }
            }

            public string SB(string input)
            {
                bool whitespace = false;
                input.Trim();
                StringBuilder sb = new StringBuilder();
                foreach (char c in input)
                {
                    if (dictBlack.Contains(c))
                    {
                        continue;
                    }
                    if (char.IsWhiteSpace(c) && !whitespace)
                    {
                        sb.Append(c);
                        whitespace = true;
                    }
                    else if (dict.Contains(c))
                    {
                        sb.Append(c);
                        whitespace = false;
                    }
                        
                }
                return sb.ToString().Trim();
            }
            public string checkEmpty(string checker)
            {
                string temp;
                temp = SB(checker);
                if (temp == "")
                {
                    temp = "all characters were rubbish";
                }
                else if (temp != "")
                {
                    temp = "";
                }
                return temp;
            }
        }
        public static void Main()
        {
            /*Stopwatch stopwatch = new Stopwatch();

            MainClass f = new MainClass(true, false, false, "!?");
            string input;
            input = Console.ReadLine();
            stopwatch.Start();
            Console.WriteLine($"amount of characters: {input.Length}\ninput: {input}\noutput: {f.SB(input)}{f.checkEmpty(input)}");
            stopwatch.Stop();
            

            Console.WriteLine("running time: " + stopwatch.ElapsedMilliseconds + "ms");*/
            Test.runTest();
        }
    }
}