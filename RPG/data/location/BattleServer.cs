using RPG.data.hero;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.data.location
{
    public class BattleServer
    {
        public static void PlayerAttack(Hero hero)
        {
            hero.Health -= Player.Hero.Damage();
        }
    }
}
