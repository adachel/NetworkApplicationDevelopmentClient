using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NetworkApplicationDevelopmentClient.HomeWorks.HomeWork2.Client;

namespace NetworkApplicationDevelopmentClient.HomeWorks.HomeWork2.Client
{
    // Добавьте возможность ввести слово Exit в чате клиента, чтобы можно было завершить его работу. 
    internal class ClientHW2
    {
        private MessageHW2? message;
        private byte[]? sendData;
        private byte[]? receiveData;
        private string? messageText;

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

                message = new MessageHW2() { Text = messageText, NickNameFrom = From, NickNameTo = "Server", DateTime = DateTime.Now };

                string json = message.SerializeMessageToJson();
                sendData = Encoding.UTF8.GetBytes(json);
                udpClient.Send(sendData, sendData.Length, iPEndPoint);


                var t = new Task(() => 
                {
                    receiveData = udpClient.Receive(ref iPEndPoint);
                });
                t.Start();

                try
                {
                    t.Wait(1000);
                    messageText = Encoding.UTF8.GetString(receiveData!);
                    Console.WriteLine(messageText);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Сервер не отвечает");
                }
            }
        }
    }
}
