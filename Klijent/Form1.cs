using Biblioteka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public partial class Form1 : Form
    {
        private Random random;
        private Thread nit1;
        private Thread nit2;
        private Thread nit3;
        private Thread nit4;
        private int brojac = 0;
        private int rb = 0;
        private BindingList<Prikaz> prikazi = new BindingList<Prikaz>();


        public Form1()
        {
            InitializeComponent();

            try
            {
                Komunikacija.GetInstance.Connect();
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStart1_Click(object sender, EventArgs e)
        {
            nit1 = new Thread(okreciPrviBroj);
            nit1.Start();
        }

        private void btnStart2_Click_1(object sender, EventArgs e)
        {
            nit2 = new Thread(okreciDrugiBroj);
            nit2.Start();
        }

        private void btnStart3_Click(object sender, EventArgs e)
        {
            nit3 = new Thread(okreciTreciBroj);
            nit3.Start();
        }

        private void btnStart4_Click(object sender, EventArgs e)
        {
            nit4 = new Thread(okreciCetvrtiBroj);
            nit4.Start();
        }

        private void okreciPrviBroj()
        {
            while (true)
            {
                Invoke(new Action(() =>
                {
                    random = new Random();
                    txtBroj1.Text = random.Next(6).ToString();
                }));
            }
        }

        private void okreciDrugiBroj()
        {
            while (true)
            {
                Invoke(new Action(() =>
                {
                    random = new Random();
                    txtBroj2.Text = random.Next(6).ToString();
                }));
            }
        }

        private void okreciTreciBroj()
        {
            while (true)
            {
                Invoke(new Action(() =>
                {
                    random = new Random();
                    txtBroj3.Text = random.Next(6).ToString();
                }));
            }
        }

        private void okreciCetvrtiBroj()
        {
            while (true)
            {
                Invoke(new Action(() =>
                {
                    random = new Random();
                    txtBroj4.Text = random.Next(6).ToString();
                }));
            }
        }

        private void btnStop1_Click(object sender, EventArgs e)
        {
            nit1.Abort();
        }
        private void btnStop2_Click_1(object sender, EventArgs e)
        {
            nit2.Abort();
        }

        private void btnStop3_Click(object sender, EventArgs e)
        {
            nit3.Abort();
        }

        private void btnStop4_Click(object sender, EventArgs e)
        {
            nit4.Abort();
        }

        private void btnPosaljiServeru_Click(object sender, EventArgs e)
        {
            Poruka poruka = new Poruka
            {
                Broj1 = txtBroj1.Text,
                Broj2 = txtBroj2.Text,
                Broj3 = txtBroj3.Text,
                Broj4 = txtBroj4.Text,
            };

            Komunikacija.GetInstance.PosaljiPoruku(poruka);
            Poruka odg = Komunikacija.GetInstance.CitajPoruku();

            Invoke(new Action(() =>
            {
                lblTacnih.Text = odg.BrojTacnih.ToString();
                lblNetacnih.Text = odg.BrojNetacnih.ToString();
            }));

            Prikaz prikaz = new Prikaz
            {
                RB = ++rb,
                Kombinacija = $"{txtBroj1.Text}-{txtBroj2.Text}-{txtBroj3.Text}-{txtBroj4.Text}",
                PogodjenihNaMestu = lblTacnih.Text,
                PogodjenihNisuNaMestu = lblNetacnih.Text
            };

            prikazi.Add(prikaz);

            dataGridView1.DataSource = prikazi;

            if (odg.BrojTacnih == 4)
            {
                MessageBox.Show("Pogidili ste kombinaciju");
                return;
            }
            else
            {
                brojac++;
            }

            if (brojac == 6)
            {
                MessageBox.Show("Iskoristili ste svih 6 pokusaja");
                Invoke(new Action(() =>
                {
                    btnPosaljiServeru.Enabled = false;
                }));
            }

           
        }

        
    }
}
