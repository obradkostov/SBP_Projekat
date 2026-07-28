using NHibernate;
using PametniParking.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PametniParking.Forme
{
    public partial class IzvestajForma : Form
    {
        public IzvestajForma()
        {
            InitializeComponent();
        }

        private void IzvestajForma_Load(object sender, EventArgs e)
        {
            GenerisiIzvestaj();
        }

        private void btnOsvezi_Click(object sender, EventArgs e)
        {
            GenerisiIzvestaj();
        }

        private void GenerisiIzvestaj()
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var zone = session.Query<ParkingZona>().ToList();
                    var parkiranja = session.Query<Parkiranje>().ToList();

                    var izvestaj = zone.Select(zona => new
                    {
                        Zona = zona.Naziv,
                        BrojParkiranja = parkiranja.Count(p => p.Zona != null && p.Zona.Id == zona.Id),
                        UkupanPrihod = parkiranja.Where(p => p.Zona != null && p.Zona.Id == zona.Id).Sum(p => (decimal?)p.ObracunatiIznos) ?? 0
                    }).ToList();

                    dgvIzvestaj.DataSource = izvestaj;

                    lblUkupno.Text = $"Ukupan broj parkiranja: {parkiranja.Count}, ukupan prihod svih zona: {parkiranja.Sum(p => p.ObracunatiIznos):0.00}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom generisanja izveštaja: " + ex.Message);
            }
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
