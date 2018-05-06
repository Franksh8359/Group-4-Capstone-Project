using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concept_0_03.Stage
{
    class StageData : StageBuild
    {
        private List<StageBuild> stageList = new List<StageBuild>
        {
            new StageBuild {
                ID = "1-1",
                Alphabet = "hira",
                Name = "",
                EnemyName = "Green Slime",
                EnemySprite = "greenSlime",
                EnemyHP = 80,
                StageBG = "bgWaterfallGreen",
                StageFG = "",
                Timer = 65,
                CharContent = {"vowel"} },
            new StageBuild {
                ID = "1-2",
                Alphabet = "hira",
                Name = "80",
                EnemyName = "Ao Bozu",
                EnemySprite = "aobozu",
                EnemyHP = 80,
                StageBG = "bgMountainsOrange",
                StageFG = "",
                Timer = 65,
                CharContent = {"k", "g"} },
            new StageBuild {
                ID = "1-3",
                Alphabet = "hira",
                Name = "",
                EnemyName = "Betobeto-san",
                EnemySprite = "betobetosan",
                EnemyHP = 100,
                StageBG = "bgMountainsViolet",
                StageFG = "",
                Timer = 85,
                CharContent = {"vowel", "g"} },
            new StageBuild {
                ID = "1-4",
                Alphabet = "hira",
                Name = "",
                EnemyName = "Pink Slime",
                EnemySprite = "pinkSlime",
                EnemyHP = 100,
                StageBG = "bgTreesPink",
                StageFG = "",
                Timer = 85,
                CharContent = {"t", "d"} },
            new StageBuild {
                ID = "1-5",
                Name = "",
                Alphabet = "hira",
                EnemyName = "Blue Wisp",
                EnemySprite = "blueWisp",
                EnemyHP = 100,
                StageBG = "bgTrees",
                StageFG = "",
                Timer = 85,
                CharContent = {"d", "s", "z"} },
            new StageBuild {
                ID = "1-6",
                Alphabet = "hira",
                Name = "",
                EnemyName = "Baby Slimes",
                EnemySprite = "tinySlimes",
                EnemyHP = 150,
                StageBG = "bgMountains",
                StageFG = "",
                Timer = 85,
                CharContent = {"vowel", "k", "g", "t", "d", "s", "z"} }, 
            new StageBuild {
                ID = "1-7",
                Alphabet = "hira",
                Name = "",
                EnemyName = "White Wisp",
                EnemySprite = "whiteWisp",
                EnemyHP = 100,
                StageBG = "bgTreesGreen",
                StageFG = "",
                Timer = 75,
                CharContent = {"n", "m", "h"} },
            new StageBuild {
                ID = "1-8",
                Alphabet = "hira",
                Name = "",
                EnemyName = "Hellhound",
                EnemySprite = "hellhound",
                EnemyHP = 95,
                StageBG = "bgWaterFallOrange",
                StageFG = "",
                Timer = 70,
                CharContent = {"t", "s", "vowel", "b", "p"} },
            new StageBuild {
                ID = "1-9",
                Alphabet = "hira",
                Name = "",
                EnemyName = "Blue Slime",
                EnemySprite = "blueSlime",
                EnemyHP = 95,
                StageBG = "bgWaterFall",
                StageFG = "",
                Timer = 70,
                CharContent = {"y", "w", "m", "n"} },
            new StageBuild {
                ID = "1-10",
                Alphabet = "hira",
                Name = "",
                EnemyName = "Pixie Pair",
                EnemySprite = "pixies",
                EnemyHP = 110,
                StageBG = "bgCloudsRed",
                StageFG = "",
                Timer = 80,
                CharContent = {"g", "d", "z", "p", "b"} },
            new StageBuild {
                ID = "1-11",
                Alphabet = "hira",
                Name = "",
                EnemyName = "Oni Overlord",
                EnemySprite = "oni",
                EnemyHP = 200,
                StageBG = "bgWaterfallViolet",
                StageFG = "",
                Timer = 110,
                CharContent = {"a", "i", "u", "e", "o"} },

            new StageBuild {
                ID = "2-1",
                Alphabet = "kata",
                Name = "",
                EnemyName = "Green Slime",
                EnemySprite = "greenSlime",
                EnemyHP = 80,
                StageBG = "bgWaterfallGreen",
                StageFG = "",
                Timer = 65,
                CharContent = {"vowel"} },
            new StageBuild {
                ID = "2-2",
                Alphabet = "kata",
                Name = "80",
                EnemyName = "Ao Bozu",
                EnemySprite = "aobozu",
                EnemyHP = 80,
                StageBG = "bgMountainsOrange",
                StageFG = "",
                Timer = 65,
                CharContent = {"k", "g"} },
            new StageBuild {
                ID = "2-3",
                Alphabet = "kata",
                Name = "",
                EnemyName = "Betobeto-san",
                EnemySprite = "betobetosan",
                EnemyHP = 100,
                StageBG = "bgMountainsViolet",
                StageFG = "",
                Timer = 85,
                CharContent = {"vowel", "g"} },
            new StageBuild {
                ID = "2-4",
                Alphabet = "kata",
                Name = "",
                EnemyName = "Pink Slime",
                EnemySprite = "pinkSlime",
                EnemyHP = 100,
                StageBG = "bgTreesPink",
                StageFG = "",
                Timer = 85,
                CharContent = {"t", "d"} },
            new StageBuild {
                ID = "2-5",
                Name = "",
                Alphabet = "kata",
                EnemyName = "Blue Wisp",
                EnemySprite = "blueWisp",
                EnemyHP = 100,
                StageBG = "bgTrees",
                StageFG = "",
                Timer = 85,
                CharContent = {"d", "s", "z"} },
            new StageBuild {
                ID = "2-6",
                Alphabet = "kata",
                Name = "",
                EnemyName = "Baby Slimes",
                EnemySprite = "tinySlimes",
                EnemyHP = 150,
                StageBG = "bgMountains",
                StageFG = "",
                Timer = 85,
                CharContent = {"vowel", "k", "g", "t", "d", "s", "z"} },
            new StageBuild {
                ID = "2-7",
                Alphabet = "kata",
                Name = "",
                EnemyName = "White Wisp",
                EnemySprite = "whiteWisp",
                EnemyHP = 100,
                StageBG = "bgTreesGreen",
                StageFG = "",
                Timer = 75,
                CharContent = {"n", "m", "h"} },
            new StageBuild {
                ID = "2-8",
                Alphabet = "kata",
                Name = "",
                EnemyName = "Hellhound",
                EnemySprite = "hellhound",
                EnemyHP = 95,
                StageBG = "bgWaterFallOrange",
                StageFG = "",
                Timer = 70,
                CharContent = {"t", "s", "vowel", "b", "p"} },
            new StageBuild {
                ID = "2-9",
                Alphabet = "kata",
                Name = "",
                EnemyName = "Blue Slime",
                EnemySprite = "blueSlime",
                EnemyHP = 95,
                StageBG = "bgWaterFall",
                StageFG = "",
                Timer = 70,
                CharContent = {"y", "w", "m", "n"} },
            new StageBuild {
                ID = "2-10",
                Alphabet = "kata",
                Name = "",
                EnemyName = "Pixie Pair",
                EnemySprite = "pixies",
                EnemyHP = 110,
                StageBG = "bgCloudsRed",
                StageFG = "",
                Timer = 80,
                CharContent = {"g", "d", "z", "p", "b"} },
            new StageBuild {
                ID = "2-11",
                Alphabet = "kata",
                Name = "",
                EnemyName = "Oni Overlord",
                EnemySprite = "oni",
                EnemyHP = 200,
                StageBG = "bgWaterfallViolet",
                StageFG = "",
                Timer = 110,
                CharContent = {"a", "i", "u", "e", "o"} },

        };

        public StageData()
        {
            this.ID = "";
            this.Name = "";
            this.EnemyName = "";
            this.EnemySprite = "";
            this.EnemyHP = 0;
            this.StageBG = "";
            this.StageFG = "";
            this.Timer = 0;
        }

        public void SetStageData(string id) //when given the stage id, it sets the object to the stage called
        {
            StageBuild result = stageList.Find(x => x.ID == id);

            this.ID = result.ID;
            this.Alphabet = result.Alphabet;
            this.Name = result.Name;
            this.EnemyName = result.EnemyName;
            this.EnemySprite = result.EnemySprite;
            this.EnemyHP = result.EnemyHP;
            this.StageBG = result.StageBG;
            this.StageFG = result.StageFG;
            this.Timer = result.Timer;
            this.CharContent = result.CharContent;
            this.CurrentSet = result.CurrentSet;
        }

    }
}
