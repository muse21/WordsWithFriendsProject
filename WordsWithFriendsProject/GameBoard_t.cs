using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace WordsWithFriendsProject
{

    class GameBoard_t
    {
        //---------------------------------------------------------------------
        public GameBoard_t 
            (
            )
        {
            mBoard = new Tile_t[ scBoardDimension, scBoardDimension ];
            InitilizeGameBoard();
            SetTileBonusValues();
        }

        //---------------------------------------------------------------------
        // PUBLIC METHODS
        //---------------------------------------------------------------------
        
        public void
        //---------------------------------------------------------------------
        ClearBoard
            (
            )
        {
            throw new NotImplementedException();
        }

        public void
        //---------------------------------------------------------------------
        SetAllTilesSearchType
            (
            )
        {
            for( int i = 0; i < scBoardDimension; ++i )
            {
                for( int j = 0; j < scBoardDimension; ++j )
                {
                    bool hasUp = false;
                    bool hasRight = false;
                    bool hasDown = false;
                    bool hasLeft = false;
                    // lookup
                    if( i - 1 >= 0 )
                    {
                        hasUp = this.mBoard[j,(i-1)].Letter != ' ';
                    }
                    // lookright
                    if( j + 1 <= scBoardDimension - 1 )
                    {
                        hasRight = this.mBoard[(j+1),i].Letter != ' ';
                    }
                    // lookdown
                    if( i + 1 <= scBoardDimension - 1 )
                    {
                        hasDown = this.mBoard[j, (i + 1)].Letter != ' ';
                    }
                    // lookleft
                    if( j - 1 >= 0 )
                    {
                        hasLeft = this.mBoard[(j - 1), i].Letter != ' ';
                    }

                    mBoard[j, i].SearchType = SetSearchType( mBoard[j,i], hasUp, hasRight, hasDown, hasLeft);

                }
            }
        }


        public SearchType_t
        //---------------------------------------------------------------------
        GetSearchType
            (
            Tile_t aTile
            )
        {
            return SearchType_t.eBlank;
        }

        //---------------------------------------------------------------------
        // PRIVATE METHODS
        //---------------------------------------------------------------------

        private void
        //---------------------------------------------------------------------
        InitilizeGameBoard
            (
            )
        {
            for(int i = 0; i<scBoardDimension; ++i )
            {
                for(int j = 0; j < scBoardDimension; ++j )
                {
                    mBoard[j,i] = new Tile_t(j,i);
                }
            }
        }

        private void
        //---------------------------------------------------------------------
        SetTileBonusValues
            (
            )
        {
            SetDoubleLetters();
            SetTripleLetters();
            SetDoubleWords();
            SetTripleWords();
        }

        private void
        //---------------------------------------------------------------------
        SetDoubleLetters
            (
            )
        {
            mBoard[2, 1].Bonus = TileBonus_t.eDoubleLetter;
            mBoard[12, 1].Bonus = TileBonus_t.eDoubleLetter;

            mBoard[1, 2].Bonus = TileBonus_t.eDoubleLetter;
            mBoard[4, 2].Bonus = TileBonus_t.eDoubleLetter;
            mBoard[10, 2].Bonus = TileBonus_t.eDoubleLetter;
            mBoard[13, 2].Bonus = TileBonus_t.eDoubleLetter;
            
            mBoard[2, 4].Bonus = TileBonus_t.eDoubleLetter;
            mBoard[6, 4].Bonus = TileBonus_t.eDoubleLetter;
            mBoard[8, 4].Bonus = TileBonus_t.eDoubleLetter;
            mBoard[12, 4].Bonus = TileBonus_t.eDoubleLetter;

            mBoard[4, 6].Bonus = TileBonus_t.eDoubleLetter;
            mBoard[10, 6].Bonus = TileBonus_t.eDoubleLetter;

            mBoard[4, 8].Bonus = TileBonus_t.eDoubleLetter;
            mBoard[10, 8].Bonus = TileBonus_t.eDoubleLetter;

            mBoard[2, 10].Bonus = TileBonus_t.eDoubleLetter;
            mBoard[6, 10].Bonus = TileBonus_t.eDoubleLetter;
            mBoard[8, 10].Bonus = TileBonus_t.eDoubleLetter;
            mBoard[12, 10].Bonus = TileBonus_t.eDoubleLetter;

            mBoard[1, 12].Bonus = TileBonus_t.eDoubleLetter;
            mBoard[4, 12].Bonus = TileBonus_t.eDoubleLetter;
            mBoard[10, 12].Bonus = TileBonus_t.eDoubleLetter;
            mBoard[13, 12].Bonus = TileBonus_t.eDoubleLetter;

            mBoard[2, 13].Bonus = TileBonus_t.eDoubleLetter;
            mBoard[12, 13].Bonus = TileBonus_t.eDoubleLetter;

        }

        private void 
        //---------------------------------------------------------------------
        SetTripleLetters
            (
            )
        {
            mBoard[6, 0].Bonus = TileBonus_t.eTripleLetter;
            mBoard[8, 0].Bonus = TileBonus_t.eTripleLetter;
            
            mBoard[3, 3].Bonus = TileBonus_t.eTripleLetter;
            mBoard[11, 3].Bonus = TileBonus_t.eTripleLetter;
            
            mBoard[5, 5].Bonus = TileBonus_t.eTripleLetter;
            mBoard[9, 5].Bonus = TileBonus_t.eTripleLetter;
            
            mBoard[0, 6].Bonus = TileBonus_t.eTripleLetter;
            mBoard[14, 6].Bonus = TileBonus_t.eTripleLetter;
            
            mBoard[0, 8].Bonus = TileBonus_t.eTripleLetter;
            mBoard[14, 8].Bonus = TileBonus_t.eTripleLetter;

            mBoard[5, 9].Bonus = TileBonus_t.eTripleLetter;
            mBoard[9, 9].Bonus = TileBonus_t.eTripleLetter;
            
            mBoard[3, 11].Bonus = TileBonus_t.eTripleLetter;
            mBoard[11, 11].Bonus = TileBonus_t.eTripleLetter;
            
            mBoard[6, 14].Bonus = TileBonus_t.eTripleLetter;
            mBoard[8, 14].Bonus = TileBonus_t.eTripleLetter;
        }

        private void
        //---------------------------------------------------------------------
        SetDoubleWords
            (
            )
        {
            mBoard[5, 1].Bonus = TileBonus_t.eDoubleWord;
            mBoard[9, 1].Bonus = TileBonus_t.eDoubleWord;
        
            mBoard[7, 3].Bonus = TileBonus_t.eDoubleWord;
            
            mBoard[1, 5].Bonus = TileBonus_t.eDoubleWord;
            mBoard[13, 5].Bonus = TileBonus_t.eDoubleWord;
            
            mBoard[3, 7].Bonus = TileBonus_t.eDoubleWord;
            mBoard[11, 7].Bonus = TileBonus_t.eDoubleWord;
            
            mBoard[1, 9].Bonus = TileBonus_t.eDoubleWord;
            mBoard[13, 9].Bonus = TileBonus_t.eDoubleWord;
            
            mBoard[7, 11].Bonus = TileBonus_t.eDoubleWord;
            
            mBoard[5, 13].Bonus = TileBonus_t.eDoubleWord;
            mBoard[9, 13].Bonus = TileBonus_t.eDoubleWord;
        }

        private void
        //---------------------------------------------------------------------
        SetTripleWords
            (
            )
        {
            mBoard[3, 0].Bonus = TileBonus_t.eTripleWord;
            mBoard[11, 0].Bonus = TileBonus_t.eTripleWord;

            mBoard[0, 3].Bonus = TileBonus_t.eTripleWord;
            mBoard[14, 3].Bonus = TileBonus_t.eTripleWord;

            mBoard[0, 11].Bonus = TileBonus_t.eTripleWord;
            mBoard[14, 11].Bonus = TileBonus_t.eTripleWord;

            mBoard[3, 14].Bonus = TileBonus_t.eTripleWord;
            mBoard[11, 14].Bonus = TileBonus_t.eTripleWord;

        }

        private SearchType_t 
        //---------------------------------------------------------------------
        SetSearchType
            (
            Tile_t aTile,
            bool aHasUp, 
            bool aHasRight, 
            bool aHasDown,
            bool aHasLeft
            )
        {
            if( aTile.HasLetter() )
            {
                return SearchType_t.ePlayed;
            }

            var theSearchType = SearchType_t.eBlank;

            var theThousands = aHasUp ? 1000 : 0;
            var theHundreds = aHasRight ? 100 : 0;
            var theTens = aHasDown ? 10 : 0;
            var theOnes = aHasLeft ? 1 : 0;

            var theCase = theThousands +
                          theHundreds +
                          theTens + 
                          theOnes;

            switch( theCase )
            {
                case( 1111 ):
                    theSearchType = SearchType_t.eAll;
                    break;
                case (1110):
                    theSearchType = SearchType_t.eAboveBelowRight;
                    break;
                case( 1101 ):
                    theSearchType = SearchType_t.eAboveLeftRight;
                    break;
                case( 1100 ):
                    theSearchType = SearchType_t.eAboveRight;
                    break;
                case( 1011 ):
                    theSearchType = SearchType_t.eAboveBelowLeft;
                    break;
                case( 1010 ):
                    theSearchType = SearchType_t.eAboveBelow;
                    break;
                case( 1001 ):
                    theSearchType = SearchType_t.eAboveLeft;
                    break;
                case( 1000 ):
                    theSearchType = SearchType_t.eAbove;
                    break;
                case( 0111 ):
                    theSearchType = SearchType_t.eBelowRightLeft;
                    break;
                case( 0110 ):
                    theSearchType = SearchType_t.eBelowRight;
                    break;
                case( 0101 ):
                    theSearchType = SearchType_t.eRightLeft;
                    break;
                case( 0100 ):
                    theSearchType = SearchType_t.eRight;
                    break;
                case( 0011 ):
                    theSearchType = SearchType_t.eBelowLeft;
                    break;
                case( 0010 ):
                    theSearchType = SearchType_t.eBelow;
                    break;
                case( 0001 ):
                    theSearchType = SearchType_t.eLeft;
                    break;
                case( 0000 ):
                default: 
                    theSearchType = SearchType_t.eBlank;
                    break;
            }

            return theSearchType;
        }

        //---------------------------------------------------------------------
        // Member Data
        //---------------------------------------------------------------------
        public Tile_t[ , ] mBoard;
        private const int scBoardDimension = 15;
    }
}
