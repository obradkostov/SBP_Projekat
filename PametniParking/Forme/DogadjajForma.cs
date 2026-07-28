using NHibernate;
using PametniParking.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PametniParking.Forme
{
    public partial class DogadjajForma : Form
    {
        public DogadjajForma()
        {
            InitializeComponent();
        }

        private void DogadjajForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var dogadjaji = session.Query<Dogadjaj>().ToList();
                dgvDogadjaji.DataSource = dogadjaji;

                if (dgvDogadjaji.Columns.Contains("Senzor"))
                    dgvDogadjaji.Columns["Senzor"].Visible = false;
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using (DogadjajEditForma forma = new DogadjajEditForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                    UcitajPodatke();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvDogadjaji.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var dogadjaj = (Dogadjaj)dgvDogadjaji.CurrentRow.DataBoundItem;
            using (DogadjajEditForma forma = new DogadjajEditForma(dogadjaj.Id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                    UcitajPodatke();
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvDogadjaji.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var dogadjaj = (Dogadjaj)dgvDogadjaji.CurrentRow.DataBoundItem;
            var result = MessageBox.Show($"Da li ste sigurni da želite da obrišete događaj br. {dogadjaj.RedniBroj}?", "Potvrda brisanja", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        var obj = session.Get<Dogadjaj>(dogadjaj.Id);
                        session.Delete(obj);
                        transaction.Commit();
                    }
                    UcitajPodatke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom brisanja događaja: {ex.Message}");
            }
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
