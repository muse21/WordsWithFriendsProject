using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    //-----------------------------------------------------------
    class Matcher_t
    //-------------------------------------------------------------------------
    {
        //---------------------------------------------------------------------
        public Matcher_t
            (
            )
        {
        }

        //---------------------------------------------------------------------
        // Public Functions
        //---------------------------------------------------------------------

        //---------------------------------------------------------------------
        public bool Evaluate
            (
            string aWord,
            List<char> aLetterList
            )
        {
            LinkedList<char> theListCopy = new LinkedList<char>(aLetterList);
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
