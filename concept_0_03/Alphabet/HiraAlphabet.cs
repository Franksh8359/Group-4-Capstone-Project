using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concept_0_03.Alphabet
{
    class HiraAlphabet
    {
        private string[] vowelSets = { "a", "i", "u", "e", "o" };
        private string[] constSets =
        {
            "vowel", "k", "g", "s", "z", "t", "d", "n", "h", "b", "p", "m", "y", "r", "w",
            "ky", "gy", "sh", "j", "ch", "ny", "hy", "by", "py", "my", "ry"
        };
        private List<JapChar> hiraList = new List<JapChar> { };

        public HiraAlphabet()
        {
            hiraList.Add(new JapChar("a", "あ", "a", "vowel"));
            hiraList.Add(new JapChar("i", "い", "i", "vowel"));
            hiraList.Add(new JapChar("u", "う", "u", "vowel"));
            hiraList.Add(new JapChar("e", "え", "e", "vowel"));
            hiraList.Add(new JapChar("o", "お", "o", "vowel"));

            hiraList.Add(new JapChar("ka", "か", "a", "k"));
            hiraList.Add(new JapChar("ki", "き", "i", "k"));
            hiraList.Add(new JapChar("ku", "く", "u", "k"));
            hiraList.Add(new JapChar("ke", "け", "e", "k"));
            hiraList.Add(new JapChar("ko", "こ", "o", "k"));

            hiraList.Add(new JapChar("ga", "が", "a", "g"));
            hiraList.Add(new JapChar("gi", "ぎ", "i", "g"));
            hiraList.Add(new JapChar("gu", "ぐ", "u", "g"));
            hiraList.Add(new JapChar("ge", "げ", "e", "g"));
            hiraList.Add(new JapChar("go", "ご", "o", "g"));


        }

        public List<JapChar> HiraList { get { return hiraList; } set { hiraList = value; } }

        //public int VowelSets(string x) { int e = 0; for (int i = 0; i < vowelSets.Length; i++) { if (vowelSets[i] == x) { e = i; } } return e; }
        //public int ConstSets(string x) { int e = 0; for (int i = 0; i < constSets.Length; i++) { if (constSets[i] == x) { e = i; } } return e; }
    }

}
