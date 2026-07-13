using NHibernate;
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
    public partial class ParkingZonaForma : Form
    {
        public ParkingZonaForma()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using (ParkingZonaEditForma forma = new ParkingZonaEditForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    UcitajPodatke();
                }
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvZone.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var zona = (ParkingZona)dgvZone.CurrentRow.DataBoundItem;
            using (ParkingZonaEditForma forma = new ParkingZonaEditForma(zona.Id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    UcitajPodatke();
                }
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvZone.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var zona = (ParkingZona)dgvZone.CurrentRow.DataBoundItem;
            var result = MessageBox.Show($"Da li ste sigurni da želite da obrišete zonu {zona.Naziv}?", "Potvrda brisanja", MessageBoxButtons.YesNo);
            if(result != DialogResult.Yes)
            {
                return;
            }
            try
            {
                using(ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(zona);
                        transaction.Commit();
                    }
                    UcitajPodatke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom brisanja zone: {ex.Message}");
            }
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ParkingZonaForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }
        private void UcitajPodatke()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var zone = session.Query<ParkingZona>().ToList();
                dgvZone.DataSource = zone;

                if (dgvZone.Columns.Contains("FiksneTarife"))
                    dgvZone.Columns["FiksneTarife"].Visible = false;
                if (dgvZone.Columns.Contains("DinamickeeTarife"))
                    dgvZone.Columns["DinamickeeTarife"].Visible = false;
                if (dgvZone.Columns.Contains("ParkingMesta"))
                    dgvZone.Columns["ParkingMesta"].Visible = false;
            }
        }
    }
}