using System;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Input;
using RPG.data.hero;
using System.Windows.Media;
using System.IO;

namespace RPG
{
    public partial class Location1 : Window
    {

 
        public Location1()
        {
            InitializeComponent();
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

        }

        private void Attack_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
