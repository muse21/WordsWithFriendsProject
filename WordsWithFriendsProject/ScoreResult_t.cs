using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    class ScoreResult_t
    {
        public ScoreResult_t
            (
            int aScore,
            string aWord,
            int aX,
            int aY
            )
        {
            Score = aScore;
            Word = aWord;
            X = aX;
            Y = aY;
        }

        //---------------------------------------------------------------------
        //  MEMBER DATA
        //---------------------------------------------------------------------
        public int Score { get; set; }
        public string Word { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
