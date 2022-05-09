using System;

namespace fefu;

public class String_Cleaner
{
    public bool eng = false;
    public bool rus = false;
    public bool nums = false;
    public string black_list = "";

    public String_Cleaner(bool eng,bool rus,bool nums,string black_list)
    {
        this.eng = eng;
        this.rus = rus;
        this.nums = nums;
        this.black_list = black_list;
    }
     public static string Clean(string str, String_Cleaner rule)
    {
        string str_res = "";
        str = str.Trim();
        for (int i = 0; i < str.Length; i++)
        {
            char c = str[i];
            if(c == ' ')
            {
                if(str_res == "")
                {

                }
                else if (str_res[str_res.Length - 1] != ' ')
                {
                    str_res += ' ';
                }
                continue;
            }
            if (rule.black_list != "")
            {
                if (rule.black_list.Contains(c))
                {
                    continue;
                }
            }
            if (rule.rus)
            {
                if (c >= 'А' && c <= 'Я' || c >= 'а' && c <= 'я')
                {
                    continue;
                }
            }
            if (rule.eng)
            {
                if (c >= 'A' && c <= 'Z' || c>= 'a' && c<= 'z')
                {
                    continue;
                }
            }
            if (rule.nums)
            {
                if (char.IsDigit(c))
                {
                    continue;
                }
            }
            str_res += c;
        }
        if (str_res[str_res.Length-1] == ' ')
        {
            str_res = str_res.Remove(str_res.Length - 1, 1);
        }
        return str_res;
    }
}
class MainClass
{
    public static void Main()
    {
    }
}
