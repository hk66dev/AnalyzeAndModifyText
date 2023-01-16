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
using CompareTextsUWP.Classes;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Reflection;
using Windows.ApplicationModel;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CompareTextsUWP
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
            StringHelper shResultDisplayMode = new StringHelper();
            resultDisplayMode1 = shResultDisplayMode.GetResultDisplayModeValue();
            resultDisplayMode2 = shResultDisplayMode.GetResultDisplayModeValue();

            // About
            About.Text = $"File version: {Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>().Version} - Package version: ";
            About.Text = About.Text + $"{Package.Current.Id.Version.Major}.{Package.Current.Id.Version.Minor}.{Package.Current.Id.Version.Build}.{Package.Current.Id.Version.Revision}";

        }

        /// <param name="e"></param>
        private void Text1_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateMainPage();

            //// Check if rows in text 1 is present in text 2. Display difference, format the output as desired "ResultDisplayMode
            //CompareTwoStrings compStrings2 = new CompareTwoStrings(Text1.Text.Trim(), Text2.Text.Trim(), MatchCase.IsChecked ?? false);
            //StringHelper shResult1 = new StringHelper();
            //Result1.Text = shResult1.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode1.SelectedValue.ToString()), compStrings2.ToString());

            //// Check if rows in text 2 is present in text 1. Display difference.
            //compStrings2 = new CompareTwoStrings(Text2.Text.Trim(), Text1.Text.Trim(), MatchCase.IsChecked ?? false);
            //StringHelper shResult2 = new StringHelper();
            //Result2.Text = shResult2.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode2.SelectedValue.ToString()), compStrings2.ToString());

            //// Display statistics of text 1
            //StringHelper strInfo = new StringHelper(Text1.Text);
            //StatText1.Text = strInfo.ToString();

            //// Display statistics of result 1
            //StringHelper strStatResult1 = new StringHelper(Result1.Text);
            //StatResult1.Text = strStatResult1.ToString();
            //// Display statistics of result 2
            //StringHelper strStatResult2 = new StringHelper(Result2.Text);
            //StatResult2.Text = strStatResult2.ToString();
        }

        private void Text2_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateMainPage();

            //// Check if rows in text 1 is present in text 2. Display difference.
            //CompareTwoStrings compStrings2 = new CompareTwoStrings(Text1.Text.Trim(), Text2.Text.Trim(), MatchCase.IsChecked ?? false);
            //StringHelper shResult1 = new StringHelper();
            //Result1.Text = shResult1.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode1.SelectedValue.ToString()), compStrings2.ToString());

            //// Check if rows in text 2 is present in text 1. Display difference.
            //compStrings2 = new CompareTwoStrings(Text2.Text.Trim(), Text1.Text.Trim(), MatchCase.IsChecked ?? false);
            //StringHelper shResult2 = new StringHelper();
            //Result2.Text = shResult2.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode2.SelectedValue.ToString()), compStrings2.ToString());

            //// Display statistics of text 2
            //StringHelper strInfo = new StringHelper(Text2.Text);
            //StatText2.Text = strInfo.ToString();

            //// Display statistics of result 1
            //StringHelper strStatResult1 = new StringHelper(Result1.Text);
            //StatResult1.Text = strStatResult1.ToString();
            //// Display statistics of result 2
            //StringHelper strStatResult2 = new StringHelper(Result2.Text);
            //StatResult2.Text = strStatResult2.ToString();
        }

        private void Text1_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateMainPage();

            //// Check if rows in text 1 is present in text 2. Display difference.
            //CompareTwoStrings compStrings2 = new CompareTwoStrings(Text1.Text.Trim(), Text2.Text.Trim(), MatchCase.IsChecked ?? false);
            //StringHelper shResult1 = new StringHelper();
            //Result1.Text = shResult1.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode1.SelectedValue.ToString()), compStrings2.ToString());

            //// Display statistics of text 1
            //StringHelper strInfo = new StringHelper(Text1.Text);
            //StatText1.Text = strInfo.ToString();

            //// Display statistics of result 1
            //StringHelper strStatResult1 = new StringHelper(Result1.Text);
            //StatResult1.Text = strStatResult1.ToString();
            //// Display statistics of result 2
            //StringHelper strStatResult2 = new StringHelper(Result2.Text);
            //StatResult2.Text = strStatResult2.ToString();
        }

        private void Text2_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateMainPage();

            //// Check if rows in text 2 is present in text 1. Display difference.
            //CompareTwoStrings compStrings2 = new CompareTwoStrings(Text2.Text.Trim(), Text1.Text.Trim(), MatchCase.IsChecked ?? false);
            //StringHelper shResult2 = new StringHelper();
            //Result2.Text = shResult2.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode2.SelectedValue.ToString()), compStrings2.ToString());

            //// Display statistics of text 2
            //StringHelper strInfo = new StringHelper(Text2.Text);
            //StatText2.Text = strInfo.ToString();

            //// Display statistics of result 1
            //StringHelper strStatResult1 = new StringHelper(Result1.Text);
            //StatResult1.Text = strStatResult1.ToString();
            //// Display statistics of result 1
            //StringHelper strStatResult2 = new StringHelper(Result2.Text);
            //StatResult2.Text = strStatResult2.ToString();
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
            Text1.Text = listHelp.StringOfDistinctList.Trim();
        }

        private void RemoveDuplicatesText2_Click(object sender, RoutedEventArgs e)
        {
            ////Remove duplicates
            ListHelper listHelp = new ListHelper(Text2.Text);
            Text2.Text = listHelp.StringOfDistinctList.Trim();
        }

        private void ResultMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMainPage();

            //// Check if rows in text 1 is present in text 2. Display difference, format the output as desired "ResultDisplayMode1
            //CompareTwoStrings compStrings = new CompareTwoStrings(Text1.Text.Trim(), Text2.Text.Trim(), MatchCase.IsChecked ?? false);
            //StringHelper shResult1 = new StringHelper();
            //Result1.Text = shResult1.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode1.SelectedValue.ToString()), compStrings.ToString());


            //// Check if rows in text 2 is present in text 1. Display difference, format the output as desired "ResultDisplayMode2
            //compStrings = new CompareTwoStrings(Text2.Text.Trim(), Text1.Text.Trim(), MatchCase.IsChecked ?? false);
            //StringHelper shResult2 = new StringHelper();

            //if (ResultMode2.SelectedValue != null)
            //    Result2.Text = shResult2.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode2.SelectedValue.ToString()), compStrings.ToString());
            //else
            //    Result2.Text = "Error";

            //// Display statistics of text 1
            //StringHelper strInfo = new StringHelper(Text1.Text);
            //StatText1.Text = strInfo.ToString();

            //// Display statistics of text 2
            //StringHelper strInfo2 = new StringHelper(Text2.Text);
            //StatText2.Text = strInfo2.ToString();

            //// Display statistics of result 1
            //StringHelper strStatResult1 = new StringHelper(Result1.Text);
            //StatResult1.Text = strStatResult1.ToString();
            //// Display statistics of result 2
            //StringHelper strStatResult2 = new StringHelper(Result2.Text);
            //StatResult2.Text = strStatResult2.ToString();
        }

        private void Replace1_Click(object sender, RoutedEventArgs e)
        {
            FindAndReplaceSubString text = new FindAndReplaceSubString(Text1.Text, FindStr1.Text,ReplaceStr1.Text);
            Text1.Text = text.CorrectedString;

        }

        private void Replace2_Click(object sender, RoutedEventArgs e)
        {
            FindAndReplaceSubString text = new FindAndReplaceSubString(Text2.Text, FindStr2.Text, ReplaceStr2.Text);
            Text2.Text = text.CorrectedString;
        }

        private void MatchCase_Checked(object sender, RoutedEventArgs e)
        {
            UpdateMainPage();
        }

        private void MatchCase_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateMainPage();
        }

        private void DisplayMatches_Checked(object sender, RoutedEventArgs e)
        { 
            UpdateMainPage(); 
        }

        private void DisplayMatches_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateMainPage();
        }

        private void UpdateMainPage()
        {
            // Check if rows in text 1 is present in text 2. Display difference, format the output as desired "ResultDisplayMode
            CompareTwoStrings compStrings1 = new CompareTwoStrings(Text1.Text.Trim(), Text2.Text.Trim(), MatchCase.IsChecked ?? false, DisplayMatches.IsChecked ?? false);
            StringHelper shResult1 = new StringHelper();
            Result1.Text = shResult1.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode1.SelectedValue.ToString()), compStrings1.ToString());

            // Check if rows in text 2 is present in text 1. Display difference.
            CompareTwoStrings compStrings2 = new CompareTwoStrings(Text2.Text.Trim(), Text1.Text.Trim(), MatchCase.IsChecked ?? false, DisplayMatches.IsChecked ?? false);
            StringHelper shResult2 = new StringHelper();
            // check resultmode 2 not null
            if (ResultMode2.SelectedValue != null)
                Result2.Text = shResult2.ModifyString((StringHelper.ResultDisplayMode)Enum.Parse(typeof(StringHelper.ResultDisplayMode), ResultMode2.SelectedValue.ToString()), compStrings2.ToString());
            else
                Result2.Text = "Error";

            // Display statistics of text 1
            StringHelper strInfo1 = new StringHelper(Text1.Text);
            StatText1.Text = strInfo1.ToString();
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
    }
}
