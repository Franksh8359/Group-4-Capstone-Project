using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concept_0_03.Alphabet
{
    class KataAlphabet : JapChar
    {
        private string[] vowelSets = { "a", "i", "u", "e", "o" };
        private string[] constSets =
        {
            "vowel", "k", "g", "s", "z", "t", "d", "n", "h", "b", "p", "m", "y", "r", "w",
            "ky", "gy", "sh", "j", "ch", "ny", "hy", "by", "py", "my", "ry"
        };

        public KataAlphabet()
        {
            CharList.Add(new JapChar("a", "ア", "a", "vowel"));
            CharList.Add(new JapChar("i", "イ", "i", "vowel"));
            CharList.Add(new JapChar("u", "ウ", "u", "vowel"));
            CharList.Add(new JapChar("e", "エ", "e", "vowel"));
            CharList.Add(new JapChar("o", "オ", "o", "vowel"));

            CharList.Add(new JapChar("ka", "カ", "a", "k"));
            CharList.Add(new JapChar("ki", "キ", "i", "k"));
            CharList.Add(new JapChar("ku", "ク", "u", "k"));
            CharList.Add(new JapChar("ke", "ケ", "e", "k"));
            CharList.Add(new JapChar("ko", "コ", "o", "k"));

            CharList.Add(new JapChar("ga", "ガ", "a", "g"));
            CharList.Add(new JapChar("gi", "ギ", "i", "g"));
            CharList.Add(new JapChar("gu", "グ", "u", "g"));
            CharList.Add(new JapChar("ge", "ゲ", "e", "g"));
            CharList.Add(new JapChar("go", "ゴ", "o", "g"));

            CharList.Add(new JapChar("ta", "タ", "a", "t"));
            CharList.Add(new JapChar("chi", "チ", "i", "t"));
            CharList.Add(new JapChar("tsu", "ツ", "u", "t"));
            CharList.Add(new JapChar("te", "テ", "e", "t"));
            CharList.Add(new JapChar("to", "ト", "o", "t"));

            CharList.Add(new JapChar("da", "ダ", "a", "d"));
            CharList.Add(new JapChar("ji", "ヂ", "i", "d"));
            CharList.Add(new JapChar("zu", "ヅ", "u", "d"));
            CharList.Add(new JapChar("de", "デ", "e", "d"));
            CharList.Add(new JapChar("do", "ド", "o", "d"));

            CharList.Add(new JapChar("sa", "サ", "a", "s"));
            CharList.Add(new JapChar("shi", "シ", "i", "s"));
            CharList.Add(new JapChar("su", "ス", "u", "s"));
            CharList.Add(new JapChar("se", "セ", "e", "s"));
            CharList.Add(new JapChar("so", "ソ", "o", "s"));

            CharList.Add(new JapChar("za", "ザ", "a", "z"));
            CharList.Add(new JapChar("ji", "ジ", "i", "z"));
            CharList.Add(new JapChar("zu", "ズ", "u", "z"));
            CharList.Add(new JapChar("ze", "ゼ", "e", "z"));
            CharList.Add(new JapChar("zo", "ゾ", "o", "z"));

            CharList.Add(new JapChar("na", "ナ", "a", "n"));
            CharList.Add(new JapChar("ni", "ニ", "i", "n"));
            CharList.Add(new JapChar("nu", "ヌ", "u", "n"));
            CharList.Add(new JapChar("ne", "ネ", "e", "n"));
            CharList.Add(new JapChar("no", "ノ", "o", "n"));

            CharList.Add(new JapChar("ha", "ハ", "a", "h"));
            CharList.Add(new JapChar("hi", "ヒ", "i", "h"));
            CharList.Add(new JapChar("fu", "フ", "u", "h"));
            CharList.Add(new JapChar("he", "ヘ", "e", "h"));
            CharList.Add(new JapChar("ho", "ホ", "o", "h"));

            CharList.Add(new JapChar("ba", "バ", "a", "b"));
            CharList.Add(new JapChar("bi", "ビ", "i", "b"));
            CharList.Add(new JapChar("bu", "ブ", "u", "b"));
            CharList.Add(new JapChar("be", "ベ", "e", "b"));
            CharList.Add(new JapChar("bo", "ボ", "o", "b"));

            CharList.Add(new JapChar("pa", "パ", "a", "p"));
            CharList.Add(new JapChar("pi", "ピ", "i", "p"));
            CharList.Add(new JapChar("pu", "プ", "u", "p"));
            CharList.Add(new JapChar("pe", "ペ", "e", "p"));
            CharList.Add(new JapChar("po", "ポ", "o", "p"));

            CharList.Add(new JapChar("ma", "マ", "a", "m"));
            CharList.Add(new JapChar("mi", "ミ", "i", "m"));
            CharList.Add(new JapChar("mu", "ム", "u", "m"));
            CharList.Add(new JapChar("me", "メ", "e", "m"));
            CharList.Add(new JapChar("mo", "モ", "o", "m"));

            CharList.Add(new JapChar("ya", "ヤ", "a", "y"));
            CharList.Add(new JapChar("yu", "ユ", "u", "y"));
            CharList.Add(new JapChar("yo", "ヨ", "o", "y"));

            CharList.Add(new JapChar("wa", "ワ", "a", "w"));
            CharList.Add(new JapChar("n", "ン", "u", "w"));
            CharList.Add(new JapChar("wo", "ヲ", "o", "w"));

            CharList.Add(new JapChar("ra", "ラ", "a", "r"));
            CharList.Add(new JapChar("ri", "リ", "i", "r"));
            CharList.Add(new JapChar("ru", "ル", "u", "r"));
            CharList.Add(new JapChar("re", "レ", "e", "r"));
            CharList.Add(new JapChar("ro", "ロ", "o", "r"));

        }

        //public int VowelSets(string x) { int e = 0; for (int i = 0; i < vowelSets.Length; i++) { if (vowelSets[i] == x) { e = i; } } return e; }
        //public int ConstSets(string x) { int e = 0; for (int i = 0; i < constSets.Length; i++) { if (constSets[i] == x) { e = i; } } return e; }
    }

}
