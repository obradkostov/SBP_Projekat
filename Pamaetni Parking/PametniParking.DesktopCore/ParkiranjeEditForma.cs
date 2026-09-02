using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.DesktopCore
{
    public partial class ParkiranjeEditForma : Form
    {
        private readonly int? _id;

        public ParkiranjeEditForma()
        {
            InitializeComponent();
            _id = null;
        }

        public ParkiranjeEditForma(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void ParkiranjeEditForma_Load(object sender, EventArgs e)
        {
            var (isErrorV, vozila, errorV) = DTOManager.VratiSvaVozila();
            if (!isErrorV)
            {
                cmbVozilo.DataSource = vozila;
                cmbVozilo.DisplayMember = "RegistarskaOznaka";
            }

            var (isErrorM, mesta, errorM) = DTOManager.VratiSvaPM();
            if (!isErrorM)
            {
                cmbMesto.DataSource = mesta;
                cmbMesto.DisplayMember = "OznakaMesta";
            }

            var (isErrorZ, zone, errorZ) = DTOManager.VratiSveZone();
            if (!isErrorZ)
            {
                cmbZona.DataSource = zone;
                cmbZona.DisplayMember = "Naziv";
            }

            var (isErrorK, karte, errorK) = DTOManager.VratiSveKarte();
            if (!isErrorK)
            {
                cmbKarta.DataSource = karte;
                cmbKarta.DisplayMember = "TipPretplate";
                cmbKarta.Enabled = false;
                chkImaKartu.CheckedChanged += (s, args) => cmbKarta.Enabled = chkImaKartu.Checked;
            }

            if (_id.HasValue)
            {
                Text = "Izmena parkiranja";
                var (isError, p, error) = await DTOManager.VratiParkiranjeAsync(_id.Value);
                if (isError)
                {
                    MessageBox.Show(error);
                    Close();
                    return;
                }
                dtpPocetak.Value = p.DatumVremePocetka;
                txtIznos.Text = p.ObracunatiIznos.ToString();

                for (int i = 0; i < cmbVozilo.Items.Count; i++)
                {
                    if (((VoziloView)cmbVozilo.Items[i]!).RegistarskaOznaka == p.VoziloOznaka)
                    {
                        cmbVozilo.SelectedIndex = i;
                        break;
                    }
                }
                for (int i = 0; i < cmbMesto.Items.Count; i++)
                {
                    if (((ParkingMestoView)cmbMesto.Items[i]!).Id == p.ParkingMestoId)
                    {
                        cmbMesto.SelectedIndex = i;
                        break;
                    }
                }
                for (int i = 0; i < cmbZona.Items.Count; i++)
                {
                    if (((ParkingZonaView)cmbZona.Items[i]!).Id == p.ZonaId)
                    {
                        cmbZona.SelectedIndex = i;
                        break;
                    }
                }
                if (p.KartaId.HasValue)
                {
                    chkImaKartu.Checked = true;
                    for (int i = 0; i < cmbKarta.Items.Count; i++)
                    {
                        if (((PretplatnaKartaView)cmbKarta.Items[i]!).Id == p.KartaId.Value)
                        {
                            cmbKarta.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            else
            {
                Text = "Dodavanje novog parkiranja";
                dtpPocetak.Value = DateTime.Now;
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (cmbVozilo.SelectedItem == null || cmbMesto.SelectedItem == null || cmbZona.SelectedItem == null)
            {
                MessageBox.Show("Vozilo, parking mesto i zona su obavezni.");
                return;
            }
            decimal.TryParse(txtIznos.Text, out decimal iznos);

            ParkiranjeView p = new()
            {
                Id = _id ?? 0,
                DatumVremePocetka = dtpPocetak.Value,
                ObracunatiIznos = iznos,
                VoziloOznaka = ((VoziloView)cmbVozilo.SelectedItem).RegistarskaOznaka,
                ParkingMestoId = ((ParkingMestoView)cmbMesto.SelectedItem).Id,
                ZonaId = ((ParkingZonaView)cmbZona.SelectedItem).Id,
                KartaId = chkImaKartu.Checked && cmbKarta.SelectedItem != null
                    ? ((PretplatnaKartaView)cmbKarta.SelectedItem).Id
                    : (int?)null
            };

            bool isError;
            string? error;

            if (_id.HasValue)
            {
                (isError, _, error) = await DTOManager.AzurirajParkiranjeAsync(p);
            }
            else
            {
                (isError, _, error) = await DTOManager.DodajParkiranjeAsync(p);
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
