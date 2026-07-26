using NHibernate;
using PametniParking.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PametniParking.Forme
{
    public partial class PretplatnaKartaForma : Form
    {
        public PretplatnaKartaForma()
        {
            InitializeComponent();
        }

        private void PretplatnaKartaForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var karte = session.Query<PretplatnaKarta>().ToList();
                dgvKarte.DataSource = karte;

                foreach (var kolona in new[] { "Korisnik", "Zone" })
                {
                    if (dgvKarte.Columns.Contains(kolona))
                        dgvKarte.Columns[kolona].Visible = false;
                }
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using (PretplatnaKartaEditForma forma = new PretplatnaKartaEditForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                    UcitajPodatke();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvKarte.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var karta = (PretplatnaKarta)dgvKarte.CurrentRow.DataBoundItem;
            using (PretplatnaKartaEditForma forma = new PretplatnaKartaEditForma(karta.Id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                    UcitajPodatke();
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvKarte.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var karta = (PretplatnaKarta)dgvKarte.CurrentRow.DataBoundItem;
            var result = MessageBox.Show($"Da li ste sigurni da želite da obrišete pretplatnu kartu br. {karta.Id}?", "Potvrda brisanja", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        var stareZone = session.Query<PretplatnaKartaZona>().Where(z => z.Karta.Id == karta.Id).ToList();
                        foreach (var z in stareZone)
                            session.Delete(z);

                        var obj = session.Get<PretplatnaKarta>(karta.Id);
                        session.Delete(obj);
                        transaction.Commit();
                    }
                    UcitajPodatke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom brisanja pretplatne karte: {ex.Message}");
            }
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
