using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concept_0_03.Alphabet
{
    public class JapChar
    {
        private string roma; //romanized form (japanese in english letters)
        private string japa; //japanese character
        private string img; //image name
        private string vowelSet; //vowel set id
        private string consonantSet; //consonant set id

        private List<JapChar> charList = new List<JapChar> { };

        public JapChar()
        {

        }

        public JapChar(string r, string j, string vset, string cset)
        {
            roma = r;
            japa = j;
            img = roma + ".png";
            vowelSet = vset;
            consonantSet = cset;
        }

        public string Roma { get { return roma; } set { roma = value; } }
        public string Japa { get { return japa; } set { japa = value; } }
        public string Img { get { return img; } set { img = value; } }
        public string VowelSet { get { return vowelSet; } set { vowelSet = value; } }
        public string ConsonantSet { get { return consonantSet; } set { consonantSet = value; } }

        public List<JapChar> CharList { get { return charList; } set { charList = value; } }
    }
}

