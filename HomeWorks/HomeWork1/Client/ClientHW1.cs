using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NetworkApplicationDevelopmentServer.HomeWorks.HomeWork1;

namespace NetworkApplicationDevelopmentClient.HomeWorks.HomeWork1.Client
{
    internal class ClientHW1
    {
        public MessageHW1? message;
        public byte[]? data;
        public string? messageText;

        public void SentMessage(string From, string ip)
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);

            while (true)
            {
                do
                {
                    Console.WriteLine("Введите сообщение");
                    messageText = Console.ReadLine()!;
                }
                while (string.IsNullOrEmpty(messageText));

                message = new MessageHW1() { Text = messageText, NickNameFrom = From, NickNameTo = "Server", DateTime = DateTime.Now };

                string json = message.SerializeMessageToJson();
                data = Encoding.UTF8.GetBytes(json);
                udpClient.Send(data, data.Length, iPEndPoint);


                var getThread = new Thread(() => 
                {
                    data = udpClient.Receive(ref iPEndPoint);
                });
   
                getThread.Start();

                if (getThread.Join(1000))
                {
                    messageText = Encoding.UTF8.GetString(data);
                    Console.WriteLine(messageText);
                    
                }
                else
                {
                    Console.WriteLine("Нет ответа от сервера");
                    getThread.Interrupt();
                }
            }
        }
    }
}
