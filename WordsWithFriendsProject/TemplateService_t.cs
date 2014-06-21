using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    static class TemplateService_t
    {
        public static Template_t
        //---------------------------------------------------------------------
        SimpleHZBlankTemplate
            (
            GameBoard_t aGameBoard,
            Tile_t aTile
            )
        {
            int theSpacesToRight = 14 - aTile.X;
            int theSpacesToLeft = aTile.X;
            int theSpacesRightToLetter = 0;
            int theSpacesLeftToLetter = 0;
            int theRightSubstringLength = 0;
            int theLeftSubstringLength = 0;
            
            for (int i = 0; i < theSpacesToRight; ++i)
            {
                if( aGameBoard.mBoard[i+1+aTile.X,aTile.Y].Letter == ' ')
                {
                    ++theSpacesRightToLetter;
                }
                else
                {
                    theRightSubstringLength = GetSubstringRightLength(aGameBoard, i+1+aTile.X, aTile.Y);
                    break;
                }
            }

            for (int i = aTile.X - 1; i >= 0; --i )
            {
                if( aGameBoard.mBoard[i, aTile.Y].Letter == ' ' )
                {
                    ++theSpacesLeftToLetter;
                }
                else
                {
                    theLeftSubstringLength = GetSubstringLeftLength(aGameBoard, i, aTile.Y);
                    break;
                }
            }

            int theTemplateSize = theLeftSubstringLength +
                                  theSpacesLeftToLetter +
                                  1 +
                                  theSpacesRightToLetter +
                                  theRightSubstringLength;

            Tile_t[] theTemplate = new Tile_t[theTemplateSize];

            for (int i = 0; i < theTemplateSize; ++i )
            {
                int theTileX = i + aTile.X - theLeftSubstringLength - theSpacesLeftToLetter;
                theTemplate[i] = (Tile_t)aGameBoard.mBoard[theTileX, aTile.Y].Clone();
            }

            return new Template_t( theTemplate,
                                    0 /* WordLength */,
                                   theLeftSubstringLength,
                                   theRightSubstringLength,
                                   ( theLeftSubstringLength + theSpacesLeftToLetter ) );
        }

        public static Template_t
        //---------------------------------------------------------------------
        SimpleVerticalWordTemplate
            (
            GameBoard_t aGameBoard,
            Tile_t aTile
            )
        {
            int theSpacesToBottom = 14 - aTile.Y;
            int theSpacesToTop = aTile.Y;
            int theSubstringDownSize = 0;
            int theSpacesDownAfterSubstringToLetter = 0;
            int theSpacesUpToLetter = 0;
            int theDownSubstringLengthAfterSpaces = 0;
            int theUpSubstringLength = 0;

            theSubstringDownSize = GetSubstringDownLength(aGameBoard, aTile.X, aTile.Y + 1);
            
            for (int i = 0; i < (theSpacesToBottom - theSubstringDownSize); ++i)
            {
                if (aGameBoard.mBoard[aTile.X, i + theSubstringDownSize + aTile.Y + 1].Letter == ' ')
                {
                    ++theSpacesDownAfterSubstringToLetter;
                }
                else
                {
                    theDownSubstringLengthAfterSpaces = GetSubstringDownLength(aGameBoard, aTile.X, i + theSubstringDownSize + aTile.Y + 1);
                    break;
                }
            }


            for (int i = aTile.Y - 1; i >= 0; --i)
            {
                if (aGameBoard.mBoard[aTile.X, i].Letter == ' ')
                {
                    ++theSpacesUpToLetter;
                }
                else
                {
                    theUpSubstringLength = GetSubstringUpLength(aGameBoard, aTile.X, i);
                    break;
                }
            }

            int theTemplateSize = theUpSubstringLength +
                                  theSpacesUpToLetter +
                                  1 +
                                  theSubstringDownSize +
                                  theSpacesDownAfterSubstringToLetter +
                                  theDownSubstringLengthAfterSpaces;

            Tile_t[] theTemplate = new Tile_t[theTemplateSize];


            for (int i = 0; i < theTemplateSize; ++i)
            {
                int theTileY = i + aTile.Y - theUpSubstringLength - theSpacesUpToLetter;
                theTemplate[i] = (Tile_t)aGameBoard.mBoard[aTile.X, theTileY].Clone();
            }

            return new Template_t( theTemplate,
                                   theSubstringDownSize, 
                                   theUpSubstringLength,
                                   theDownSubstringLengthAfterSpaces,
                                   ( theUpSubstringLength + theSpacesUpToLetter ) );
        }


        //---------------------------------------------------------------------
        // Private Functions
        //---------------------------------------------------------------------

        private static int
        //---------------------------------------------------------------------
        GetSubstringRightLength
            (
            GameBoard_t aGameBoard, 
            int aX,
            int aY
            )
        {
            int theReturn = 0;

            while( aX != 15 &&
                   aGameBoard.mBoard[aX, aY].Letter != ' ' )
            {
                ++theReturn;
                ++aX;
            }

            return theReturn;
        }

        private static int
        //---------------------------------------------------------------------
        GetSubstringLeftLength
           (
           GameBoard_t aGameBoard,
           int aX,
           int aY
           )
        {
            int theReturn = 0;

            while( aX != -1 &&
                   aGameBoard.mBoard[aX, aY].Letter != ' ' )
            {
                ++theReturn;
                --aX;
            }
            return theReturn;
        }

        private static int
        //---------------------------------------------------------------------
        GetSubstringDownLength
            (
            GameBoard_t aGameBoard,
            int aX,
            int aY
            )
        {
            int theReturn = 0;

            while (aY != 15 &&
                   aGameBoard.mBoard[aX, aY].Letter != ' ')
            {
                ++theReturn;
                ++aY;
            }
            return theReturn;
        }

        private static int
        //---------------------------------------------------------------------
        GetSubstringUpLength
           (
           GameBoard_t aGameBoard,
           int aX,
           int aY
           )
        {
            int theReturn = 0;

            while (aY != -1 &&
                   aGameBoard.mBoard[aX, aY].Letter != ' ')
            {
                ++theReturn;
                --aY;
            }
            return theReturn;
        }

        //---------------------------------------------------------------------
        // Private Data
        //---------------------------------------------------------------------
    }
}
