using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concept_0_03
{
    class KeyInventory
    {
        //Variables
        private List<KeyClass> SilverKeyList = new List<KeyClass>();
        private List<KeyClass> GoldKeyList = new List<KeyClass>();

        public KeyInventory()
        {
            CreateListOfKeys();
        }

        private void CreateListOfKeys()
        {
            SilverKeyList = AddKeysToList(SilverKeyList, "Silver");
            GoldKeyList = AddKeysToList(GoldKeyList, "Gold");

            SilverKeyList = ChangeObtainValueAtRandom(SilverKeyList);
            GoldKeyList = ChangeObtainValueAtRandom(GoldKeyList);
        }

        private List<KeyClass> AddKeysToList(List<KeyClass> list, string color)
        {
            List<int> WorldLevelCount = new List<int>() { 11, 11, 12 };

            int worldcount = 1;
            int levelcount = 1;

            for (int a = 0; a < WorldLevelCount.Count; a++)
                for (int i = 0; i < WorldLevelCount[a]; i++)
                {
                    list.Add(new KeyClass(worldcount, levelcount, color));
                    levelcount++;
                    if (levelcount == WorldLevelCount[a] + 1)
                    {
                        levelcount = 1;
                        worldcount++;
                    }

                }
            return list;
        }

        private List<KeyClass> ChangeObtainValueAtRandom(List<KeyClass> list)
        {
            int temp;
            Random rand = new Random();

            int count = 0;

            for (int i = 0; i < list.Count; i++)
            {
                temp = rand.Next(0, 2);
                if (count == 0)
                {
                    list[i].SetObtained(false);
                    count++;
                }
                else
                {
                    list[i].SetObtained(true);
                    count = 0;
                }
            }

            return list;
        }

        public void FindKeyAndSetObtainToTrue(string goldOrSilver, string worldLevelName)
        {
            List<KeyClass> tempList;

            if (goldOrSilver.ToLower() == "gold")
                tempList = GoldKeyList;
            else
                tempList = SilverKeyList;

            for (int i = 0; i < tempList.Count; i++)
                if (tempList[i].GetKeyLevelName() == worldLevelName)
                    tempList[i].SetObtained(true);

        //ChangeScreen deletes previous screen.
        //push screen pushes a new screen on top of old screens
        //pop screen removes the screen from the stack
        }

        public List<KeyClass> GetSilverKeyList()
        {
            return SilverKeyList;
        }

        public List<KeyClass> GetGoldKeyList()
        {
            return GoldKeyList;
        }
    }
}
