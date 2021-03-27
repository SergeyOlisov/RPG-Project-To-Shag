using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using RPG.data.hero;
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
        public bool isSpellCast = false;
        private bool _isAttack = false;
        List<Ability> abilities;
        Hero player_Server = new Hero();
        Hero player_Client = new Hero();

        //Enemy player_Server = new Enemy("123",1,100,50);
        //Enemy player_Client = new Enemy("123", 1, 150, 25);
        public OnlineBattleServer()
        {
            InitializeComponent();
            HP_Hero_Server.Text = player_Server.Health.ToString();
            Mana_Hero_Server.Text = player_Server.Mana.ToString();
            HP_Hero_Client.Text = player_Client.Health.ToString();
            Mana_Hero_Client.Text = player_Client.Mana.ToString();
            HP_Hero_Server_Bottle.Text = Player.HealthPotions.ToString();
            Mana_Hero_Server_Bottle.Text = Player.ManaPotions.ToString();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void Attack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BattleServer.PlayerAttack(player_Client);
            HP_Hero_Client.Text = player_Client.Health.ToString();
            Mana_Hero_Client.Text = player_Client.Mana.ToString();
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
