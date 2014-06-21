using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    public enum TileBonus_t
    {
        eNone,
        eDoubleLetter,
        eTripleLetter,
        eDoubleWord,
        eTripleWord
    };

    public enum SearchType_t
    {
        eBlank,
        ePlayed,
        eAbove,
        eRight,
        eBelow,
        eLeft,
        eAboveRight,
        eAboveLeft,
        eAboveLeftRight,
        eAboveBelowRight,
        eAboveBelowLeft,
        eAboveBelow,
        eBelowRight,
        eBelowLeft,
        eBelowRightLeft,
        eRightLeft,
        eAll,
        eDirty
    };

    class Tile_t : ICloneable
    {
        //---------------------------------------------------------------------
        public Tile_t
            (
            int aX,
            int aY
            )
        {
            X = aX;
            Y = aY;
            Letter = ' ';
            Bonus = TileBonus_t.eNone;
            SearchType = SearchType_t.eBlank;
            IsWild = false;
        }

        public object
        //---------------------------------------------------------------------
        Clone
            (
            )
        {
            return this.MemberwiseClone();
        }

        public bool
        //---------------------------------------------------------------------
        HasLetter
            (
            )
        {
            return this.Letter != ' ';
        }

        //---------------------------------------------------------------------
        // Member Data
        //---------------------------------------------------------------------
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Letter { get; set; }
        public TileBonus_t Bonus { get; set; }
        public SearchType_t SearchType;
        public bool IsWild{ get; set; }
    }
}
