using Biblioteka;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerskiDeo
{
    public class ClientHandler
    {
        private Socket klijentSoket;
        private object clients;
        private List<int> trazenaKombinacija;
        private CommunicationHelper helper;

        public ClientHandler(Socket klijentSoket, object clients, List<int> brojevi)
        {
            this.klijentSoket = klijentSoket;
            this.clients = clients;
            this.trazenaKombinacija = brojevi;

            helper = new CommunicationHelper(klijentSoket);
        }

        internal void obradiZahteve()
        {
            try
            {
                while (true)
                {
                    Poruka poruka = helper.CitajPoruku<Poruka>();
                    List<int> pokusaj = new List<int>
                    {
                        Convert.ToInt32(poruka.Broj1),
                        Convert.ToInt32(poruka.Broj2),
                        Convert.ToInt32(poruka.Broj3),
                        Convert.ToInt32(poruka.Broj4)
                    };


                    (int BrojTacnih, int BrojNetacnih) = vratiRezultatObrade(trazenaKombinacija, pokusaj);


                    Poruka odg = new Poruka
                    {
                        BrojTacnih = BrojTacnih,
                        BrojNetacnih = BrojNetacnih
                    };

                    helper.PosaljiPoruku(odg);
                }
            }
            catch (IOException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (klijentSoket != null)
                {
                    klijentSoket.Shutdown(SocketShutdown.Both);
                    klijentSoket.Close();
                }
            }

        }

        private (int BrojTacnih, int BrojNetacnih) vratiRezultatObrade(List<int> trazenaKombinacija, List<int> pokusaj)
        {
            List<int> listaPoklopljnih = new List<int>();
            List<int> listaNepokopljenih = new List<int>();
            int brojTacnihNaPogresnomMestu = 0;

            // 0 5 3 1 -> trazena kombinacija
            // 0 1 1 4 -> pokusaj

            for (int i = 0; i < trazenaKombinacija.Count(); i++)
            {
                if (trazenaKombinacija[i] == pokusaj[i])
                {
                    listaPoklopljnih.Add(trazenaKombinacija[i]); // 0
                }
                else
                {
                    listaNepokopljenih.Add(trazenaKombinacija[i]); // 5 3 1 
                }
            }

            // sad cemo iz pokusaja da obrisemo 0 isto
            for (int i = 0; i < listaPoklopljnih.Count(); i++)
            {
                pokusaj.Remove(listaPoklopljnih[i]);
            }

            // listaNepokopljenih -> 5 3 1
            // pokusaj -> 1 1 4
            for (int i = 0; i < pokusaj.Count(); i++)
            {
                if (listaNepokopljenih.Contains(pokusaj[i]))
                {
                    brojTacnihNaPogresnomMestu++;
                    listaNepokopljenih.Remove(pokusaj[i]);
                }
            }

            return (listaPoklopljnih.Count(), brojTacnihNaPogresnomMestu);
        }
    }
}
