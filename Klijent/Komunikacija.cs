using Biblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Klijent
{
    public class Komunikacija
    {
        private static Komunikacija instance;
        private Socket socket;
        private CommunicationHelper helper;

        public static Komunikacija GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Komunikacija();
                }

                return instance;
            }
        }

        private Komunikacija()
        {

        }

        public void PosaljiPoruku(Poruka p)
        {
            helper.PosaljiPoruku(p);
        }

        public Poruka CitajPoruku()
        {
            return helper.CitajPoruku<Poruka>();
        }

        public void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);

            helper = new CommunicationHelper(socket);
        }
    }
}
