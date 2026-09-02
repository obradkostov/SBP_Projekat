using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.DesktopCore
{
    public partial class PretplatnaKartaEditForma : Form
    {
        private readonly int? _id;

        public PretplatnaKartaEditForma()
        {
            InitializeComponent();
            _id = null;
        }

        public PretplatnaKartaEditForma(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void PretplatnaKartaEditForma_Load(object sender, EventArgs e)
        {
            var (isErrorK, korisnici, errorK) = DTOManager.VratiSveKorisnike();
            if (!isErrorK)
            {
                cmbKorisnik.DataSource = korisnici;
                cmbKorisnik.DisplayMember = "Email";
            }

            var (isErrorZ, zone, errorZ) = DTOManager.VratiSveZone();
            if (!isErrorZ)
            {
                clbZone.Items.Clear();
                foreach (var zona in zone)
                {
                    clbZone.Items.Add(zona);
                }
                clbZone.DisplayMember = "Naziv";
            }

            if (_id.HasValue)
            {
                Text = "Izmena pretplatne karte";
                var (isError, k, error) = await DTOManager.VratiKartuAsync(_id.Value);
                if (isError)
                {
                    MessageBox.Show(error);
                    Close();
                    return;
                }
                txtTipPretplate.Text = k.TipPretplate;
                dtpPocetak.Value = k.PocetakVazenja;
                dtpKraj.Value = k.KrajVazenja;
                txtCena.Text = k.Cena.ToString();
                txtMaksBrVozila.Text = k.MaksBrVozila.ToString();

                for (int i = 0; i < cmbKorisnik.Items.Count; i++)
                {
                    if (((KorisnikView)cmbKorisnik.Items[i]!).Id == k.KorisnikId)
                    {
                        cmbKorisnik.SelectedIndex = i;
                        break;
                    }
                }
                for (int i = 0; i < clbZone.Items.Count; i++)
                {
                    var zona = (ParkingZonaView)clbZone.Items[i];
                    if (k.ZoneId.Contains(zona.Id))
                    {
                        clbZone.SetItemChecked(i, true);
                    }
                }
            }
            else
            {
                Text = "Dodavanje nove pretplatne karte";
                dtpPocetak.Value = DateTime.Now;
                dtpKraj.Value = DateTime.Now.AddMonths(6);
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTipPretplate.Text) || cmbKorisnik.SelectedItem == null)
            {
                MessageBox.Show("Tip pretplate i korisnik su obavezni.");
                return;
            }
            if (clbZone.CheckedItems.Count == 0)
            {
                MessageBox.Show("Izaberite bar jednu zonu za koju pretplatna karta važi.");
                return;
            }
            decimal.TryParse(txtCena.Text, out decimal cena);
            int.TryParse(txtMaksBrVozila.Text, out int maksBrVozila);
            if (maksBrVozila == 0) maksBrVozila = 1;

            List<int> zoneId = new();
            foreach (var stavka in clbZone.CheckedItems)
            {
                zoneId.Add(((ParkingZonaView)stavka).Id);
            }

            PretplatnaKartaView p = new()
            {
                Id = _id ?? 0,
                TipPretplate = txtTipPretplate.Text,
                PocetakVazenja = dtpPocetak.Value,
                KrajVazenja = dtpKraj.Value,
                Cena = cena,
                MaksBrVozila = maksBrVozila,
                KorisnikId = ((KorisnikView)cmbKorisnik.SelectedItem).Id,
                ZoneId = zoneId
            };

            bool isError;
            string? error;

            if (_id.HasValue)
            {
                (isError, _, error) = await DTOManager.AzurirajKartuAsync(p);
            }
            else
            {
                (isError, _, error) = await DTOManager.DodajKartuAsync(p);
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
