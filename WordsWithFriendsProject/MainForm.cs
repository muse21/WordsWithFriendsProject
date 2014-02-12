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

            mLetters = new List<char>();
            mDictionary = new Dictionary_t();
            mFirstWord = new FirstWord_t( mDictionary );
            mSimpleSearch = new SimpleSearch_t( mDictionary );
            mSuccessWords = new List<WordResult_t>();
            mScorer = new Scorer_t();
            mMyWords = new MyWords_t(mDictionary);

            LoadScorersComboBoxes();
            SetComboBoxes();
            mJustMySubStringsCB.Checked = true;
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
            mScoreLetter1.MaxLength = 1;
            mScoreLetter2.MaxLength = 1;
            mScoreLetter1.MaxLength = 1;
            mScoreLetter2.MaxLength = 1;
            mScoreLetter1.MaxLength = 1;
            mScoreLetter2.MaxLength = 1;
            mScoreLetter1.MaxLength = 1;
            mScoreLetter2.MaxLength = 1;
            mScoreLetter1.MaxLength = 1;
            mScoreLetter2.MaxLength = 1;
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
                the1Result = Char.ToLower(System.Convert.ToChar(mLetter1TextBox.Text));
            }
            if (mLetter2TextBox.Text.Trim().Length != 0)
            {
                the2Result = Char.ToLower(System.Convert.ToChar(mLetter2TextBox.Text));
            }
            if (mLetter3TextBox.Text.Trim().Length != 0)
            {
                the3Result = Char.ToLower(System.Convert.ToChar(mLetter3TextBox.Text));
            }
            if (mLetter4TextBox.Text.Trim().Length != 0)
            {
                the4Result = Char.ToLower(System.Convert.ToChar(mLetter4TextBox.Text));
            }
            if (mLetter5TextBox.Text.Trim().Length != 0)
            {
                the5Result = Char.ToLower(System.Convert.ToChar(mLetter5TextBox.Text));
            }
            if (mLetter6TextBox.Text.Trim().Length != 0)
            {
                the6Result = Char.ToLower(System.Convert.ToChar(mLetter6TextBox.Text));
            }
            if (mLetter7TextBox.Text.Trim().Length != 0)
            {
                the7Result = Char.ToLower(System.Convert.ToChar(mLetter7TextBox.Text));
            }

            List<char> theTemp = new List<char>(new char[] {the1Result, the2Result, 
                the3Result, the4Result, the5Result, the6Result, the7Result});
         
            if(ThereAreNotMoreThanOneBlankTiles(theTemp))
            {
                mLetters = new List<char>( new char[] {the1Result, the2Result, 
                the3Result, the4Result, the5Result, the6Result, the7Result});
            }
        }

        private void
        //-----------------------------------------------------------
        FillScoringWord
        //-----------------------------------------------------------
            (
            List<ScoringLetter_t> aWord
            )
        {
            if (mScoreLetter1.Text.Trim().Length != 0)
            {
                ScoringLetter_t aLetter = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter1.Text), 
                                                                                    mCB1.SelectedIndex);
                aWord.Add(aLetter);
            }
            if (mScoreLetter2.Text.Trim().Length != 0)
            {
                ScoringLetter_t aLetter = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter2.Text),
                                                                                    mCB2.SelectedIndex);
                aWord.Add(aLetter);
            }
            if (mScoreLetter3.Text.Trim().Length != 0)
            {
                ScoringLetter_t aLetter = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter3.Text),
                                                                                    mCB3.SelectedIndex);
                aWord.Add(aLetter);
            }
            if (mScoreLetter4.Text.Trim().Length != 0)
            {
                ScoringLetter_t aLetter = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter4.Text),
                                                                                    mCB4.SelectedIndex);
                aWord.Add(aLetter);
            }
            if (mScoreLetter5.Text.Trim().Length != 0)
            {
                ScoringLetter_t aLetter = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter5.Text),
                                                                                    mCB5.SelectedIndex);
                aWord.Add(aLetter);
            }
            if (mScoreLetter6.Text.Trim().Length != 0)
            {
                ScoringLetter_t aLetter = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter6.Text),
                                                                                    mCB6.SelectedIndex);
                aWord.Add(aLetter);
            }
            if (mScoreLetter7.Text.Trim().Length != 0)
            {
                ScoringLetter_t aLetter = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter7.Text),
                                                                                    mCB7.SelectedIndex);
                aWord.Add(aLetter);
            }
            if (mScoreLetter8.Text.Trim().Length != 0)
            {
                ScoringLetter_t aLetter = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter8.Text),
                                                                                    mCB8.SelectedIndex);
                aWord.Add(aLetter);
            }
            if (mScoreLetter9.Text.Trim().Length != 0)
            {
                ScoringLetter_t aLetter = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter9.Text),
                                                                                    mCB9.SelectedIndex);
                aWord.Add(aLetter);
            }
            if (mScoreLetter10.Text.Trim().Length != 0)
            {
                ScoringLetter_t aLetter = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter10.Text),
                                                                                    mCB10.SelectedIndex);
                aWord.Add(aLetter);
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

        public void
        //-----------------------------------------------------------
        StartEvent
        //-----------------------------------------------------------
            (
            )
        {
            mLetters.Clear();
            ClearListBox();
            FillLetterList();
        }

        public void
        //-----------------------------------------------------------
        FinishEvent
        //-----------------------------------------------------------
            (
            )
        {
            Reset();
        }

        private void
        //-----------------------------------------------------------
        LoadScorersComboBoxes
        //-----------------------------------------------------------
            (
            )
        {
            string[] theOptions = new string[]{ "ST", "DL", "TL", "DW", "TW", "?" };
            foreach (string s in theOptions)
            {
                mCB1.Items.Add(s);
                mCB2.Items.Add(s);
                mCB3.Items.Add(s);
                mCB4.Items.Add(s);
                mCB5.Items.Add(s);
                mCB6.Items.Add(s); 
                mCB7.Items.Add(s);
                mCB8.Items.Add(s);
                mCB9.Items.Add(s);
                mCB10.Items.Add(s);
            }
            
        }

        private void
        //-----------------------------------------------------------
        SetComboBoxes
        //-----------------------------------------------------------
            (
            )
        {
            mCB1.SelectedIndex = 0;
            mCB2.SelectedIndex = 0;
            mCB3.SelectedIndex = 0;
            mCB4.SelectedIndex = 0;
            mCB5.SelectedIndex = 0;
            mCB6.SelectedIndex = 0;
            mCB7.SelectedIndex = 0;
            mCB8.SelectedIndex = 0;
            mCB9.SelectedIndex = 0;
            mCB10.SelectedIndex = 0;
        }

        private void 
        //-----------------------------------------------------------
        ClearAllTextBoxes
        //-----------------------------------------------------------
            (
            )
        {
            mResultsBox.Items.Clear();
            mScoreLetter1.Clear();
            mScoreLetter2.Clear();
            mScoreLetter3.Clear();
            mScoreLetter4.Clear();
            mScoreLetter5.Clear();
            mScoreLetter6.Clear();
            mScoreLetter7.Clear();
            mScoreLetter8.Clear();
            mScoreLetter9.Clear();
            mScoreLetter10.Clear();
            mLetter1TextBox.Clear();
            mLetter2TextBox.Clear();
            mLetter3TextBox.Clear();
            mLetter4TextBox.Clear();
            mLetter5TextBox.Clear();
            mLetter6TextBox.Clear();
            mLetter7TextBox.Clear();
            mSimpleSearchTextBox.Clear();
        }

        private List<ScoringLetter_t>
         //-----------------------------------------------------------
         BuildScoringWord
         //-----------------------------------------------------------
            (
            )
        {

            ScoringLetter_t aLetter1 = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter1.Text),
                                                          mCB1.SelectedIndex);
            ScoringLetter_t aLetter2 = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter2.Text),
                                                          mCB2.SelectedIndex);
            ScoringLetter_t aLetter3 = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter3.Text),
                                                          mCB3.SelectedIndex);
            ScoringLetter_t aLetter4 = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter4.Text),
                                                          mCB4.SelectedIndex);
            ScoringLetter_t aLetter5 = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter5.Text),
                                                          mCB5.SelectedIndex);
            ScoringLetter_t aLetter6 = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter6.Text),
                                                          mCB6.SelectedIndex);
            ScoringLetter_t aLetter7 = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter7.Text),
                                                          mCB7.SelectedIndex);
            ScoringLetter_t aLetter8 = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter8.Text),
                                                          mCB8.SelectedIndex);
            ScoringLetter_t aLetter9 = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter9.Text),
                                                          mCB9.SelectedIndex);
            ScoringLetter_t aLetter10 = new ScoringLetter_t(System.Convert.ToChar(mScoreLetter10.Text),
                                                          mCB10.SelectedIndex);

            List<ScoringLetter_t> theWord = new List<ScoringLetter_t>{ aLetter1, aLetter2, aLetter3,
                aLetter4, aLetter5, aLetter6, aLetter7, aLetter8, aLetter9, aLetter10};

            return theWord;
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
            StartEvent();

            if (mLetters.Count() > 0)
            {
                DisplayResults( mFirstWord.GetResults( mLetters,
                    mDoubleFirstWordCB.Checked ) );
            }
            else
            {
                mResultsBox.Items.Add("Invaled Entry");
            }

            FinishEvent();
        }

        private void 
        //-----------------------------------------------------------
        HandleSimpleSearchClicked
        //-----------------------------------------------------------
            (
            object sender,
            EventArgs e
            )
        {
            StartEvent();

            if( mSimpleSearchTextBox.Text.Length == 0 )
            {
                mResultsBox.Items.Add("No word to search for");  
            }
            else
            {
                DisplayResults(mSimpleSearch.GetResults(mSimpleSearchTextBox.Text, 
                    mLetters, 
                    mShowSubStringsCB.Checked,
                    mJustMySubStringsCB.Checked));
            }

            mSimpleSearch.Reset();
            FinishEvent();
        }

        private void 
        //-----------------------------------------------------------
        HandleScoreClicked
        //-----------------------------------------------------------
            (
            object sender, 
            EventArgs e
            )
        {
            StartEvent();

            List<ScoringLetter_t> theWord = new List<ScoringLetter_t>();
            FillScoringWord(theWord);
            Int32 theScore = mScorer.StandardScore(theWord);
            string theResult = System.String.Empty;

            foreach (ScoringLetter_t s in theWord)
            {
                theResult += s.mChar;
            }

            mResultsBox.Items.Clear();
            mResultsBox.Items.Add(theResult + " is worth " + theScore + " points");
            
            FinishEvent();
        }

        private void 
        //-----------------------------------------------------------
        HandleClearClicked
        //-----------------------------------------------------------
            (
            object sender, 
            EventArgs e
            )

        {
            StartEvent();

            SetComboBoxes();
            ClearAllTextBoxes();

            FinishEvent();
        }

        private void
        //-----------------------------------------------------------
        HandleAutoScoreClicked
        //-----------------------------------------------------------
            (
            object sender, 
            EventArgs e)
        {
            StartEvent();
            
            FillLetterList();
            string theSub = mSimpleSearchTextBox.Text;
            List<string> theWords = new List<string>();
            theWords = mSimpleSearch.SubSetScores(theWords, theSub, mLetters); // unimplemented

            List<ScoringLetter_t> theScoringWord = new List<ScoringLetter_t>();
            //theScoringWord = BuildScoringWord();

            List<string> theResults = mScorer.SubScore(theWords, theScoringWord, mLetters);  // unimplemented

            FinishEvent();
        }

        private void
        //-----------------------------------------------------------
        HandleMyMatchesClicked
        //-----------------------------------------------------------
            (
            object sender, 
            EventArgs e
            )
        {
            StartEvent();

            List<string> theResults = new List<string>();

            if (mLetters.Count != 0)
            {
                theResults = mMyWords.GetResults(mLetters);
            }
            DisplayResults(theResults);
            
            FinishEvent();
        }


        //-----------------------------------------------------------
        // Member Data
        //-----------------------------------------------------------
        private List<char> mLetters;
        private List<WordResult_t> mSuccessWords;
        private Dictionary_t mDictionary;
        private FirstWord_t mFirstWord;
        private SimpleSearch_t mSimpleSearch;
        private Scorer_t mScorer;
        private MyWords_t mMyWords;
        const char scDefaultChar = '-';

        
        
        
        
    }
}
