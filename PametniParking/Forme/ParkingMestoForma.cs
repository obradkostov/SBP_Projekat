using NHibernate;
using PametniParking.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PametniParking.Forme
{
    public partial class ParkingMestoForma : Form
    {
        public ParkingMestoForma()
        {
            InitializeComponent();
        }

        private void ParkingMestoForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var mesta = session.Query<ParkingMesto>().ToList();
                dgvMesta.DataSource = mesta;

                if (dgvMesta.Columns.Contains("Zona"))
                    dgvMesta.Columns["Zona"].Visible = false;
                if (dgvMesta.Columns.Contains("Senzori"))
                    dgvMesta.Columns["Senzori"].Visible = false;
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using (ParkingMestoEditForma forma = new ParkingMestoEditForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                    UcitajPodatke();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvMesta.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var mesto = (ParkingMesto)dgvMesta.CurrentRow.DataBoundItem;
            using (ParkingMestoEditForma forma = new ParkingMestoEditForma(mesto.Id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                    UcitajPodatke();
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvMesta.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var mesto = (ParkingMesto)dgvMesta.CurrentRow.DataBoundItem;
            var result = MessageBox.Show($"Da li ste sigurni da želite da obrišete mesto {mesto.OznakaMesta}?", "Potvrda brisanja", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        var obj = session.Get<ParkingMesto>(mesto.Id);
                        session.Delete(obj);
                        transaction.Commit();
                    }
                    UcitajPodatke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom brisanja mesta: {ex.Message}");
            }
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
