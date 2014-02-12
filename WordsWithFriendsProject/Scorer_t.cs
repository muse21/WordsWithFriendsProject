using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    //-----------------------------------------------------------
    class Scorer_t
    //-----------------------------------------------------------
    {
        //-----------------------------------------------------------
        // Public Functions
        //-----------------------------------------------------------
        
        //-----------------------------------------------------------
        public Scorer_t
        //-----------------------------------------------------------
            (
            )
        {
            mScoreTable = new ScoreTable_t();
        }

        public Int32
        //-----------------------------------------------------------
        ScoreFirstWord
        //-----------------------------------------------------------
            (
            string aWord, 
            bool aDoubleScore
            )
        {
            Int32 theScore = 0;

            foreach (char c in aWord)
            {
                theScore += mScoreTable.GetScore(c);
            }

            if (aWord.Length > 4 && aDoubleScore )
            {
                theScore = (Int32)(theScore * scDouble);
            }

            if (aWord.Length == 7)
            {
                theScore += scBingoBonus;
            }

            return theScore;
        }

        public Int32
        //-----------------------------------------------------------
        StandardScore
        //-----------------------------------------------------------
            (
            List<ScoringLetter_t> aWord
            )
        {
            Int32 theScore = 0;
            Int32 theLetterMultiplier = 0;
            Int32 theWordMultiplier = 1;
            Int32 theTemp = 0;
            Int32 theScoreHolder = 0;

            foreach(ScoringLetter_t s in aWord)
            {
                theTemp = s.mIndex;
                theLetterMultiplier = GetLetterMultiplier(theTemp);
                theWordMultiplier = theWordMultiplier * GetWordMultiplier(theTemp);
                theScoreHolder = mScoreTable.GetScore(s.mChar);
                theScore = theScore + (Int32)(theScoreHolder * theLetterMultiplier);
            }

            theScore = theScore * theWordMultiplier;

            return theScore;
        }

        public List<string>
            SubScore(List<string> aWordList, List<ScoringLetter_t> aList, List<char> aLetters) { return aWordList; }

        //-----------------------------------------------------------
        // Private Functions
        //-----------------------------------------------------------

        private Int32
        //-----------------------------------------------------------
        GetLetterMultiplier
        //-----------------------------------------------------------
            (
            Int32 aNum
            )
        {
            Int32 theValue = 0;
            switch (aNum)
            {
                case 1:
                    theValue = 2;
                    break;
                case 2:
                    theValue = 3;
                    break;
                case 5:
                    theValue = 0;
                    break;
                default:
                    theValue = 1;
                    break;
            }
            return theValue;
        }

        private Int32
        //-----------------------------------------------------------
        GetWordMultiplier
        //-----------------------------------------------------------
            (
            Int32 aNum
            )
        {
            Int32 theValue = 0;
            switch (aNum)
            {
                case 3:
                    theValue = 2;
                    break;
                case 4:
                    theValue = 3;
                    break;
                default:
                    theValue = 1;
                    break;
            }
            return theValue;
        }
        //-----------------------------------------------------------
        // Member Data
        //-----------------------------------------------------------
        ScoreTable_t mScoreTable;
        const Int32 scDouble = 2;
        const Int32 scBingoBonus = 35;
    }
}
