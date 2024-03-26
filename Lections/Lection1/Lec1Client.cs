using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client.Lections.Lection1
{
    internal class Lec1Client
    {

        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Клиент на сокет начало
        //public void WithUdp()
        //{
        //    using (Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
        //    {
        //        var localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);

        //        Console.WriteLine("I`m client. Connecting...");

        //        client.Bind(localEndPoint);

        //        try
        //        {
        //            client.Connect(IPAddress.Parse("127.0.0.1"), 4567);
        //        }
        //        catch
        //        {
        //        }
        //        if (client.Connected)
        //        {
        //            Console.WriteLine("Connected!");
        //            Console.WriteLine("localEndPoint" + client.LocalEndPoint);
        //            Console.WriteLine("remoteEndPoint" + client.RemoteEndPoint);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Connected problem!");
        //            return;
        //        }


        //        byte[] bytes = Encoding.UTF8.GetBytes("Привет"); 

        //        Console.WriteLine("Нажмите клавишу для отправки...");
        //        Console.ReadKey();

        //        if (client.Poll(100, SelectMode.SelectRead) && client.Poll(100, SelectMode.SelectError)) 
        //        {
        //            int count = client.Send(bytes); 
        //            if (count == bytes.Length)
        //            {
        //                Console.WriteLine("Отправлено ");
        //            }
        //            else Console.WriteLine("Что-то пошло не так...");
        //        }

        //    }


        //}


        //public void Run()
        //{
        //    using (Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        //    {
        //        var remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345); // куда стучаться, чтобы произвести соединение

        //        var localEndPoint = new IPEndPoint(IPAddress.Any, 12346);



        //        Console.WriteLine("I`m client. Connecting...");

        //        client.Bind(localEndPoint);

        //        // client.NoDelay = true; // отправляет пакеты сразу, без задержки, если false, применяется алгоритм, объединяющий данные для оптимизации

        //        //////////////////////////////////////////////////////
        //        /// умное подключение
        //        /// 
        //        try
        //        {
        //            client.Connect(remoteEndPoint);
        //        }
        //        catch (Exception)
        //        {
        //        }
        //        if (client.Connected)
        //        {
        //            Console.WriteLine("Connected!");
        //            Console.WriteLine("localEndPoint" + client.LocalEndPoint);
        //            Console.WriteLine("remoteEndPoint" + client.RemoteEndPoint);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Connected problem!");
        //            return;
        //        }

        //        /////////////////////////////////////////////////////////////////////////////////////
        //        /// свойства сокета
        //        /// 
        //        // client.AddressFamily // хранит тип адрессации, кот исп сокет
        //        // client.Connected // состояние сокета на момент последней опреации. true - если соед установлено, иначе false.
        //        // устанавливается только тогда, когда сокет делает какие-то действия
        //        // client.IsBound // привязан ли сокет к порту
        //        // client.ReceiveBufferSize // размер буфера для хранения, полученного сообщения
        //        // client.ReceiveTimeout // кол-во времени в мс, после кот происходит таймаут в методе рессив. по умолчанию 0, что означ бесконечное ожидание

        //        /////////////////////////////////////////////////////////////////////////////////
        //        /// будем передавать данные. Сокет умеет передавать ТОЛЬКО байты
        //        /// 
        //        byte[] bytes = Encoding.UTF8.GetBytes("Привет"); // преобраз byte в текст и текст в byte. в данном случае текст в byte.

        //        Console.WriteLine("Нажмите клавишу для отправки...");
        //        Console.ReadKey(); 

        //        // client.SendTimeout = 1000;  // в лохой сети уст мах

        //        if (client.Poll(100, SelectMode.SelectRead) && client.Poll(100, SelectMode.SelectError))  // перед вызовом send, опрашиваем сокет
        //                                                                                                  // на возможность записать в него данные.
        //                                                                                                  // SelectError проверяем на наличие ошибок
        //        {
        //            int count = client.Send(bytes); // предназначен для отправки массива байт в удаленный EndPoint. Возвр кол-во байт, кот удалось отпр

        //            if (count == bytes.Length)
        //            {
        //                Console.WriteLine("Отправлено ");
        //            }
        //            else Console.WriteLine("Что-то пошло не так...");
        //        }

        //    }


        //    //////////////////////////////////////////////////////////////////////////////////////////
        //    /// еще вариант создания сокета
        //    /// 
        //    // Socket client = new Socket(SafeSocketHandle ); // создается на основе сокета, открытого операционной системой в другой программе
        //    // Socket client = new Socket(SocketInformation ); // созд на основе закрытого ранее сокета о кот есть инфо

        //}

        /// Клиент на сокет конец
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Клиент сокет для UDP начало

        //static void Send(byte[] buffers, Socket socket)
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        socket.Send(buffers);
        //        var buffIn = new byte[1];

        //        int count = socket.Receive(buffIn);

        //        // socket.Send(buffers);

        //        if (count == 1)
        //        {
        //            Console.Write(buffIn[0]);
        //        }
        //    }
        //    socket.Close();
        //}
        //public void Run()
        //{
        //    Socket socket1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        //    Socket socket2 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        //    var localEP1 = new IPEndPoint(IPAddress.Any, 2234);
        //    var localEP2 = new IPEndPoint(IPAddress.Any, 2235);

        //    socket1.Bind(localEP1);
        //    socket2.Bind(localEP2);

        //    socket1.Connect("127.0.0.1", 1234);
        //    socket2.Connect("127.0.0.1", 1234);

        //    (new Thread(() => Send(new byte[] { 3 }, socket1))).Start();
        //    (new Thread(() => Send(new byte[] { 5 }, socket2))).Start();

        //}

        /// Клиент сокет для UDP конец
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Клиент сокет для MultiIP начало
        //static void ConnentYa(Socket client, IPAddress[] ipAddress, bool reconnect)
        //{
        //    try
        //    {
        //        if (reconnect)
        //        {
        //            var task = client.ConnectAsync(ipAddress, 80);
        //            task.Wait();
        //        }
        //        else client.Connect(ipAddress, 80);
        //    }
        //    catch
        //    {
        //    }
        //    if (client.Connected)
        //    {
        //        Console.WriteLine("Connected!");
        //        Console.WriteLine("localEndPoint" + client.LocalEndPoint);
        //        Console.WriteLine("remoteEndPoint" + client.RemoteEndPoint);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Connected problem!");
        //        return;
        //    }

        //    Console.WriteLine("Disconnected..");

        //    client.Disconnect(true); // планируем ли мы переиспользовать сокет. true - да

        //    Console.WriteLine("Disconnected..");

        //}

        //public void Run()
        //{
        //    using (Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        //    {
        //        Console.WriteLine("I`m clientMulIP. Connecting...");

        //        var address = Dns.GetHostAddresses("yandex.ru"); // этот запрос вернет массив адресов

        //        Console.WriteLine("Адреса");
        //        foreach (var item in address)
        //            Console.WriteLine(item); // посмотрим, что получили

        //        ConnentYa(client, address, false);

        //        ConnentYa(client, address, true);
        //    }
        //}
        /// Клиент сокет для MultiIP конец
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Клиент TcpListener начало
        /// Основное назначение класса – это “слушать” сеть, ожидая новых TCP-подключений. 
        /// Класс предоставляет удобные методы создания серверного соединения и ожидания.

        //public void Run()
        //{

        //    using (Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        //    {
        //        var localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);

        //        Console.WriteLine("I`m client. Connecting...");

        //        client.Bind(localEndPoint);

        //        try
        //        {
        //            client.Connect(IPAddress.Parse("127.0.0.1"), 12345);
        //        }
        //        catch
        //        {
        //        }

        //        if (client.Connected)
        //        {
        //            Console.WriteLine("Connected!");
        //            Console.WriteLine("localEndPoint" + client.LocalEndPoint);
        //            Console.WriteLine("remoteEndPoint" + client.RemoteEndPoint);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Connected problem!");
        //            return;
        //        }

        //        byte[] bytes = Encoding.UTF8.GetBytes("Привет");

        //        int count = client.Send(bytes);

        //        if (count == bytes.Length)
        //        {
        //            Console.WriteLine("Отправлено ");
        //        }
        //        else Console.WriteLine("Что-то пошло не так...");
        //    }

        //}

        /// Клиент TcpListener конец 
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Клиент TcpClient
        ///     

        //public void Run()
        //{
        //    using (TcpClient client = new TcpClient())
        //    {
        //        var localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);

        //        Console.WriteLine("I`m client. Connecting...");

        //        try
        //        {
        //            client.Connect(IPAddress.Parse("127.0.0.1"), 12345);
        //        }
        //        catch
        //        {
        //        }

        //        if (client.Connected)
        //        {
        //            Console.WriteLine("Connected!");
        //            Console.WriteLine("localEndPoint" + client.Client.LocalEndPoint);
        //            Console.WriteLine("remoteEndPoint" + client.Client.RemoteEndPoint);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Connected problem!");
        //            return;
        //        }


        //        using (var stream = client.GetStream())  // код отправки
        //        { 
        //            byte[] bytes = Encoding.UTF8.GetBytes("Привет");

        //            try
        //            {
        //                stream.Write(bytes);
        //                Console.WriteLine("Сообщение отправлено");
        //            }
        //            catch
        //            {
        //                Console.WriteLine("Сообщение не отправлено");
        //            }
        //        }
        //    }
        //}
        /// Клиент TCPClient конец
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Клиент со StreamReader и StreamWriter(умеют работать с потоками как с текстом)
        /// 
        //public void Run()
        //{
        //    using (TcpClient client = new TcpClient())
        //    {
        //        client.Connect(IPAddress.Parse("127.0.0.1"), 12345);

        //        using (var writer = new StreamWriter(client.GetStream()))  // код отправки
        //        {
        //            writer.WriteLine("Привет, я клиент StreamWriter");
        //        }
        //    }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Сервер со StreamReader и StreamWriter заставим получать строку, переворачивать ее и отправлять обратно
        /// 
        //public void Run()
        //{
        //    using (TcpClient client = new TcpClient())
        //    {
        //        client.Connect(IPAddress.Parse("127.0.0.1"), 12345);

        //        var reader = new StreamReader(client.GetStream());
        //        var writer = new StreamWriter(client.GetStream());

        //        writer.WriteLine("Привет");
        //        writer.Flush();

        //        Console.WriteLine(reader.ReadLine());
        //    }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// пример с HTTP на основе клиетского сервиса
        /// 
        public void Run()
        { 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://yandex.ru"); // HttpWebRequest возвращает HttpWebResponse. В данном случае указываем адрес

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (var s = new StreamReader(response.GetResponseStream()))
                {
                    Console.WriteLine(s.ReadToEnd());
                }
            
            
            }


        }
    }
}
