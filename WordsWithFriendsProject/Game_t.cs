using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsWithFriendsProject
{
    [Serializable]
    public class Game_t
    {
        public string Name { get; set; }
        public char[] Row0 { get; set; }
        public char[] Row1 { get; set; }
        public char[] Row2 { get; set; }
        public char[] Row3 { get; set; }
        public char[] Row4 { get; set; }
        public char[] Row5 { get; set; }
        public char[] Row6 { get; set; }
        public char[] Row7 { get; set; }
        public char[] Row8 { get; set; }
        public char[] Row9 { get; set; }
        public char[] Row10 { get; set; }
        public char[] Row11 { get; set; }
        public char[] Row12 { get; set; }
        public char[] Row13 { get; set; }
        public char[] Row14 { get; set; }

    }

    [Serializable]
    public class Games_t
    {
        public string Names { get; set; }
        public Game_t[] Games { get; set; }
    }
}
