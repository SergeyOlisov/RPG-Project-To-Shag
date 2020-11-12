using System;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Input;
using RPG.data.hero;
using System.Windows.Media;
using System.IO;
using RPG.data.location;

namespace RPG
{
    public partial class Location1 : Window
    {
        Enemy enemy = new Enemy();

 
        public Location1()
        {
            InitializeComponent();
            HP_Hero.Text = Player.hero.Health.ToString();
            Mana_Hero.Text = Player.hero.Mana.ToString();
            HP_Enemy.Text = enemy.Health.ToString();
            Mana_Enemy.Text = enemy.Mana.ToString();
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

        private void Ex_Hero_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var WindowsStaticHero = new WindowStaticHero();
            WindowsStaticHero.Show();
        }

        private void Ability_Hero_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var ChoiceAbilities = new ChoiceAbilities(this, ref enemy);
            ChoiceAbilities.Show();
        }

        private void Attack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Battle.HeroAttack(ref enemy);
            HP_Enemy.Text = enemy.Health.ToString();
            Mana_Enemy.Text = enemy.Mana.ToString();
        }
    }
}
