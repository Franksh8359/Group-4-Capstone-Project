using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concept_0_03
{
    class Combat
    {

        private int playerHP;
        private int enemyHP;

        private int dmg;

        public Combat()
        {
            playerHP = 0;
            enemyHP = 0;
        }

        public void SetCombat(int pHP, int eHP)
        {
            playerHP = pHP;
            enemyHP = eHP;
        }

        public int EnemyAttack()
        {
            playerHP -= dmg;
            return playerHP;
        }

        public int PlayerAttack()
        {
            enemyHP -= dmg;
            return enemyHP;
        }

    }
}
