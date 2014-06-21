using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    //-----------------------------------------------------------
    class Dictionary_t
    //-----------------------------------------------------------
    {

        //-----------------------------------------------------------
        public Dictionary_t
        //-----------------------------------------------------------
            (
            )
        {
            var theWordList = new List<string>();

            string theLine;
            using (StreamReader theStreamReader = new StreamReader( "words.txt" ) )
            {
                while( ( theLine = theStreamReader.ReadLine() ) != null )
                {
                    theWordList.Add( theLine );
                }
                theStreamReader.Close();
                theStreamReader.Dispose();
            }
            WordList = theWordList;
        }


        //-----------------------------------------------------------
        // Member Data
        //-----------------------------------------------------------
        public IEnumerable<string> WordList{ get; private set;}
    }
}
