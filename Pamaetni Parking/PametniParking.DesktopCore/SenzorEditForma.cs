using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.DesktopCore
{
    public partial class SenzorEditForma : Form
    {
        private readonly int? _id;

        public SenzorEditForma()
        {
            InitializeComponent();
            _id = null;
        }

        public SenzorEditForma(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void SenzorEditForma_Load(object sender, EventArgs e)
        {
            cmbTip.Items.Clear();
            cmbTip.Items.AddRange(new object[] { "magnetni", "ultrazvucni", "opticki", "video", "kombinovani" });

            var (isErrorM, mesta, errorM) = DTOManager.VratiSvaPM();
            if (isErrorM)
            {
                MessageBox.Show(errorM);
            }
            else
            {
                cmbMesto.DataSource = mesta;
                cmbMesto.DisplayMember = "OznakaMesta";
            }

            if (_id.HasValue)
            {
                Text = "Izmena senzora";
                var (isError, sz, error) = await DTOManager.VratiSenzorAsync(_id.Value);
                if (isError)
                {
                    MessageBox.Show(error);
                    Close();
                    return;
                }
                txtProizvodjac.Text = sz.Proizvodjac;
                txtModel.Text = sz.Model;
                txtSerijskiBroj.Text = sz.SerijskiBroj;
                dtpDatum.Value = sz.DatumInstalacije;
                txtStatus.Text = sz.Status;
                cmbTip.SelectedItem = sz.TipSenzora;
                txtRezolucija.Text = sz.Rezolucija;
                txtUgao.Text = sz.UgaoPokrivanja?.ToString();
                chkPrepoznavanje.Checked = sz.PrepRegOznaka == 'D' || sz.PrepRegOznaka == 'd';

                for (int i = 0; i < cmbMesto.Items.Count; i++)
                {
                    if (((ParkingMestoView)cmbMesto.Items[i]!).Id == sz.ParkingMestoId)
                    {
                        cmbMesto.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                Text = "Dodavanje novog senzora";
                dtpDatum.Value = DateTime.Now;
            }
            PrikaziVideoPolja();
        }

        private void cmbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrikaziVideoPolja();
        }

        private void PrikaziVideoPolja()
        {
            pnlVideo.Visible = cmbTip.SelectedItem?.ToString() == "video";
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSerijskiBroj.Text) || cmbTip.SelectedItem == null || cmbMesto.SelectedItem == null)
            {
                MessageBox.Show("Serijski broj, tip senzora i parking mesto su obavezni.");
                return;
            }
            decimal.TryParse(txtUgao.Text, out decimal ugao);

            SenzorView p = new()
            {
                Id = _id ?? 0,
                Proizvodjac = txtProizvodjac.Text,
                Model = txtModel.Text,
                SerijskiBroj = txtSerijskiBroj.Text,
                DatumInstalacije = dtpDatum.Value,
                Status = txtStatus.Text,
                TipSenzora = cmbTip.SelectedItem.ToString(),
                ParkingMestoId = ((ParkingMestoView)cmbMesto.SelectedItem).Id,
                Rezolucija = txtRezolucija.Text,
                UgaoPokrivanja = ugao,
                PrepRegOznaka = chkPrepoznavanje.Checked ? 'D' : 'N'
            };

            bool isError;
            string? error;

            if (_id.HasValue)
            {
                (isError, _, error) = await DTOManager.AzurirajSenzorAsync(p);
            }
            else if (p.TipSenzora == "video")
            {
                (isError, _, error) = await DTOManager.DodajVideoSenzorAsync(p);
            }
            else
            {
                (isError, _, error) = await DTOManager.DodajSenzorAsync(p);
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
