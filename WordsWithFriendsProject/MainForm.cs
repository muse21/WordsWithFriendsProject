using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordsWithFriendsProject
{
    public partial class MainForm : Form
    {
        public 
        //-----------------------------------------------------------
        MainForm
        //-----------------------------------------------------------
            (
            )
        {
            InitializeComponent();
            ClearListBox();
            LimitTextBoxSize();

            mFirstWord = new FirstWord_t();
            mLetters = new List<char>();
            mSuccessWords = new List<WordResult_t>();
        }

        //-----------------------------------------------------------
        // private functions
        //-----------------------------------------------------------

        private void
        //-----------------------------------------------------------
        ClearListBox
        //-----------------------------------------------------------
            (
            )
        {
            mResultsBox.Items.Clear();
        }

        private void
        //-----------------------------------------------------------
        LimitTextBoxSize
        //-----------------------------------------------------------
            (
            )
        {
            mLetter1TextBox.MaxLength = 1;
            mLetter2TextBox.MaxLength = 1;
            mLetter3TextBox.MaxLength = 1;
            mLetter4TextBox.MaxLength = 1;
            mLetter5TextBox.MaxLength = 1;
            mLetter6TextBox.MaxLength = 1;
            mLetter7TextBox.MaxLength = 1;
        }

        private void
        //-----------------------------------------------------------
        FillLetterList
        //-----------------------------------------------------------
            (
            )
        {
            char the1Result = scDefaultChar;
            char the2Result = scDefaultChar;
            char the3Result = scDefaultChar;
            char the4Result = scDefaultChar;
            char the5Result = scDefaultChar;
            char the6Result = scDefaultChar;
            char the7Result = scDefaultChar;

            if (mLetter1TextBox.Text.Trim().Length != 0)
            {
                the1Result = System.Convert.ToChar(mLetter1TextBox.Text);
            }
            if (mLetter2TextBox.Text.Trim().Length != 0)
            {
                the2Result = System.Convert.ToChar(mLetter2TextBox.Text);
            }
            if (mLetter3TextBox.Text.Trim().Length != 0)
            {
                the3Result = System.Convert.ToChar(mLetter3TextBox.Text);
            }
            if (mLetter4TextBox.Text.Trim().Length != 0)
            {
                the4Result = System.Convert.ToChar(mLetter4TextBox.Text);
            }
            if (mLetter5TextBox.Text.Trim().Length != 0)
            {
                the5Result = System.Convert.ToChar(mLetter5TextBox.Text);
            }
            if (mLetter6TextBox.Text.Trim().Length != 0)
            {
                the6Result = System.Convert.ToChar(mLetter6TextBox.Text);
            }
            if (mLetter7TextBox.Text.Trim().Length != 0)
            {
                the7Result = System.Convert.ToChar(mLetter7TextBox.Text);
            }

            List<char> theTemp = new List<char>(new char[] {the1Result, the2Result, 
                the3Result, the4Result, the5Result, the6Result, the7Result});
         
            if(ThereAreNotMoreThanOneBlankTiles(theTemp))
            {
                mLetters = new List<char>( new char[] {the1Result, the2Result, 
                the3Result, the4Result, the5Result, the6Result, the7Result});
            }
        }

        private bool
        //-----------------------------------------------------------
        ThereAreNotMoreThanOneBlankTiles
        //-----------------------------------------------------------
            (
            List<char> aList
            )
        {
            if(aList.Contains('?'))
            {
                aList.Remove('?');
                if(aList.Contains('?'))
                {
                    return false;
                }
            }
            return true;
        }

        private void
        //-----------------------------------------------------------
        DisplayResults
        //-----------------------------------------------------------
            (
            List<string> aList
            )
        {
            foreach (string s in aList)
            {
                mResultsBox.Items.Add(s);
            }
        }

        public void
        //-----------------------------------------------------------
        Reset
        //-----------------------------------------------------------
            (
            )
        {
            mLetters.Clear();
            mSuccessWords.Clear();
            mFirstWord.Reset();
        }

        //-----------------------------------------------------------
        // Event Handlers
        //-----------------------------------------------------------

        private void 
        //-----------------------------------------------------------
        HandleGoClicked
        //-----------------------------------------------------------
            (
            object sender,
            EventArgs e
            )
        {
            mLetters.Clear();
            ClearListBox();
            FillLetterList();


            if (mLetters.Count() > 0)
            {
                DisplayResults( mFirstWord.GetResults( mLetters ) );
            }
            else
            {
                mResultsBox.Items.Add("Invaled Entry");
            }
            Reset();
        }

        //-----------------------------------------------------------
        // Member Data
        //-----------------------------------------------------------
        private List<char> mLetters;
        private List<WordResult_t> mSuccessWords;
        private FirstWord_t mFirstWord;
        const char scDefaultChar = '-';
    }
}
