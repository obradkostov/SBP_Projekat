using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.DesktopCore
{
    public partial class ParkingMestoEditForma : Form
    {
        private readonly int? _id;

        public ParkingMestoEditForma()
        {
            InitializeComponent();
            _id = null;
        }

        public ParkingMestoEditForma(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void ParkingMestoEditForma_Load(object sender, EventArgs e)
        {
            cmbTip.Items.Clear();
            cmbTip.Items.AddRange(new object[] { "standardna", "rezervisana", "invaliditet", "dostavna_vozila", "stanari", "taxi", "punjac_ev" });

            var (isErrorZ, zone, errorZ) = DTOManager.VratiSveZone();
            if (isErrorZ)
            {
                MessageBox.Show(errorZ);
            }
            else
            {
                cmbZona.DataSource = zone;
                cmbZona.DisplayMember = "Naziv";
            }

            if (_id.HasValue)
            {
                Text = "Izmena parking mesta";
                var (isError, m, error) = await DTOManager.VratiPMAsync(_id.Value);
                if (isError)
                {
                    MessageBox.Show(error);
                    Close();
                    return;
                }
                txtOznaka.Text = m.OznakaMesta;
                txtLokacija.Text = m.GeografskaLokacija;
                txtStatus.Text = m.Status;
                txtDozDuzina.Text = m.DozDuzina.ToString();
                chkNatkriveno.Checked = m.Natkrivenost == 'D' || m.Natkrivenost == 'd';
                txtKameraSenzor.Text = m.KameraSenzor;
                cmbTip.SelectedItem = m.TipMesta;
                txtNivoPristupacnosti.Text = m.NivoPristupacnosti;
                txtSnagaPunjaca.Text = m.SnagaPunjaca?.ToString();
                txtTipKonektora.Text = m.TipKonektora;
                txtBrojPrikljucaka.Text = m.BrojPrikljucaka?.ToString();
                txtRezimiPunjenja.Text = m.RezimiPunjenja;

                for (int i = 0; i < cmbZona.Items.Count; i++)
                {
                    if (((ParkingZonaView)cmbZona.Items[i]!).Id == m.ZonaId)
                    {
                        cmbZona.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                Text = "Dodavanje novog parking mesta";
            }
            PrikaziPolja();
        }

        private void cmbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrikaziPolja();
        }

        private void PrikaziPolja()
        {
            string? tip = cmbTip.SelectedItem?.ToString();
            pnlInvaliditet.Visible = tip == "invaliditet";
            pnlPunjac.Visible = tip == "punjac_ev";
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOznaka.Text) || cmbTip.SelectedItem == null || cmbZona.SelectedItem == null)
            {
                MessageBox.Show("Oznaka mesta, tip mesta i zona su obavezni.");
                return;
            }
            decimal.TryParse(txtDozDuzina.Text, out decimal dozDuzina);
            decimal.TryParse(txtSnagaPunjaca.Text, out decimal snagaPunjaca);
            int.TryParse(txtBrojPrikljucaka.Text, out int brojPrikljucaka);

            ParkingMestoView p = new()
            {
                Id = _id ?? 0,
                OznakaMesta = txtOznaka.Text,
                GeografskaLokacija = txtLokacija.Text,
                Status = txtStatus.Text,
                TipMesta = cmbTip.SelectedItem.ToString(),
                DozDuzina = dozDuzina,
                Natkrivenost = chkNatkriveno.Checked ? 'D' : 'N',
                KameraSenzor = txtKameraSenzor.Text,
                ZonaId = ((ParkingZonaView)cmbZona.SelectedItem).Id,
                NivoPristupacnosti = txtNivoPristupacnosti.Text,
                SnagaPunjaca = snagaPunjaca,
                TipKonektora = txtTipKonektora.Text,
                BrojPrikljucaka = brojPrikljucaka,
                RezimiPunjenja = txtRezimiPunjenja.Text
            };

            bool isError;
            string? error;

            if (_id.HasValue)
            {
                (isError, _, error) = await DTOManager.AzurirajPMAsync(p);
            }
            else if (p.TipMesta == "invaliditet")
            {
                (isError, _, error) = await DTOManager.DodajPMInvaliditetAsync(p);
            }
            else if (p.TipMesta == "punjac_ev")
            {
                (isError, _, error) = await DTOManager.DodajPMPunjacAsync(p);
            }
            else
            {
                (isError, _, error) = await DTOManager.DodajPMAsync(p);
            }

            if (isError)
            {
                MessageBox.Show(error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
