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

namespace ServerskiDeo
{
    public partial class Form1 : Form
    {
        private Thread nit;
        private Random random;
        private Server server;

        public Form1()
        {
            InitializeComponent();

            random = new Random();
            txtBroj1.Text = random.Next(6).ToString();
            txtBroj2.Text = random.Next(6).ToString();
            txtBroj3.Text = random.Next(6).ToString();
            txtBroj4.Text = random.Next(6).ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            nit = new Thread(generisiBrojeve);
            nit.Start();
        }

        private void generisiBrojeve()
        {
            while (true)
            {
                Invoke(new Action(() =>
                {
                    random = new Random();
                    txtBroj1.Text = random.Next(6).ToString();
                    txtBroj2.Text = random.Next(6).ToString();
                    txtBroj3.Text = random.Next(6).ToString();
                    txtBroj4.Text = random.Next(6).ToString();
                }));
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            nit.Abort();
        }

        private void btnPokreniServer_Click(object sender, EventArgs e)
        {
            server = new Server();
            List<int> brojevi = new List<int>
            {
                Convert.ToInt32(txtBroj1.Text),
                Convert.ToInt32(txtBroj2.Text),
                Convert.ToInt32(txtBroj3.Text),
                Convert.ToInt32(txtBroj4.Text)
            };

            try
            {
                server.Start(brojevi);
                Thread thread = new Thread(server.obradiKlijenta);
                thread.Start();
                MessageBox.Show("Server je pokrenut");
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBroj4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBroj3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBroj2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBroj1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
