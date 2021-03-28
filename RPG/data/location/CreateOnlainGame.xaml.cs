using RPG.data.hero;
using System;
using System.Collections.Generic;
using System.IO;
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

        private void Connect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var OnlainBattleClient = new OnlainBattle();
            OnlainBattleClient.Show();
            Close();

        }

        private void StartServer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /*string path = Directory.GetCurrentDirectory();
            path = path + @"\Server\ServerRPG.exe";
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = path;
            p.Start();*/
            var OnlainBattleServer = new OnlineBattleServer();
            OnlainBattleServer.Show();
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

        private void RollUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Exit_x_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
