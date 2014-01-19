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
            string aWord
            )
        {
            Int32 theScore = 0;

            foreach (char c in aWord)
            {
                theScore += mScoreTable.GetScore(c);
            }

            if (aWord.Length > 4)
            {
                theScore = theScore * scDouble;
            }

            if (aWord.Length == 7)
            {
                theScore += scBingoBonus;
            }

            return theScore;
        }

        //-----------------------------------------------------------
        // Private Functions
        //-----------------------------------------------------------


        //-----------------------------------------------------------
        // Member Data
        //-----------------------------------------------------------
        ScoreTable_t mScoreTable;
        const Int32 scDouble = 2;
        const Int32 scBingoBonus = 35;
    }
}
