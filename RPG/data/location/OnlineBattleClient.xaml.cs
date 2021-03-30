using RPG.data.hero;
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
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using System.Threading;
using GrpcGreeterClient;

namespace RPG.data.location
{
    /// <summary>
    /// Логика взаимодействия для OnlainBattle.xaml
    /// </summary>
    public partial class OnlainBattle : Window
    {
        public bool isSpellCast = false;
        private bool _isAttack = false;
        GrpcClient grpcClient;
        List<Ability> abilities;
        Hero player_Server = new Hero();
        Hero player_Client = new Hero();
        public OnlainBattle()
        {
            InitializeComponent();
            HP_Hero_Server.Text = player_Server.Health.ToString();
            Mana_Hero_Server.Text = player_Server.Mana.ToString();
            HP_Hero_Client.Text = player_Client.Health.ToString();
            Mana_Hero_Client.Text = player_Client.Mana.ToString();
            HP_Hero_Client_Bottle.Text = Player.HealthPotions.ToString();
            Mana_Hero_Client_Bottle.Text = Player.ManaPotions.ToString();
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

        private void RollUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private async void Attack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //BattleServer.PlayerAttack(ref player_Server);
            var temp = BattleServer.PlayerAttack(ref player_Server);
            HP_Hero_Server.Text = player_Server.Health.ToString();
            Mana_Hero_Server.Text = player_Server.Mana.ToString();
            //var qqq = Test("Client");
            TestListBox.Items.Add(await Connect("Client"));
        }

        private void Ability_Hero_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void EndTurn_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ManaPotion(object sender, MouseButtonEventArgs e)
        {

        }

        private void HealthPotion(object sender, MouseButtonEventArgs e)
        {

        }

        public async Task<string> Connect(string name)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = name });
            string Mes = reply.Message;
            return Mes;
        }
    }
}
