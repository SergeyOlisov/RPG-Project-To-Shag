using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        
        public static void EnemyAttack(ref Enemy enemy)
        {
            var random = new Random();
            if (random.Next(0, 100) > Player.hero.Dodge())
            {
                Player.hero.Health -= enemy.Damage();
            }
            else
            {
                MessageBox.Show("Hero dodge, bitch!");
            }
        }

        private static void IsEnemyDead(ref Enemy enemy) 
        {
            if (enemy.Health <= 0)
            {
                MessageBox.Show("Враг повержен!");
                Player.hero.LevelUp(enemy.Dead());
                Player.QuickSave(Player.hero);
            }
        }
    }
}
