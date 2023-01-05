using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareTexts.Classes
{
    internal class FindAndReplaceItem
    {
        //properties
        public string Item { get; set; }
        public string Description { get; set; }
        public string AlternativeString { get; set; }

        // constructors
        public FindAndReplaceItem()
        {
        }

        public FindAndReplaceItem(string item, string description, string alternativeText)
        {
            Item = item;
            Description = description;
            AlternativeString = alternativeText;
        }
    }

    internal class FindAndReplaceItems
    {
        // properties

        /// <summary>
        /// Initiate list control
        /// </summary>
        public ObservableCollection<FindAndReplaceItem> Items
        {
            get
            {
                return InitiateList();
            }
        }

        // methods

        public ObservableCollection<FindAndReplaceItem> InitiateList()
        {
            var listItems = new ObservableCollection<FindAndReplaceItem>
           {
                //Colon, Comma, Dot, Newline, Semicolon, Space, Tab,
               new FindAndReplaceItem { Item="COLON", Description = "Colon", AlternativeString=":" },
               new FindAndReplaceItem { Item="COMMA", Description = "Comma", AlternativeString="," },
               new FindAndReplaceItem { Item="DOT", Description = "Dot", AlternativeString="." },
               new FindAndReplaceItem { Item="NEWLINE", Description = "Newline", AlternativeString=Environment.NewLine },
               new FindAndReplaceItem { Item="SEMICOLON", Description = "Semicolon", AlternativeString=";" },
               new FindAndReplaceItem { Item="SPACE", Description = "Space", AlternativeString=" " },
               new FindAndReplaceItem { Item="TAB", Description = "Tabulator", AlternativeString=" " }

           };

            return new ObservableCollection<FindAndReplaceItem>(listItems.OrderBy(x => x.Item).ToList());
        }


    }
}

