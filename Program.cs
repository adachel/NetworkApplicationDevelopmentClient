using NetworkApplicationDevelopmentClient.HomeWorks.HomeWork1;
using NetworkApplicationDevelopmentClient.HomeWorks.HomeWork1.Client;

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
            ClientHW1 clientHW1 = new ClientHW1();
            clientHW1.SentMessage(args[0], args[1]);

        }
    }
}

