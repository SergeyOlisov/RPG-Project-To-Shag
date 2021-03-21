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
    /// Логика взаимодействия для CreateOnlainGame.xaml
    /// </summary>
    public partial class CreateOnlainGame : Window
    {
        public CreateOnlainGame()
        {
            InitializeComponent();
        }

        private void RollUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Exit_x_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Polygon_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void ConnectGame_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void CreateGame_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
