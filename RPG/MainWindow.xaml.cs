using System;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Input;
using RPG.data.hero;
using System.Windows.Media;
using System.IO;

namespace RPG
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Editor.EnemySerialize(new Enemy());
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
        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
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
        private void NewGames_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(Player.Hero == null)
            {
                Player.CreatePlayer();
            }
            var Location1 = new Location1();
            Location1.Show();
            Close();

        }
        private void Load_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.json)|*.json|(*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                Player.Hero = Editor.HeroDeserializeAsync(openFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("Ошибка загрузки");
            }

        }
        private void Setting_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var Settings = new Settings();
            Settings.Show();
            Close();
        }
        private void Authors_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var Authors = new Authors();
            Authors.Show();
            Close();
        }
    }
}
