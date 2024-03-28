using NetworkApplicationDevelopmentServer.Seminars.Seminar1.Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApplicationDevelopmentClient.Seminars.Seminar1
{
    internal class Sem1
    {
        public static void SentMessage(string From, string ip)
        {
            
            UdpClient udpClient = new UdpClient();      // созд экземпляр класса UdpClient
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345); // Задали параметры ip и port

            while (true)
            {
                string messageText; // переменная messageText
                do
                {
                    Console.Clear(); // очищаем консоль
                    Console.WriteLine("Введите сообщение"); 
                    messageText = Console.ReadLine()!;  // в messageText записываем данные с консоли
                }
                while (string.IsNullOrEmpty(messageText)); // проверяем, что messageText не пустая, цикл завершился. IsNullOrEmpty возвращает true или false

                Message message = new Message() { Text = messageText, NickNameFrom = From, NickNameTo = "Server", DateTime = DateTime.Now }; 
                                                                                                                // экз класса Messagе, в Text ложим текст сообщения,
                                                                                                                // NickNameFrom - имя, задаем на входе,
                                                                                                                // NickNameTo - имя кому, пока не используется,
                                                                                                                // DateTime - время.

                string json = message.SerializeMessageToJson(); // создает текстовый файл - шаблон json c данными из экз message

                byte[] data = Encoding.UTF8.GetBytes(json); // переводим данные в массив байтов

                udpClient.Send(data, data.Length, iPEndPoint); // отправляем данные
            }

        }
        public void Run(string[] args)
        {
            SentMessage(args[0], args[1]);


        }
    }
}
