using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareTexts.Classes
{
    class CompareTwoStrings
    {
        public string Str1 { get; set; }
        public string Str2 { get; set; }
        public bool IsMatchCase { get; set; }

        public CompareTwoStrings(string str1, string str2, bool matchCase)
        {
            Str1 = str1;
            Str2 = str2;
            IsMatchCase = matchCase;
        }

        /// <summary>
        /// Checks if a row in the first string is present in the second string
        /// </summary>
        /// <returns>String with the rows in the first string that are not present in the second string</returns>
        public string FindNotMatchingStrings()
        {

            ListHelper listHelp = new ListHelper(Str1);
            List<string> rows1 = listHelp.IntactList;
            listHelp = new ListHelper(Str2);
            List<string> rows2 = listHelp.IntactList;
            // make strings in list low case 
            List<string> lcRows2 = new List<string>();
            foreach (var r2 in rows2)
            {
                lcRows2.Add(r2.ToString().ToLower());
            }

            List<string> differences = new List<string>();

            // check if comparing should be done as case sensitive or not
            if (IsMatchCase)
            {
                // comparing as case sensitive
                foreach (var r1 in rows1)
                {
                    // if list rows2 not empty
                    if (rows2.Count > 0)
                    {
                        // check if comparing as case sensitive
                        if (IsMatchCase)
                        {
                            // if item in rows1 missing in rows2
                            if (!rows2.Contains(r1))
                            {
                                // add item to list differences
                                differences.Add(r1);
                            }
                            else if (!lcRows2.Contains(r1.ToLower()))
                            {
                                // add item to list differences
                                differences.Add(r1);
                            }
                        }
                    }
                    else
                    {
                        // if 
                        differences.Add(r1);
                    }
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
            return FindNotMatchingStrings().Trim();
        }
    }
}
