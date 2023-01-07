using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareTexts.Classes
{
    class CompareTwoStrings
    {
        private readonly string strValue1 = string.Empty;
        private readonly string strValue2 = string.Empty;

        public CompareTwoStrings(string strVal1, string strVal2, bool matchCase)
        {
            strValue1 = strVal1;
            strValue2 = strVal2;
        }

        /// <summary>
        /// Checks if a row in the first string is present in the second string
        /// </summary>
        /// <returns>String with the rows in the first string that are not present in the second string</returns>
        public string CheckNotPresentRowsInTwoStrings()
        {

            ListHelper listHelp = new ListHelper(strValue1);
            List<string> rows1 = listHelp.IntactList;
            listHelp = new ListHelper(strValue2);
            List<string> rows2 = listHelp.IntactList;

            List<string> differences = new List<string>();

            foreach (var r1 in rows1)
            {
                // if list rows2 not empty
                if (rows2.Count > 0)
                {
                    // if item in rows1 missing in rows2
                    if (!rows2.Contains(r1))
                    {
                        // add item to list differences
                        differences.Add(r1);
                    }
                }
                else
                {
                    // if 
                    differences.Add(r1);
                }
            }

            string strDiff = string.Empty;
            foreach (var diff in differences)
            {
                strDiff += diff.ToString() + Environment.NewLine;
            }

            return strDiff;
        }

        public override string ToString()
        {
            //return $"{CheckNotPresentRowsInTwoStrings()}";
            return CheckNotPresentRowsInTwoStrings().Trim();
        }
    }
}
