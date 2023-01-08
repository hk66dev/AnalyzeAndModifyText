using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Casting;

namespace CompareTexts.Classes
{
    class CompareTwoStrings
    {
        public string Str1 { get; set; }
        public string Str2 { get; set; }
        public bool IsMatchCase { get; set; }
        public bool IsDisplayMatches { get; set; }

        public CompareTwoStrings(string str1, string str2, bool matchCase, bool displayMatches)
        {
            Str1 = str1;
            Str2 = str2;
            IsMatchCase = matchCase;
            IsDisplayMatches = displayMatches;
        }

        /// <summary>
        /// Checks if a row in the first string is present in the second string
        /// </summary>
        /// <returns>String with the rows in the first string that are not present in the second string</returns>
        public string FindStrings()
        {
            // list for collecting results
            List<string> results = new List<string>();

            // if both strings are empty there is no need to compare
            if (!(string.IsNullOrWhiteSpace(Str1) && string.IsNullOrWhiteSpace(Str2)))
            {
                ListHelper listHelp = new ListHelper(Str1);
                List<string> rows1 = listHelp.IntactList;
                listHelp = new ListHelper(Str2);
                List<string> rows2 = listHelp.IntactList;

                // Test if one of the two strings is empty
                if (string.IsNullOrWhiteSpace(Str1) || string.IsNullOrWhiteSpace(Str2))
                {
                    //  if one of the two strings is empty, copy list rows1 to list results
                    results = new List<string>(rows1);
                }
                else
                {
                    //  if Str2 is not empty, compare strings
                    // compare strings in lists
                    foreach (var r1 in rows1)
                    {
                        // check if comparing as case sensitive
                        if (IsMatchCase)
                        {
                            // check if displaying matches or differences
                            if (IsDisplayMatches)
                            {
                                // if item in rows1 present in rows2
                                if (rows2.Contains(r1))
                                {
                                    // add item to list results
                                    results.Add(r1);
                                }
                            }
                            else
                            {
                                // if item in rows1 missing in rows2
                                if (!rows2.Contains(r1))
                                {
                                    // add item to list results
                                    results.Add(r1);
                                }
                            }
                        }
                        else
                        {
                            // make strings in list low case 
                            List<string> lcRows2 = new List<string>();
                            foreach (var r2 in rows2)
                            {
                                lcRows2.Add(r2.ToString().ToLower());
                            }

                            // check if displaying matches or differences
                            if (IsDisplayMatches)
                            {
                                // if item in rows1 present in rows2
                                if (lcRows2.Contains(r1.ToLower()))        // compare strings not case sensitive
                                {
                                    // add item to list results
                                    results.Add(r1);
                                }
                            }
                            else
                            {
                                // if item in rows1 missing in rows2
                                if (!lcRows2.Contains(r1.ToLower()))    // compare strings not case sensitive
                                {
                                    // add item to list results
                                    results.Add(r1);
                                }
                            }
                        }
                    }
                }
            }

            // build  string from list results
            string strResult = string.Empty;
            foreach (var r in results)
            {
                strResult += r.ToString() + Environment.NewLine;
            }

            return strResult.Trim();
        }

        public override string ToString()
        {
            return FindStrings().Trim();
            return CheckNotPresentRowsInTwoStrings().Trim();
            return CheckNotPresentRowsInTwoStrings().Trim();
            return CheckNotPresentRowsInTwoStrings().Trim();
            return CheckNotPresentRowsInTwoStrings().Trim();
        }
    }
}
