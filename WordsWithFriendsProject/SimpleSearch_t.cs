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
            mHash = new HashSet<string>();
            mPreliminaryResults = new List<string>();
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

            var theWord = from word in mDictionary.WordList
                          where String.Compare(word, mString) == 0
                          select word;

            if (theWord.Count() > 0 )
            {
                mResults.Add("--- " + mString + " is in the Dictionary");
            }
            else
            {
                mResults.Add("--- " + mString + " is not in the Dictionary");
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
            
            return mResults;
        }

        public void
        //-----------------------------------------------------------
        Reset
        //-----------------------------------------------------------
            (
            )
        {
            mResults.Clear();
            mPreliminaryResults.Clear();
            mHash.Clear();
        }

        public List<string>
        //-----------------------------------------------------------
        SubSetScores
        //-----------------------------------------------------------
            (
            string aWord,
            List<char> aLetters
            )
        {
            Reset();
            mString = aWord.ToLower();
            mLetters = aLetters;

            GetPreliminaryResults();
            DiscoverSubStringsThatIncludeMyLetters();

            mResults = mResults.Concat(mHash).ToList();
            mResults.Sort();

            return mResults;
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
            var theWords = from words in mDictionary.WordList
                           where words.Contains(mString)
                           select words;

            mPreliminaryResults = mPreliminaryResults.Concat(theWords).ToList();
        }

        private void
        //-----------------------------------------------------------
        AddSubStringResults
        //-----------------------------------------------------------
            (
            )
        {
            mResults = mResults.Concat(mPreliminaryResults).ToList();
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
            mResults = mResults.Concat(mHash).ToList();
            mResults.Sort();
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

            if (mLetters[0] != '?')
            {
                foreach (string s in mPreliminaryResults)
                {
                    List<char> theCopy = new List<char>(mLetters);
                    theResult = String.Copy(s);
                    theTemp = ReplaceFirst(theResult, mString, "");

                    if (mMatcher.Evaluate(theTemp, theCopy))
                    {
                        mHash.Add(theResult);
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
            foreach (char c in mAlphabet)
            {
                mLetters[0] = c;
                DiscoverSubStringsThatIncludeMyLetters();
            }
        }


        private void 
        //-----------------------------------------------------------
        AddSubStringHeader
        //-----------------------------------------------------------
            (
            )
        {
            mResults.Add("--- Words containing " + mString+"---");
        }

        private void
        //-----------------------------------------------------------
        AddSubstringsWithMyLettersHeader
        //-----------------------------------------------------------
            (
            )
        {
            mResults.Add("--- Words I can make with " + mString +"---");
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
        private HashSet<string> mHash;
        private string mString;
        private Matcher_t mMatcher;
        private char[] mAlphabet;

    }
}
