using RPG.data.hero;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.data.location
{
    public class BattleServer
    {
        public static int PlayerAttack(ref Hero hero)
        {
            var damage = Player.Hero.Damage();
            hero.Health -= damage;
            return damage;
        }

        public static int PlayerAttack1(int damage, Hero hero)
        {
            hero.Health -= damage;
            return damage;
        }
    }
}
