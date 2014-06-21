using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    //-------------------------------------------------------------------------
    class Scorer_t
    //-------------------------------------------------------------------------
    {
        //---------------------------------------------------------------------
        public Scorer_t
        //---------------------------------------------------------------------
            (
            )
        {
            mScoreTable = new ScoreTable_t();
        }

        public List<String>
        //---------------------------------------------------------------------
        ScoreBoardResults
            (
            List<SearchResults_t> aSearchResults
            )
        {
            var theScoredResultStrings = new HashSet<string>();

            foreach (var theResults in aSearchResults)
            {
                int theScore = 0;
                foreach (var theResult in theResults.Results)
                {
                    theResult.Score = ScoreWord(theResult.Word);
                    theScore += ScoreWord(theResult.Word);
                }
                var theMainResult = theResults.Results.FirstOrDefault();
                var theTile = theMainResult.Word.FirstOrDefault();
                string theWord = System.String.Empty;

                theWord += theScore + " - ";

                foreach (var theLetter in theMainResult.Word)
                {
                    theWord += System.Convert.ToString(Char.ToUpper(theLetter.Letter));
                }

                theWord += " - " + theTile.X + " " + theTile.Y;

                theScoredResultStrings.Add(theWord);
            }
            return theScoredResultStrings.ToList();
        }

        public int
        //---------------------------------------------------------------------
        ScoreFirstWord
            (
            string aWord, 
            bool aDoubleScore
            )
        {
            var theScore = 0;

            foreach (char theChar in aWord)
            {
                theScore += mScoreTable.GetScore(theChar);
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

        //---------------------------------------------------------------------
        // Private Functions
        //---------------------------------------------------------------------

        private int
        //---------------------------------------------------------------------
        ScoreWord
            (
            List<Tile_t> aWord
            )
        {
            var theScore = 0;
            var theWordMultiplier = 1;

            foreach (var theTile in aWord)
            {
                Int32 theLetterScore = 0;
                if (!theTile.IsWild)
                {
                    theLetterScore += mScoreTable.GetScore(theTile.Letter);
                }
                var theLetterBonus = 1;

                if (theTile.SearchType == SearchType_t.ePlayed)
                {
                    theTile.Bonus = TileBonus_t.eNone;
                }

                switch (theTile.Bonus)
                {
                    case TileBonus_t.eDoubleLetter:
                        theLetterBonus = 2;
                        break;
                    case TileBonus_t.eTripleLetter:
                        theLetterBonus = 3;
                        break;
                    case TileBonus_t.eDoubleWord:
                        theWordMultiplier = theWordMultiplier * 2;
                        break;
                    case TileBonus_t.eTripleWord:
                        theWordMultiplier = theWordMultiplier * 3;
                        break;
                    case TileBonus_t.eNone:
                    default:
                        theLetterBonus = 1;
                        break;
                }

                theScore += theLetterScore * theLetterBonus;
            }
            theScore = theScore * theWordMultiplier;
            return theScore;
        }

        //---------------------------------------------------------------------
        // Member Data
        //---------------------------------------------------------------------
        ScoreTable_t mScoreTable;
        const Int32 scDouble = 2;
        const Int32 scBingoBonus = 35;
    }
}
