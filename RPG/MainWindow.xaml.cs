using System;
using System.IO;
using System.Text.Json.Serialization;
using System.Windows;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Win32;
using RPG.data.helpers;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Windows.Input;

namespace RPG
{

    public partial class MainWindow : Window
    {
        static Hero hero = new Hero();
        public MainWindow()
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
                hero = Editor.HeroDeserializeAsync(openFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("Ошибка загрузки");
            }

        }
        private void Setting_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void Authors_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
