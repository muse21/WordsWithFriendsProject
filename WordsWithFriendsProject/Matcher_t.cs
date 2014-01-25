using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    //-----------------------------------------------------------
    class Matcher_t
    //-----------------------------------------------------------
    {
        //-----------------------------------------------------------
        public Matcher_t
        //-----------------------------------------------------------
            (
            )
        {
        }

        //-----------------------------------------------------------
        // Public Functions
        //-----------------------------------------------------------

        //----------------------------------------------------------
        public bool Evaluate
        //-----------------------------------------------------------
            (
            string aWord,
            List<char> aLetterList
            )
        {
            List<char> theListCopy = new List<char>();

            foreach (char c in aLetterList)
            {
                theListCopy.Add(c);
            }

            foreach (char c in aWord)
            {
                if (theListCopy.Contains(c))
                {
                    theListCopy.Remove(c);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

    }
}
