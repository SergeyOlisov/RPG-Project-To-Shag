using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RPG.data.hero;

namespace RPG.data.location
{
    public abstract class Battle
    {
        public static void HeroAttack(ref Enemy enemy)
        {
            enemy.Health -= Player.hero.Damage();
            IsEnemyDead(ref enemy);
        }

        public static void HeroSpellCaste(ref Enemy enemy, Ability ability) 
        {
            enemy.Health -= ability.AttackAbility(ability);
            IsEnemyDead(ref enemy);
        }

        private static void IsEnemyDead(ref Enemy enemy) 
        {
            if (enemy.Health <= 0)
            {
                Player.hero.LevelUp(enemy.Dead());
            }
        }

        private static void EndBattle() 
        {
            Player.QuickSave(Player.hero);
        }
    }
}
