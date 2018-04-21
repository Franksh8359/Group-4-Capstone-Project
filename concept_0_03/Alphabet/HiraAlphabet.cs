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

            hiraList.Add(new JapChar("ta", "た", "a", "t"));
            hiraList.Add(new JapChar("chi", "ち", "i", "t"));
            hiraList.Add(new JapChar("tsu", "つ", "u", "t"));
            hiraList.Add(new JapChar("te", "て", "e", "t"));
            hiraList.Add(new JapChar("to", "と", "o", "t"));

            hiraList.Add(new JapChar("da", "だ", "a", "d"));
            hiraList.Add(new JapChar("ji", "ぢ", "i", "d"));
            hiraList.Add(new JapChar("zu", "づ", "u", "d"));
            hiraList.Add(new JapChar("de", "で", "e", "d"));
            hiraList.Add(new JapChar("do", "ど", "o", "d"));

            hiraList.Add(new JapChar("sa", "さ", "a", "s"));
            hiraList.Add(new JapChar("shi", "し", "i", "s"));
            hiraList.Add(new JapChar("su", "す", "u", "s"));
            hiraList.Add(new JapChar("se", "せ", "e", "s"));
            hiraList.Add(new JapChar("so", "そ", "o", "s"));

            hiraList.Add(new JapChar("za", "ざ", "a", "z"));
            hiraList.Add(new JapChar("ji", "じ", "i", "z"));
            hiraList.Add(new JapChar("zu", "ず", "u", "z"));
            hiraList.Add(new JapChar("ze", "ぜ", "e", "z"));
            hiraList.Add(new JapChar("zo", "ぞ", "o", "z"));

            hiraList.Add(new JapChar("na", "な", "a", "n"));
            hiraList.Add(new JapChar("ni", "に", "i", "n"));
            hiraList.Add(new JapChar("nu", "ぬ", "u", "n"));
            hiraList.Add(new JapChar("ne", "ね", "e", "n"));
            hiraList.Add(new JapChar("no", "の", "o", "n"));

            hiraList.Add(new JapChar("ha", "は", "a", "h"));
            hiraList.Add(new JapChar("hi", "ひ", "i", "h"));
            hiraList.Add(new JapChar("fu", "ふ", "u", "h"));
            hiraList.Add(new JapChar("he", "へ", "e", "h"));
            hiraList.Add(new JapChar("ho", "ほ", "o", "h"));

            hiraList.Add(new JapChar("ba", "ば", "a", "b"));
            hiraList.Add(new JapChar("bi", "び", "i", "b"));
            hiraList.Add(new JapChar("bu", "ぶ", "u", "b"));
            hiraList.Add(new JapChar("be", "べ", "e", "b"));
            hiraList.Add(new JapChar("bo", "ぼ", "o", "b"));

            hiraList.Add(new JapChar("pa", "ぱ", "a", "p"));
            hiraList.Add(new JapChar("pi", "ぴ", "i", "p"));
            hiraList.Add(new JapChar("pu", "ぷ", "u", "p"));
            hiraList.Add(new JapChar("pe", "ぺ", "e", "p"));
            hiraList.Add(new JapChar("po", "ぽ", "o", "p"));

            hiraList.Add(new JapChar("ma", "ま", "a", "m"));
            hiraList.Add(new JapChar("mi", "み", "i", "m"));
            hiraList.Add(new JapChar("mu", "む", "u", "m"));
            hiraList.Add(new JapChar("me", "め", "e", "m"));
            hiraList.Add(new JapChar("mo", "も", "o", "m"));

            hiraList.Add(new JapChar("ya", "や", "a", "y"));
            hiraList.Add(new JapChar("yu", "ゆ", "u", "y"));
            hiraList.Add(new JapChar("yo", "よ", "o", "y"));

            hiraList.Add(new JapChar("wa", "わ", "a", "w"));
            hiraList.Add(new JapChar("n", "ん", "u", "w"));
            hiraList.Add(new JapChar("wo", "を", "o", "w"));

            hiraList.Add(new JapChar("ra", "ら", "a", "r"));
            hiraList.Add(new JapChar("ri", "り", "i", "r"));
            hiraList.Add(new JapChar("ru", "る", "u", "r"));
            hiraList.Add(new JapChar("re", "れ", "e", "r"));
            hiraList.Add(new JapChar("ro", "ろ", "o", "r"));

        }

        public List<JapChar> HiraList { get { return hiraList; } set { hiraList = value; } }

        //public int VowelSets(string x) { int e = 0; for (int i = 0; i < vowelSets.Length; i++) { if (vowelSets[i] == x) { e = i; } } return e; }
        //public int ConstSets(string x) { int e = 0; for (int i = 0; i < constSets.Length; i++) { if (constSets[i] == x) { e = i; } } return e; }
    }

}
