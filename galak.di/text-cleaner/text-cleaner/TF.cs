﻿using System;
using System.Collections.Generic;
using System.Text;


namespace text_cleaner
{
    public class TextFormatter
    {
        public bool Eng;
        public bool Rus;
        public bool Dig;
        public string AddWL = "";
        public string AddBL = "";
        bool inserted = false;
        bool blacklisted = false;


        public TextFormatter(bool eng, bool rus, bool dig, string AWL, string ABL)
        {
            Eng = eng;
            Rus = rus;
            Dig = dig;
            AddWL = AWL;
            AddBL = ABL;
        }

        bool IsEngChar(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }

        bool IsRusChar(char c)
        {
            return c >= 'А' && c <= 'я';
        }
        bool IsDig(char c)
        {
            return c >= '0' && c <= '9';
        }

        public string format(string text)
        {
            char[] n = new char[10000000];
            StringBuilder sb = new StringBuilder();
            int i_n = 0;
            HashSet<char> WL = new HashSet<char>(AddWL);
            WL.Remove(' ');
            for (int i = 0; i < text.Length; i++)
            {
                foreach (char c in WL)
                {
                    if (c == text[i] && !blacklisted)
                    {
                        sb.Append(c);
                        inserted = true;
                    }
                }
                if (!inserted && !blacklisted)
                {
                    if (!IsDig(text[i]) && !IsEngChar(text[i]) && !IsRusChar(text[i]) && text[i] != ' ')
                    {
                        sb.Append(text[i]);
                    }
                    if (Eng)
                    {
                        if (IsEngChar(text[i]))
                        {
                            sb.Append(text[i]);
                        }
                    }
                    if (Rus)
                    {
                        if (IsRusChar(text[i]))
                        {
                            sb.Append(text[i]);
                        }
                    }
                    if (Dig)
                    {
                        if (IsDig(text[i]))
                        {
                            sb.Append(text[i]);
                        }
                    }
                    if (text[i] == ' ')
                    {
                        if (i > 0)
                        {
                            if (text[i - 1] != ' ')
                            {
                                sb.Append(text[i]);
                            }
                        }
                    }
                }
                inserted = false;
                blacklisted = false;
            }
            if (sb.Length > 0)
            {
                try
                {
                    while (sb[sb.Length - 1] == ' ')
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    while (sb[0] == ' ')
                    {
                        sb.Remove(0, 1);
                    }
                }
                catch
                {

                }
            }
            return sb.ToString();
        }


        static void Main(string[] args)
        {
            /*TextFormatter tf = new TextFormatter(false, false, false, "", "");
            string actual = tf.format("test тес");
            string expected = "";*/


            TextFormatter TF = new TextFormatter(true, true, true, "", "");
            string x = System.IO.File.ReadAllText("input.txt");
            x = TF.format(x);
            //do not change
            TF.Eng = true;
            TF.Rus = true;
            TF.Dig = true;
            Console.WriteLine('"' + TF.format(x) + '"');
        }

    }
}