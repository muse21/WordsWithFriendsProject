using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    //-----------------------------------------------------------
    class SimpleSearch_t
    //-----------------------------------------------------------
    {
        //-----------------------------------------------------------
        // Public Functions
        //-----------------------------------------------------------

        //-----------------------------------------------------------
        public SimpleSearch_t
        //-----------------------------------------------------------
            (
            Dictionary_t aDictionary
            )
        {
            mDictionary = aDictionary;
            mLetters = new List<char>();
            mResults = new List<string>();
            mPreliminaryResults = new List<string>();
        }

        public List<string>
        //-----------------------------------------------------------
        GetResults
        //-----------------------------------------------------------
            (
            string aWord,
            List<char> aLetters
            )
        {
            aWord = aWord.ToLower();
            bool theSuccess = false;
            string theNextWord;

            while ( mDictionary.HasMoreWords() )
            {
                theNextWord = mDictionary.GetNextWord();
                if ( theNextWord.Length == aWord.Length ) // speed
                {
                    if ( String.Compare(theNextWord, aWord) == 0 )
                    {
                        theSuccess = true;
                        break;
                    }
                }
            }

            if (theSuccess)
            {
                mResults.Add(aWord + " is in the Dictionary");
            }
            else
            {
                mResults.Add(aWord + " is not in the Dictionary");
            }

            GetPreliminaryResults(aWord);
            AddSubStringResults();
            AddSubStringsThatIncludeMyLetters();
            mDictionary.Reset();

            return mResults;
        }

        public void
        //-----------------------------------------------------------
        Reset
        //-----------------------------------------------------------
            (
            )
        {
            mDictionary.Reset();
            mResults.Clear();
            mPreliminaryResults.Clear();
        }

        //-----------------------------------------------------------
        // Private Functions
        //-----------------------------------------------------------

        private void
        //-----------------------------------------------------------
        GetPreliminaryResults
        //-----------------------------------------------------------
            (
            string aWord
            )
        {
            string theNextWord;
            while (mDictionary.HasMoreWords())
            {
                theNextWord = mDictionary.GetNextWord();
                if (theNextWord.Contains(aWord))
                {
                    mResults.Add(theNextWord);
                }
            }
        }

        private void
        //-----------------------------------------------------------
        AddSubStringResults
        //-----------------------------------------------------------
            (
            )
        {
            mDictionary.Reset();
            mResults.Add("---------------------------");
            mResults.Add("Substrings");
            mResults.Add("---------------------------");

            foreach (string s in mResults)
            {
                mResults.Add(s);
            }
        }

        private void
        //-----------------------------------------------------------
        AddSubStringsThatIncludeMyLetters
        //-----------------------------------------------------------
            (
            )
        {
            mResults.Add("---------------------------");
            mResults.Add("Substrings with my letters");
            mResults.Add("---------------------------");

            foreach (string s in mPreliminaryResults)
            {

            }
        }

        //-----------------------------------------------------------
        // Member Data
        //-----------------------------------------------------------
        private Dictionary_t mDictionary;
        private List<char> mLetters;
        private List<string> mResults;
        private List<string> mPreliminaryResults;

    }
}
