using NHibernate;
using PametniParking.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PametniParking.Forme
{
    public partial class ParkiranjeEditForma : Form
    {
        private readonly int? _parkiranjeId;

        public ParkiranjeEditForma()
        {
            InitializeComponent();
            _parkiranjeId = null;
        }

        public ParkiranjeEditForma(int parkiranjeId)
        {
            InitializeComponent();
            _parkiranjeId = parkiranjeId;
        }

        private void ParkiranjeEditForma_Load(object sender, EventArgs e)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var vozila = session.Query<Vozilo>().ToList();
                cmbVozilo.DataSource = vozila;
                cmbVozilo.DisplayMember = "RegistarskaOznaka";
                cmbVozilo.ValueMember = "RegistarskaOznaka";

                var mesta = session.Query<ParkingMesto>().ToList();
                cmbMesto.DataSource = mesta;
                cmbMesto.DisplayMember = "OznakaMesta";
                cmbMesto.ValueMember = "Id";

                var zone = session.Query<ParkingZona>().ToList();
                cmbZona.DataSource = zone;
                cmbZona.DisplayMember = "Naziv";
                cmbZona.ValueMember = "Id";

                var karte = session.Query<PretplatnaKarta>().ToList();
                cmbKarta.DataSource = karte;
                cmbKarta.DisplayMember = "TipPretplate";
                chkImaKartu.CheckedChanged += (s, args) => cmbKarta.Enabled = chkImaKartu.Checked;

                if (_parkiranjeId.HasValue)
                {
                    this.Text = "Izmena parkiranja";
                    var parkiranje = session.Get<Parkiranje>(_parkiranjeId.Value);
                    dtpPocetak.Value = parkiranje.DatumVremePocetka;
                    txtIznos.Text = parkiranje.ObracunatiIznos.ToString();
                    cmbVozilo.SelectedItem = parkiranje.Vozilo;
                    cmbMesto.SelectedItem = parkiranje.ParkingMesto;
                    cmbZona.SelectedItem = parkiranje.Zona;

                    if (parkiranje.Karta != null)
                    {
                        chkImaKartu.Checked = true;
                        cmbKarta.SelectedItem = parkiranje.Karta;
                    }
                    else
                    {
                        chkImaKartu.Checked = false;
                        cmbKarta.Enabled = false;
                    }
                }
                else
                {
                    this.Text = "Dodavanje novog parkiranja";
                    dtpPocetak.Value = DateTime.Now;
                    chkImaKartu.Checked = false;
                    cmbKarta.Enabled = false;
                }
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (cmbVozilo.SelectedItem == null || cmbMesto.SelectedItem == null || cmbZona.SelectedItem == null)
            {
                MessageBox.Show("Vozilo, parking mesto i zona su obavezni.");
                return;
            }
            decimal iznos = 0;
            if (!string.IsNullOrWhiteSpace(txtIznos.Text) && !decimal.TryParse(txtIznos.Text, out iznos))
            {
                MessageBox.Show("Obračunati iznos mora biti broj.");
                return;
            }
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Parkiranje parkiranje;
                    bool novo = !_parkiranjeId.HasValue;
                    if (!novo)
                        parkiranje = session.Get<Parkiranje>(_parkiranjeId.Value);
                    else
                        parkiranje = new Parkiranje();

                    parkiranje.DatumVremePocetka = dtpPocetak.Value;
                    parkiranje.ObracunatiIznos = iznos;
                    parkiranje.Vozilo = (Vozilo)cmbVozilo.SelectedItem;
                    parkiranje.ParkingMesto = (ParkingMesto)cmbMesto.SelectedItem;
                    parkiranje.Zona = (ParkingZona)cmbZona.SelectedItem;
                    parkiranje.Karta = chkImaKartu.Checked ? cmbKarta.SelectedItem as PretplatnaKarta : null;

                    if (novo)
                        session.Save(parkiranje);
                    else
                        session.Update(parkiranje);

                    transaction.Commit();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message);
            }
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
