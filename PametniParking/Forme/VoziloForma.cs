using NHibernate;
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

namespace PametniParking.Forme
{
    public partial class VoziloForma : Form
    {
        public VoziloForma()
        {
            InitializeComponent();
        }

        private void VoziloForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var vozila = session.Query<Vozilo>().ToList();
                dgvVozila.DataSource = vozila;

                if (dgvVozila.Columns.Contains("Korisnik"))
                    dgvVozila.Columns["Korisnik"].Visible = false;
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using (VoziloEditForma forma = new VoziloEditForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    UcitajPodatke();
                }
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvVozila.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var vozilo = (Vozilo)dgvVozila.CurrentRow.DataBoundItem;
            using (VoziloEditForma forma = new VoziloEditForma(vozilo.RegistarskaOznaka))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    UcitajPodatke();
                }
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvVozila.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var vozilo = (Vozilo)dgvVozila.CurrentRow.DataBoundItem;
            var result = MessageBox.Show($"Da li ste sigurni da želite da obrišete vozilo {vozilo.RegistarskaOznaka}?", "Potvrda brisanja", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        var obj = session.Get<Vozilo>(vozilo.RegistarskaOznaka);
                        session.Delete(obj);
                        transaction.Commit();
                    }
                    UcitajPodatke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom brisanja vozila: {ex.Message}");
            }
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
