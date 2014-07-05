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
        SimpleHZTemplate
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

            int theMaxWordLength = theTemplateSize - 
                                   2 - 
                                   theLeftSubstringLength - 
                                   theRightSubstringLength;

            return new Template_t( theTemplate,
                                    0 /* WordLength */,
                                   theLeftSubstringLength,
                                   theRightSubstringLength,
                                   ( theLeftSubstringLength + theSpacesLeftToLetter ),
                                   theMaxWordLength );
        }
    
        public static Template_t
        //---------------------------------------------------------------------
        SimpleVerticalAboveTemplate
            (
            GameBoard_t aGameBoard,
            Tile_t aTile
            )
        {
            int theSpacesToTop = aTile.Y;
            int theSpacesToBottom = 14 - aTile.Y;
            int theSubstringUpLength = 0;
            int theSpacesUpAfterSubstringToLetter = 0;
            int theSpacesDownToLetter = 0;
            int theDownSubstringLengthAfterSpaces = 0;
            int theSecondUpSubstringLength = 0;


            theSubstringUpLength = GetSubstringUpLength(aGameBoard, aTile.X, aTile.Y - 1);

            for (int i = 0; i < (theSpacesToTop - theSubstringUpLength); ++i)
            {
                if (aGameBoard.mBoard[aTile.X, aTile.Y - i  - theSubstringUpLength - 1].Letter == ' ')
                {
                    ++theSpacesUpAfterSubstringToLetter;
                }
                else
                {
                    theSecondUpSubstringLength = GetSubstringUpLength(aGameBoard, aTile.X, aTile.Y - i - theSubstringUpLength - 1);
                    break;
                }
            }

            for (int i = aTile.Y + 1; i <= 14; ++i)
            {
                if (aGameBoard.mBoard[aTile.X, i].Letter == ' ')
                {
                    ++theSpacesDownToLetter;
                }
                else
                {
                    theDownSubstringLengthAfterSpaces = GetSubstringDownLength(aGameBoard, aTile.X, i);
                    break;
                }
            }

            int theTemplateSize = theSecondUpSubstringLength +
                                  theSpacesUpAfterSubstringToLetter +
                                  theSubstringUpLength +
                                  1 +
                                  theSpacesDownToLetter +
                                  theDownSubstringLengthAfterSpaces;

            Tile_t[] theTemplate = new Tile_t[theTemplateSize];


            for (int i = 0; i < theTemplateSize; ++i)
            {
                int theTileY = i + aTile.Y - theSecondUpSubstringLength - theSpacesUpAfterSubstringToLetter - theSubstringUpLength;
                theTemplate[i] = (Tile_t)aGameBoard.mBoard[aTile.X, theTileY].Clone();
            }

            int theMaxWordLength = theSpacesUpAfterSubstringToLetter + theSubstringUpLength + theSpacesDownToLetter + 1 - 2;

            return new Template_t( theTemplate,
                                   theSubstringUpLength,
                                   theSecondUpSubstringLength,
                                   theDownSubstringLengthAfterSpaces,
                                   ( theSubstringUpLength + theSpacesUpAfterSubstringToLetter + theSecondUpSubstringLength ),
                                   theMaxWordLength );
        }

        public static Template_t
        //---------------------------------------------------------------------
        SimpleVerticalBelowTemplate
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

            int theMaxWordLength = theTemplateSize -
                                   2 -
                                   theUpSubstringLength -
                                   theDownSubstringLengthAfterSpaces;

            return new Template_t( theTemplate,
                                   theSubstringDownSize, 
                                   theUpSubstringLength,
                                   theDownSubstringLengthAfterSpaces,
                                   ( theUpSubstringLength + theSpacesUpToLetter ),
                                   theMaxWordLength );
        }

        internal static object 
        //---------------------------------------------------------------------
        SimpleHorizontalRightTemplate
            (
            GameBoard_t aGameBoard, 
            Tile_t aTile
            )
        {
            int theSpacesToRight = 14 - aTile.X;
            int theSpacesToLeft = aTile.X;
            int theSubstringRightSize = 0;
            int theSpacesRightAfterSubstringToLetter = 0;
            int theSpacesLeftToLetter = 0;
            int theRightSubstringLengthAfterSpaces = 0;
            int theLeftSubstringLength = 0;

            theSubstringRightSize = GetSubstringRightLength(aGameBoard, aTile.X+1, aTile.Y);
            
            for (int i = 0; i < (theSpacesToRight - theSubstringRightSize); ++i)
            {
                if (aGameBoard.mBoard[i + theSubstringRightSize + aTile.X + 1, aTile.Y].Letter == ' ')
                {
                    ++theSpacesRightAfterSubstringToLetter;
                }
                else
                {
                    theRightSubstringLengthAfterSpaces = GetSubstringRightLength(aGameBoard, i + theSubstringRightSize + aTile.X + 1, aTile.Y);
                    break;
                }
            }

            for (int i = aTile.X - 1; i >= 0; --i)
            {
                if (aGameBoard.mBoard[i, aTile.Y].Letter == ' ')
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
                                  theSubstringRightSize +
                                  theSpacesRightAfterSubstringToLetter +
                                  theRightSubstringLengthAfterSpaces;

            Tile_t[] theTemplate = new Tile_t[theTemplateSize];

            int theTileX = 0;
            for (int i = 0; i < theTemplateSize; ++i)
            {
                theTileX = i + aTile.X - theLeftSubstringLength - theSpacesLeftToLetter;
                theTemplate[i] = (Tile_t)aGameBoard.mBoard[theTileX, aTile.Y].Clone();
            }

            int theMaxWordLength = theTemplateSize -
                                   2 -
                                   theLeftSubstringLength -
                                   theRightSubstringLengthAfterSpaces;

            return new Template_t( theTemplate,
                                   theSubstringRightSize, 
                                   theLeftSubstringLength,
                                   theRightSubstringLengthAfterSpaces,
                                   ( theLeftSubstringLength + theSpacesLeftToLetter ),
                                   theMaxWordLength );
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
