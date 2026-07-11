using PametniParking.Forme;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PametniParking
{
    public partial class GlavnaForma : Form
    {
        public GlavnaForma()
        {
            InitializeComponent();
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnZone_Click(object sender, EventArgs e)
        {
            using (var forma = new ParkingZonaForma())
            {
                forma.ShowDialog();
            }
        }

        private void btnMesta_Click(object sender, EventArgs e)
        {
            using (var forma = new ParkingMestoForma())
            {
                forma.ShowDialog();
            }
        }

        private void btnDogadjaj_Click(object sender, EventArgs e)
        {
            using (var forma = new DogadjajForma())
            {
                forma.ShowDialog();
            }
        }

        private void btnVozila_Click(object sender, EventArgs e)
        {
            using (var forma = new VoziloForma())
            {
                forma.ShowDialog();
            }
        }

        private void btnKorisnici_Click(object sender, EventArgs e)
        {
            using (var forma = new KorisnikForma())
            {
                forma.ShowDialog();
            }
        }

        private void btnPretplate_Click(object sender, EventArgs e)
        {
            using (var forma = new PretplatnaKartaForma())
            {
                forma.ShowDialog();
            }
        }

        private void btnSenzori_Click(object sender, EventArgs e)
        {
            using (var forma = new SenzorForma())
            {
                forma.ShowDialog();
            }
        }

        private void btnIzvestaji_Click(object sender, EventArgs e)
        {
            using (var forma = new IzvestajForma())
            {
                forma.ShowDialog();
            }
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateHelper.OpenSession())
                {
                    MessageBox.Show("Konekcija uspesna!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message +
                    "\n\nInner: " + ex.InnerException?.Message +
                    "\n\nInner2: " + ex.InnerException?.InnerException?.Message +
                    "\n\nInner3: " + ex.InnerException?.InnerException?.InnerException?.Message);
            }
        }*/
    }
}
