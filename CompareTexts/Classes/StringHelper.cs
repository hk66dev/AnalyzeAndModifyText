using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareTexts.Classes
{
    partial class StringHelper
    {

        #region --- private variables

        private  string replaceTwoCharNewLineWithOneChar;

        #endregion

        #region --- constructors

        /// <summary>
        /// Construcor: default
        /// </summary>
        /// <param name="strVal">string parameter</param>
        public StringHelper()
        {
            StrValue = string.Empty;
            replaceTwoCharNewLineWithOneChar = StrValue;
        }

        /// <summary>
        /// Construcor: string to analyse and return information 
        /// </summary>
        /// <param name="strVal">string parameter</param>
        public StringHelper(string strVal)
        {
            StrValue = strVal;
            replaceTwoCharNewLineWithOneChar = StrValue;
        }
        #endregion

        #region --- properties
               
        /// <summary>
        /// Set and get string in StringHelper
        /// </summary>
        public string StrValue { get; set; }

        /// <summary>
        /// Replace a two character 'NewLine' = "\n\r" with a one character 'NewLine' = '\r'.
        /// </summary>
        public  string ReplaceTwoCharNewLineWithOneChar
        {
            get { return replaceTwoCharNewLineWithOneChar.Replace("\r\n", "\r"); }
            set
            {
                replaceTwoCharNewLineWithOneChar = value;
            }
        }



        #endregion

        #region --- methods

        /// <summary>
        /// Counts the number of characters in the string
        /// </summary>
        /// <returns>int number characters</returns>
        public int NumberOfCharacters()
        {
            int numOfCharacters = 0;
            bool previusNewline = false;

            foreach (var c in StrValue)
            {
                // if Newline="\r\n" ´just count one charachter
                if (!(previusNewline && (c == '\n')))
                {
                    // increment numOfCharacters
                    numOfCharacters++;

                    // if c is the newline character \r
                    if (c == '\r')
                    {
                        // set previusNewline to true
                        previusNewline = true;
                    }
                    else
                    {
                        // set previusNewline to false
                        previusNewline = false;
                    }
                }
            }

            return numOfCharacters;
        }

        /// <summary>
        /// Counts the number of words in the string
        /// </summary>
        /// <returns>int number of words</returns>
        public int NumberOfWords()
        {

            int numOfWords = 0;
            int index = 0;

            // skip whitespace until first word
            while (index < StrValue.Length && char.IsWhiteSpace(StrValue[index]))
            {
                index++;
            }

            while (index < StrValue.Length)
            {
                // check if current char is part of a word
                while (index < StrValue.Length && !char.IsWhiteSpace(StrValue[index]))
                {
                    index++;
                }

                numOfWords++;

                // skip whitespace until next word
                while (index < StrValue.Length && char.IsWhiteSpace(StrValue[index]))
                {
                    index++;
                }
            }

            return numOfWords;
        }

        /// <summary>
        /// Counts the number of lines in the string
        /// </summary>
        /// <returns>int number of lines</returns>
        public int NumberOfLines()
        {
            // convert string to list
            ListHelper listHelp = new ListHelper(StrValue);
            List<string> lines = listHelp.IntactList;


            // if the string is empty return 0 lines otherwise count the lines
            int numOfLines = 0;
            if (NumberOfCharacters().ToString() != "0")
            {
                numOfLines = lines.Count();
            }

            return numOfLines;
        }

        public override string ToString()
        {
            return $"{NumberOfLines()} lines, {NumberOfWords()} words, {NumberOfCharacters()} characters";
        }

        #endregion
    }
}
