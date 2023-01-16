using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareTextsUWP.Classes
{
    internal class FindAndReplaceSubString
    {
        // properties
        private string Input { get; set; }

        private string Find { get; set; }

        private string Replace { get; set; }

        public string CorrectedString
        {
            get
            {
                return ReplaceString(Input, Find, Replace);
            }
        }

        // constructors
        public FindAndReplaceSubString(string input, string find, string replace)
        {
            Input = input;
            Find = find;
            Replace = replace;
        }

        // methods		
        private string ReplaceString(string input, string find, string replace)
        {
            //if (input.Length != 0)
            if (input.Length > 0 && find.Length > 0 )
            {
                string tmpInput = FixNewLine(input);
                string tmpFind = FixFindReplaceStrings(find);
                string tmpReplace = FixFindReplaceStrings(replace);

                return tmpInput.Replace(tmpFind, tmpReplace);
            }
            else
            {
                return input;
            }
        }

        private string FixNewLine(string input)
        {
            string tmp = input;
            tmp = tmp.Replace("\r\n", "\n");
            tmp = tmp.Replace("\r", "\n");
            tmp = tmp.Replace("\n", Environment.NewLine);
            return tmp;
        }

        private string FixFindReplaceStrings(string stringToFix)
        {
            string tmp;

            // "Colon", "Comma", "Dot", "Newline", "Semicolon", "Space", "Tab"

            switch (stringToFix.ToUpper())
            {
                case "COLON":
                    tmp = ":";
                    break;
                case "COMMA":
                    tmp = ",";
                    break;
                case "DOT":
                    tmp = ".";
                    break;
                case "NEWLINE":
                    tmp = Environment.NewLine;
                    break;
                case "SEMICOLON":
                    tmp = ";";
                    break;
                case "SPACE":
                    tmp = " ";
                    break;
                case "TAB":
                    tmp = "\t";
                    break;
                default:
                    tmp = stringToFix;
                    break;
            }

            return tmp;
        }
    }
}
