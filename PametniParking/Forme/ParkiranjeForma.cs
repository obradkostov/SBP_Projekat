using NHibernate;
using PametniParking.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PametniParking.Forme
{
    public partial class ParkiranjeForma : Form
    {
        public ParkiranjeForma()
        {
            InitializeComponent();
        }

        private void ParkiranjeForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var parkiranja = session.Query<Parkiranje>().ToList();
                dgvParkiranja.DataSource = parkiranja;

                foreach (var kolona in new[] { "Vozilo", "ParkingMesto", "Zona", "Karta" })
                {
                    if (dgvParkiranja.Columns.Contains(kolona))
                        dgvParkiranja.Columns[kolona].Visible = false;
                }
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using (ParkiranjeEditForma forma = new ParkiranjeEditForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                    UcitajPodatke();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvParkiranja.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var parkiranje = (Parkiranje)dgvParkiranja.CurrentRow.DataBoundItem;
            using (ParkiranjeEditForma forma = new ParkiranjeEditForma(parkiranje.Id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                    UcitajPodatke();
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvParkiranja.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var parkiranje = (Parkiranje)dgvParkiranja.CurrentRow.DataBoundItem;
            var result = MessageBox.Show($"Da li ste sigurni da želite da obrišete parkiranje br. {parkiranje.Id}?", "Potvrda brisanja", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        var obj = session.Get<Parkiranje>(parkiranje.Id);
                        session.Delete(obj);
                        transaction.Commit();
                    }
                    UcitajPodatke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom brisanja parkiranja: {ex.Message}");
            }
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}