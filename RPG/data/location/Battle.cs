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
            if (ability is AttackSpell attack)
            {
                enemy.Health -= ability.AttackAbility(ability);
                IsEnemyDead(ref enemy);
            }
            else 
            {
                Player.hero.Health += ability.Buff(ability);
                if (Player.hero.MaxHealth < Player.hero.Health) 
                {
                    Player.hero.Health = Player.hero.MaxHealth;
                }
            }
        }

        public static void IsEnemyDead(ref Enemy enemy) 
        {
            if (enemy.Health <= 0)
            {
                Player.hero.LevelUp(enemy.Dead());
            }
        }

        public static void EndBattle() 
        {
            Player.QuickSave(Player.hero);
        }
    }
}
