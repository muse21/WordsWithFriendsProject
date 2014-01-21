using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    //-----------------------------------------------------------
    class FirstWord_t
    //-----------------------------------------------------------    
    {
        //-----------------------------------------------------------
        // Public Functions
        //-----------------------------------------------------------
        
        //-----------------------------------------------------------
        public FirstWord_t
            //-----------------------------------------------------------
            (
            )
        {
            mDictionary = new Dictionary_t();
            mLetters = new List<char>();
            mSuccessWords = new List<WordResult_t>();
            mMatcher = new Matcher_t();
            mScorer = new Scorer_t();
            mResultList = new List<string>();
            mAlphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 
                's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        }

        //-----------------------------------------------------------
        public List<string>
        GetResults
        //-----------------------------------------------------------
            (
            List<char> aLetters
            )
        {
            mLetters = aLetters;

            FindMatches();
            SortResults();
            PrepareResults();

            return mResultList;
        }

        public void
        //-----------------------------------------------------------
        Reset
        //-----------------------------------------------------------
            (
            )
        {
            mDictionary.Reset();
            mLetters.Clear();
            mSuccessWords.Clear();
            mResultList.Clear();
        }
        
        //-----------------------------------------------------------
        // Private Functions
        //-----------------------------------------------------------
        
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
        PrepareResults
        //-----------------------------------------------------------
            (
            )
        {

            for (int i = 0; i < mSuccessWords.Count(); i++)
            {
                mResultList.Add(MakeResultString(mSuccessWords[i]));
            }
        }

        //-----------------------------------------------------------
        // Member Data
        //-----------------------------------------------------------
        private Dictionary_t mDictionary;
        private List<char> mLetters;
        private List<WordResult_t> mSuccessWords;
        private List<string> mResultList;
        private Matcher_t mMatcher;
        private Scorer_t mScorer;
        private char[] mAlphabet;
        const int scResultsLimit = 20;
        const char scDefaultChar = '-';
    }
}
