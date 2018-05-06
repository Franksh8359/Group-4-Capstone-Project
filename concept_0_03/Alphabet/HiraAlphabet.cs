using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concept_0_03.Alphabet
{
    class HiraAlphabet : JapChar
    {
        private string[] vowelSets = { "a", "i", "u", "e", "o" };
        private string[] constSets =
        {
            "vowel", "k", "g", "s", "z", "t", "d", "n", "h", "b", "p", "m", "y", "r", "w",
            "ky", "gy", "sh", "j", "ch", "ny", "hy", "by", "py", "my", "ry"
        };

        public HiraAlphabet()
        {
            CharList.Add(new JapChar("a", "あ", "a", "vowel"));
            CharList.Add(new JapChar("i", "い", "i", "vowel"));
            CharList.Add(new JapChar("u", "う", "u", "vowel"));
            CharList.Add(new JapChar("e", "え", "e", "vowel"));
            CharList.Add(new JapChar("o", "お", "o", "vowel"));

            CharList.Add(new JapChar("ka", "か", "a", "k"));
            CharList.Add(new JapChar("ki", "き", "i", "k"));
            CharList.Add(new JapChar("ku", "く", "u", "k"));
            CharList.Add(new JapChar("ke", "け", "e", "k"));
            CharList.Add(new JapChar("ko", "こ", "o", "k"));

            CharList.Add(new JapChar("ga", "が", "a", "g"));
            CharList.Add(new JapChar("gi", "ぎ", "i", "g"));
            CharList.Add(new JapChar("gu", "ぐ", "u", "g"));
            CharList.Add(new JapChar("ge", "げ", "e", "g"));
            CharList.Add(new JapChar("go", "ご", "o", "g"));

            CharList.Add(new JapChar("ta", "た", "a", "t"));
            CharList.Add(new JapChar("chi", "ち", "i", "t"));
            CharList.Add(new JapChar("tsu", "つ", "u", "t"));
            CharList.Add(new JapChar("te", "て", "e", "t"));
            CharList.Add(new JapChar("to", "と", "o", "t"));

            CharList.Add(new JapChar("da", "だ", "a", "d"));
            CharList.Add(new JapChar("ji", "ぢ", "i", "d"));
            CharList.Add(new JapChar("zu", "づ", "u", "d"));
            CharList.Add(new JapChar("de", "で", "e", "d"));
            CharList.Add(new JapChar("do", "ど", "o", "d"));

            CharList.Add(new JapChar("sa", "さ", "a", "s"));
            CharList.Add(new JapChar("shi", "し", "i", "s"));
            CharList.Add(new JapChar("su", "す", "u", "s"));
            CharList.Add(new JapChar("se", "せ", "e", "s"));
            CharList.Add(new JapChar("so", "そ", "o", "s"));

            CharList.Add(new JapChar("za", "ざ", "a", "z"));
            CharList.Add(new JapChar("ji", "じ", "i", "z"));
            CharList.Add(new JapChar("zu", "ず", "u", "z"));
            CharList.Add(new JapChar("ze", "ぜ", "e", "z"));
            CharList.Add(new JapChar("zo", "ぞ", "o", "z"));

            CharList.Add(new JapChar("na", "な", "a", "n"));
            CharList.Add(new JapChar("ni", "に", "i", "n"));
            CharList.Add(new JapChar("nu", "ぬ", "u", "n"));
            CharList.Add(new JapChar("ne", "ね", "e", "n"));
            CharList.Add(new JapChar("no", "の", "o", "n"));

            CharList.Add(new JapChar("ha", "は", "a", "h"));
            CharList.Add(new JapChar("hi", "ひ", "i", "h"));
            CharList.Add(new JapChar("fu", "ふ", "u", "h"));
            CharList.Add(new JapChar("he", "へ", "e", "h"));
            CharList.Add(new JapChar("ho", "ほ", "o", "h"));

            CharList.Add(new JapChar("ba", "ば", "a", "b"));
            CharList.Add(new JapChar("bi", "び", "i", "b"));
            CharList.Add(new JapChar("bu", "ぶ", "u", "b"));
            CharList.Add(new JapChar("be", "べ", "e", "b"));
            CharList.Add(new JapChar("bo", "ぼ", "o", "b"));

            CharList.Add(new JapChar("pa", "ぱ", "a", "p"));
            CharList.Add(new JapChar("pi", "ぴ", "i", "p"));
            CharList.Add(new JapChar("pu", "ぷ", "u", "p"));
            CharList.Add(new JapChar("pe", "ぺ", "e", "p"));
            CharList.Add(new JapChar("po", "ぽ", "o", "p"));

            CharList.Add(new JapChar("ma", "ま", "a", "m"));
            CharList.Add(new JapChar("mi", "み", "i", "m"));
            CharList.Add(new JapChar("mu", "む", "u", "m"));
            CharList.Add(new JapChar("me", "め", "e", "m"));
            CharList.Add(new JapChar("mo", "も", "o", "m"));

            CharList.Add(new JapChar("ya", "や", "a", "y"));
            CharList.Add(new JapChar("yu", "ゆ", "u", "y"));
            CharList.Add(new JapChar("yo", "よ", "o", "y"));

            CharList.Add(new JapChar("wa", "わ", "a", "w"));
            CharList.Add(new JapChar("n", "ん", "u", "w"));
            CharList.Add(new JapChar("wo", "を", "o", "w"));

            CharList.Add(new JapChar("ra", "ら", "a", "r"));
            CharList.Add(new JapChar("ri", "り", "i", "r"));
            CharList.Add(new JapChar("ru", "る", "u", "r"));
            CharList.Add(new JapChar("re", "れ", "e", "r"));
            CharList.Add(new JapChar("ro", "ろ", "o", "r"));

        }

        //public int VowelSets(string x) { int e = 0; for (int i = 0; i < vowelSets.Length; i++) { if (vowelSets[i] == x) { e = i; } } return e; }
        //public int ConstSets(string x) { int e = 0; for (int i = 0; i < constSets.Length; i++) { if (constSets[i] == x) { e = i; } } return e; }
    }

}
