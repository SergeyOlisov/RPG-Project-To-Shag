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

namespace RPG
{
    /// <summary>
    /// Логика взаимодействия для Authors.xaml
    /// </summary>
    public partial class Authors : Window
    {
        public Authors()
        {
            InitializeComponent();
        }

        private void Button_OK_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var MainWindow = new MainWindow();
            MainWindow.Show();
            Close();
        }
    }
}
