using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    class Template_t
    {
        public Template_t
            (
            Tile_t[] aTemplate,
            int aCenterStringSize,
            int aLeftStringSize,
            int aRightStringSize,
            int aRootIndex,
            int aMaxWordLength
            )
        {
            mTemplate = aTemplate;
            Size = mTemplate.Count();
            StringOnLeft = aLeftStringSize > 0;
            StringOnRight = aRightStringSize > 0;
            CenterStringSize = aCenterStringSize;
            LeftStringSize = aLeftStringSize;
            RightStringSize = aRightStringSize;
            RootIndex = aRootIndex;
            MaxWordLength = aMaxWordLength;
        }

        public Tile_t
            //---------------------------------------------------------------------
        At
            (
            int aIndex
            )
        {
            if (aIndex < this.Size)
            {
                return mTemplate[aIndex];
            }
            return null;
        }

        public bool
        //---------------------------------------------------------------------
        StringOnTop
            (
            )
        {
            return StringOnLeft;
        }

        public bool
        //---------------------------------------------------------------------
        StringOnBottom
            (
            )
        {
            return StringOnRight;
        }

        public int
        //---------------------------------------------------------------------
        TopStringSize
            (
            )
        {
            return LeftStringSize;
        }

        public int
        //---------------------------------------------------------------------
        BottomStringSize
            (
            )
        {
            return RightStringSize;
        }

        //---------------------------------------------------------------------
        //  Member Data
        //---------------------------------------------------------------------
        public Tile_t[] mTemplate { get; private set; }
        public int Size { get; private set; }
        public bool StringOnLeft { get; private set; }
        public bool StringOnRight { get; private set; }
        public int CenterStringSize { get; private set; }
        public int LeftStringSize { get; private set; }
        public int RightStringSize { get; private set; }
        public int RootIndex { get; private set; }
        public int MaxWordLength { get; private set; }
    }


}
