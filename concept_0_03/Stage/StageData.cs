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
            new StageBuild {ID = "1-1", Name = "Tsuki Forest", EnemyName = "Wraith", EnemySprite = "wraith", EnemyHP = 50,
                            StageBG = "bgMountainsSmaller", StageFG = "", Timer = 65,
                            CharContent = {"vowel"} }, //requires 10 correct answers with room for ~10 errors
            new StageBuild {ID = "1-2", Name = "Tsuki Falls", EnemyName = "Wraith", EnemySprite = "wraith", EnemyHP = 70,
                            StageBG = "bgCloudsSmaller", StageFG = "", Timer = 85,
                            CharContent = {"k", "g"} }, //requires 14 correct answers with room for ~14 errors
            new StageBuild {ID = "1-3", Name = "Tsuki Mountains", EnemyName = "Wraith", EnemySprite = "wraith", EnemyHP = 70,
                            StageBG = "bgMountainsSmaller", StageFG = "", Timer = 85,
                            CharContent = {"vowel", "g"} },

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
