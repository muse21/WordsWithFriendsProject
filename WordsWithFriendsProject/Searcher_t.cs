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
            mMatcher = new Matcher_t();
            mHash = new HashSet<string>();
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
                            theResultsList = theResultsList.Concat( AllResults(aBoard.mBoard[j,i])).ToList();
                            break;
                        case (SearchType_t.eAboveBelowRight): // 1110
                            theResultsList = theResultsList.Concat(AboveBelowRightResults(aBoard.mBoard[j, i])).ToList();
                            break;
                        case (SearchType_t.eAboveLeftRight): // 1101
                            theResultsList = theResultsList.Concat(AboveBelowRightResults(aBoard.mBoard[j, i])).ToList();
                            break;
                        case (SearchType_t.eAboveRight): // 1100
                            theResultsList = theResultsList.Concat(AboveRightResults(aBoard.mBoard[j, i])).ToList();
                            break;
                        case (SearchType_t.eAboveBelowLeft):
                            theResultsList = theResultsList.Concat(AboveBelowLeftResults(aBoard.mBoard[j, i])).ToList();
                            break;
                        case (SearchType_t.eAboveBelow): // 1010
                            theResultsList = theResultsList.Concat(AboveBelowResults(aBoard.mBoard[j, i])).ToList();
                            break;
                        case (SearchType_t.eAboveLeft): // 1001
                            theResultsList = theResultsList.Concat(AboveLeftResults(aBoard.mBoard[j, i])).ToList();
                            break;
                        case (SearchType_t.eAbove): // 1000
                            theResultsList = theResultsList.Concat(AboveResults(aBoard.mBoard[j, i])).ToList();
                            break;
                        case (SearchType_t.eBelowRightLeft): // 0111
                            theResultsList = theResultsList.Concat(BelowRightLeftResults(aBoard.mBoard[j, i])).ToList();
                            break;
                        case (SearchType_t.eBelowRight): // 0110
                            theResultsList = theResultsList.Concat(BelowRightResults(aBoard.mBoard[j, i])).ToList();
                            break;
                        case (SearchType_t.eRightLeft): // 0101
                            theResultsList = theResultsList.Concat(RightLeftResults(aBoard.mBoard[j, i])).ToList();
                            break;
                        case (SearchType_t.eRight): // 0100
                            theResultsList = theResultsList.Concat(RightResults(aBoard.mBoard[j, i])).ToList();
                            break;
                        case (SearchType_t.eBelowLeft): // 0011
                            theResultsList = theResultsList.Concat(BelowLeftResults(aBoard.mBoard[j, i])).ToList();
                            break;
                        case (SearchType_t.eBelow): // 0010
                            theResultsList = theResultsList.Concat(BelowResults(aBoard.mBoard[j, i])).ToList();
                            break;
                        case (SearchType_t.eLeft): // 0001
                            theResultsList = theResultsList.Concat(LeftResults(aBoard.mBoard[j, i])).ToList();
                            break;
                        case( SearchType_t.eBlank ): // 0000
                            break;
                        case( SearchType_t.ePlayed ):
                            break;
                        default:
                            throw new NotImplementedException();    
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
            var theResults = new List<SearchResults_t>();

            string theSubstringUp = SubstringUp(aTile);
            /*  Vertical Results */
            var theVertTemplate = TemplateService_t.SimpleVerticalAboveTemplate(mBoard, (Tile_t)aTile.Clone());

            theResults = theResults.Concat(SimpleVerticalUpResults((Tile_t)aTile.Clone(), theVertTemplate, theSubstringUp)).ToList();

            var theSimpleHZTemplate = TemplateService_t.SimpleHZTemplate(mBoard, (Tile_t)aTile.Clone());

            // Horizontal Results 
            var theLettersForUpWords = LettersForUpWords(aTile, theSubstringUp);
            
            var theWords = from words in mDictionary.WordList
                           where words.Length == theSubstringUp.Length + 1
                           select words;

            // make down result
            foreach (var theLetter in theLettersForUpWords)
            {
                string theWord = theSubstringUp + theLetter.Letter;

                foreach (var theCurrentWord in theWords)
                {
                    if (string.Compare(theCurrentWord, theWord, true) == 0)
                    {
                        List<Tile_t> theWordList = new List<Tile_t>();
                        int theLength = theSubstringUp.Length;

                        for (int i = 0; i < theLength; ++i)
                        {
                            theWordList.Add((Tile_t)mBoard.mBoard[aTile.X, aTile.Y - theLength + i].Clone());
                        }
                        var theThisTile = (Tile_t)aTile.Clone();
                        theThisTile.Letter = theLetter.Letter;
                        theThisTile.IsWild = theLetter.IsWild;
                        theWordList.Add(theThisTile);

                        var theUpResult = new SearchResult_t(theWordList);

                        theResults = theResults.Concat( HorizontalResults( theThisTile, theUpResult, theSimpleHZTemplate, SearchType_t.eAbove)).ToList();

                        List<SearchResult_t> theNewResults = new List<SearchResult_t>();
                        theNewResults.Add(theUpResult);
                        theResults.Add(new SearchResults_t(theNewResults));
                    }
                }
            }

            return theResults;
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
            var theResults = new List<SearchResults_t>();
            
            var theSubstringRight = SubstringRight(aTile);

            
            //  Vertical Results 
            var theTemplate = TemplateService_t.SimpleHorizontalRightTemplate(mBoard, (Tile_t)aTile.Clone());

            theResults = theResults.Concat(SimpleHorizontalRightResults((Tile_t)aTile.Clone(), theTemplate)).ToList();
            /*

            var theSimpleHZTemplate = TemplateService_t.SimpleHZTemplate(mBoard, (Tile_t)aTile.Clone());

            // Horizontal Results 
            var theLettersForDownWords = LettersForDownWords(aTile, theSubstringDown);

            // make down result
            foreach (var theLetter in theLettersForDownWords)
            {
                string theWord = theLetter.Letter + theSubstringDown;

                var theWords = from words in mDictionary.WordList
                               where words.Length <= theWord.Length &&
                               words.Contains(theLetter.Letter)
                               select words;

                foreach (var theCurrentWord in theWords)
                {
                    if (theWord.Length == theWord.Length &&
                        string.Compare(theCurrentWord, theWord, true) == 0)
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

                        theResults = theResults.Concat(HorizontalResults(theThisTile,
                                                                         theDownResult,
                                                                         theSimpleHZTemplate,
                                                                         SearchType_t.eBelow)).ToList();

                        List<SearchResult_t> theNewResults = new List<SearchResult_t>();
                        theNewResults.Add(theDownResult);
                        theResults.Add(new SearchResults_t(theNewResults));
                    }
                }
            }
            */
            return theResults;
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
            var theVertTemplate = TemplateService_t.SimpleVerticalBelowTemplate( mBoard, (Tile_t)aTile.Clone() );

            theResults = theResults.Concat(SimpleVerticalDownResults((Tile_t)aTile.Clone(), theVertTemplate)).ToList();

            var theSimpleHZTemplate = TemplateService_t.SimpleHZTemplate(mBoard, (Tile_t)aTile.Clone());

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

                        theResults = theResults.Concat(HorizontalResults(theThisTile, 
                                                                         theDownResult,
                                                                         theSimpleHZTemplate,
                                                                         SearchType_t.eBelow)).ToList();

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
            Template_t aSimpleHZTemplate,
            SearchType_t aSearchType
            )
        {
            var theReturn = new List<SearchResults_t>();

            theReturn = theReturn.Concat(SimpleHZResults(aSimpleHZTemplate, 
                                                         aClonedTile,
                                                         aResult, 
                                                         aSearchType)).ToList();

            return theReturn;
        }

        private List<SearchResults_t>
        //---------------------------------------------------------------------
        SimpleHZResults
            (
            Template_t aTemplate,
            Tile_t aClonedTile, 
            SearchResult_t aResult,
            SearchType_t aSearchType
            )
        {
            List<SearchResults_t> theReturn = new List<SearchResults_t>();  
            
            List<LetterWord_t> theMyResults = mMyWords.GetLetterWordResults(mLetters);
            var theLetter = new Letter_t(aClonedTile.Letter, aClonedTile.IsWild);

            theMyResults = RemoveWordsWithoutLetter(theMyResults, theLetter);
            var theMyResultsWith2ofLetter = new List<LetterWord_t>();
            var theMyResultsWith3ofLetter = new List<LetterWord_t>();

            foreach( var word in theMyResults)
            {
                if(word.HasAtLeastNOfLetter( word, theLetter.Letter, 2))
                {
                    theMyResultsWith2ofLetter.Add(word);

                    if (word.HasAtLeastNOfLetter(word, theLetter.Letter, 3))
                    {
                        theMyResultsWith3ofLetter.Add(word);
                    }
                }
            }

            theReturn = theReturn.Concat(SimpleHZByIndex( aTemplate,
                                                          aClonedTile, 
                                                          aResult,
                                                          aSearchType,
                                                          theMyResults,
                                                          theLetter,
                                                          1 ) ).ToList();
            
            if( theMyResultsWith2ofLetter.Count() > 0 )
            {
                theReturn = theReturn.Concat(SimpleHZByIndex(aTemplate,
                                                             aClonedTile,
                                                             aResult,
                                                             aSearchType,
                                                             theMyResultsWith2ofLetter,
                                                             theLetter,
                                                             2)).ToList();

                if( theMyResultsWith3ofLetter.Count() > 0 )
                {
                    theReturn = theReturn.Concat(SimpleHZByIndex(aTemplate,
                                                                 aClonedTile,
                                                                 aResult,
                                                                 aSearchType,
                                                                 theMyResultsWith3ofLetter,
                                                                 theLetter,
                                                                 3)).ToList();
                }
            }
            return theReturn;
        }

        private List<SearchResults_t>
        //---------------------------------------------------------------------
        SimpleHZByIndex
            (
            Template_t aTemplate,
            Tile_t aClonedTile, 
            SearchResult_t aResult,
            SearchType_t aSearchType,
            List<LetterWord_t> aMyResults,
            Letter_t aLetter,
            int aN
            )
        {
            List<SearchResults_t> theReturn = new List<SearchResults_t>();  

            foreach (var Result in aMyResults)
            {
                string theWord = Result.Word();
                int theLetterIndex = IndexOfNChar(theWord, aLetter.Letter, aN);
                int theLettersBefore = theLetterIndex;
                int theLettersAfter = theWord.Count() - theLettersBefore - 1;

                int theRootIndex = aTemplate.RootIndex;

                int theStartIndex = theRootIndex - theLettersBefore;

                if (theStartIndex < 0 ||
                    (aTemplate.StringOnLeft &&
                    theStartIndex - (aTemplate.LeftStringSize + 1) < 0)) continue;

                List<Tile_t> theResult = new List<Tile_t>();
                int theLastIndexInWord = 0;

                bool isValid = true;
                if (theStartIndex + theWord.Count() <= aTemplate.Size)
                {
                    for (int i = 0; i < theWord.Count(); ++i)
                    {
                        theLastIndexInWord = theStartIndex + i;
                        var theTile = (Tile_t)aTemplate.At(theLastIndexInWord).Clone();
                        if (!(theTile.SearchType == SearchType_t.eBlank ||
                            (theTile.SearchType == aSearchType &&
                            theTile.X == aClonedTile.X))) isValid = false;
                        theTile.Letter = Result.At(i).Letter;
                        theTile.IsWild = Result.At(i).IsWild;
                        theResult.Add(theTile);
                    }
                }
                else
                {
                    continue;
                }

                if (!isValid ||
                    aTemplate.StringOnRight &&
                    !(theLastIndexInWord <= aTemplate.Size - aTemplate.RightStringSize - 1 - 1)) continue;

                SearchResult_t theFinallyGotHere = new SearchResult_t(theResult);

                theReturn.Add(new SearchResults_t(new List<SearchResult_t> { theFinallyGotHere, aResult }));
            }
            return theReturn;
        }

        private List<SearchResults_t>
        //---------------------------------------------------------------------
        SimpleVerticalDownResults
            (
            Tile_t aTile, 
            Template_t aVertTemplate
            )
        {
            var theReturn = new List<SearchResults_t>();
            string theSubstringDown = SubstringDown(aTile);

            var theWords = from words in mDictionary.WordList
                           where words.Length <= aVertTemplate.MaxWordLength &&
                           words.Contains(theSubstringDown) 
                           select words;
            List<string> theWordsList = new List<string>( theWords );

            var theLetters = new List<char>();
            foreach( var letter in mLetters)
            {
                theLetters.Add(letter.Letter);
            }

            mHash.Clear();
            SubStringsWithMyLetters(theWordsList, theSubstringDown, theLetters);

            var theResultsWithSubStrings = mHash.ToList();

            List<LetterWord_t> theLetterWords = new List<LetterWord_t>();

            foreach( var result in theResultsWithSubStrings )
            {
                theLetterWords.Add( new LetterWord_t( result, new List<char>(theLetters)));
            }

            foreach( var theResult in theLetterWords )
            {
                // get index of first letter in string
                var theLetter = new Letter_t( mBoard.mBoard[aTile.X, aTile.Y + 1].Letter, 
                                              mBoard.mBoard[aTile.X, aTile.Y + 1].IsWild);
                string theWord = theResult.Word();

                if (String.Compare(theWord, theSubstringDown, true) == 0) continue;
                int theLetterIndex = IndexOfChar(theWord, theLetter.Letter);
                int theLettersBefore = theLetterIndex - 1;
                int theLettersAfter = theWord.Count() - theLettersBefore - 1;

                int theRootIndex = aVertTemplate.RootIndex;

                int theStartIndex = theRootIndex - theLettersBefore;

                if( theStartIndex < 0 ||
                    ( aVertTemplate.StringOnTop() &&
                    theStartIndex - (aVertTemplate.TopStringSize() + 1) < 0) ) continue;

                List<Tile_t> theResultList = new List<Tile_t>();
                int theLastIndexInWord = 0;

                bool isValid = true;
                if( theStartIndex + theWord.Count() <= aVertTemplate.Size)
                {
                    for(int i = 0; i< theWord.Count(); ++i)
                    {
                        theLastIndexInWord = theStartIndex + i;
                        var theTile = (Tile_t)aVertTemplate.At(theLastIndexInWord).Clone();
                        if (!(theTile.SearchType == SearchType_t.eBlank ||
                            theTile.SearchType == SearchType_t.ePlayed ||
                            ( theTile.SearchType == SearchType_t.eBelow && 
                            theTile.Y == aTile.Y ) ||
                            ( theTile.SearchType == SearchType_t.eAbove &&
                            aTile.Y + 1 + aVertTemplate.CenterStringSize == theTile.Y ) ) ) isValid = false;

                        theTile.Letter = theResult.At(i).Letter;
                        theTile.IsWild = theResult.At(i).IsWild;
                        theResultList.Add(theTile);
                    }
                }
              else
              {
                  continue;
              }

              if (!isValid ||
                  aVertTemplate.StringOnBottom() &&
                  !(theLastIndexInWord <= aVertTemplate.Size - aVertTemplate.BottomStringSize() - 1 - 1)) continue;

              SearchResult_t theFinallyGotHere = new SearchResult_t(theResultList);

              theReturn.Add(new SearchResults_t( new List<SearchResult_t> { theFinallyGotHere }));
            }

            return theReturn;
        }

        private List<SearchResults_t> 
        //---------------------------------------------------------------------    
        SimpleHorizontalRightResults
            (
            Tile_t aTile, 
            Template_t aTemplate
            )
        {
            var theReturn = new List<SearchResults_t>();
            string theSubstringRight = SubstringRight(aTile);

            var theWords = from words in mDictionary.WordList
                           where words.Length <= aTemplate.MaxWordLength &&
                           words.Contains(theSubstringRight)
                           select words;

            List<string> theWordsList = new List<string>(theWords);

            var theLetters = new List<char>();
            foreach (var letter in mLetters)
            {
                theLetters.Add(letter.Letter);
            }

            mHash.Clear();
            SubStringsWithMyLetters(theWordsList, theSubstringRight, theLetters);

            var theResultsWithSubStrings = mHash.ToList();

            List<LetterWord_t> theLetterWords = new List<LetterWord_t>();

            foreach (var result in theResultsWithSubStrings)
            {
                theLetterWords.Add(new LetterWord_t(result, new List<char>(theLetters)));
            }
            /*

            foreach (var theResult in theLetterWords)
            {
                // get index of first letter in string
                var theLetter = new Letter_t(mBoard.mBoard[aTile.X, aTile.Y + 1].Letter,
                                              mBoard.mBoard[aTile.X, aTile.Y + 1].IsWild);
                string theWord = theResult.Word();

                if (String.Compare(theWord, theSubstringDown, true) == 0) continue;
                int theLetterIndex = IndexOfChar(theWord, theLetter.Letter);
                int theLettersBefore = theLetterIndex - 1;
                int theLettersAfter = theWord.Count() - theLettersBefore - 1;

                int theRootIndex = aVertTemplate.RootIndex;

                int theStartIndex = theRootIndex - theLettersBefore;

                if (theStartIndex < 0 ||
                    (aVertTemplate.StringOnTop() &&
                    theStartIndex - (aVertTemplate.TopStringSize() + 1) < 0)) continue;

                List<Tile_t> theResultList = new List<Tile_t>();
                int theLastIndexInWord = 0;

                bool isValid = true;
                if (theStartIndex + theWord.Count() <= aVertTemplate.Size)
                {
                    for (int i = 0; i < theWord.Count(); ++i)
                    {
                        theLastIndexInWord = theStartIndex + i;
                        var theTile = (Tile_t)aVertTemplate.At(theLastIndexInWord).Clone();
                        if (!(theTile.SearchType == SearchType_t.eBlank ||
                            theTile.SearchType == SearchType_t.ePlayed ||
                            (theTile.SearchType == SearchType_t.eBelow &&
                            theTile.Y == aTile.Y) ||
                            (theTile.SearchType == SearchType_t.eAbove &&
                            aTile.Y + 1 + aVertTemplate.CenterStringSize == theTile.Y))) isValid = false;

                        theTile.Letter = theResult.At(i).Letter;
                        theTile.IsWild = theResult.At(i).IsWild;
                        theResultList.Add(theTile);
                    }
                }
                else
                {
                    continue;
                }

                if (!isValid ||
                    aVertTemplate.StringOnBottom() &&
                    !(theLastIndexInWord <= aVertTemplate.Size - aVertTemplate.BottomStringSize() - 1 - 1)) continue;

                SearchResult_t theFinallyGotHere = new SearchResult_t(theResultList);

                theReturn.Add(new SearchResults_t(new List<SearchResult_t> { theFinallyGotHere }));
            }
            */
            return theReturn;
        }

        private List<SearchResults_t>
        //---------------------------------------------------------------------
        SimpleVerticalUpResults
           (
           Tile_t aTile,
           Template_t aVertTemplate,
           string aSubstringUp
           )
        {
            var theReturn = new List<SearchResults_t>();

            var theWords = from words in mDictionary.WordList
                           where words.Length <= aVertTemplate.MaxWordLength &&
                           words.Contains(aSubstringUp)
                           select words;
            List<string> theWordsList = new List<string>(theWords);

            var theLetters = new List<char>();
            foreach (var letter in mLetters)
            {
                theLetters.Add(letter.Letter);
            }

            mHash.Clear();
            SubStringsWithMyLetters(theWordsList, aSubstringUp, theLetters);

            var theResultsWithSubStrings = mHash.ToList();

            List<LetterWord_t> theLetterWords = new List<LetterWord_t>();

            foreach (var result in theResultsWithSubStrings)
            {
                theLetterWords.Add(new LetterWord_t(result, new List<char>(theLetters)));
            }

            foreach (var theResult in theLetterWords)
            {
                // get index of first letter in string
                var theLetterAtTheTop = new Letter_t(mBoard.mBoard[aTile.X, aTile.Y - aVertTemplate.CenterStringSize].Letter,
                                                     mBoard.mBoard[aTile.X, aTile.Y - aVertTemplate.CenterStringSize].IsWild); // always false?
                string theWord = theResult.Word();
                if (String.Compare(theWord, aSubstringUp, true) == 0) continue;
                int theLetterIndex = IndexOfChar(theWord, theLetterAtTheTop.Letter);
                int theLettersBefore = theLetterIndex;
                int theLettersAfter = theWord.Count() - theLettersBefore - 1;

                int theRootIndex = aVertTemplate.RootIndex;

                int theStartIndex = theRootIndex - aVertTemplate.CenterStringSize - theLettersBefore;

                if (theStartIndex < 0 ||
                    theRootIndex + theLettersAfter + 1 > aVertTemplate.Size ) continue;

                List<Tile_t> theResultList = new List<Tile_t>();
                int theLastIndexInWord = 0;

                bool isValid = true;

                if (theStartIndex + theWord.Count() <= aVertTemplate.Size)
                {
                    for (int i = 0; i < theWord.Count(); ++i)
                    {
                        theLastIndexInWord = theStartIndex + i;
                        var theTile = (Tile_t)aVertTemplate.At(theLastIndexInWord).Clone();
                        if (!(theTile.SearchType == SearchType_t.eBlank ||
                             theTile.SearchType == SearchType_t.ePlayed ||
                            (theTile.SearchType == SearchType_t.eAbove &&
                            theTile.Y == aTile.Y) ||
                            (theTile.SearchType == SearchType_t.eBelow &&
                            aTile.Y - 1 - aVertTemplate.CenterStringSize == theTile.Y))) isValid = false;


                        if (theTile.SearchType == SearchType_t.ePlayed &&
                            Char.ToLower( theTile.Letter ) != theResult.At(i).Letter) isValid = false;

                        theTile.Letter = theResult.At(i).Letter;
                        theTile.IsWild = theResult.At(i).IsWild;
                        theResultList.Add(theTile);
                    }
                }
                else
                {
                    continue;
                }

                if ( !isValid ||
                     aVertTemplate.StringOnBottom() &&
                     !(theLastIndexInWord <= aVertTemplate.Size - aVertTemplate.BottomStringSize() - 1 - 1)) continue;

                SearchResult_t theFinallyGotHere = new SearchResult_t(theResultList);

                theReturn.Add(new SearchResults_t(new List<SearchResult_t> { theFinallyGotHere }));
            }
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
            char theLowerChar = Char.ToLower(aChar);
            int theIndex = 0;

            foreach(var theChar in aWord)
            {
                if( theLowerChar == theChar)
                {
                    return theIndex;
                }
                ++theIndex;
            }

            return theIndex;
        }

        private int
        //---------------------------------------------------------------------
        IndexOfNChar
            (
            string aWord,
            char aChar,
            int n
            )
        {
            char theLowerChar = Char.ToLower(aChar);
            int theCount = 0;
            int theIndex = 0;

            foreach (var theChar in aWord)
            {
                if (theLowerChar == theChar)
                {
                    ++theCount;
                    if( theCount == n)
                    {
                        return theIndex;
                    }
                }
                ++theIndex;
            }

            return -1;
        }

        string
        //---------------------------------------------------------------------
        SubstringUp
            (
            Tile_t aTile

            )
        {
            var theSubstring = System.String.Empty;
            // we won't call this function if we are on the first row
            // nevertheless, we return if we are already on the first row
            if(aTile.Y == 0)
            {
                return theSubstring.ToLower();
            }

            var theNewY = aTile.Y - 1;

            while( theNewY >= 0 )
            {
                Tile_t theNextTile = mBoard.mBoard[ aTile.X, theNewY ];
                if( theNextTile.Letter == ' ' )
                {
                    break;
                }
                else
                {
                    theSubstring += theNextTile.Letter;
                }
                --theNewY;
            }
            return ReversedString(theSubstring);
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
                    break;
                }
                else
                {
                    theSubstring += theNextTile.Letter;
                }
                ++theNewY;
            }

            return theSubstring.ToLower();
        }

        private string
        //---------------------------------------------------------------------
        SubstringRight
            (
            Tile_t aTile

            )
        {
            var theSubstring = System.String.Empty;
            // we won't call this function if we are on the last row
            // nevertheless, we return if we are already on the last row
            if (aTile.X == scBoardDimension - 1)
            {
                return theSubstring;
            }

            var theNewX = aTile.X + 1;

            while (theNewX < scBoardDimension)
            {
                Tile_t theNextTile = mBoard.mBoard[theNewX, aTile.Y];
                if (theNextTile.Letter == ' ')
                {
                    break;
                }
                else
                {
                    theSubstring += theNextTile.Letter;
                }
                ++theNewX;
            }

            return theSubstring.ToLower();
        }

        private string
            //---------------------------------------------------------------------
        SubstringLeft
            (
            Tile_t aTile
            )
        {
            var theSubstring = System.String.Empty;
            // we won't call this function if we are on the last row
            // nevertheless, we return if we are already on the last row
            if (aTile.X == 0)
            {
                return theSubstring;
            }

            var theNewX = aTile.X - 1;

            while (theNewX > 0)
            {
                Tile_t theNextTile = mBoard.mBoard[theNewX, aTile.Y];
                if (theNextTile.Letter == ' ')
                {
                    break;
                }
                else
                {
                    theSubstring += theNextTile.Letter;
                }
                --theNewX;
            }
            return ReversedString(theSubstring);
        }

        private string 
        //---------------------------------------------------------------------
        ReversedString
            (
            string aSubstring
            )
        {
            aSubstring = aSubstring.ToLower();
            // gotta reverse it....
            char[] array = aSubstring.ToCharArray();
            Array.Reverse(array);
            return new String(array);
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
            string theMatchWord = System.String.Empty;
            int theWordLength = aSubstring.Length + 1;

            var theWords = from words in mDictionary.WordList
                           where words.Length == theWordLength
                           select words;

            foreach( var theLetter in mLetters)
            {

                if (theLetter.IsWild)
                {
                    for (int i = 0; i < mAlphabet.Count(); ++i)
                    {

                        theMatchWord = mAlphabet[i] + aSubstring;

                        foreach (var word in theWords)
                        {
                            if (string.Compare(word, theMatchWord, true) == 0)
                            {
                                theMatchingLetters.Add(new Letter_t(mAlphabet[i], true));
                                break;
                            }
                        }
                    }
                }
                else
                {
                    theMatchWord = theLetter.Letter + aSubstring;

                    var theStandardWords = from words in theWords
                                           where words[0] == theLetter.Letter
                                           select words;
                    foreach (var theStandardWord in theStandardWords)
                    {
                        if (string.Compare(theStandardWord, theMatchWord, true) == 0)
                        {
                            theMatchingLetters.Add((Letter_t)theLetter.Clone());
                        }
                    }
                }
            }

            return theMatchingLetters;
        }

        private List<Letter_t>
        //---------------------------------------------------------------------
        LettersForUpWords
            (
            Tile_t aTile,
            string aSubstring
            )
        {
            var theMatchingLetters = new List<Letter_t>();

            if (aTile.Y == 0 )
            {
                return theMatchingLetters;
            }
            string theMatchWord = System.String.Empty;
            int theWordLength = aSubstring.Length + 1;

            var theWords = from words in mDictionary.WordList
                           where words.Length == theWordLength
                           select words;
            foreach (var theLetter in mLetters)
            {
                if (theLetter.IsWild)
                {
                    for (int i = 0; i < mAlphabet.Count(); ++i)
                    {
                        theMatchWord = aSubstring + mAlphabet[i];

                        foreach (var word in theWords)
                        {
                            if (string.Compare(word, theMatchWord, true) == 0)
                            {
                                theMatchingLetters.Add(new Letter_t(mAlphabet[i], true));
                                break;
                            }
                        }
                    }
                }
                else
                {
                    theMatchWord = aSubstring + theLetter.Letter;

                    var theStandardWords = from words in theWords
                                           where words[theWordLength-1] == theLetter.Letter
                                           select words;
                    foreach (var theStandardWord in theStandardWords)
                    {
                        if (string.Compare(theStandardWord, theMatchWord, true) == 0)
                        {
                            theMatchingLetters.Add((Letter_t)theLetter.Clone());
                        }
                    }
                }
            }
            return theMatchingLetters;
        }

        private void
        //-----------------------------------------------------------
        SubStringsWithMyLetters
            (
            List<string> aList,
            string aSubString,
            List<char> aLetters
            )
        {
            string theTemp = System.String.Empty;
            string theResult = System.String.Empty;
                    
            if (aLetters[0] != '?')
            {
                foreach (var s in aList)
                {
                    List<char> theCopy = new List<char>(aLetters);
                    theResult = String.Copy(s);
                    theTemp = ReplaceFirst(theResult, aSubString, "");

                    if (mMatcher.Evaluate(theTemp, theCopy))
                    {
                        mHash.Add(theResult);
                    }
                }
            }
            else
            {
                SubStringsWithBlank( aList, aSubString, aLetters);
            }
        }

        private void
        //-----------------------------------------------------------
        SubStringsWithBlank
        //-----------------------------------------------------------
            (
            List<string> aList,
            string aSubString,
            List<char> aLetters
            )
        {
            foreach (char c in mAlphabet)
            {
                aLetters[0] = c;
                SubStringsWithMyLetters( aList, aSubString, aLetters);
            }
        }

        // http://stackoverflow.com/questions/8809354/replace-first-occurrence-of-pattern-in-a-string
        private string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
        //----------------------------------------------------------------------
        // MEMBER DATA
        //----------------------------------------------------------------------

        private GameBoard_t mBoard;
        private Dictionary_t mDictionary;
        private List<Letter_t> mLetters;
        private List<char> mCharLetters;
        private MyWords_t mMyWords;
        private Matcher_t mMatcher;
        private HashSet<string> mHash;
        private const int scBoardDimension = 15;
        private char[] mAlphabet;


    }
}
