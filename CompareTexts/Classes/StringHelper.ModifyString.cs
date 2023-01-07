using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Markup;

namespace CompareTexts.Classes
{
    partial class StringHelper
    {

        #region --- enum
        public enum ResultDisplayMode
        {
            [Display(Name = "Original separator")]
            [Description("Original separators are preserved ")]
            Original,
            [Display(Name = "Comma separator")]
            [Description("Change to comma separator")]
            Comma,
            [Display(Name = "NOT selection Extens")]
            [Description("Negative selection in Extens")]
            ExtensNot,
            [Display(Name = "NOT selection in Skola 24 Schema")]
            [Description("Negative selection in Skola 24 Schema")]
            Skola24SchemaNot,
            [Display(Name = "Semicolon separator")]
            [Description("Change to semicolon separator")]
            SemiColon,
            [Display(Name = "Tab separator")]
            [Description("Change to tab separator")]
            Tab,
            [Display(Name = "In Operator in SQL")]
            [Description("Selection for In Operator in SQL")]
            InOperatorSQL
        };
        #endregion

        #region --- methods


        /// <summary>
        /// Get the IEnumerable value collection
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        public IEnumerable<ResultDisplayMode> GetResultDisplayModeValue()
        {
            //IEnumerable<ResultDisplayMode> resultDisplayMode1
            return Enum.GetValues(typeof(ResultDisplayMode)).Cast<ResultDisplayMode>(); // TODO
        }

        /// <summary>
        /// Modify the string depending on the ResultDisplayMode
        /// </summary>
        /// <param name="changeMode">Modify depending on this parameter</param>
        /// <param name="stringToModify">The string to modify</param>
        /// <returns></returns>
        public string ModifyString(ResultDisplayMode changeMode, string stringToModify)
        {
            string strResult = string.Empty;
            //string[] strNewlines = new string[4] { Environment.NewLine, "\r\n", "\r", "\n" };

            switch (changeMode)
            {
                case ResultDisplayMode.Original: // test OK
                    strResult = stringToModify;
                    break;
                case ResultDisplayMode.Comma:
                    strResult = Modify(strModify: stringToModify, newSeparator: ","); // test OK
                    break;
                case ResultDisplayMode.ExtensNot:
                    strResult = Modify(strModify: stringToModify, newSeparator: ", ", notOperator: "ej "); // test
                    break;
                case ResultDisplayMode.Skola24SchemaNot:
                    strResult = Modify(strModify: stringToModify, newSeparator: "&", notOperator: "!");  // test
                    break;
                case ResultDisplayMode.SemiColon:
                    strResult = Modify(strModify: stringToModify, newSeparator: ";"); // test OK
                    break;
                case ResultDisplayMode.Tab:
                    strResult = Modify(strModify: stringToModify, newSeparator: "\t"); // test Ok
                    break;
                case ResultDisplayMode.InOperatorSQL:
                    strResult = Modify(strModify: stringToModify, newSeparator: ", ", surround: "\'"); // test Ok
                    break;
                default:
                    break;
            }

            return strResult;
        }

        /// <summary>
        /// Use parameters to modify string
        /// </summary>
        /// <param name="strModify">The string to modify</param>
        /// <param name="newSeparator">New separator</param>
        /// <param name="notOperator">The NOT operator</param>
        /// <param name="surround"></param>
        /// <returns></returns>
        private string Modify(string strModify, string newSeparator, string notOperator = "", string surround = "")
        {
            StringBuilder sb = new StringBuilder(string.Empty);

            ListHelper lh = new ListHelper(strModify);

            List<string> list = lh.IntactList;

            // create new string with new separators between the items from the list
            for (int i = 0; i < list.Count(); i++)
            {
                // if present, apply the notOperator in front of the item
                if (notOperator != string.Empty)
                {
                    sb.Append(notOperator);
                }

                // if present, apply the surround string in front of the item
                if (surround != string.Empty)
                {
                    sb.Append(surround);
                }

                // append the string item from the list to the new string
                sb.Append(list[i].ToString());

                // if present, apply the surround string after the item
                if (surround != string.Empty)
                {
                    sb.Append(surround);
                }

                // don´t append a separater to string after the last item in list
                if (i + 1 < list.Count())
                {
                    // append separator to string
                    sb.Append(newSeparator);
                }
            }

            return sb.ToString().Trim();
        }
        #endregion
    }
}
