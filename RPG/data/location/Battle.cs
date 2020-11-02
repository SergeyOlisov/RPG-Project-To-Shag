using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RPG.data.hero;

namespace RPG.data.location
{
    public abstract class Battle
    {
        static Hero hero = Player.GetHero();
        static IAbility spell = hero;
        TaskCompletionSource<bool> End = new TaskCompletionSource<bool>();

        public static void Attack(ref Enemy enemy)
        {
            enemy.Health -= hero.Damage();
            IsEnemyDead(ref enemy);
        }

        public static void SpellCaste(ref Enemy enemy, Ability ability) 
        {
            if (ability is AttackSpell attack)
            {
                enemy.Health -= spell.AttackAbility(ability);
                IsEnemyDead(ref enemy);
            }
            else 
            {
                hero.Health += spell.Buff(ability);
                if (hero.MaxHealth < hero.Health) 
                {
                    hero.Health = hero.MaxHealth;
                }
            }
        }

        public static void IsEnemyDead(ref Enemy enemy) 
        {
            if (enemy.Health <= 0)
            {
                hero.LevelUp(enemy.Dead());
            }
        }

        public static void EndBattle() 
        {
            Player.TempHeroSave(hero);
        }
    }
}
