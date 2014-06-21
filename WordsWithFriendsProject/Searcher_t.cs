using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    class Searcher_t
    {
        public Searcher_t
            (
            Dictionary_t aDictionary
            )
        {
            mDictionary = aDictionary;
            mMyWords = new MyWords_t(mDictionary);
            mLetters = new List<Letter_t>();
            mAlphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 
                's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        }

        //---------------------------------------------------------------------
        public List< SearchResults_t >
        SearchBoard
            (
            List<char> aLetters,
            GameBoard_t aBoard
            )
        {
            mLetters.Clear();
            var theResultsList = new List< SearchResults_t >();
            foreach ( var theLetter in aLetters )
            {
                mLetters.Add(new Letter_t(theLetter, theLetter == '?'));
            }
            mBoard = aBoard;
            mBoard.SetAllTilesSearchType();

            for (int i = 0; i < scBoardDimension; ++i)
            {
                for( int j = 0; j < scBoardDimension; ++j )
                {
                    var theType = aBoard.mBoard[j, i].SearchType;
                    switch( theType )
                    {
                        case (SearchType_t.eAll): //1111
                            foreach( var theResults in AllResults(aBoard.mBoard[j,i]))
                            {
                                theResultsList.Add(theResults);
                            }
                            break;
                        case (SearchType_t.eAboveBelowRight): // 1110
                            foreach( var theResults in AboveBelowRightResults( aBoard.mBoard[j,i]))
                            {
                                theResultsList.Add(theResults);
                            }
                            break;
                        case (SearchType_t.eAboveLeftRight): // 1101
                            foreach( var theResults in AboveLeftRightResults(aBoard.mBoard[j, i]))
                            {
                                theResultsList.Add(theResults);
                            }
                            break;
                        case (SearchType_t.eAboveRight): // 1100
                            foreach( var theResults in AboveRightResults(aBoard.mBoard[j, i]))
                            {
                                theResultsList.Add(theResults);
                            }
                            break;
                        case (SearchType_t.eAboveBelowLeft): // 1011
                            foreach (var theResults in AboveBelowLeftResults(aBoard.mBoard[j, i]))
                            {
                                theResultsList.Add(theResults);
                            }
                            break;
                        case (SearchType_t.eAboveBelow): // 1010
                            foreach (var theResults in AboveBelowResults(aBoard.mBoard[j, i]))
                            {
                                theResultsList.Add(theResults);
                            }
                            break;
                        case (SearchType_t.eAboveLeft): // 1001
                            foreach (var theResults in AboveLeftResults(aBoard.mBoard[j, i]))
                            {
                                theResultsList.Add(theResults);
                            }
                            break;
                        case (SearchType_t.eAbove): // 1000
                            foreach (var theResults in AboveResults(aBoard.mBoard[j, i]))
                            {
                                theResultsList.Add(theResults);
                            }
                            break;
                        case (SearchType_t.eBelowRightLeft): // 0111
                            foreach (var theResults in BelowRightLeftResults(aBoard.mBoard[j, i]))
                            {
                                theResultsList.Add(theResults);
                            }
                            break;
                        case (SearchType_t.eBelowRight): // 0110
                            foreach (var theResults in BelowRightResults(aBoard.mBoard[j, i]))
                            {
                                theResultsList.Add(theResults);
                            }
                            break;
                        case (SearchType_t.eRightLeft): // 0101
                            foreach (var theResults in RightLeftResults(aBoard.mBoard[j, i]))
                            {
                                theResultsList.Add(theResults);
                            }
                            break;
                        case (SearchType_t.eRight): // 0100
                            foreach (var theResults in RightResults(aBoard.mBoard[j, i]))
                            {
                                theResultsList.Add(theResults);
                            }
                            break;
                        case (SearchType_t.eBelowLeft): // 0011
                            foreach (var theResults in BelowLeftResults(aBoard.mBoard[j, i]))
                            {
                                theResultsList.Add(theResults);
                            }
                            break;
                        case (SearchType_t.eBelow): // 0010
                            foreach (var theResults in BelowResults(aBoard.mBoard[j, i]))
                            {
                                theResultsList.Add(theResults);
                            }
                            break;
                        case (SearchType_t.eLeft): // 0001
                            foreach (var theResults in LeftResults(aBoard.mBoard[j, i]))
                            {
                                theResultsList.Add(theResults);
                            }
                            break;
                        case( SearchType_t.eBlank ): // 0000
                        default:
                            // do nothing
                            break;
                    }
                }
            }
            return theResultsList;
        }



        private List<SearchResults_t> 
        //---------------------------------------------------------------------
        AllResults
            (
            Tile_t aTile
            )
        {
            return new List<SearchResults_t>();
        }

        private List<SearchResults_t>
        //---------------------------------------------------------------------
        AboveBelowRightResults
            (
            Tile_t aTile
            )
        {
            return new List<SearchResults_t>();
        }
        
        private List<SearchResults_t>
        //---------------------------------------------------------------------
        AboveLeftRightResults
            (
            Tile_t aTile
            )
        {
            return new List<SearchResults_t>();
        }

        private List<SearchResults_t>
        //---------------------------------------------------------------------
        AboveRightResults
            (
            Tile_t aTile
            )
        {
            return new List<SearchResults_t>();
        }

        private List<SearchResults_t>
            //---------------------------------------------------------------------
        AboveBelowLeftResults
            (
            Tile_t aTile
            )
        {
            return new List<SearchResults_t>();
        }

        private List<SearchResults_t>
        //---------------------------------------------------------------------
        AboveBelowResults
            (
            Tile_t aTile
            )
        {
            return new List<SearchResults_t>();
        }

        private List<SearchResults_t>
        //---------------------------------------------------------------------
        AboveLeftResults
            (
            Tile_t aTile
            )
        {
            return new List<SearchResults_t>();            
        }

        private List<SearchResults_t>
        //---------------------------------------------------------------------
        AboveResults
            (
            Tile_t aTile
            )
        {
            return new List<SearchResults_t>();
        }

        private List<SearchResults_t>
        //---------------------------------------------------------------------
        BelowRightLeftResults
            (
            Tile_t aTile
            )
        {
            return new List<SearchResults_t>();
        }

        private List<SearchResults_t>
        //---------------------------------------------------------------------
        BelowRightResults
            (
            Tile_t aTile
            )
        {
            return new List<SearchResults_t>();
        }

        private List<SearchResults_t>
            //---------------------------------------------------------------------
        RightLeftResults
            (
            Tile_t aTile
            )
        {
            return new List<SearchResults_t>();
        }

        private List<SearchResults_t>
            //---------------------------------------------------------------------
        RightResults
            (
            Tile_t aTile
            )
        {
            return new List<SearchResults_t>();
        }

        private List<SearchResults_t>
            //---------------------------------------------------------------------
        BelowLeftResults
            (
            Tile_t aTile
            )
        {
            return new List<SearchResults_t>();
        }

        private List<SearchResults_t>
        //---------------------------------------------------------------------
        BelowResults
            (
            Tile_t aTile
            )
        {
            var theResults = new List<SearchResults_t>();

            var theSubstringDown = SubstringDown(aTile);
            /*  Vertical Results */
            var theVertTemplate = TemplateService_t.SimpleVerticalWordTemplate( mBoard, (Tile_t)aTile.Clone() );

            foreach( var theVertResult in SimpleVerticalResults((Tile_t)aTile.Clone(), theVertTemplate))
            {
                theResults.Add(theVertResult);
            }

            var theSimpleHZTemplate = TemplateService_t.SimpleHZBlankTemplate(mBoard, (Tile_t)aTile.Clone());

            /* Horizontal Results */
            var theLettersForDownWords = LettersForDownWords(aTile, theSubstringDown);

            // make down result
            foreach( var theLetter in theLettersForDownWords )
            {
                string theWord = theLetter.Letter + theSubstringDown;
                
                var theWords = from words in mDictionary.WordList
                               where words.Length <= theWord.Length &&
                               words.Contains(theLetter.Letter)
                               select words;

                foreach( var theCurrentWord in theWords)
                {
                    if (theWord.Length == theWord.Length &&
                        string.Compare( theCurrentWord, theWord, true ) == 0)
                    {
                        var theThisTile = (Tile_t)aTile.Clone();
                        theThisTile.Letter = theLetter.Letter;
                        theThisTile.IsWild = theLetter.IsWild;

                        List<Tile_t> theWordList = new List<Tile_t>();
                        theWordList.Add(theThisTile);
                        int theLength = theSubstringDown.Length;

                        for (int i = 1; i <= theLength; ++i)
                        {
                            theWordList.Add((Tile_t)mBoard.mBoard[aTile.X, aTile.Y + i].Clone());
                        }

                        var theDownResult = new SearchResult_t(theWordList);

                        foreach (var theHorizontalResult in HorizontalResults(theThisTile, theDownResult, theSimpleHZTemplate))
                        {
                            theResults.Add(theHorizontalResult);
                        }

                        List<SearchResult_t> theNewResults = new List<SearchResult_t>();
                        theNewResults.Add( theDownResult);
                        theResults.Add( new SearchResults_t(theNewResults));
                    }
                }
            }

            return theResults;
        }

       

        private List<SearchResults_t>
        //---------------------------------------------------------------------
        LeftResults
            (
            Tile_t aTile
            )
        {
            return new List<SearchResults_t>();
        }

        private List<SearchResults_t>
        //---------------------------------------------------------------------
        HorizontalResults
            (
            Tile_t aClonedTile,
            SearchResult_t aResult,
            Template_t aSimpleHZTemplate
            )
        {
            List<SearchResults_t> theReturn = new List<SearchResults_t>();
            SearchResults_t theHorizontalResults = new SearchResults_t(null /*aResults*/);
            

            foreach( var theSimpleHZResult in SimpleHZResults( aSimpleHZTemplate, aClonedTile, aResult))
            {

                theReturn.Add(theSimpleHZResult);
            }


            return theReturn;
        }

        /// <summary>
        /// Doesn't consider substrings, just fills spaces
        /// </summary>
        /// <param name="aClonedTile"></param>
        /// <param name="aResult"></param>
        /// <returns></returns>
        private List<SearchResults_t>
        //---------------------------------------------------------------------
        SimpleHZResults
            (
            Template_t aTemplate,
            Tile_t aClonedTile, 
            SearchResult_t aResult
            )
        {
            List<SearchResults_t> theReturn = new List<SearchResults_t>();  
            
            List<LetterWord_t> theMyResults = mMyWords.GetLetterWordResults(mLetters);
            var theLetter = new Letter_t(aClonedTile.Letter, aClonedTile.IsWild);

            theMyResults = RemoveWordsWithoutLetter(theMyResults, theLetter);

            foreach( var Result in theMyResults)
            {
                string theWord = Result.Word();
                int theLetterIndex = IndexOfChar(theWord, theLetter.Letter);
                int theLettersBefore = theLetterIndex;
                int theLettersAfter = theWord.Count() - theLettersBefore - 1;
                
                int theRootIndex = aTemplate.RootIndex;

                int theStartIndex = theRootIndex - theLettersBefore;

                if( theStartIndex < 0 ||
                    ( aTemplate.StringOnLeft &&
                    theStartIndex - (aTemplate.LeftStringSize + 1) < 0) ) continue;

                List<Tile_t> theResult = new List<Tile_t>();
                int theLastIndexInWord = 0;

                if( theStartIndex + theWord.Count() <= aTemplate.Size)
                {
                    for(int i = 0; i< theWord.Count(); ++i)
                    {
                        theLastIndexInWord = theStartIndex + i;
                        var theTile = (Tile_t)aTemplate.At(theLastIndexInWord).Clone();
                        if (!(theTile.SearchType == SearchType_t.eBlank ||
                            ( theTile.SearchType == SearchType_t.eBelow && 
                            theTile.X == aClonedTile.X ) ) ) continue;
                        theTile.Letter = Result.At(i).Letter;
                        theTile.IsWild = Result.At(i).IsWild;
                        theResult.Add(theTile);
                    }
                }
                else
                {
                    continue;
                }

                if (aTemplate.StringOnRight &&
                    !(theLastIndexInWord <= aTemplate.Size - aTemplate.RightStringSize - 1 - 1)) continue;

                SearchResult_t theFinallyGotHere = new SearchResult_t(theResult);

                theReturn.Add(new SearchResults_t( new List<SearchResult_t> { theFinallyGotHere, aResult }));

            }

            return theReturn;
        }

        private List<SearchResults_t>
        //---------------------------------------------------------------------
        SimpleVerticalResults
            (
            Tile_t aTile, 
            Template_t aVertTemplate
            )
        {
            var theReturn = new List<SearchResults_t>();



            return theReturn;
        }

        /*
         move to static utilities
         */
        private List<LetterWord_t> 
        //---------------------------------------------------------------------
        RemoveWordsWithoutLetter
            (
            List<LetterWord_t> theMyResults,
            Letter_t aLetter
            )
        {
            var theReturn = new List<LetterWord_t>();
            foreach( var theWord in theMyResults)
            {
                foreach( var theLetter in theWord.LetterWord)
                {
                    if( theLetter.Letter == aLetter.Letter)
                    {
                        theReturn.Add(theWord);
                        break;
                    }
                }
            }
            return theReturn;
        }

        private int
        //---------------------------------------------------------------------
        IndexOfChar
            (
            string aWord,
            char aChar
            )
        {
            int theIndex = 0;

            foreach(var theChar in aWord)
            {
                if( aChar == theChar)
                {
                    return theIndex;
                }
                ++theIndex;
            }

            return theIndex;
        }

        private string
        //---------------------------------------------------------------------
        SubstringDown
            (
            Tile_t aTile

            )
        {
            var theSubstring = System.String.Empty;
            // we won't call this function if we are on the last row
            // nevertheless, we return if we are already on the last row
            if(aTile.Y == scBoardDimension - 1)
            {
                return theSubstring;
            }

            var theNewY = aTile.Y + 1;

            while( theNewY < scBoardDimension)
            {
                Tile_t theNextTile = mBoard.mBoard[ aTile.X, theNewY ];
                if( theNextTile.Letter == ' ' )
                {
                    return theSubstring;
                }
                else
                {
                    theSubstring += theNextTile.Letter;
                }
                ++theNewY;
            }

            return theSubstring;
        }

        private List<Letter_t> 
        //---------------------------------------------------------------------
        LettersForDownWords
            (
            Tile_t aTile,
            string aSubstring
            )
        {
            var theMatchingLetters = new List<Letter_t>();

            if( aTile.Y == scBoardDimension -1)
            {
                return theMatchingLetters;
            }
            
            foreach( var theLetter in mLetters)
            {
                string theMatchWord = System.String.Empty;
                
                if( theLetter.IsWild )
                {
                    int theWordLength = aSubstring.Length + 1;

                    var theWords = from words in mDictionary.WordList
                                   where words.Length <= theWordLength
                                   select words;

                    for (int i = 0; i < mAlphabet.Count(); ++i )
                    {

                        theMatchWord = mAlphabet[i] + aSubstring;

                        foreach( var word in theWords )
                        {
                            if (word.Length == theMatchWord.Length &&
                                string.Compare(word, theMatchWord, true) == 0)
                            {
                                theMatchingLetters.Add(new Letter_t( mAlphabet[i], true));
                                break;
                            }
                        }
                    }
                }

                theMatchWord = theLetter.Letter + aSubstring;

                var theStandardWords = from words in mDictionary.WordList
                                       where words.Length <= theMatchWord.Length &&
                                       words[0] == theLetter.Letter
                                       select words;
                foreach( var theStandardWord in theStandardWords )
                {
                    if (string.Compare(theStandardWord, theMatchWord, true) == 0)
                    {
                        theMatchingLetters.Add((Letter_t)theLetter.Clone());
                    }
                }
            }

            return theMatchingLetters;
        }

        //----------------------------------------------------------------------
        // MEMBER DATA
        //----------------------------------------------------------------------

        private GameBoard_t mBoard;
        private Dictionary_t mDictionary;
        private List<Letter_t> mLetters;
        private MyWords_t mMyWords;
        private const int scBoardDimension = 15;
        private char[] mAlphabet;


    }
}
