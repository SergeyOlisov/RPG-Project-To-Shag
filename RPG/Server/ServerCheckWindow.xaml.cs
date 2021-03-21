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
using System.Threading;
using System.Threading.Tasks;

namespace RPG.Server
{
    /// <summary>
    /// Логика взаимодействия для ServerW.xaml
    /// </summary>
    public partial class ServerCheckWindow : Window
    {
        public ServerCheckWindow()
        {
            InitializeComponent();
            Client client = new Client();
            checkServer.Items.Add("Клиент создан");
            client.Mes = checkServer.Items[checkServer.Items.Count - 1].ToString();
            client.ClientServer();
            checkServer.Items.Add(client.Mes);
            //Server server = new Server();
            //Parallel.Invoke(() => server.StartServer(), () => client.ClientServer());
            ///server.StartServer();
            //checkServer.Text = server.StringW();
        }
    }
}
