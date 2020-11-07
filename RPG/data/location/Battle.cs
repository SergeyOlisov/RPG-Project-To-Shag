using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RPG.data.hero;

namespace RPG.data.location
{
    public abstract class Battle
    {
        static IAbility spell = Player.hero;
        TaskCompletionSource<bool> End = new TaskCompletionSource<bool>();

        public static void Attack(ref Enemy enemy)
        {
            enemy.Health -= Player.hero.Damage();
            IsEnemyDead(ref enemy);

            Hero hero = new Hero();
            Enemy enemy1 = new Enemy();
        }

        public static void SpellCaste(ref Enemy enemy, ref Hero hero, Ability ability) 
        {
            if(hero.Mana <= ability.ManaCoast)
            {
                return;
            }
            hero.Mana -= ability.ManaCoast;

            if (ability is AttackSpell attack)
            {
                enemy.Health -= spell.AttackAbility(ability);
                IsEnemyDead(ref enemy);
            }
            else 
            {
                Player.hero.Health += spell.Buff(ability);
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
            Player.TempHeroSave(Player.hero);
        }
    }
}
