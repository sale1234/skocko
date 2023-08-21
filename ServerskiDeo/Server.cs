using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerskiDeo
{
    public class Server
    {
        private Socket serverSocket;
        private List<ClientHandler> clients = new List<ClientHandler>();
        private List<int> brojevi;

        internal void Start(List<int> brojevi)
        {
            if (serverSocket == null)
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999));
                serverSocket.Listen(4);

                this.brojevi = brojevi;
            }

        }

        internal void obradiKlijenta()
        {
            // konstantno osluskuj klijenta, i njegove zahteve
            while (true)
            {
                try
                {
                    Socket klijentSoket = serverSocket.Accept();
                    ClientHandler handler = new ClientHandler(klijentSoket, clients, brojevi);
                    clients.Add(handler);

                    Thread nit = new Thread(handler.obradiZahteve);
                    nit.Start();
                }
                catch (SocketException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
