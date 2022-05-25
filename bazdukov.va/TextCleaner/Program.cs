using System.Security;
using System.Text;
using System.Xml.Schema;

namespace TextCleaner
{
    public class TextFormatter
    {
        public TextFormatter(bool _eng, bool _rus, bool _dig)
        {
            eng = _eng;
            rus = _rus;
            dig = _dig;
        }
        private bool eng;
        private bool rus;
        private bool dig;
        
        bool IsRussian(char symbol)
        {
            return (symbol >= 'а' && symbol <= 'я') || (symbol >= 'А' && symbol <= 'Я');
        }
        bool IsEnglish(char symbol)
        {
            return (symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z');
        }
        bool IsDigital(char symbol)
        {
            return (symbol >= '0' && symbol <= '9');
        }
        
        public string FormatString(string sourceString)
        {
            if (sourceString == "") return "";
            StringBuilder newString = new StringBuilder();
            
            foreach (char elem in sourceString)
            {
                if (elem == ' ') newString.Append(elem);
                if (IsEnglish(elem) && eng) newString.Append(elem);
                if (IsRussian(elem) && rus) newString.Append(elem);
                if (IsDigital(elem) && dig) newString.Append(elem);
            }

            while (newString.ToString().Contains("  ")) newString.Replace("  ", " ");
            return newString.ToString().Trim(' ');
        }
        
        static  void Main() {}
    }
}