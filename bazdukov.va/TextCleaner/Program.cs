using System.Security;
using System.Text;
using System.Xml.Schema;

namespace TextCleaner
{
    internal class TextFormatter
    {
        
        public struct Config
        {
            public bool rus;
            public bool eng;
            public bool dig;

            public Config(bool _eng, bool _rus, bool _dig)
            {
                eng = _eng;
                rus = _rus;
                dig = _dig; 
            }
        }

        bool IsRussian(char symbol)
        {
            return (symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z');
        }
        bool IsEnglish(char symbol)
        {
            return (symbol >= 'а' && symbol <= 'я') || (symbol >= 'А' && symbol <= 'я');
        }
        bool IsDigital(char symbol)
        {
            return (symbol >= '0' && symbol <= '9');
        }
        public string FormatString(string sourceString)
        {
            StringBuilder newString = new StringBuilder();
            Config config = new Config();
            foreach (char elem in sourceString)
            {
                if (IsEnglish(elem)) newString.Append(elem);
                if (IsRussian(elem)) newString.Append(elem);
                if (IsDigital(elem)) newString.Append(elem);
            }
            return newString.ToString();
        }
    }
}