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
        ThereAreNotMoreThanOneBlankTiles
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
                        
                        if (CheckForDuplicates(theCurrentWord))
                        {
                            mSuccessWords.Add(new WordResult_t(theCurrentWord,
                                                               mScorer.ScoreFirstWord(theCurrentWord)));
                        }
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

        private bool
        //-----------------------------------------------------------
        CheckForDuplicates
        //-----------------------------------------------------------
            (
            string aWord
            )
        {
            if (mSuccessWords.Count() > 0)
            {
                foreach (WordResult_t w in mSuccessWords)
                {
                    if (String.Compare(w.GetWord(), aWord) == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
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

            if (mLetters.Count() > 0)
            {
                FindMatches();
                SortResults();
                DisplayResults();
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
        private Dictionary_t mDictionary;
        private List<char> mLetters;
        private List<WordResult_t> mSuccessWords;
        private Matcher_t mMatcher;
        private Scorer_t mScorer;
        private char[] mAlphabet;
        const int scResultsLimit = 20;
        const char scDefaultChar = '-';
    }
}
