using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RPG.data.location;
using RPG.data.hero.HeroWindows;
using RPG.data.hero;

namespace RPG.data.location
{
    /// <summary>
    /// Логика взаимодействия для Briefing.xaml
    /// </summary>
    public partial class Briefing : Window
    {
        public Briefing()
        {
            InitializeComponent();
        }

        private void Ex_Hero_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var WindowsStaticHero = new WindowStaticHero();
            WindowsStaticHero.Show();
        }

        private void Study_Abilities_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var StudyAbilities = new StudyAbilities(this);
            StudyAbilities.Show();
        }

        private void Start_Next_Fight_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Player.Hero.Health = Player.Hero.MaxHealth;
            Player.Hero.Mana = Player.Hero.MaxMana;
            var Location1 = new Location1();
            Location1.Show();
            Close();
        }

        private void Exit_to_Menu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var MainWindow = new MainWindow();
            MainWindow.Show();
            Player.Hero = null;
            Close();
        }
    }
}
