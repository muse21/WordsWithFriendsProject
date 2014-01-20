using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    //-----------------------------------------------------------
    class ScoreTable_t
    //-----------------------------------------------------------
    {
        //-----------------------------------------------------------
        // Public Functions
        //-----------------------------------------------------------

        //-----------------------------------------------------------
        public ScoreTable_t
        //-----------------------------------------------------------
            (
            )
        {
        }

        public Int32
        //-----------------------------------------------------------
        GetScore
        //-----------------------------------------------------------
            (
            char aChar
            )
        {
            char theChar = char.ToLower(aChar);
            Int32 theValue = 0;
            switch (theChar)
            {
                case 'a':
                    theValue = scAValue;
                    break;
                case 'b':
                    theValue = scBValue;
                    break;
                case 'c':
                    theValue = scCValue;
                    break;
                case 'd':
                    theValue = scDValue;
                    break;
                case 'e':
                    theValue = scEValue;
                    break;
                case 'f':
                    theValue = scFValue;
                    break;
                case 'g':
                    theValue = scGValue;
                    break;
                case 'h':
                    theValue = scHValue;
                    break;
                case 'i':
                    theValue = scIValue;
                    break;
                case 'j':
                    theValue = scJValue;
                    break;
                case 'k':
                    theValue = scKValue;
                    break;
                case 'l':
                    theValue = scKValue;
                    break;
                case 'm':
                    theValue = scMValue;
                    break;
                case 'n':
                    theValue = scNValue;
                    break;
                case 'o':
                    theValue = scOValue;
                    break;
                case 'p':
                    theValue = scPValue;
                    break;
                case 'q':
                    theValue = scQValue;
                    break;
                case 'r':
                    theValue = scPValue;
                    break;
                case 's':
                    theValue = scSValue;
                    break;
                case 't':
                    theValue = scTValue;
                    break;
                case 'u':
                    theValue = scUValue;
                    break;
                case 'v':
                    theValue = scVValue;
                    break;
                case 'w':
                    theValue = scWValue;
                    break;
                case 'x':
                    theValue = scXValue;
                    break;
                case 'y':
                    theValue = scYValue;
                    break;
                case 'z':
                    theValue = scZValue;
                    break;
                default:
                    theValue = scDefaultValue;
                    break;
            }

            return theValue;
        }

        //-----------------------------------------------------------
        // Private Functions
        //-----------------------------------------------------------

        //-----------------------------------------------------------
        // Member Data
        //-----------------------------------------------------------
        const Int32 scAValue = 1;
        const Int32 scBValue = 4;
        const Int32 scCValue = 4;
        const Int32 scDValue = 2;
        const Int32 scEValue = 1;
        const Int32 scFValue = 4;
        const Int32 scGValue = 3;
        const Int32 scHValue = 3;
        const Int32 scIValue = 1;
        const Int32 scJValue = 10;
        const Int32 scKValue = 5;
        const Int32 scLValue = 2;
        const Int32 scMValue = 4;
        const Int32 scNValue = 2;
        const Int32 scOValue = 1;
        const Int32 scPValue = 4;
        const Int32 scQValue = 10;
        const Int32 scRValue = 1;
        const Int32 scSValue = 1;
        const Int32 scTValue = 1;
        const Int32 scUValue = 2;
        const Int32 scVValue = 5;
        const Int32 scWValue = 4;
        const Int32 scXValue = 8;
        const Int32 scYValue = 3;
        const Int32 scZValue = 10;
        const Int32 scDefaultValue = 0;

    }
}
