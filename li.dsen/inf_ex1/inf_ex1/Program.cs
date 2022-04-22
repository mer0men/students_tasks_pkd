using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace inf_ex1
{
    internal class Program
    {
        class textFormat
        {
            public struct config
            {
                public config(bool _eng, bool _rus, bool _dig, string _whiteList)
                {
                    eng = _eng;
                    rus = _rus;
                    dig = _dig;
                    whiteList = _whiteList;
                }

                public bool eng;
                public bool rus;
                public bool dig;

                public string whiteList;
                // public string[] blackList;
            }

            private static config curConfig;

            private List<char> ENG = new List<char>() {'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p',
                'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l',
                'z', 'x', 'c', 'v', 'b', 'n', 'm'};
            
            private List<char> RUS = new List<char>() {'ё', 'й', 'ц' ,'у', 'к', 'е', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ъ',
                'ф', 'ы', 'в', 'а', 'п', 'р', 'о', 'л', 'д', 'ж', 'э',
                'я', 'ч', 'с', 'м', 'и', 'т', 'ь', 'б', 'ю'};
            
            private List<char> DIG = new List<char>() {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
            private List<char> FORMAT = new List<char>();
            public textFormat(bool eng, bool rus, bool dig, string whiteList)
            {
                curConfig = new config(eng, rus, dig, whiteList);
                if (curConfig.eng)
                {
                    FORMAT.AddRange(ENG);
                }
                if (curConfig.rus)
                {
                    FORMAT.AddRange(RUS);
                }
                if (curConfig.dig)
                {
                    FORMAT.AddRange(DIG);
                }
                if (curConfig.whiteList != "")
                {
                    FORMAT.AddRange(curConfig.whiteList);
                }
            }
            public string format(string input)
            {
                Console.WriteLine(input.Length);
                string temp = "";
                for (int i = 0; i < input.Length; i++)
                {
                    if (FORMAT.Contains(Char.Parse(input[i].ToString().ToLower()))) temp += input[i];
                }
                return temp;
            }
            
        }
        public static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            textFormat f = new textFormat(true, false, false, "!?");
            stopwatch.Start();
            Console.WriteLine(f.format("asfjbqwiwebvq;oiofc13f8c24jf0j23jc"));
            stopwatch.Stop();
            Console.WriteLine("ms: " + stopwatch.ElapsedMilliseconds);
        }
    }
}