using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WordsWithFriendsProject
{
    class XmlService_t
    {
        public static Dictionary< string, GameBoard_t >
        //---------------------------------------------------------------------
        GetGames
            (
            )
        {
            Dictionary<string, GameBoard_t> theGames = new Dictionary<string, GameBoard_t>();

            var theDoc = XDocument.Load(@"games.xml");
            foreach( var theGame in theDoc.Descendants("Game_t"))
            {
                var theChild = theGame.Element("Name");
                string theKey = (string)theChild.Value;
                GameBoard_t theValue = MakeDictionary(theGame);
                theGames.Add(theKey, theValue);

            }

            return theGames;
        }

        
        public static void
        //---------------------------------------------------------------------
        SaveGames
            (
            Dictionary<string, GameBoard_t> aDictionary
            )
        {
            int theNumberOfGames = aDictionary.Count;
            if (theNumberOfGames == 0)
            {
                return;
            }

            System.Xml.Serialization.XmlSerializer writer =
               new System.Xml.Serialization.XmlSerializer(typeof(Games_t));

            System.IO.StreamWriter file = new System.IO.StreamWriter(
                @"games.xml");

            Games_t theGames = new Games_t();

            theGames.Names = "Games";
            theGames.Games = new Game_t[theNumberOfGames];

            int theIndex = 0;
            foreach (var theKey in aDictionary.Keys)
            {
                theGames.Games[theIndex++] = PlaceDataInGame(theKey, aDictionary[theKey]); ;
            }

            writer.Serialize(file, theGames);

            file.Close();
        }

        //---------------------------------------------------------------------
        // PRIVATE FUNCTIONS
        //---------------------------------------------------------------------

        private static GameBoard_t
        //---------------------------------------------------------------------
        MakeDictionary
            (
            XElement aChild
            )
        {
            GameBoard_t theReturn = new GameBoard_t();
            string[] theRows = new string[] { "Row0", "Row1", "Row2", "Row3",
            "Row4", "Row5", "Row6", "Row7", "Row8", "Row9", "Row10", "Row11", 
            "Row12", "Row13", "Row14"};
            int theX = 0;
            int theY = 0;
            
            foreach( string theRowName in theRows)
            {
                var theNode = aChild.Element(theRowName);
                foreach( var theChar in NodeToCharArray(theNode) )
                {
                    theReturn.mBoard[theX, theY].Letter = (char)theChar;
                    ++theX;
                }
                theX = 0;
                ++theY;
            }
            return theReturn;
        }

        private static char[] 
        NodeToCharArray
            (
            XElement aNode
            )
        {
            char[] theReturn = new char[15];
            int i = 0;
            string theValue;
            foreach( var theChar in aNode.Descendants("char"))
            {
                if( theChar != null)
                {
                    theValue = (string)theChar.Value;
                    int theInt = System.Convert.ToInt32(theValue);
                    theReturn[i++] = System.Convert.ToChar(theInt);
                }
            }


            return theReturn;
        }

        private static Game_t
        //---------------------------------------------------------------------
        PlaceDataInGame
           (
           string aName,
           GameBoard_t aGameBoard
           )
        {
            Game_t theGame = new Game_t();
            theGame.Name = aName;
            theGame.Row0 = RowToCharArray(0, aGameBoard);
            theGame.Row1 = RowToCharArray(1, aGameBoard);
            theGame.Row2 = RowToCharArray(2, aGameBoard);
            theGame.Row3 = RowToCharArray(3, aGameBoard);
            theGame.Row4 = RowToCharArray(4, aGameBoard);
            theGame.Row5 = RowToCharArray(5, aGameBoard);
            theGame.Row6 = RowToCharArray(6, aGameBoard);
            theGame.Row7 = RowToCharArray(7, aGameBoard);
            theGame.Row8 = RowToCharArray(8, aGameBoard);
            theGame.Row9 = RowToCharArray(9, aGameBoard);
            theGame.Row10 = RowToCharArray(10, aGameBoard);
            theGame.Row11 = RowToCharArray(11, aGameBoard);
            theGame.Row12 = RowToCharArray(12, aGameBoard);
            theGame.Row13 = RowToCharArray(13, aGameBoard);
            theGame.Row14 = RowToCharArray(14, aGameBoard);

            return theGame;
        }

        private static char[]
        RowToCharArray
           (
           int aRow,
           GameBoard_t aGameBoard
           )
        {
            var theRow = new char[15];

            for (int i = 0; i < 15; ++i)
            {
                theRow[i] = aGameBoard.mBoard[i, aRow].Letter;
            }

            return theRow;
        }
    }
}
