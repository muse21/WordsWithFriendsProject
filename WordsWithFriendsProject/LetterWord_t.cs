using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    class LetterWord_t
    {
        public LetterWord_t
        //---------------------------------------------------------------------
        
            (
            List<Letter_t> aLetterWord
            )
        {
            LetterWord = aLetterWord;
        }

        public LetterWord_t
        //---------------------------------------------------------------------
            (
            string aString,
            List<char> aLetters
            )
        {
            var theLetterWord = new List<Letter_t>();

            if( IsThereABlankTile( aLetters))
            {
                foreach( var theLetter in aString )
                {
                    if( aLetters.Contains(theLetter))
                    {
                        theLetterWord.Add(new Letter_t(theLetter, false));
                    }
                    else
                    {
                        // wild
                        theLetterWord.Add(new Letter_t(theLetter, true));
                    }
                }
            }
            else
            {
                foreach( var theLetter in aString)
                {
                    theLetterWord.Add(new Letter_t(theLetter, false));
                }
            }

            LetterWord = theLetterWord;
        }

        public int
        //---------------------------------------------------------------------
        Size
            (
            )
        {
            return LetterWord.Count();
        }

        public Letter_t
        //---------------------------------------------------------------------
        At
           (
           int aIndex
           )
        {
            return LetterWord.ElementAt(aIndex);
        }

        public string
        //---------------------------------------------------------------------
        Word
            (
            )
        {
            string theWord = System.String.Empty;
            foreach( var theLetter in LetterWord)
            {
                theWord += theLetter.Letter;
            }
            return theWord;
        }

        //---------------------------------------------------------------------
        //  Private Functions
        //---------------------------------------------------------------------

        private bool
        //---------------------------------------------------------------------
        IsThereABlankTile
            (
            List<char> aLetters
            )
        {
            return aLetters[0] == '?';
        }

        public List<Letter_t> LetterWord { get; private set; }

        internal bool 
        //---------------------------------------------------------------------
        HasAtLeastNOfLetter
            (
            LetterWord_t word,
            char p,
            int n
            )
        {
            int count = 0;
            foreach( var c in word.LetterWord)
            {
                if (c.Letter == p) ++count;
                if (count > n-1) break;
            }
            return count > n-1;
        }
    }
}
