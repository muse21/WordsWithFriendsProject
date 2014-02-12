using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    //-----------------------------------------------------------
    class MyWords_t
    //-----------------------------------------------------------
    {
        //-----------------------------------------------------------
        // Public Functions
        //-----------------------------------------------------------
        public MyWords_t
            (
            Dictionary_t aDictionary
            )
        {
            mDictionary = aDictionary;
            mDictionary.Reset();
            mLetters = new List<char>();
            mMatcher = new Matcher_t();
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
            mLetters.Clear();
            mResultList.Clear();
            mLetters = aLetters;

            mDictionary.Reset();
            FindMatches();
            mDictionary.Reset();

            mResultList.Sort();

            return mResultList;
        }


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

                        if (!mResultList.Contains(theCurrentWord))
                        {
                            mResultList.Add(theCurrentWord);
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
        
        //-----------------------------------------------------------
        // Member Data
        //-----------------------------------------------------------
        private Dictionary_t mDictionary;
        private List<char> mLetters;
        private List<string> mResultList;
        private Matcher_t mMatcher;
        private char[] mAlphabet;
        const char scDefaultChar = '-';
    }
}
