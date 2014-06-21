using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    class MyWords_t
    {
        //---------------------------------------------------------------------
        // Public Functions
        //---------------------------------------------------------------------

        //---------------------------------------------------------------------
        public MyWords_t
            (
            Dictionary_t aDictionary
            )
        {
            mDictionary = aDictionary;
            mHash = new HashSet<string>();
            mLetters = new List<char>();
            mMatcher = new Matcher_t();
            mResultList = new List<string>();
            mAlphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 
                's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        }
        
        public List<string>
        //---------------------------------------------------------------------
        GetResults
            (
            List<char> aLetters
            )
        {
            mLetters.Clear();
            mResultList.Clear();
            mHash.Clear();
            mLetters = aLetters;

            FindMatches();

            mResultList = mHash.ToList();
            mResultList.Sort();

            return mResultList;
        }

        public List<LetterWord_t>
        //---------------------------------------------------------------------
        GetLetterWordResults
            (
            List<Letter_t> aLetters
            )
        {
            var theLetterWordResults = new List<LetterWord_t>();
            List<char> theLetters = new List<char>();
            foreach( var Letter in aLetters)
            {
                theLetters.Add(Letter.Letter);
            }
            var theCallWithThis = new List<char>( theLetters);

            foreach (var theResult in GetResults(theLetters))
            {
                theLetterWordResults.Add(new LetterWord_t(theResult, theCallWithThis));
            }

            return theLetterWordResults;
        }

        //---------------------------------------------------------------------
        // Private Functions
        //---------------------------------------------------------------------

        private void
        //---------------------------------------------------------------------
        FindMatches
            (
            )
        {
            if (mLetters[0] != '?')
            {
                foreach( var theWord in mDictionary.WordList )
                {
                    if (mMatcher.Evaluate(theWord, mLetters))
                    {
                        mHash.Add(theWord);
                    }
                }
            }
            else
            {
                FindMatchesWithBlank();
            }
        }

        private void
        //-----------------------------------------------------------
        FindMatchesWithBlank
        //-----------------------------------------------------------
            (
            )
        {
            foreach (char c in mAlphabet)
            {
                mLetters[0] = c;
                FindMatches();
            }
        }
        
        //-----------------------------------------------------------
        // Member Data
        //-----------------------------------------------------------
        private Dictionary_t mDictionary;
        private List<char> mLetters;
        private HashSet<string> mHash;
        private List<string> mResultList;
        private Matcher_t mMatcher;
        private char[] mAlphabet;
        const char scDefaultChar = '_';
    }
}
