using NHibernate;
using PametniParking.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PametniParking.Forme
{
    public partial class KorisnikForma : Form
    {
        public KorisnikForma()
        {
            InitializeComponent();
        }

        private void KorisnikForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var korisnici = session.Query<Korisnik>().ToList();
                dgvKorisnici.DataSource = korisnici;

                if (dgvKorisnici.Columns.Contains("Telefoni"))
                    dgvKorisnici.Columns["Telefoni"].Visible = false;
                if (dgvKorisnici.Columns.Contains("Vozila"))
                    dgvKorisnici.Columns["Vozila"].Visible = false;
                if (dgvKorisnici.Columns.Contains("PretplatneKarte"))
                    dgvKorisnici.Columns["PretplatneKarte"].Visible = false;

                if (!dgvKorisnici.Columns.Contains("Tip"))
                {
                    var tipColumn = new DataGridViewTextBoxColumn();
                    tipColumn.Name = "Tip";
                    tipColumn.HeaderText = "Tip korisnika";
                    dgvKorisnici.Columns.Add(tipColumn);
                }
                foreach (DataGridViewRow row in dgvKorisnici.Rows)
                {
                    var korisnik = (Korisnik)row.DataBoundItem;
                    row.Cells["Tip"].Value = korisnik is FizickoLice ? "Fizičko lice" : korisnik is PravnoLice ? "Pravno lice" : "-";
                }
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using (KorisnikEditForma forma = new KorisnikEditForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                    UcitajPodatke();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvKorisnici.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var korisnik = (Korisnik)dgvKorisnici.CurrentRow.DataBoundItem;
            using (KorisnikEditForma forma = new KorisnikEditForma(korisnik.Id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                    UcitajPodatke();
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvKorisnici.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var korisnik = (Korisnik)dgvKorisnici.CurrentRow.DataBoundItem;
            var result = MessageBox.Show($"Da li ste sigurni da želite da obrišete korisnika {korisnik.Email}?", "Potvrda brisanja", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        var obj = session.Get<Korisnik>(korisnik.Id);
                        session.Delete(obj);
                        transaction.Commit();
                    }
                    UcitajPodatke();
                }
            }
            catch (Exception ex)
            {
                string poruka = "Greška: " + ex.Message;
                var inner = ex.InnerException;
                while (inner != null)
                {
                    poruka += "\n\n---\n" + inner.Message;
                    inner = inner.InnerException;
                }
                MessageBox.Show(poruka);
            }
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}