using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    class SearchResult_t
    {
        public SearchResult_t
            (
            List<Tile_t> aWord
            )
        {
            Word = aWord;
        }

        //---------------------------------------------------------------------
        // MEMBER DATA
        //---------------------------------------------------------------------
        public List<Tile_t> Word { get; private set; }
        public int Score { get; set; }
    }

    class SearchResults_t
    {
        public SearchResults_t
            (
            List<SearchResult_t> aResults
            )
        {
            Results = aResults;
        }

        public void
        //---------------------------------------------------------------------
        SetResults
            (
            List<SearchResult_t> aResults
            )
        {
            Results = aResults;
        }

        public void
        //---------------------------------------------------------------------
        AddResult
            (
            SearchResult_t aResults
            )
        {
            if( Results == null )
            {
                Results = new List<SearchResult_t>();
            }
            
            Results.Add(aResults);
        }
        
        //---------------------------------------------------------------------
        // MEMBER DATA
        //---------------------------------------------------------------------
        public List<SearchResult_t> Results { get; private set; }

    }
}
