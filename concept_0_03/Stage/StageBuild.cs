using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concept_0_03.Stage
{
    class StageBuild
    {

        private string id;  //ex: 2-1
        private string alphabet; //ex: kata
        private string name; //ex: Tsuki Mountain
        private string enemyName; //ex: Panda-sama
        private string enemySprite; //ex: Panda-sama
        private int enemyHP; //ex: 100
        private string stageBG; //ex: mountainsBG
        private string stageFG; //ex: brownFG
        private int timer; //ex: 120 (seconds)
        private bool completed;
        private bool unlocked;

        //this defines the character pools to use for the stage
        private List<string> charContent = new List<string> { }; //ex: "ka", "ki", "ku", "ke", "ko"
        private List<Alphabet.JapChar> currentSet = new List<Alphabet.JapChar> { };

        public StageBuild() {}

        public void SetCurrentSet(List<string> tag)
        {

            Alphabet.JapChar alpha;

            if (alphabet == "hira") { alpha = new Alphabet.HiraAlphabet(); }
            else { alpha = new Alphabet.KataAlphabet(); }

            foreach (string t in tag)
            {
                Alphabet.JapChar result = alpha.CharList.Find(x => x.VowelSet == t);
                if (result != null)
                {
                    alpha.CharList.Remove(result);
                    currentSet.Add(result);
                }

                while (result != null)
                {
                    
                    result = alpha.CharList.Find(x => x.VowelSet == t);
                    if (result != null) 
                    {
                        alpha.CharList.Remove(result);
                        currentSet.Add(result);
                    }
                    
                }


                result = alpha.CharList.Find(x => x.ConsonantSet == t);
                if (result != null)
                {
                    alpha.CharList.Remove(result);
                    currentSet.Add(result);
                }
                while (result != null)
                {
                    
                    result = alpha.CharList.Find(x => x.ConsonantSet == t);
                    if (result != null)
                    {
                        alpha.CharList.Remove(result);
                        currentSet.Add(result);
                    }
                    
                }
            }
        }

        public string ID { get { return id; } set { id = value; } }
        public string Alphabet { get { return alphabet; } set { alphabet = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string EnemyName { get { return enemyName; } set { enemyName = value; } }
        public string EnemySprite { get { return enemySprite; } set { enemySprite = value; } }
        public string StageBG { get { return stageBG; } set { stageBG = value; } }
        public string StageFG { get { return stageFG; } set { stageFG = value; } }
        public int EnemyHP { get { return enemyHP; } set { enemyHP = value; } }
        public int Timer { get { return timer; } set { timer = value; } }
        public List<string> CharContent { get { return charContent; } set { charContent = value; } }
        public List<Alphabet.JapChar> CurrentSet { get { return currentSet; } set { SetCurrentSet(charContent); } }
        public bool Completed { get { return completed; } set { completed = value; } }
        public bool Unlocked { get { return unlocked; } set { unlocked = value; } }
    }
}
