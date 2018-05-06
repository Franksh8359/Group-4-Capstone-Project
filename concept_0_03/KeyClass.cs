using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concept_0_03
{
    class KeyClass
    {
        //Variables
        int keyWorld;
        int keyLevel;
        string keyLevelName;
        KeyType keyType;
        bool obtained = false;

        public enum KeyType
        {
            Gold,
            Silver,
            NotObtained
        };

        //Constructors
        public KeyClass()
        {
            keyLevelName = "";
            keyType = KeyType.Gold;
            obtained = false;
        }

        public KeyClass(int kWorld, int kLevel, string keyColor)
        {
            keyWorld = kWorld;
            keyLevel = kLevel;
            keyLevelName = kWorld.ToString() + "-" + kLevel.ToString();
            if (keyColor == "Gold")
                keyType = KeyType.Gold;
            else if (keyColor == "Silver")
                keyType = KeyType.Silver;
            else
                keyType = KeyType.NotObtained;
            obtained = false;
        }

        //Getters
        public int GetKeyWorld()
        {
            return keyWorld;
        }

        public int GetKeyLevel()
        {
            return keyLevel;
        }

        public string GetKeyLevelName()
        {
            return keyLevelName;
        }

        public KeyType GetKeyType()
        {
            return keyType;
        }

        public bool GetObtained()
        {
            return obtained;
        }

        //Setters
        public void SetKeyName(int world)
        {
            keyWorld = world;
        }

        public void SetKeyLevel(int level)
        {
            keyLevel = level;
        }

        public void SetKeyLevelName(string levelName)
        {
            keyLevelName = levelName;
        }

        public void SetKeyType(KeyType type)
        {
            keyType = type;
        }

        public void SetObtained(bool b)
        {
            obtained = b;
        }
    }
}
