using NHibernate;
using PametniParking.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PametniParking.Forme
{
    public partial class DogadjajEditForma : Form
    {
        private readonly int? _dogadjajId;

        public DogadjajEditForma()
        {
            InitializeComponent();
            _dogadjajId = null;
        }

        public DogadjajEditForma(int dogadjajId)
        {
            InitializeComponent();
            _dogadjajId = dogadjajId;
        }

        private void DogadjajEditForma_Load(object sender, EventArgs e)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var senzori = session.Query<Senzor>().ToList();
                cmbSenzor.DataSource = senzori;
                cmbSenzor.DisplayMember = "SerijskiBroj";
                cmbSenzor.ValueMember = "Id";

                if (_dogadjajId.HasValue)
                {
                    this.Text = "Izmena događaja";
                    var dogadjaj = session.Get<Dogadjaj>(_dogadjajId.Value);
                    txtRedniBroj.Text = dogadjaj.RedniBroj.ToString();
                    txtTip.Text = dogadjaj.TipDogadjaja;
                    dtpVreme.Value = dogadjaj.VremeNastanka;
                    txtOcitanaVrednost.Text = dogadjaj.OcitanaVrednost;
                    txtNivoPouzdanosti.Text = dogadjaj.NivoPouzdanosti.ToString();
                    txtPotvrda.Text = dogadjaj.Potvrda;
                    cmbSenzor.SelectedItem = dogadjaj.Senzor;
                }
                else
                {
                    this.Text = "Dodavanje novog događaja";
                    dtpVreme.Value = DateTime.Now;
                }
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
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
            decimal nivoPouzdanosti = 0;
            if (!string.IsNullOrWhiteSpace(txtNivoPouzdanosti.Text) && !decimal.TryParse(txtNivoPouzdanosti.Text, out nivoPouzdanosti))
            {
                MessageBox.Show("Nivo pouzdanosti mora biti broj.");
                return;
            }
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Dogadjaj dogadjaj;
                    bool novo = !_dogadjajId.HasValue;
                    if (!novo)
                        dogadjaj = session.Get<Dogadjaj>(_dogadjajId.Value);
                    else
                        dogadjaj = new Dogadjaj();

                    dogadjaj.RedniBroj = redniBroj;
                    dogadjaj.TipDogadjaja = txtTip.Text;
                    dogadjaj.VremeNastanka = dtpVreme.Value;
                    dogadjaj.OcitanaVrednost = txtOcitanaVrednost.Text;
                    dogadjaj.NivoPouzdanosti = nivoPouzdanosti;
                    dogadjaj.Potvrda = txtPotvrda.Text;
                    dogadjaj.Senzor = (Senzor)cmbSenzor.SelectedItem;

                    if (novo)
                        session.Save(dogadjaj);
                    else
                        session.Update(dogadjaj);

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