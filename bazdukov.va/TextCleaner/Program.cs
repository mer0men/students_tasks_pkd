using System.Security;
using System.Text;
using System.Xml.Schema;

namespace TextCleaner
{
    public class TextFormatter
    {
        public TextFormatter(bool _eng, bool _rus, bool _dig)
        {
            Config config = new Config(_eng,_rus,_dig);
        }
        private struct Config
        {
            private bool eng;
            private bool rus;
            private bool dig;

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
                if (elem == ' ') newString.Append(elem);
                if (IsEnglish(elem)) newString.Append(elem);
                if (IsRussian(elem)) newString.Append(elem);
                if (IsDigital(elem)) newString.Append(elem);
            }

            if (newString[0] == ' ') newString.Remove(1, 0);
            if (newString[newString.Length - 1] == ' ') newString.Remove(1, newString.Length - 1);
            return newString.ToString();
        }
        
        static  void Main() {}
    }
}