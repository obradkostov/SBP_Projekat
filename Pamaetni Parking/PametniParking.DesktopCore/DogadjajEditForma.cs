using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.DesktopCore
{
    public partial class DogadjajEditForma : Form
    {
        private readonly int? _id;

        public DogadjajEditForma()
        {
            InitializeComponent();
            _id = null;
        }

        public DogadjajEditForma(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void DogadjajEditForma_Load(object sender, EventArgs e)
        {
            var (isErrorS, senzori, errorS) = DTOManager.VratiSveSenzore();
            if (isErrorS)
            {
                MessageBox.Show(errorS);
            }
            else
            {
                cmbSenzor.DataSource = senzori;
                cmbSenzor.DisplayMember = "SerijskiBroj";
            }

            if (_id.HasValue)
            {
                Text = "Izmena događaja";
                var (isError, d, error) = await DTOManager.VratiDogadjajAsync(_id.Value);
                if (isError)
                {
                    MessageBox.Show(error);
                    Close();
                    return;
                }
                txtRedniBroj.Text = d.RedniBroj.ToString();
                txtTip.Text = d.TipDogadjaja;
                dtpVreme.Value = d.VremeNastanka;
                txtOcitanaVrednost.Text = d.OcitanaVrednost;
                txtNivoPouzdanosti.Text = d.NivoPouzdanosti.ToString();
                txtPotvrda.Text = d.Potvrda;

                for (int i = 0; i < cmbSenzor.Items.Count; i++)
                {
                    if (((SenzorView)cmbSenzor.Items[i]!).Id == d.SenzorId)
                    {
                        cmbSenzor.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                Text = "Dodavanje novog događaja";
                dtpVreme.Value = DateTime.Now;
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRedniBroj.Text) || string.IsNullOrWhiteSpace(txtTip.Text) || cmbSenzor.SelectedItem == null)
            {
                MessageBox.Show("Redni broj, tip događaja i senzor su obavezni.");
                return;
            }
            if (!int.TryParse(txtRedniBroj.Text, out int redniBroj))
            {
                MessageBox.Show("Redni broj mora biti ceo broj.");
                return;
            }
            decimal.TryParse(txtNivoPouzdanosti.Text, out decimal nivoPouzdanosti);

            DogadjajView p = new()
            {
                Id = _id ?? 0,
                RedniBroj = redniBroj,
                TipDogadjaja = txtTip.Text,
                VremeNastanka = dtpVreme.Value,
                OcitanaVrednost = txtOcitanaVrednost.Text,
                NivoPouzdanosti = nivoPouzdanosti,
                Potvrda = txtPotvrda.Text,
                SenzorId = ((SenzorView)cmbSenzor.SelectedItem).Id
            };

            bool isError;
            string? error;

            if (_id.HasValue)
            {
                (isError, _, error) = await DTOManager.AzurirajDogadjajAsync(p);
            }
            else
            {
                (isError, _, error) = await DTOManager.DodajDogadjajAsync(p);
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
