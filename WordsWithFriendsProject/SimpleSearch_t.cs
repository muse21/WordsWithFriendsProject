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
            mMySubStringResults = new List<string>();
            mMatcher = new Matcher_t();
            mAlphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 
                's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        }

        public List<string>
        //-----------------------------------------------------------
        GetResults
        //-----------------------------------------------------------
            (
            string aWord,
            List<char> aLetters,
            bool aShowSubs,
            bool aShowJustMySubs
            )
        {
            mString = aWord.ToLower();
            mLetters = aLetters;

            bool theSuccess = false;
            string theNextWord = System.String.Empty;

            while ( mDictionary.HasMoreWords() )
            {
                theNextWord = mDictionary.GetNextWord();
                if ( theNextWord.Length == mString.Length ) 
                {
                    if ( String.Compare(theNextWord, mString) == 0 )
                    {
                        theSuccess = true;
                        break;
                    }
                }
            }

            if (theSuccess)
            {
                mResults.Add(mString + " is in the Dictionary");
            }
            else
            {
                mResults.Add(mString + " is not in the Dictionary");
            }

            GetPreliminaryResults();

            if (aShowSubs)
            {
                AddSubStringHeader();
                AddSubStringResults();
            }
            if (aShowJustMySubs)
            {
                DiscoverSubStringsThatIncludeMyLetters();
                AddSubStringsThatIncludeMyLetters();
            }
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
            mMySubStringResults.Clear();
        }

        public List<string>
        //-----------------------------------------------------------
        SubSetScores
        //-----------------------------------------------------------
            (
            List<string> aList, 
            string aSub,
            List<char> aLetters
            )
        {

            return aList;
        }

        //-----------------------------------------------------------
        // Private Functions
        //-----------------------------------------------------------

        private void
        //-----------------------------------------------------------
        GetPreliminaryResults
        //-----------------------------------------------------------
            (
            )
        {
            mDictionary.Reset();
            string theNextWord = System.String.Empty;
            while (mDictionary.HasMoreWords())
            {
                theNextWord = mDictionary.GetNextWord();
                if (theNextWord.Contains(mString))
                {
                    mPreliminaryResults.Add(theNextWord);
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
            
            foreach (string s in mPreliminaryResults)
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
            DiscoverSubStringsThatIncludeMyLetters();
            AddSubstringsWithMyLettersHeader();
            mMySubStringResults.Sort();
            foreach (string s in mMySubStringResults)
            {
                mResults.Add(s);
            }
        }

        private void
        //-----------------------------------------------------------
        DiscoverSubStringsThatIncludeMyLetters
        //-----------------------------------------------------------
            (
            )
        {
            string theTemp = System.String.Empty;
            string theResult = System.String.Empty;

            if (!mLetters.Contains('?'))
            {

                foreach (string s in mPreliminaryResults)
                {
                    theResult = String.Copy(s);
                    theTemp = ReplaceFirst(theResult, mString, "");

                    if (mMatcher.Evaluate(theTemp, mLetters))
                    {
                        if(!mMySubStringResults.Contains(theResult) )
                        {
                            mMySubStringResults.Add(theResult);
                        }
                    }
                }
            }
            else
            {
                SubStringsWithBlank();
            }
        }

        private void
        //-----------------------------------------------------------
        SubStringsWithBlank
        //-----------------------------------------------------------
            (
            )
        {
            mLetters.Remove('?');
            foreach (char c in mAlphabet)
            {
                mLetters.Add(c);
                DiscoverSubStringsThatIncludeMyLetters();
                mLetters.Remove(c);
            }
        }


        private void 
        //-----------------------------------------------------------
        AddSubStringHeader
        //-----------------------------------------------------------
            (
            )
        {
            mResults.Add("---------------------------");
            mResults.Add("Words containing " + mString);
            mResults.Add("---------------------------");
        }

        private void
        //-----------------------------------------------------------
        AddSubstringsWithMyLettersHeader
        //-----------------------------------------------------------
            (
            )
        {
            mResults.Add("---------------------------");
            mResults.Add("Words I can make with " + mString);
            mResults.Add("---------------------------");
        }

        // http://stackoverflow.com/questions/8809354/replace-first-occurrence-of-pattern-in-a-string
        public string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        //-----------------------------------------------------------
        // Member Data
        //-----------------------------------------------------------
        private Dictionary_t mDictionary;
        private List<char> mLetters;
        private List<string> mResults;
        private List<string> mPreliminaryResults;
        private List<string> mMySubStringResults;
        private string mString;
        private Matcher_t mMatcher;
        private char[] mAlphabet;

    }
}
