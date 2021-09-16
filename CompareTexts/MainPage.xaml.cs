using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CompareTexts.Classes;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CompareTexts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        readonly IEnumerable<StringHelper.ResultDisplayMode> resultDisplayMode1;
        readonly IEnumerable<StringHelper.ResultDisplayMode> resultDisplayMode2;

        public MainPage()
        {
            this.InitializeComponent();

            // Enum to combobox
            //IEnumerable<StringHelper.ResultDisplayMode> resultDisplayMode1 = Enum.GetValues(typeof(StringHelper.ResultDisplayMode)).Cast<StringHelper.ResultDisplayMode>(); // TODO
            StringHelper shResultDisplayMode = new StringHelper();
            resultDisplayMode1 = shResultDisplayMode.GetResultDisplayModeValue();
            resultDisplayMode2 = shResultDisplayMode.GetResultDisplayModeValue();

            //StringBuilder stringbuilder = new StringBuilder();
            //foreach (var resultDisplayModeItem in resultDisplayMode1)
            //{
            //    stringbuilder.Append(resultDisplayModeItem.GetDescription() + "|");//TODO test this
            //}
        }

        /// <param name="e"></param>
        private void Text1_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Check if rows in text 1 is present in text 2. Display difference, format the output as desired "ResultDisplayMode
            CompareTwoStrings compStrings = new CompareTwoStrings(Text1.Text.Trim(), Text2.Text.Trim());
            StringHelper shResult1 = new StringHelper();
            Result1.Text = shResult1.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode1.SelectedValue.ToString()), compStrings.ToString());


            // Check if rows in text 2 is present in text 1. Display difference.
            compStrings = new CompareTwoStrings(Text2.Text.Trim(), Text1.Text.Trim());
            StringHelper shResult2 = new StringHelper();
            Result2.Text = shResult2.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode2.SelectedValue.ToString()), compStrings.ToString());

            // Display statistics of text 1
            StringHelper strInfo = new StringHelper(Text1.Text);
            StatText1.Text = strInfo.ToString();

            // Display statistics of result 1
            StringHelper strStatResult1 = new StringHelper(Result1.Text);
            StatResult1.Text = strStatResult1.ToString();
            // Display statistics of result 2
            StringHelper strStatResult2 = new StringHelper(Result2.Text);
            StatResult2.Text = strStatResult2.ToString();
        }

        private void Text2_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Check if rows in text 1 is present in text 2. Display difference.
            CompareTwoStrings compStrings = new CompareTwoStrings(Text1.Text.Trim(), Text2.Text.Trim());
            StringHelper shResult1 = new StringHelper();
            Result1.Text = shResult1.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode1.SelectedValue.ToString()), compStrings.ToString());

            // Check if rows in text 2 is present in text 1. Display difference.
            compStrings = new CompareTwoStrings(Text2.Text.Trim(), Text1.Text.Trim());
            StringHelper shResult2 = new StringHelper();
            Result2.Text = shResult2.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode2.SelectedValue.ToString()), compStrings.ToString());

            // Display statistics of text 2
            StringHelper strInfo = new StringHelper(Text2.Text);
            StatText2.Text = strInfo.ToString();

            // Display statistics of result 1
            StringHelper strStatResult1 = new StringHelper(Result1.Text);
            StatResult1.Text = strStatResult1.ToString();
            // Display statistics of result 2
            StringHelper strStatResult2 = new StringHelper(Result2.Text);
            StatResult2.Text = strStatResult2.ToString();
        }

        private void Text1_Loaded(object sender, RoutedEventArgs e)
        {
            // Check if rows in text 1 is present in text 2. Display difference.
            CompareTwoStrings compStrings = new CompareTwoStrings(Text1.Text.Trim(), Text2.Text.Trim());
            StringHelper shResult1 = new StringHelper();
            Result1.Text = shResult1.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode1.SelectedValue.ToString()), compStrings.ToString());

            // Display statistics of text 1
            StringHelper strInfo = new StringHelper(Text1.Text);
            StatText1.Text = strInfo.ToString();

            // Display statistics of result 1
            StringHelper strStatResult1 = new StringHelper(Result1.Text);
            StatResult1.Text = strStatResult1.ToString();
            // Display statistics of result 2
            StringHelper strStatResult2 = new StringHelper(Result2.Text);
            StatResult2.Text = strStatResult2.ToString();
        }

        private void Text2_Loaded(object sender, RoutedEventArgs e)
        {
            // Check if rows in text 2 is present in text 1. Display difference.
            CompareTwoStrings compStrings = new CompareTwoStrings(Text2.Text.Trim(), Text1.Text.Trim());
            StringHelper shResult2 = new StringHelper();
            Result2.Text = shResult2.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode2.SelectedValue.ToString()), compStrings.ToString());

            // Display statistics of text 2
            StringHelper strInfo = new StringHelper(Text2.Text);
            StatText2.Text = strInfo.ToString();

            // Display statistics of result 1
            StringHelper strStatResult1 = new StringHelper(Result1.Text);
            StatResult1.Text = strStatResult1.ToString();
            // Display statistics of result 1
            StringHelper strStatResult2 = new StringHelper(Result2.Text);
            StatResult2.Text = strStatResult2.ToString();
        }

        private void SortText1_Click(object sender, RoutedEventArgs e)
        {
            //Sort text and remove empty entries
            ListHelper listHelp = new ListHelper(Text1.Text);
            Text1.Text = listHelp.StringOfSortedList;
        }

        private void SortText2_Click(object sender, RoutedEventArgs e)
        {
            //Sort text and remove empty entries
            ListHelper listHelp = new ListHelper(Text2.Text);
            Text2.Text = listHelp.StringOfSortedList;
        }

        private void RemoveDuplicatesText1_Click(object sender, RoutedEventArgs e)
        {
            ////Remove duplicates
            ListHelper listHelp = new ListHelper(Text1.Text);
            Text1.Text = listHelp.StringOfDistinctList;
        }

        private void RemoveDuplicatesText2_Click(object sender, RoutedEventArgs e)
        {
            ////Remove duplicates
            ListHelper listHelp = new ListHelper(Text2.Text);
            Text2.Text = listHelp.StringOfDistinctList;
        }

        private void ResultMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check if rows in text 1 is present in text 2. Display difference, format the output as desired "ResultDisplayMode1
            CompareTwoStrings compStrings = new CompareTwoStrings(Text1.Text.Trim(), Text2.Text.Trim());
            StringHelper shResult1 = new StringHelper();
            Result1.Text = shResult1.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode1.SelectedValue.ToString()), compStrings.ToString());


            // Check if rows in text 2 is present in text 1. Display difference, format the output as desired "ResultDisplayMode2
            compStrings = new CompareTwoStrings(Text2.Text.Trim(), Text1.Text.Trim());
            StringHelper shResult2 = new StringHelper();

            if (ResultMode2.SelectedValue != null)
                Result2.Text = shResult2.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode2.SelectedValue.ToString()), compStrings.ToString());
            else
                Result2.Text = "Error";

            // Display statistics of text 1
            StringHelper strInfo = new StringHelper(Text1.Text);
            StatText1.Text = strInfo.ToString();

            // Display statistics of text 2
            StringHelper strInfo2 = new StringHelper(Text2.Text);
            StatText2.Text = strInfo2.ToString();

            // Display statistics of result 1
            StringHelper strStatResult1 = new StringHelper(Result1.Text);
            StatResult1.Text = strStatResult1.ToString();
            // Display statistics of result 2
            StringHelper strStatResult2 = new StringHelper(Result2.Text);
            StatResult2.Text = strStatResult2.ToString();
        }

        private void Replace1_Click(object sender, RoutedEventArgs e)
        {
            if (OldValue.Text == "TAB" && NewValue.Text == "TAB")
            {
                Text1.Text = Text1.Text.Replace("\t", "\t");
            }
            else if (OldValue.Text == "NEWLINE" && NewValue.Text == "NEWLINE")
            {
                Text1.Text = Text1.Text.Replace(Environment.NewLine, Environment.NewLine);
            }
            else if (OldValue.Text == "NEWLINE" && NewValue.Text == "TAB")
            {
                Text1.Text = Text1.Text.Replace(Environment.NewLine, "\t");
            }
            else if (OldValue.Text == "TAB" && NewValue.Text == "NEWLINE")
            {
                Text1.Text = Text1.Text.Replace("\t", Environment.NewLine);
            }
            else if (OldValue.Text == "TAB")
            {
                Text1.Text = Text1.Text.Replace("\t", NewValue.Text);
            }
            else if (NewValue.Text == "TAB")
            {
                Text1.Text = Text1.Text.Replace(OldValue.Text, "\t");
            }
            else if (OldValue.Text == "NEWLINE")
            {
                Text1.Text = Text1.Text.Replace(Environment.NewLine, NewValue.Text);
            }
            else if (NewValue.Text == "NEWLINE")
            {
                Text1.Text = Text1.Text.Replace(OldValue.Text, Environment.NewLine);
            }
            else
            {
                if (OldValue.Text != string.Empty)
                {
                    Text1.Text = Text1.Text.Replace(OldValue.Text, NewValue.Text);
                }
            }

        }
    }
}
