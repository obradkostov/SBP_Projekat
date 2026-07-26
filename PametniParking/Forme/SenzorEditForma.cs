using NHibernate;
using PametniParking.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PametniParking.Forme
{
    public partial class SenzorEditForma : Form
    {
        private readonly int? _senzorId;

        public SenzorEditForma()
        {
            InitializeComponent();
            _senzorId = null;
        }

        public SenzorEditForma(int senzorId)
        {
            InitializeComponent();
            _senzorId = senzorId;
        }

        private void SenzorEditForma_Load(object sender, EventArgs e)
        {
            cmbTip.Items.Clear();
            cmbTip.Items.AddRange(new object[] { "magnetni", "ultrazvucni", "opticki", "video", "kombinovani" });

            using (ISession session = NHibernateHelper.OpenSession())
            {
                var mesta = session.Query<ParkingMesto>().ToList();
                cmbMesto.DataSource = mesta;
                cmbMesto.DisplayMember = "OznakaMesta";
                cmbMesto.ValueMember = "Id";

                if (_senzorId.HasValue)
                {
                    this.Text = "Izmena senzora";
                    var senzor = session.Get<Senzor>(_senzorId.Value);
                    txtProizvodjac.Text = senzor.Proizvodjac;
                    txtModel.Text = senzor.Model;
                    txtSerijskiBroj.Text = senzor.SerijskiBroj;
                    dtpDatum.Value = senzor.DatumInstalacije;
                    txtStatus.Text = senzor.Status;
                    cmbTip.SelectedItem = senzor.TipSenzora;
                    cmbMesto.SelectedItem = senzor.ParkingMesto;

                    var video = session.Query<VideoSenzor>().FirstOrDefault(v => v.SenzorId == senzor.Id);
                    if (video != null)
                    {
                        txtRezolucija.Text = video.Rezolucija;
                        txtUgao.Text = video.UgaoPokrivanja.ToString();
                        chkPrepoznavanje.Checked = video.PrepRegOznaka == 'D' || video.PrepRegOznaka == 'd';
                    }
                }
                else
                {
                    this.Text = "Dodavanje novog senzora";
                    dtpDatum.Value = DateTime.Now;
                }
            }

            PrikaziVideoPolja();
        }

        private void cmbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrikaziVideoPolja();
        }

        private void PrikaziVideoPolja()
        {
            bool jeVideo = cmbTip.SelectedItem != null && cmbTip.SelectedItem.ToString() == "video";
            pnlVideo.Visible = jeVideo;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSerijskiBroj.Text) || cmbTip.SelectedItem == null || cmbMesto.SelectedItem == null)
            {
                MessageBox.Show("Serijski broj, tip senzora i parking mesto su obavezni.");
                return;
            }
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Senzor senzor;
                    bool novo = !_senzorId.HasValue;
                    if (!novo)
                        senzor = session.Get<Senzor>(_senzorId.Value);
                    else
                        senzor = new Senzor();

                    senzor.Proizvodjac = txtProizvodjac.Text;
                    senzor.Model = txtModel.Text;
                    senzor.SerijskiBroj = txtSerijskiBroj.Text;
                    senzor.DatumInstalacije = dtpDatum.Value;
                    senzor.Status = txtStatus.Text;
                    senzor.TipSenzora = cmbTip.SelectedItem.ToString();
                    senzor.ParkingMesto = (ParkingMesto)cmbMesto.SelectedItem;

                    if (novo)
                        session.Save(senzor);
                    else
                        session.Update(senzor);

                    if (senzor.TipSenzora == "video")
                    {
                        var video = session.Query<VideoSenzor>().FirstOrDefault(v => v.SenzorId == senzor.Id);
                        if (video == null)
                        {
                            video = new VideoSenzor { Senzor = senzor };
                        }
                        video.Rezolucija = txtRezolucija.Text;
                        video.UgaoPokrivanja = string.IsNullOrWhiteSpace(txtUgao.Text) ? 0 : decimal.Parse(txtUgao.Text);
                        video.PrepRegOznaka = chkPrepoznavanje.Checked ? 'D' : 'N';
                        session.SaveOrUpdate(video);
                    }

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
