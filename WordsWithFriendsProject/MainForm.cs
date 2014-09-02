using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WordsWithFriendsProject
{
    public partial class MainForm : Form
    {
        public 
        //---------------------------------------------------------------------
        MainForm
            (
            )
        {
            InitializeComponent();
            ClearListBox();

            Letters = new List<char>();
            mDictionary = new Dictionary_t();
            mFirstWord = new FirstWord_t( mDictionary );
            mSimpleSearch = new SimpleSearch_t( mDictionary );
            mSuccessWords = new List<WordResult_t>();
            mScorer = new Scorer_t();
            mMyWords = new MyWords_t(mDictionary);
            mGameBoard = new GameBoard_t();
            mSearcher = new Searcher_t(mDictionary);
            mGames = XmlService_t.GetGames();
            LoadGames();

            mJustMySubStringsCB.Checked = true;
        }

        //---------------------------------------------------------------------
        // private functions
        //---------------------------------------------------------------------
       
        private void 
        //---------------------------------------------------------------------
        LoadGames
            (
            )
        {
            mGamesListBox.Items.Clear();
            if (mGames.Count > 0)
            {
                foreach (string theKey in mGames.Keys)
                {
                    mGamesListBox.Items.Add(theKey);
                }
            }
        }

        private void
        //---------------------------------------------------------------------
        ClearListBox
            (
            )
        {
            mResultsBox.Items.Clear();
        }

        private void
        //---------------------------------------------------------------------
        FillLetterList
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

            theTemp.Sort();

            if(ThereAreNotMoreThanOneBlankTiles(theTemp))
            {
                Letters = new List<char>( new char[] {the1Result, the2Result, 
                the3Result, the4Result, the5Result, the6Result, the7Result});
            }
        }

        private bool
        //---------------------------------------------------------------------
        ThereAreNotMoreThanOneBlankTiles
            (
            List<char> aList
            )
        {
            return !(aList[0] == '?' && aList[1] == '?');
        }

        private void
        //---------------------------------------------------------------------
        DisplayResults
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
        //---------------------------------------------------------------------
        Reset
            (
            )
        {
            Letters.Clear();
            mSuccessWords.Clear();
            mFirstWord.Reset();
        }

        public void
        //---------------------------------------------------------------------
        StartEvent
            (
            )
        {
            Letters.Clear();
            ClearListBox();
            FillLetterList();
            while (Letters.Contains(scDefaultChar)) Letters.Remove(scDefaultChar);
            Letters.Sort();
        }

        public void
        //---------------------------------------------------------------------
        FinishEvent
            (
            )
        {
            Reset();
        }

        private void 
        //----------------------------------------------------------------------
        ClearAllTextBoxes
            (
            )
        {
            mResultsBox.Items.Clear();
            mLetter1TextBox.Clear();
            mLetter2TextBox.Clear();
            mLetter3TextBox.Clear();
            mLetter4TextBox.Clear();
            mLetter5TextBox.Clear();
            mLetter6TextBox.Clear();
            mLetter7TextBox.Clear();
            mSimpleSearchTextBox.Clear();

            ClearGameBoard();
        }

        private void
        //---------------------------------------------------------------------
        FillLettersFromGameBoard
            (
            )
        {
            mA1.Text = System.Convert.ToString(mGameBoard.mBoard[0, 0].Letter);
            mA2.Text = System.Convert.ToString(mGameBoard.mBoard[1, 0].Letter);
            mA3.Text = System.Convert.ToString(mGameBoard.mBoard[2, 0].Letter);
            mA4.Text = System.Convert.ToString(mGameBoard.mBoard[3, 0].Letter);
            mA5.Text = System.Convert.ToString(mGameBoard.mBoard[4, 0].Letter);
            mA6.Text = System.Convert.ToString(mGameBoard.mBoard[5, 0].Letter);
            mA7.Text = System.Convert.ToString(mGameBoard.mBoard[6, 0].Letter);
            mA8.Text = System.Convert.ToString(mGameBoard.mBoard[7, 0].Letter);
            mA9.Text = System.Convert.ToString(mGameBoard.mBoard[8, 0].Letter);
            mA10.Text = System.Convert.ToString(mGameBoard.mBoard[9, 0].Letter);
            mA11.Text = System.Convert.ToString(mGameBoard.mBoard[10, 0].Letter);
            mA12.Text = System.Convert.ToString(mGameBoard.mBoard[11, 0].Letter);
            mA13.Text = System.Convert.ToString(mGameBoard.mBoard[12, 0].Letter);
            mA14.Text = System.Convert.ToString(mGameBoard.mBoard[13, 0].Letter);
            mA15.Text = System.Convert.ToString(mGameBoard.mBoard[14, 0].Letter);

            mB1.Text = System.Convert.ToString(mGameBoard.mBoard[0, 1].Letter);
            mB2.Text = System.Convert.ToString(mGameBoard.mBoard[1, 1].Letter);
            mB3.Text = System.Convert.ToString(mGameBoard.mBoard[2, 1].Letter);
            mB4.Text = System.Convert.ToString(mGameBoard.mBoard[3, 1].Letter);
            mB5.Text = System.Convert.ToString(mGameBoard.mBoard[4, 1].Letter);
            mB6.Text = System.Convert.ToString(mGameBoard.mBoard[5, 1].Letter);
            mB7.Text = System.Convert.ToString(mGameBoard.mBoard[6, 1].Letter);
            mB8.Text = System.Convert.ToString(mGameBoard.mBoard[7, 1].Letter);
            mB9.Text = System.Convert.ToString(mGameBoard.mBoard[8, 1].Letter);
            mB10.Text = System.Convert.ToString(mGameBoard.mBoard[9, 1].Letter);
            mB11.Text = System.Convert.ToString(mGameBoard.mBoard[10, 1].Letter);
            mB12.Text = System.Convert.ToString(mGameBoard.mBoard[11, 1].Letter);
            mB13.Text = System.Convert.ToString(mGameBoard.mBoard[12, 1].Letter);
            mB14.Text = System.Convert.ToString(mGameBoard.mBoard[13, 1].Letter);
            mB15.Text = System.Convert.ToString(mGameBoard.mBoard[14, 1].Letter);

            mC1.Text = System.Convert.ToString(mGameBoard.mBoard[0, 2].Letter);
            mC2.Text = System.Convert.ToString(mGameBoard.mBoard[1, 2].Letter);
            mC3.Text = System.Convert.ToString(mGameBoard.mBoard[2, 2].Letter);
            mC4.Text = System.Convert.ToString(mGameBoard.mBoard[3, 2].Letter);
            mC5.Text = System.Convert.ToString(mGameBoard.mBoard[4, 2].Letter);
            mC6.Text = System.Convert.ToString(mGameBoard.mBoard[5, 2].Letter);
            mC7.Text = System.Convert.ToString(mGameBoard.mBoard[6, 2].Letter);
            mC8.Text = System.Convert.ToString(mGameBoard.mBoard[7, 2].Letter);
            mC9.Text = System.Convert.ToString(mGameBoard.mBoard[8, 2].Letter);
            mC10.Text = System.Convert.ToString(mGameBoard.mBoard[9,2].Letter);
            mC11.Text = System.Convert.ToString(mGameBoard.mBoard[10, 2].Letter);
            mC12.Text = System.Convert.ToString(mGameBoard.mBoard[11, 2].Letter);
            mC13.Text = System.Convert.ToString(mGameBoard.mBoard[12, 2].Letter);
            mC14.Text = System.Convert.ToString(mGameBoard.mBoard[13, 2].Letter);
            mC15.Text = System.Convert.ToString(mGameBoard.mBoard[14, 2].Letter);

            mD1.Text = System.Convert.ToString(mGameBoard.mBoard[0, 3].Letter);
            mD2.Text = System.Convert.ToString(mGameBoard.mBoard[1, 3].Letter);
            mD3.Text = System.Convert.ToString(mGameBoard.mBoard[2, 3].Letter);
            mD4.Text = System.Convert.ToString(mGameBoard.mBoard[3, 3].Letter);
            mD5.Text = System.Convert.ToString(mGameBoard.mBoard[4, 3].Letter);
            mD6.Text = System.Convert.ToString(mGameBoard.mBoard[5, 3].Letter);
            mD7.Text = System.Convert.ToString(mGameBoard.mBoard[6, 3].Letter);
            mD8.Text = System.Convert.ToString(mGameBoard.mBoard[7, 3].Letter);
            mD9.Text = System.Convert.ToString(mGameBoard.mBoard[8, 3].Letter);
            mD10.Text = System.Convert.ToString(mGameBoard.mBoard[9, 3].Letter);
            mD11.Text = System.Convert.ToString(mGameBoard.mBoard[10, 3].Letter);
            mD12.Text = System.Convert.ToString(mGameBoard.mBoard[11, 3].Letter);
            mD13.Text = System.Convert.ToString(mGameBoard.mBoard[12, 3].Letter);
            mD14.Text = System.Convert.ToString(mGameBoard.mBoard[13, 3].Letter);
            mD15.Text = System.Convert.ToString(mGameBoard.mBoard[14, 3].Letter);

            mE1.Text = System.Convert.ToString(mGameBoard.mBoard[0, 4].Letter);
            mE2.Text = System.Convert.ToString(mGameBoard.mBoard[1, 4].Letter);
            mE3.Text = System.Convert.ToString(mGameBoard.mBoard[2, 4].Letter);
            mE4.Text = System.Convert.ToString(mGameBoard.mBoard[3, 4].Letter);
            mE5.Text = System.Convert.ToString(mGameBoard.mBoard[4, 4].Letter);
            mE6.Text = System.Convert.ToString(mGameBoard.mBoard[5, 4].Letter);
            mE7.Text = System.Convert.ToString(mGameBoard.mBoard[6, 4].Letter);
            mE8.Text = System.Convert.ToString(mGameBoard.mBoard[7, 4].Letter);
            mE9.Text = System.Convert.ToString(mGameBoard.mBoard[8, 4].Letter);
            mE10.Text = System.Convert.ToString(mGameBoard.mBoard[9, 4].Letter);
            mE11.Text = System.Convert.ToString(mGameBoard.mBoard[10, 4].Letter);
            mE12.Text = System.Convert.ToString(mGameBoard.mBoard[11, 4].Letter);
            mE13.Text = System.Convert.ToString(mGameBoard.mBoard[12, 4].Letter);
            mE14.Text = System.Convert.ToString(mGameBoard.mBoard[13, 4].Letter);
            mE15.Text = System.Convert.ToString(mGameBoard.mBoard[14, 4].Letter);

            mF1.Text = System.Convert.ToString(mGameBoard.mBoard[0, 5].Letter);
            mF2.Text = System.Convert.ToString(mGameBoard.mBoard[1, 5].Letter);
            mF3.Text = System.Convert.ToString(mGameBoard.mBoard[2, 5].Letter);
            mF4.Text = System.Convert.ToString(mGameBoard.mBoard[3, 5].Letter);
            mF5.Text = System.Convert.ToString(mGameBoard.mBoard[4, 5].Letter);
            mF6.Text = System.Convert.ToString(mGameBoard.mBoard[5, 5].Letter);
            mF7.Text = System.Convert.ToString(mGameBoard.mBoard[6, 5].Letter);
            mF8.Text = System.Convert.ToString(mGameBoard.mBoard[7, 5].Letter);
            mF9.Text = System.Convert.ToString(mGameBoard.mBoard[8, 5].Letter);
            mF10.Text = System.Convert.ToString(mGameBoard.mBoard[9,5].Letter);
            mF11.Text = System.Convert.ToString(mGameBoard.mBoard[10, 5].Letter);
            mF12.Text = System.Convert.ToString(mGameBoard.mBoard[11, 5].Letter);
            mF13.Text = System.Convert.ToString(mGameBoard.mBoard[12, 5].Letter);
            mF14.Text = System.Convert.ToString(mGameBoard.mBoard[13, 5].Letter);
            mF15.Text = System.Convert.ToString(mGameBoard.mBoard[14, 5].Letter);

            mG1.Text = System.Convert.ToString(mGameBoard.mBoard[0, 6].Letter);
            mG2.Text = System.Convert.ToString(mGameBoard.mBoard[1, 6].Letter);
            mG3.Text = System.Convert.ToString(mGameBoard.mBoard[2, 6].Letter);
            mG4.Text = System.Convert.ToString(mGameBoard.mBoard[3, 6].Letter);
            mG5.Text = System.Convert.ToString(mGameBoard.mBoard[4, 6].Letter);
            mG6.Text = System.Convert.ToString(mGameBoard.mBoard[5, 6].Letter);
            mG7.Text = System.Convert.ToString(mGameBoard.mBoard[6, 6].Letter);
            mG8.Text = System.Convert.ToString(mGameBoard.mBoard[7, 6].Letter);
            mG9.Text = System.Convert.ToString(mGameBoard.mBoard[8, 6].Letter);
            mG10.Text = System.Convert.ToString(mGameBoard.mBoard[9,6].Letter);
            mG11.Text = System.Convert.ToString(mGameBoard.mBoard[10, 6].Letter);
            mG12.Text = System.Convert.ToString(mGameBoard.mBoard[11, 6].Letter);
            mG13.Text = System.Convert.ToString(mGameBoard.mBoard[12, 6].Letter);
            mG14.Text = System.Convert.ToString(mGameBoard.mBoard[13, 6].Letter);
            mG15.Text = System.Convert.ToString(mGameBoard.mBoard[14, 6].Letter);

            mH1.Text = System.Convert.ToString(mGameBoard.mBoard[0, 7].Letter);
            mH2.Text = System.Convert.ToString(mGameBoard.mBoard[1, 7].Letter);
            mH3.Text = System.Convert.ToString(mGameBoard.mBoard[2, 7].Letter);
            mH4.Text = System.Convert.ToString(mGameBoard.mBoard[3, 7].Letter);
            mH5.Text = System.Convert.ToString(mGameBoard.mBoard[4, 7].Letter);
            mH6.Text = System.Convert.ToString(mGameBoard.mBoard[5, 7].Letter);
            mH7.Text = System.Convert.ToString(mGameBoard.mBoard[6, 7].Letter);
            mH8.Text = System.Convert.ToString(mGameBoard.mBoard[7, 7].Letter);
            mH9.Text = System.Convert.ToString(mGameBoard.mBoard[8, 7].Letter);
            mH10.Text = System.Convert.ToString(mGameBoard.mBoard[9, 7].Letter);
            mH11.Text = System.Convert.ToString(mGameBoard.mBoard[10, 7].Letter);
            mH12.Text = System.Convert.ToString(mGameBoard.mBoard[11, 7].Letter);
            mH13.Text = System.Convert.ToString(mGameBoard.mBoard[12, 7].Letter);
            mH14.Text = System.Convert.ToString(mGameBoard.mBoard[13, 7].Letter);
            mH15.Text = System.Convert.ToString(mGameBoard.mBoard[14, 7].Letter);

            mI1.Text = System.Convert.ToString(mGameBoard.mBoard[0, 8].Letter);
            mI2.Text = System.Convert.ToString(mGameBoard.mBoard[1, 8].Letter);
            mI3.Text = System.Convert.ToString(mGameBoard.mBoard[2, 8].Letter);
            mI4.Text = System.Convert.ToString(mGameBoard.mBoard[3, 8].Letter);
            mI5.Text = System.Convert.ToString(mGameBoard.mBoard[4, 8].Letter);
            mI6.Text = System.Convert.ToString(mGameBoard.mBoard[5, 8].Letter);
            mI7.Text = System.Convert.ToString(mGameBoard.mBoard[6, 8].Letter);
            mI8.Text = System.Convert.ToString(mGameBoard.mBoard[7, 8].Letter);
            mI9.Text = System.Convert.ToString(mGameBoard.mBoard[8, 8].Letter);
            mI10.Text = System.Convert.ToString(mGameBoard.mBoard[9, 8].Letter);
            mI11.Text = System.Convert.ToString(mGameBoard.mBoard[10, 8].Letter);
            mI12.Text = System.Convert.ToString(mGameBoard.mBoard[11, 8].Letter);
            mI13.Text = System.Convert.ToString(mGameBoard.mBoard[12, 8].Letter);
            mI14.Text = System.Convert.ToString(mGameBoard.mBoard[13, 8].Letter);
            mI15.Text = System.Convert.ToString(mGameBoard.mBoard[14, 8].Letter);

            mJ1.Text = System.Convert.ToString(mGameBoard.mBoard[0, 9].Letter);
            mJ2.Text = System.Convert.ToString(mGameBoard.mBoard[1, 9].Letter);
            mJ3.Text = System.Convert.ToString(mGameBoard.mBoard[2, 9].Letter);
            mJ4.Text = System.Convert.ToString(mGameBoard.mBoard[3, 9].Letter);
            mJ5.Text = System.Convert.ToString(mGameBoard.mBoard[4, 9].Letter);
            mJ6.Text = System.Convert.ToString(mGameBoard.mBoard[5, 9].Letter);
            mJ7.Text = System.Convert.ToString(mGameBoard.mBoard[6, 9].Letter);
            mJ8.Text = System.Convert.ToString(mGameBoard.mBoard[7, 9].Letter);
            mJ9.Text = System.Convert.ToString(mGameBoard.mBoard[8, 9].Letter);
            mJ10.Text = System.Convert.ToString(mGameBoard.mBoard[9, 9].Letter);
            mJ11.Text = System.Convert.ToString(mGameBoard.mBoard[10, 9].Letter);
            mJ12.Text = System.Convert.ToString(mGameBoard.mBoard[11, 9].Letter);
            mJ13.Text = System.Convert.ToString(mGameBoard.mBoard[12, 9].Letter);
            mJ14.Text = System.Convert.ToString(mGameBoard.mBoard[13, 9].Letter);
            mJ15.Text = System.Convert.ToString(mGameBoard.mBoard[14, 9].Letter);

            mK1.Text = System.Convert.ToString(mGameBoard.mBoard[0, 10].Letter);
            mK2.Text = System.Convert.ToString(mGameBoard.mBoard[1, 10].Letter);
            mK3.Text = System.Convert.ToString(mGameBoard.mBoard[2, 10].Letter);
            mK4.Text = System.Convert.ToString(mGameBoard.mBoard[3, 10].Letter);
            mK5.Text = System.Convert.ToString(mGameBoard.mBoard[4, 10].Letter);
            mK6.Text = System.Convert.ToString(mGameBoard.mBoard[5, 10].Letter);
            mK7.Text = System.Convert.ToString(mGameBoard.mBoard[6, 10].Letter);
            mK8.Text = System.Convert.ToString(mGameBoard.mBoard[7, 10].Letter);
            mK9.Text = System.Convert.ToString(mGameBoard.mBoard[8, 10].Letter);
            mK10.Text = System.Convert.ToString(mGameBoard.mBoard[9, 10].Letter);
            mK11.Text = System.Convert.ToString(mGameBoard.mBoard[10, 10].Letter);
            mK12.Text = System.Convert.ToString(mGameBoard.mBoard[11, 10].Letter);
            mK13.Text = System.Convert.ToString(mGameBoard.mBoard[12, 10].Letter);
            mK14.Text = System.Convert.ToString(mGameBoard.mBoard[13, 10].Letter);
            mK15.Text = System.Convert.ToString(mGameBoard.mBoard[14, 10].Letter);

            mL1.Text = System.Convert.ToString(mGameBoard.mBoard[0, 11].Letter);
            mL2.Text = System.Convert.ToString(mGameBoard.mBoard[1, 11].Letter);
            mL3.Text = System.Convert.ToString(mGameBoard.mBoard[2, 11].Letter);
            mL4.Text = System.Convert.ToString(mGameBoard.mBoard[3, 11].Letter);
            mL5.Text = System.Convert.ToString(mGameBoard.mBoard[4, 11].Letter);
            mL6.Text = System.Convert.ToString(mGameBoard.mBoard[5, 11].Letter);
            mL7.Text = System.Convert.ToString(mGameBoard.mBoard[6, 11].Letter);
            mL8.Text = System.Convert.ToString(mGameBoard.mBoard[7, 11].Letter);
            mL9.Text = System.Convert.ToString(mGameBoard.mBoard[8, 11].Letter);
            mL10.Text = System.Convert.ToString(mGameBoard.mBoard[9, 11].Letter);
            mL11.Text = System.Convert.ToString(mGameBoard.mBoard[10, 11].Letter);
            mL12.Text = System.Convert.ToString(mGameBoard.mBoard[11, 11].Letter);
            mL13.Text = System.Convert.ToString(mGameBoard.mBoard[12, 11].Letter);
            mL14.Text = System.Convert.ToString(mGameBoard.mBoard[13, 11].Letter);
            mL15.Text = System.Convert.ToString(mGameBoard.mBoard[14, 11].Letter);

            mM1.Text = System.Convert.ToString(mGameBoard.mBoard[0, 12].Letter);
            mM2.Text = System.Convert.ToString(mGameBoard.mBoard[1, 12].Letter);
            mM3.Text = System.Convert.ToString(mGameBoard.mBoard[2, 12].Letter);
            mM4.Text = System.Convert.ToString(mGameBoard.mBoard[3, 12].Letter);
            mM5.Text = System.Convert.ToString(mGameBoard.mBoard[4, 12].Letter);
            mM6.Text = System.Convert.ToString(mGameBoard.mBoard[5, 12].Letter);
            mM7.Text = System.Convert.ToString(mGameBoard.mBoard[6, 12].Letter);
            mM8.Text = System.Convert.ToString(mGameBoard.mBoard[7, 12].Letter);
            mM9.Text = System.Convert.ToString(mGameBoard.mBoard[8, 12].Letter);
            mM10.Text = System.Convert.ToString(mGameBoard.mBoard[9, 12].Letter);
            mM11.Text = System.Convert.ToString(mGameBoard.mBoard[10, 12].Letter);
            mM12.Text = System.Convert.ToString(mGameBoard.mBoard[11, 12].Letter);
            mM13.Text = System.Convert.ToString(mGameBoard.mBoard[12, 12].Letter);
            mM14.Text = System.Convert.ToString(mGameBoard.mBoard[13, 12].Letter);
            mM15.Text = System.Convert.ToString(mGameBoard.mBoard[14, 12].Letter);

            mN1.Text = System.Convert.ToString(mGameBoard.mBoard[0, 13].Letter);
            mN2.Text = System.Convert.ToString(mGameBoard.mBoard[1, 13].Letter);
            mN3.Text = System.Convert.ToString(mGameBoard.mBoard[2, 13].Letter);
            mN4.Text = System.Convert.ToString(mGameBoard.mBoard[3, 13].Letter);
            mN5.Text = System.Convert.ToString(mGameBoard.mBoard[4, 13].Letter);
            mN6.Text = System.Convert.ToString(mGameBoard.mBoard[5, 13].Letter);
            mN7.Text = System.Convert.ToString(mGameBoard.mBoard[6, 13].Letter);
            mN8.Text = System.Convert.ToString(mGameBoard.mBoard[7, 13].Letter);
            mN9.Text = System.Convert.ToString(mGameBoard.mBoard[8, 13].Letter);
            mN10.Text = System.Convert.ToString(mGameBoard.mBoard[9, 13].Letter);
            mN11.Text = System.Convert.ToString(mGameBoard.mBoard[10, 13].Letter);
            mN12.Text = System.Convert.ToString(mGameBoard.mBoard[11, 13].Letter);
            mN13.Text = System.Convert.ToString(mGameBoard.mBoard[12, 13].Letter);
            mN14.Text = System.Convert.ToString(mGameBoard.mBoard[13, 13].Letter);
            mN15.Text = System.Convert.ToString(mGameBoard.mBoard[14, 13].Letter);

            mO1.Text = System.Convert.ToString(mGameBoard.mBoard[0, 14].Letter);
            mO2.Text = System.Convert.ToString(mGameBoard.mBoard[1, 14].Letter);
            mO3.Text = System.Convert.ToString(mGameBoard.mBoard[2, 14].Letter);
            mO4.Text = System.Convert.ToString(mGameBoard.mBoard[3, 14].Letter);
            mO5.Text = System.Convert.ToString(mGameBoard.mBoard[4, 14].Letter);
            mO6.Text = System.Convert.ToString(mGameBoard.mBoard[5, 14].Letter);
            mO7.Text = System.Convert.ToString(mGameBoard.mBoard[6, 14].Letter);
            mO8.Text = System.Convert.ToString(mGameBoard.mBoard[7, 14].Letter);
            mO9.Text = System.Convert.ToString(mGameBoard.mBoard[8, 14].Letter);
            mO10.Text = System.Convert.ToString(mGameBoard.mBoard[9, 14].Letter);
            mO11.Text = System.Convert.ToString(mGameBoard.mBoard[10, 14].Letter);
            mO12.Text = System.Convert.ToString(mGameBoard.mBoard[11, 14].Letter);
            mO13.Text = System.Convert.ToString(mGameBoard.mBoard[12, 14].Letter);
            mO14.Text = System.Convert.ToString(mGameBoard.mBoard[13, 14].Letter);
            mO15.Text = System.Convert.ToString(mGameBoard.mBoard[14, 14].Letter);
        }

        private void
        //---------------------------------------------------------------------
        ClearGameBoard
            (
            )
        {
            mA1.Clear(); mA2.Clear();  mA3.Clear(); mA4.Clear(); mA5.Clear();
            mA6.Clear(); mA7.Clear(); mA8.Clear(); mA9.Clear(); mA10.Clear();
            mA11.Clear(); mA12.Clear(); mA13.Clear(); mA14.Clear(); mA15.Clear();

            mB1.Clear(); mB2.Clear(); mB3.Clear(); mB4.Clear(); mB5.Clear();
            mB6.Clear(); mB7.Clear(); mB8.Clear(); mB9.Clear(); mB10.Clear();
            mB11.Clear(); mB12.Clear(); mB13.Clear(); mB14.Clear(); mB15.Clear();

            mC1.Clear(); mC2.Clear(); mC3.Clear(); mC4.Clear(); mC5.Clear();
            mC6.Clear(); mC7.Clear(); mC8.Clear(); mC9.Clear(); mC10.Clear();
            mC11.Clear(); mC12.Clear(); mC13.Clear(); mC14.Clear(); mC15.Clear();

            mD1.Clear(); mD2.Clear(); mD3.Clear(); mD4.Clear(); mD5.Clear();
            mD6.Clear(); mD7.Clear(); mD8.Clear(); mD9.Clear(); mD10.Clear();
            mD11.Clear(); mD12.Clear(); mD13.Clear(); mD14.Clear(); mD15.Clear();

            mE1.Clear(); mE2.Clear(); mE3.Clear(); mE4.Clear(); mE5.Clear();
            mE6.Clear(); mE7.Clear(); mE8.Clear(); mE9.Clear(); mE10.Clear();
            mE11.Clear(); mE12.Clear(); mE13.Clear(); mE14.Clear(); mE15.Clear();

            mF1.Clear(); mF2.Clear(); mF3.Clear(); mF4.Clear(); mF5.Clear();
            mF6.Clear(); mF7.Clear(); mF8.Clear(); mF9.Clear(); mF10.Clear();
            mF11.Clear(); mF12.Clear(); mF13.Clear(); mF14.Clear(); mF15.Clear();

            mG1.Clear(); mG2.Clear(); mG3.Clear(); mG4.Clear(); mG5.Clear();
            mG6.Clear(); mG7.Clear(); mG8.Clear(); mG9.Clear(); mG10.Clear();
            mG11.Clear(); mG12.Clear(); mG13.Clear(); mG14.Clear(); mG15.Clear();

            mH1.Clear(); mH2.Clear(); mH3.Clear(); mH4.Clear(); mH5.Clear();
            mH6.Clear(); mH7.Clear(); mH8.Clear(); mH9.Clear(); mH10.Clear();
            mH11.Clear(); mH12.Clear(); mH13.Clear(); mH14.Clear(); mH15.Clear();

            mI1.Clear(); mI2.Clear(); mI3.Clear(); mI4.Clear(); mI5.Clear();
            mI6.Clear(); mI7.Clear(); mI8.Clear(); mI9.Clear(); mI10.Clear();
            mI11.Clear(); mI12.Clear(); mI13.Clear(); mI14.Clear(); mI15.Clear();

            mJ1.Clear(); mJ2.Clear(); mJ3.Clear(); mJ4.Clear(); mJ5.Clear();
            mJ6.Clear(); mJ7.Clear(); mJ8.Clear(); mJ9.Clear(); mJ10.Clear();
            mJ11.Clear(); mJ12.Clear(); mJ13.Clear(); mJ14.Clear(); mJ15.Clear();

            mK1.Clear(); mK2.Clear(); mK3.Clear(); mK4.Clear(); mK5.Clear();
            mK6.Clear(); mK7.Clear(); mK8.Clear(); mK9.Clear(); mK10.Clear();
            mK11.Clear(); mK12.Clear(); mK13.Clear(); mK14.Clear(); mK15.Clear();

            mL1.Clear(); mL2.Clear(); mL3.Clear(); mL4.Clear(); mL5.Clear();
            mL6.Clear(); mL7.Clear(); mL8.Clear(); mL9.Clear(); mL10.Clear();
            mL11.Clear(); mL12.Clear(); mL13.Clear(); mL14.Clear(); mL15.Clear();

            mM1.Clear(); mM2.Clear(); mM3.Clear(); mM4.Clear(); mM5.Clear();
            mM6.Clear(); mM7.Clear(); mM8.Clear(); mM9.Clear(); mM10.Clear();
            mM11.Clear(); mM12.Clear(); mM13.Clear(); mM14.Clear(); mM15.Clear();

            mN1.Clear(); mN2.Clear(); mN3.Clear(); mN4.Clear(); mN5.Clear();
            mN6.Clear(); mN7.Clear(); mN8.Clear(); mN9.Clear(); mN10.Clear();
            mN11.Clear(); mN12.Clear(); mN13.Clear(); mN14.Clear(); mN15.Clear();

            mO1.Clear(); mO2.Clear(); mO3.Clear(); mO4.Clear(); mO5.Clear();
            mO6.Clear(); mO7.Clear(); mO8.Clear(); mO9.Clear(); mO10.Clear();
            mO11.Clear(); mO12.Clear(); mO13.Clear(); mO14.Clear(); mO15.Clear();
        }

        private void
        //---------------------------------------------------------------------
        CopyGameBoardValues
            (
            GameBoard_t aSourceBoard,
            GameBoard_t aDestinationBoard
            )
        {
            for( int y = 0; y < 15; ++y)
            {
                for( int x = 0; x< 15; ++x  )
                {
                    aDestinationBoard.mBoard[x, y].Letter = aSourceBoard.mBoard[x, y].Letter;
                }
            }
        }
        
        //---------------------------------------------------------------------
        // Event Handlers
        //---------------------------------------------------------------------

        private void 
        //---------------------------------------------------------------------
        HandleGoClicked
            (
            object sender,
            EventArgs e
            )
        {
            StartEvent();

            if (Letters.Count() > 0)
            {
                DisplayResults( mFirstWord.GetResults( Letters,
                    mDoubleFirstWordCB.Checked ) );
            }
            else
            {
                mResultsBox.Items.Add("Invalid Entry");
            }

            FinishEvent();
        }

        private void 
        //---------------------------------------------------------------------
        HandleSimpleSearchClicked
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
                    Letters, 
                    mShowSubStringsCB.Checked,
                    mJustMySubStringsCB.Checked));
            }

            mSimpleSearch.Reset();
            FinishEvent();
        }

        private void 
        //---------------------------------------------------------------------
        HandleClearClicked
            (
            object sender, 
            EventArgs e
            )

        {
            StartEvent();
            ClearAllTextBoxes();
            FinishEvent();
        }

        private void
        //---------------------------------------------------------------------
        HandleMyMatchesClicked
            (
            object sender, 
            EventArgs e
            )
        {
            StartEvent();

            List<string> theResults = new List<string>();

            if (Letters.Count != 0)
            {
                theResults = mMyWords.GetResults(Letters);
            }
            DisplayResults(theResults);
            
            FinishEvent();
        }
        
        private void
        //---------------------------------------------------------------------
        HandlePlaceWordButtonClicked
            (
            object sender,
            EventArgs e
            )
        {

        }

        private void
        //---------------------------------------------------------------------
        HandleSearchClicked
            (
            object sender,
            EventArgs e
            )
        {
            StartEvent();

            if (Letters.Count() > 0)
            {
                var theSearchWords = mSearcher.SearchBoard(Letters, mGameBoard);
                List<ScoreResult_t> theResults = mScorer.ScoreBoardResults(theSearchWords);

                var theSortedResults = (from aResult in theResults
                                       orderby aResult.Score descending
                                       select aResult).Take(25);


                foreach (var theResult in theSortedResults)
                {
                    string theFinalResult = theResult.Score +
                                            " - " +
                                            theResult.Word +
                                            " - " +
                                            theResult.X +
                                            " " +
                                            theResult.Y;
                    mResultsBox.Items.Add(theFinalResult);

                }
            }
            else
            {
                mResultsBox.Items.Add("Invalid Entry");
            }
            FinishEvent();
        }

        private void
        //---------------------------------------------------------------------
        HandleLoadGameClicked
            (
            object sender,
            EventArgs e
            )
        {
            if (mGamesListBox.SelectedItem == null)
            {
                return;
            }
            if (mGames.ContainsKey((string)mGamesListBox.SelectedItem))
            {
                CopyGameBoardValues(mGames[(string)mGamesListBox.SelectedItem], mGameBoard );
            }

            FillLettersFromGameBoard();

            // TODO:  calculate letters remaining when that feature is added
        }

        private void
        //---------------------------------------------------------------------
        HandleGameNameTextChanged
            (
            object sender, 
            EventArgs e
            )
        {
            if ((sender as TextBox).MaxLength == (sender as TextBox).TextLength) SendKeys.Send("{TAB}");
        }

        private void
        //---------------------------------------------------------------------
        HandleGameNameTextBoxKeyPress
            (
            object sender,
            KeyPressEventArgs e
            )
        {
            if( e.KeyChar == Convert.ToChar( Keys.Return ) )
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void 
        //---------------------------------------------------------------------
        HandleSaveButtonClick
            (
            object sender,
            EventArgs e
            )
        {
            if(mGamesListBox.SelectedItem == null ||
               !mGames.ContainsKey((string)mGamesListBox.SelectedItem) )
            {
                return;
            }
            CopyGameBoardValues(mGameBoard, mGames[(string)mGamesListBox.SelectedItem]);
        }

        private void
        //---------------------------------------------------------------------
        HandleDeleteGameClick
            (
            object sender, 
            EventArgs e
            )
        {
            if( mGamesListBox.SelectedItem == null)
            {
                return;
            }
            if(mGames.ContainsKey((string)mGamesListBox.SelectedItem))
            {
                mGames.Remove((string)mGamesListBox.SelectedItem);
            }
            LoadGames();
        }
        
        private void
        //---------------------------------------------------------------------
        HandleNewGameClicked
            (
            object sender,
            EventArgs e
            )
        {
            string theKey = mGameNameTextBox.Text;
            if (theKey == ""  ||
                mGames.ContainsKey(theKey) )
            {
                return;
            }
            GameBoard_t theValue = new GameBoard_t();
            CopyGameBoardValues(mGameBoard, theValue);

            mGames.Add(theKey, theValue);
            mGamesListBox.Items.Add(mGameNameTextBox.Text);
            mGameNameTextBox.Text = "";
        }

        private void
        //---------------------------------------------------------------------
        HandleTileBoxTextChanged
            (
            object sender, 
            EventArgs e
            )
        {
            if ((sender as TextBox).MaxLength == (sender as TextBox).TextLength) SendKeys.Send("{TAB}");
        }

        private void 
        //---------------------------------------------------------------------
        HandleFormClosing
            (
            object sender, 
            FormClosingEventArgs e
            )
        {
            XmlService_t.SaveGames(mGames);
        }

        //---------------------------------------------------------------------
        // Member Data
        //---------------------------------------------------------------------
        private List<char> Letters;
        private List<WordResult_t> mSuccessWords;
        private Dictionary_t mDictionary;
        private FirstWord_t mFirstWord;
        private SimpleSearch_t mSimpleSearch;
        private Scorer_t mScorer;
        private MyWords_t mMyWords;
        private GameBoard_t mGameBoard;
        private Searcher_t mSearcher;
        private Dictionary<string, GameBoard_t> mGames;
        const char scDefaultChar = '_';

        //---------------------------------------------------------------------
        // UGLY HANDLERS UPDATE THE GAMEBOARD
        //---------------------------------------------------------------------

        private void
        //---------------------------------------------------------------------
        GameBoardTileTextChanged
            (
            object sender,
            int aX, 
            int aY
            )
        {
            if ((sender as TextBox).MaxLength == (sender as TextBox).TextLength)
            {
                mGameBoard.mBoard[aX, aY].Letter = System.Convert.ToChar((sender as TextBox).Text);
                mGameBoard.mBoard[aX, aY].SearchType = SearchType_t.ePlayed;
                (sender as TextBox).Text = System.Convert.ToString(System.Convert.ToChar((sender as TextBox).Text));
            }
            else
            {
                mGameBoard.mBoard[aX, aY].Letter = ' ';
                mGameBoard.mBoard[aX, aY].SearchType = SearchType_t.eDirty;
            }
            //if( (sender as TextBox).MaxLength == (sender as TextBox).TextLength)
            //{
            //    (sender as TextBox).BackColor = System.Drawing.Color.Yellow;
            //}
        }

        private void HandlemA1TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 0, 0);
        }

        private void HandlemA2TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 1, 0);
        }

        private void HandlemA3TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 2, 0);
        }

        private void HandlemA4TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 3, 0);
        }

        private void HandlemA5TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 4, 0);
        }

        private void HandlemA6TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 5, 0);
        }

        private void HandlemA7TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 6, 0);
        }

        private void HandlemA8TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 7, 0);
        }

        private void HandlemA9TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 8, 0);
        }

        private void HandlemA10TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 9, 0);
        }

        private void HandlemA11TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 10, 0);
        }

        private void HandlemA12TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 11, 0);
        }

        private void HandlemA13TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 12, 0);
        }

        private void HandlemA14TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 13, 0);
        }

        private void HandlemA15TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 14, 0);
        }

        private void HandlemB1TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 0, 1);
        }

        private void HandlemB2TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 1, 1);
        }

        private void HandlemB3TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 2, 1);
        }

        private void HandlemB4TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 3, 1);
        }

        private void HandlemB5TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 4, 1);
        }

        private void HandlemB6TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 5, 1);
        }

        private void HandlemB7TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 6, 1);
        }

        private void HandlemB8TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 7, 1);
        }

        private void HandlemB9TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 8, 1);
        }

        private void HandlemB10TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 9, 1);
        }

        private void HandlemB11TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 10, 1);
        }

        private void HandlemB12TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 11, 1);
        }

        private void HandlemB13TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 12, 1);
        }

        private void HandlemB14TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 13, 1);
        }

        private void HandlemB15TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 14, 1);
        }

        private void HandlemC1TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 0, 2);
        }

        private void HandlemC2TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 1, 2);
        }

        private void HandlemC3TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 2, 2);
        }

        private void HandlemC4TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 3, 2);
        }

        private void HandlemC5TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 4, 2);
        }

        private void HandlemC6TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 5, 2);
        }

        private void HandlemC7TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 6, 2);
        }

        private void HandlemC8TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 7, 2);
        }

        private void HandlemC9TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 8, 2);
        }

        private void HandlemC10TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 9, 2);
        }

        private void HandlemC11TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 10, 2);
        }

        private void HandlemC12TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 11, 2);
        }

        private void HandlemC13TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 12, 2);
        }

        private void HandlemC14TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 13, 2);
        }

        private void HandlemC15TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 14, 2);
        }

        private void HandlemD1TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 0, 3);
        }

        private void HandlemD2TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 1, 3);
        }

        private void HandlemD3TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 2, 3);
        }

        private void HandlemD4TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 3, 3);
        }

        private void HandlemD5TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 4, 3);
        }

        private void HandlemD6TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 5, 3);
        }

        private void HandlemD7TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 6, 3); 
        }

        private void HandlemD8TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 7, 3);
        }

        private void HandlemD9TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 8, 3);
        }

        private void HandlemD10TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 9, 3);
        }

        private void HandlemD11TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 10, 3);
        }

        private void HandlemD12TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 11, 3);
        }

        private void HandlemD13TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 12, 3);
        }

        private void HandlemD14TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 13, 3);
        }

        private void HandlemD15TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 14, 3);
        }

        private void HandlemE1TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 0, 4);
        }

        private void HandlemE2TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 1, 4);
        }

        private void HandlemE3TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 2, 4);
        }

        private void HandlemE4TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 3, 4);
        }

        private void HandlemE5TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 4, 4);
        }

        private void HandlemE6TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 5, 4);
        }

        private void HandlemE7TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 6, 4);
        }

        private void HandlemE8TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 7, 4);
        }

        private void HandlemE9TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 8, 4);
        }

        private void HandlemE10TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 9, 4);
        }

        private void HandlemE11TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 10, 4);
        }

        private void HandlemE12TextChanged(object sender, EventArgs e) 
        {
            GameBoardTileTextChanged(sender, 11, 4);
        }

        private void HandlemE13TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 12, 4);
        }

        private void HandlemE14TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 13, 4);
        }

        private void HandlemE15TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 14, 4);
        }

        private void HandlemF1TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 0, 5);
        }

        private void HandlemF2TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 1, 5);
        }

        private void HandlemF3TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 2, 5);           
        }

        private void HandlemF4TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 3, 5);
        }

        private void HandlemF5TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 4, 5);
        }

        private void HandlemF6TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 5, 5);
        }

        private void HandlemF7TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 6, 5);
        }

        private void HandlemF8TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 7, 5);
        }

        private void HandlemF9TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 8, 5);
        }

        private void HandlemF10TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 9, 5);
        }

        private void HandlemF11TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 10, 5);
        }

        private void HandlemF12TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 11, 5);
        }

        private void HandlemF13TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 12, 5);
        }

        private void HandlemF14TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 13, 5);
        }

        private void HandlemF15TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 14, 5);
        }

        private void HandlemG1TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 0, 6);
        }

        private void HandlemG2TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 1, 6);
        }

        private void HandlemG3TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 2, 6);
        }

        private void HandlemG4TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 3, 6);
        }

        private void HandlemG5TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 4, 6);
        }

        private void HandlemG6TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 5, 6);
        }

        private void HandlemG7TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 6, 6);
        }

        private void HandlemG8TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 7, 6);
        }

        private void HandlemG9TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 8, 6);
        }

        private void HandlemG10TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 9, 6);
        }

        private void HandlemG11TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 10, 6);
        }

        private void HandlemG12TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 11, 6);
        }

        private void HandlemG13TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 12, 6);
        }

        private void HandlemG14TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 13, 6);
        }

        private void HandlemG15TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 14, 6);
        }

        private void HandlemH1TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 0, 7);
        }

        private void HandlemH2TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 1, 7);
        }

        private void HandlemH3TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 2, 7);
        }

        private void HandlemH4TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 3, 7);
        }

        private void HandlemH5TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 4, 7);
        }

        private void HandlemH6TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 5, 7);
        }

        private void HandlemH7TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 6, 7);
        }

        private void HandlemH8TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 7, 7);
        }

        private void HandlemH9TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 8, 7);
        }

        private void HandlemH10TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 9, 7);
        }

        private void HandlemH11TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 10, 7);
        }

        private void HandlemH12TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 11, 7);
        }

        private void HandlemH13TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 12, 7);
        }

        private void HandlemH14TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 13, 7);
        }

        private void HandlemH15TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 14, 7);
        }

        private void HandlemI1TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 0, 8);
        }

        private void HandlemI2TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 1, 8);
        }

        private void HandlemI3TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 2, 8);
        }

        private void HandlemI4TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 3, 8);
        }

        private void HandlemI5TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 4, 8);
        }

        private void HandlemI6TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 5, 8);
        }

        private void HandlemI7TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 6, 8);
        }

        private void HandlemI8TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 7, 8);
        }

        private void HandlemI9TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 8, 8);
        }

        private void HandlemI10TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 9, 8);
        }

        private void HandlemI11TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 10, 8);
        }

        private void HandlemI12TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 11, 8);
        }

        private void HandlemI13TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 12, 8);
        }

        private void HandlemI14TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 13, 8);
        }

        private void HandlemI15TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 14, 8);
        }

        private void HandlemJ1TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 0, 9);
        }

        private void HandlemJ2TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 1, 9);
        }

        private void HandlemJ3TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 2, 9);
        }

        private void HandlemJ4extChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 3, 9);
        }

        private void HandlemJ5TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 4, 9);
        }

        private void HandlemJ6TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 5, 9);
        }

        private void HandlemJ7TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 6, 9);
        }

        private void HandlemJ8TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 7, 9);
        }

        private void HandlemJ9TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 8, 9);
        }

        private void HandlemJ10TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 9, 9);
        }

        private void HandlemJ11TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 10, 9);
        }

        private void HandlemJ12TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 11, 9);
        }

        private void HandlemJ13TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 12, 9);
        }

        private void HandlemJ14TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 13, 9);
        }

        private void HandlemJ15TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 14, 9);
        }

        private void HandlemK1TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 0, 10);
        }

        private void HandlemK2TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 1, 10);
        }

        private void HandlemK3TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 2, 10);
        }

        private void HandlemK4TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 3, 10);
        }

        private void HandlemK5TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 4, 10);
        }

        private void HandlemK6TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 5, 10);
        }

        private void HandlemK7TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 6, 10);
        }

        private void HandlemK8TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 7, 10);
        }

        private void HandlemK9TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 8, 10);
        }

        private void HandlemK10TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 9, 10);
        }

        private void HandlemK11TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 10, 10);
        }

        private void HandlemK12TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 11, 10);
        }

        private void HandleMk13TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 12, 10);
        }

        private void HandlemK14TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 13, 10);
        }

        private void HandlemK15TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 14, 10);
        }

        private void HandlemL1TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 0, 11);
        }

        private void HandlemL2TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 1, 11);
        }

        private void HandlemL3TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 2, 11);
        }

        private void HandlemL4TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 3, 11);
        }

        private void HandlemL5TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 4, 11);
        }

        private void HandlemL6TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 5, 11);
        }

        private void HandlemL7TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 6, 11);
        }

        private void HandlemL8TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 7, 11);
        }

        private void HandlemL9TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 8, 11);
        }

        private void HandlemL10TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 9, 11);
        }

        private void HandlemL11TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 10, 11);
        }

        private void HandlemL12TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 11, 11);
        }

        private void HandlemL13TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 12, 11);
        }

        private void HandlemL14TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 13, 11);
        }

        private void HandlemL15TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 14, 11);
        }

        private void HandlemM1TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 0, 12);
        }

        private void HandlemM2TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 1, 12);
        }

        private void HandlemM3TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 2, 12);
        }

        private void HandlemM4TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 3, 12);
        }

        private void HandlemM5TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 4, 12);
        }

        private void HandlemM6TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 5, 12);
        }

        private void HandlemM7TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 6, 12);
        }

        private void HandlemM8TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 7, 12);
        }

        private void HandlemM9TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 8, 12);
        }

        private void HandlemM10TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 9, 12);
        }

        private void HandlemM11TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 10, 12);
        }

        private void HandlemM12TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 11, 12);
        }

        private void HandlemM13TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 12, 12);
        }

        private void HandlemM14TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 13, 12);
        }

        private void HandlemM15TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 14, 12);
        }

        private void HandlemN1TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 0, 13);
        }

        private void HandlemN2TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 1, 13);
        }

        private void HandlemN3TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 2, 13);
        }

        private void HandlemN4TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 3, 13);
        }

        private void HandlemN5TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 4, 13);
        }

        private void HandlemN6TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 5, 13);
        }

        private void HandlemN7TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 6, 13);
        }

        private void HandlemN8TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 7, 13);
        }

        private void HandlemN9TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender,8, 13);
        }

        private void HandlemN10TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 9, 13);
        }

        private void HandlemN11TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 10, 13);
        }

        private void HandlemN12TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 11, 13);
        }

        private void HandlemN13TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 12, 13);
        }

        private void HandlemN14TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 13, 13);
        }

        private void HandlemN15TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 14, 13);
        }

        private void HandlemO1TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 0, 14);
        }

        private void HandlemO2TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 1, 14);
        }

        private void HandlemO3TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 2, 14);
        }

        private void HandlemO4TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 3, 14);
        }

        private void HandlemO5TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 4, 14);
        }

        private void HandlemO6TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 5, 14);
        }

        private void HandlemO7TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 6, 14);
        }

        private void HandlemO8TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 7, 14);
        }

        private void HandlemO9TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 8, 14);
        }

        private void HandlemO10TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 9, 14);
        }

        private void HandlemO11TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 10, 14);
        }

        private void HandlemO12TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 11, 14);
        }

        private void HandlemO13TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 12, 14);
        }

        private void HandlemO14TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 13, 14);
        }

        private void HandlemO15TextChanged(object sender, EventArgs e)
        {
            GameBoardTileTextChanged(sender, 14, 14);
        }

        


    }
}
