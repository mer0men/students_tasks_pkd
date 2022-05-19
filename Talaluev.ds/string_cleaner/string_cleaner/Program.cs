using System;

namespace fefu;

public class Char
{
    public static bool IsEng(char c)
    {
        if (c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z')
        {
            return true;
        }
        return false;
    }
    public static bool IsRus(char c)
    {
        if (c >= 'А' && c <= 'Я' || c >= 'а' && c <= 'я')
        {
            return true;
        }
        return false;
    }
    public static bool IsDigit(char c)
    {
        if (c >= '0' && c <= '9')
        {
            return true;
        }
        return false;
    }
}
public class StringCleaner
{
    public bool Eng = false;
    public bool Rus = false;
    public bool Nums = false;
    public string WhiteList = "";
    public string BlackList = "";

    public StringCleaner(bool Eng, bool Rus, bool Nums, string WhiteList, string BlackList)
    {
        this.Eng = Eng;
        this.Rus = Rus;
        this.Nums = Nums;
        this.WhiteList = WhiteList;
        this.BlackList = BlackList;
    }
    public string Clean(string Str)
    {

        string StrRez = "";
        Str = Str.Trim();
        for (int i = 0; i < Str.Length; i++)
        {
            char c = Str[i];
            if (c == ' ')
            {
                if (StrRez == "")
                {

                }
                else if (StrRez[StrRez.Length - 1] != ' ')
                {
                    StrRez += ' ';
                }
                continue;
            }
            if (this.BlackList != "")
            {
                if (this.BlackList.Contains(c))
                {
                    continue;
                }
            }
            if (this.WhiteList != "")
            {
                if (this.WhiteList.Contains(c))
                {
                    StrRez += c;
                    continue;
                }
            }
            if (this.Rus)
            {
                if (Char.IsRus(c))
                {
                    StrRez += c;
                    continue;
                }
            }
            if (this.Eng)
            {
                if (Char.IsEng(c))
                {
                    StrRez += c;
                    continue;
                }
            }
            if (this.Nums)
            {
                if (Char.IsDigit(c))
                {
                    StrRez += c;
                    continue;
                }
            }
        }
        if (StrRez[StrRez.Length - 1] == ' ')
        {
            StrRez = StrRez.Remove(StrRez.Length - 1, 1);
        }
        return StrRez;
    }
}
class MainClass
{
    public static void Main()
    {
        StringCleaner stringCleaner = new StringCleaner(true, true, true, "", "");
        string Str = "!#";
        Console.WriteLine(stringCleaner.Clean(Str));
    }
}
