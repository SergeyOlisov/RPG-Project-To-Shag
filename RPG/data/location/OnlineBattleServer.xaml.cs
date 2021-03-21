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

namespace RPG.data.location
{
    /// <summary>
    /// Логика взаимодействия для OnlineBattleServer.xaml
    /// </summary>
    public partial class OnlineBattleServer : Window
    {
        public OnlineBattleServer()
        {
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void Attack_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Ability_Hero_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void EndTurn_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Exit_x_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void RollUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Polygon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
