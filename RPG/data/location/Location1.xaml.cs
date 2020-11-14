using System;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Input;
using RPG.data.hero;
using System.Windows.Media;
using System.IO;
using RPG.data.location;
using RPG.data.hero.HeroWindows;

namespace RPG
{
    public partial class Location1 : Window
    {
        Enemy enemy = new Enemy(Player.hero);
        public bool isSpellCast = false;
        private bool _isAttack = false;
        //private bool _isPotionUsed = false;
        public Location1()
        {
            InitializeComponent();
            HP_Hero.Text = Player.hero.Health.ToString();
            Mana_Hero.Text = Player.hero.Mana.ToString();
            HP_Enemy.Text = enemy.Health.ToString();
            Mana_Enemy.Text = enemy.Mana.ToString();
        }
        public void EndFight() 
        {
            if (enemy.Health <= 0)
            {
                var Briefing = new Briefing();
                Briefing.Show();
                Close();
            }
        }
        private void Exit_x_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Close();
        }
        private void RollUp_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Polygon_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Polygon_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Polygon_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Polygon_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Ability_Hero_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isSpellCast)
            {
                MessageBox.Show("Нельзя повторно применить заклинание", "Achtung!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var ChoiceAbilities = new ChoiceAbilities(this, ref enemy);
            ChoiceAbilities.Show();
        }

        private void Attack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_isAttack)
            {
                MessageBox.Show("Нельзя повторно атаковать", "Achtung!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Battle.HeroAttack(ref enemy);
            _isAttack = true;
            EndFight();
            HP_Enemy.Text = enemy.Health.ToString();
            Mana_Enemy.Text = enemy.Mana.ToString();
        }

        private void EndTurn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isSpellCast = false;
            _isAttack = false;
            Battle.EnemyAttack(ref enemy);
            HP_Hero.Text = Player.hero.Health.ToString();
        }
    }
}
