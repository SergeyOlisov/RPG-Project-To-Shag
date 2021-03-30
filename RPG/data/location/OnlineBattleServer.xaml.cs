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
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;
using System.Threading;

namespace RPG.data.location
{
    /// <summary>
    /// Логика взаимодействия для OnlineBattleServer.xaml
    /// </summary>
    public partial class OnlineBattleServer : Window
    {
        GrpcClient grpcClient = new GrpcClient();
        public bool isSpellCast = false;
        private bool _isAttack = false;
        List<Ability> abilities;
        Hero player_Server = new Hero();
        Hero player_Client = new Hero();
        public OnlineBattleServer()
        {
            InitializeComponent();
            //Task.Factory.StartNew(new Action(client.Process));
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

        private async void Attack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var damage = BattleServer.PlayerAttack(ref player_Client);
            HP_Hero_Client.Text = player_Client.Health.ToString();
            Mana_Hero_Client.Text = player_Client.Mana.ToString();
            //var test = Test();
            //test.Start();
            TestListBox.Items.Add(await Connect("Host"));

        }

        private void Ability_Hero_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //client.Process();
            //Task.Factory.StartNew(new Action(client.Process));
            //var temp = client.GetMessage();
            // var temp1 = Convert.ToInt32(temp);
            //BattleServer.PlayerAttack1(temp1 ,player_Client);
            HP_Hero_Client.Text = player_Client.Health.ToString();
            Mana_Hero_Client.Text = player_Client.Mana.ToString();

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
