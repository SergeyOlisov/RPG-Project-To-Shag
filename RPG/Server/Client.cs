using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace RPG.Server
{
    public class Client
    {
        public string Mes { get; set; }
        public string MesW()
        {
            return Mes;
        }
        // адрес и порт сервера, к которому будем подключаться
        static int port = 8888; // порт сервера
        static string address = "127.0.0.1"; // адрес сервера
        public void ClientServer()
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                Thread.Sleep(10000);
                // подключаемся к удаленному хосту
                socket.Connect(ipPoint);
                //Console.Write("Введите сообщение:");

                byte[] data = Encoding.Unicode.GetBytes(Mes);
                socket.Send(data);

                // получаем ответ
                data = new byte[256]; // буфер для ответа
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // количество полученных байт

                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                //Console.WriteLine("ответ сервера: " + builder.ToString());

                // закрываем сокет
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                Mes = ex.Message;
            }
            //Console.Read();
        }
    }
}