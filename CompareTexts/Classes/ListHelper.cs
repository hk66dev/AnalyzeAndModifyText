using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareTexts.Classes
{
    class ListHelper
    {
        #region --- private variables

        private List<string> ascendingList;
        private List<string> descendingList;
        private List<string> distinctList;
        private string stringOfAscendingList;
        private string stringOfDescendingList;
        private string stringOfDistinctList;
        private string stringOfIntactList;

        #endregion
       
        #region --- constructors

        /// <summary>
        /// Constructor: default
        /// </summary>
        public ListHelper()
        {
            IntactList.Clear();
            ascendingList.Clear();
            distinctList.Clear();
        }

        /// <summary>
        /// Constructor: split string on 'newline' into a list
        /// </summary>
        /// <param name="strVal">string parameter</param>
        public ListHelper(string _strVal)
        {
            IntactList = new List<string>(_strVal.Split(new string[] { Environment.NewLine, "\r\n", "\n", "\r" }, StringSplitOptions.None));
            ascendingList = IntactList;
            distinctList = IntactList;
        }
        
        /// <summary>
        /// Constructor: takes a list
        /// </summary>
        /// <param name="_list">list parameter</param>
        public ListHelper(List<string> _list)
        {
            IntactList = _list;
            ascendingList = IntactList;
            distinctList = IntactList;
        }

        #endregion

        #region --- properties

        /// <summary>
        /// IntactList
        /// </summary>
        public List<string> IntactList { get;  set; }

        /// <summary>
        /// Returns a string from an intact list
        /// </summary>
        public string StringOfIntactList
        {
            get
            {
                foreach (var il in IntactList)
                {
                    stringOfIntactList = il.ToString() + Environment.NewLine;
                }
                return stringOfIntactList;
            }
        }

        /// <summary>
        /// Ascending list
        /// </summary>
        public List<string> AscendingList
        {
            get
            {
                ascendingList.Sort();
                return ascendingList;
            }
            set { ascendingList = value; }
        }

        /// <summary>
        /// Returns a string from a ascending list
        /// </summary>
        public string StringOfSortedList
        {
            get
            {
                foreach (var sl in AscendingList)
                {
                    stringOfAscendingList += sl.ToString() + Environment.NewLine;
                }

                return stringOfAscendingList.Trim();
            }
        }

        /// <summary>
        /// Descending list
        /// </summary>
        public List<string> DescendingList
        {
            get
            {
                descendingList.Sort();
                descendingList.Reverse();
                return descendingList;
            }
            set { descendingList = value; }
        }

        public string StringOfDescendingList
        {
            get
            {
                foreach (var desc in DescendingList)
                {
                    stringOfDescendingList += desc.ToString() + Environment.NewLine;

                }
                return stringOfDescendingList.Trim();
            }
        }

        public List<string> DistinctList
        {
            get
            {
                return distinctList.Distinct().ToList();
            }
            set { distinctList = value; }
        }

        public string StringOfDistinctList
        {
            get
            {
                foreach (var dl in DistinctList)
                {
                    stringOfDistinctList += dl.ToString() + Environment.NewLine;
                }

                return stringOfDistinctList;
            }

        }

        #endregion

        #region --- methods

        /// <summary>
        /// Override ToString(), returns string of intact list
        /// </summary>
        /// <returns>string of intact list</returns>
        public override string ToString()
        {
            return StringOfIntactList; // what to return ???hkl
        }

        #endregion
    }
}
