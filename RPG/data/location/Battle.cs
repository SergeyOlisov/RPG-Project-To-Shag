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
            enemy.Health -= Player.Hero.Damage();
            IsEnemyDead(ref enemy);
        }

        public static void HeroSpellCaste(ref Enemy enemy, Ability ability)
        {
            enemy.Health -= ability.AttackAbility(ability) * Player.Hero.Intellect * 30 / 100;
            IsEnemyDead(ref enemy);
        }
        
        public static void EnemyAttack(ref Enemy enemy)
        {
            var random = new Random();
            if (random.Next(0, 100) > Player.Hero.Dodge())
            {
                Player.Hero.Health -= enemy.Damage();
                IsHeroDead();
            }
            else
            {
                MessageBox.Show("Hero dodge, bitch!", "DODGE", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private static void IsEnemyDead(ref Enemy enemy) 
        {
            if (enemy.Health <= 0)
            {
                MessageBox.Show("Враг повержен!", "ПОБЕДА", MessageBoxButton.OK, MessageBoxImage.Warning);
                Player.Hero.LevelUp(enemy.Dead());
                Player.QuickSave(Player.Hero);
            }
        }
        private static void IsHeroDead()
        {
            if (Player.Hero.Health <= 0)
            {
                MessageBox.Show("Вы погибли!", "Поражение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
