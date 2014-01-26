using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    //-----------------------------------------------------------
    class ScoringLetter_t
    {
        //-----------------------------------------------------------
        public ScoringLetter_t
        //-----------------------------------------------------------
            (
            char aChar,
            int aIndex
            )
        {
            mChar = aChar;
            mIndex = aIndex;
        }

        //-----------------------------------------------------------
        // Member Data
        //-----------------------------------------------------------
        public char mChar;
        public int mIndex;
    }

    //-----------------------------------------------------------
    class ScoringWord_t
    {
        //-----------------------------------------------------------
        public ScoringWord_t
        //-----------------------------------------------------------
            (
            )
        {
            mLetters = new List<ScoringLetter_t>();
        }

        public void
        //-----------------------------------------------------------
        Add
        //-----------------------------------------------------------
            (
            ScoringLetter_t aLetter
            )
        {
            mLetters.Add(aLetter);
        }

        public int
        //-----------------------------------------------------------
        Count
        //-----------------------------------------------------------
            (
            )
        {
            return mLetters.Count();
        }
        //-----------------------------------------------------------
        // Member Data
        //-----------------------------------------------------------
        List<ScoringLetter_t> mLetters;
    }
}
