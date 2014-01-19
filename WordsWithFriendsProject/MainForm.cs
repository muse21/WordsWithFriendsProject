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
            
            mDictionary = new Dictionary_t();
            mLetters = new List<char>();
            mSuccessWords = new List<WordResult_t>();
            mMatcher = new Matcher_t();
            mScorer = new Scorer_t();
            mAlphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 
                's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
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
            if (mLetter1TextBox.Text.Trim().Length != 0)
            {
                mLetters.Add(System.Convert.ToChar(mLetter1TextBox.Text));
            }
            if (mLetter2TextBox.Text.Trim().Length != 0)
            {
                mLetters.Add(System.Convert.ToChar(mLetter2TextBox.Text));
            }
            if (mLetter3TextBox.Text.Trim().Length != 0)
            {
                mLetters.Add(System.Convert.ToChar(mLetter3TextBox.Text));
            }
            if (mLetter4TextBox.Text.Trim().Length != 0)
            {
                mLetters.Add(System.Convert.ToChar(mLetter4TextBox.Text));
            }
            if (mLetter5TextBox.Text.Trim().Length != 0)
            {
                mLetters.Add(System.Convert.ToChar(mLetter5TextBox.Text));
            }
            if (mLetter6TextBox.Text.Trim().Length != 0)
            {
                mLetters.Add(System.Convert.ToChar(mLetter6TextBox.Text));
            }
            if (mLetter7TextBox.Text.Trim().Length != 0)
            {
                mLetters.Add(System.Convert.ToChar(mLetter7TextBox.Text));
            }
        }

        private void
        //-----------------------------------------------------------
        FindMatches
        //-----------------------------------------------------------
            (
            )
        {
            string theCurrentWord;
            if (!mLetters.Contains('?'))
            {
                while (mDictionary.HasMoreWords())
                {
                    theCurrentWord = mDictionary.GetNextWord();
                    if (mMatcher.Evaluate(theCurrentWord, mLetters))
                    {
                        // TODO: don't add words twice
                        mSuccessWords.Add(new WordResult_t(theCurrentWord,
                                                           mScorer.ScoreFirstWord(theCurrentWord)));
                    }
                }
            }
            else
            {
                FindMatchesWithBlank();
            }
            mDictionary.Reset();
        }

        private void
        //-----------------------------------------------------------
        FindMatchesWithBlank
        //-----------------------------------------------------------
            (
            )
        {
            mLetters.Remove('?');
            foreach (char c in mAlphabet)
            {
                mLetters.Add(c);
                FindMatches();
                mLetters.Remove(c);
            }
            mLetters.Add('?');
        }

        private void
        //-----------------------------------------------------------
        DisplayResults
        //-----------------------------------------------------------
            (
            )
        {
          
            for (int i = 0; i < mSuccessWords.Count(); i++)
            {
                mResultsBox.Items.Add(MakeResultString(mSuccessWords[i]));
            }
        }

        private string
        //-----------------------------------------------------------
        MakeResultString
        //-----------------------------------------------------------
            (
            WordResult_t aResult
            )
        {
            string theWord = aResult.GetWord();
            Int32 theScore = aResult.GetScore();

            return theWord + " for " + theScore + " points";
        }

        private void
        //-----------------------------------------------------------
        SortResults
        //-----------------------------------------------------------
            (
            )
        {
            int theIndex;
            int theHighestScore;
            int theCurrentIndex;
            List<WordResult_t> theLocalList = new List<WordResult_t>();
            
            while( theLocalList.Count < scResultsLimit && mSuccessWords.Count() != 0 )
            {
                theIndex = 0;
                theHighestScore = 0;
                theCurrentIndex = 0;
                foreach (WordResult_t w in mSuccessWords)
                {
                    if (w.GetScore() > theHighestScore)
                    {
                        theHighestScore = w.GetScore();
                        theIndex = theCurrentIndex;
                    }
                    theCurrentIndex++;
                }
                if (mSuccessWords.Count() > theIndex)
                {
                    theLocalList.Add(mSuccessWords[theIndex]);
                    mSuccessWords.RemoveAt(theIndex);
                }
            }
            mSuccessWords = theLocalList;
        }

        private void
        //-----------------------------------------------------------
        Reset
        //-----------------------------------------------------------
            (
            )
        {
            mDictionary.Reset();
            mLetters.Clear();
            mSuccessWords.Clear();
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
            FindMatches();
            SortResults();
            DisplayResults();
            Reset();
        }

        //-----------------------------------------------------------
        // Member Data
        //-----------------------------------------------------------
        private Dictionary_t mDictionary;
        private List<char> mLetters;
        private List<WordResult_t> mSuccessWords;
        private Matcher_t mMatcher;
        private Scorer_t mScorer;
        private char[] mAlphabet;
        const int scResultsLimit = 20;
    }
}
