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
            mWordList = new List<string>();
            mIndex = 0;

            string theLine;
            using (StreamReader theStreamReader = new StreamReader( "words.txt" ) )
            {
                while( ( theLine = theStreamReader.ReadLine() ) != null )
                {
                    mWordList.Add( theLine );
                }
                theStreamReader.Close();
                theStreamReader.Dispose();
            }
        }

        //-----------------------------------------------------------
        // public functions
        //-----------------------------------------------------------

        public string
        //-----------------------------------------------------------
        GetNextWord
        //-----------------------------------------------------------
            (
            )
        {

            return mWordList[mIndex++];
        }

        public void
        //-----------------------------------------------------------
        Reset
        //-----------------------------------------------------------
            (
            )
        {
            mIndex = 0;
        }

        public bool
        //-----------------------------------------------------------
        HasMoreWords
        //-----------------------------------------------------------
            (
            )
        {
            return mWordList.Count > (mIndex + 1);
        }

        //-----------------------------------------------------------
        // Member Data
        //-----------------------------------------------------------
        private List<string> mWordList;
        private Int32 mIndex;
    }
}
