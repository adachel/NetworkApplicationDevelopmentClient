using NetworkApplicationDevelopmentClient.HomeWorks.HomeWork1;
using NetworkApplicationDevelopmentClient.HomeWorks.HomeWork1.Client;
using NetworkApplicationDevelopmentClient.HomeWorks.HomeWork2.Client;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /////////////////////////////////////////////////////////////////////////
            /// Lection 
            //Lec1Client lec1Client = new Lec1Client();
            //lec1Client.Run();

            ////////////////////////////////////////////////////////////////////////////
            /// Seminar 1
            /// 
            //Sem1 sem1 = new Sem1();
            //sem1.Run(args);

            /////////////////////////////////////////////////////////////////////////
            /// HomeWork 1
            /// 
            //ClientHW2 clientHW1 = new ClientHW2();
            //clientHW1.SentMessage(args[0], args[1]);

            /////////////////////////////////////////////////////////////////////////
            /// HomeWork 2
            /// 
            ClientHW2 clientHW2 = new ClientHW2();
            clientHW2.SentMessage(args[0], args[1]);

        }
    }
}
