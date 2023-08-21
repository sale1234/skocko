using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Poruka
    {
        public string Broj1 { get; set; }
        public string Broj2 { get; set; }
        public string Broj3 { get; set; }
        public string Broj4 { get; set; }
        public int BrojTacnih { get; set; }
        public int BrojNetacnih { get; set; }
    }
}
