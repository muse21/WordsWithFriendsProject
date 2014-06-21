using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    class Letter_t : ICloneable
    {
        public Letter_t
            (
            char aLetter,
            bool aIsWild
            )
        {
            Letter = aLetter;
            IsWild = aIsWild;
        }

        public object
        //---------------------------------------------------------------------
        Clone
            (
            )
        {
            return this.MemberwiseClone();
        }

        //---------------------------------------------------------------------
        //  MEMBER DATA
        //---------------------------------------------------------------------

        public char Letter { get; set; }
        public bool IsWild { get; private set; }
    }
}
