using NHibernate;
using PametniParking.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PametniParking.Forme
{
    public partial class ParkingMestoEditForma : Form
    {
        private readonly int? _mestoId;

        public ParkingMestoEditForma()
        {
            InitializeComponent();
            _mestoId = null;
        }

        public ParkingMestoEditForma(int mestoId)
        {
            InitializeComponent();
            _mestoId = mestoId;
        }

        private void ParkingMestoEditForma_Load(object sender, EventArgs e)
        {
            cmbTip.Items.Clear();
            cmbTip.Items.AddRange(new object[] {
                "standardna", "rezervisana", "invaliditet", "dostavna_vozila",
                "stanari", "taxi", "punjac_ev"
            });

            using (ISession session = NHibernateHelper.OpenSession())
            {
                var zone = session.Query<ParkingZona>().ToList();
                cmbZona.DataSource = zone;
                cmbZona.DisplayMember = "Naziv";
                cmbZona.ValueMember = "Id";

                if (_mestoId.HasValue)
                {
                    this.Text = "Izmena parking mesta";
                    var mesto = session.Get<ParkingMesto>(_mestoId.Value);
                    txtOznaka.Text = mesto.OznakaMesta;
                    txtLokacija.Text = mesto.GeografakaLokacija;
                    txtStatus.Text = mesto.Status;
                    txtDozDuzina.Text = mesto.DozDuzina.ToString();
                    chkNatkriveno.Checked = mesto.Natkrivenost == 'D' || mesto.Natkrivenost == 'd';
                    txtKameraSenzor.Text = mesto.KameraSenzor;
                    cmbTip.SelectedItem = mesto.TipMesta;
                    cmbZona.SelectedItem = mesto.Zona;

                    if (mesto.TipMesta == "invaliditet")
                    {
                        var mi = session.Query<MestoOsobaSaInvaliditetom>().FirstOrDefault(x => x.ParkingMestoId == mesto.Id);
                        if (mi != null) txtNivoPristupacnosti.Text = mi.NivoPristupacnosti;
                    }
                    else if (mesto.TipMesta == "punjac_ev")
                    {
                        var mp = session.Query<MestoSaPunjacem>().FirstOrDefault(x => x.ParkingMestoId == mesto.Id);
                        if (mp != null)
                        {
                            txtSnagaPunjaca.Text = mp.SnagaPunjaca.ToString();
                            txtTipKonektora.Text = mp.TipKonektora;
                            txtBrojPrikljucaka.Text = mp.BrojPrikljucaka.ToString();
                            txtRezimiPunjenja.Text = mp.RezimiPunjenja;
                        }
                    }
                }
                else
                {
                    this.Text = "Dodavanje novog parking mesta";
                }
            }

            PrikaziPolja();
        }

        private void cmbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrikaziPolja();
        }

        private void PrikaziPolja()
        {
            string tip = cmbTip.SelectedItem?.ToString();
            pnlInvaliditet.Visible = tip == "invaliditet";
            pnlPunjac.Visible = tip == "punjac_ev";
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOznaka.Text) || cmbTip.SelectedItem == null || cmbZona.SelectedItem == null)
            {
                MessageBox.Show("Oznaka mesta, tip mesta i zona su obavezni.");
                return;
            }
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    ParkingMesto mesto;
                    bool novo = !_mestoId.HasValue;
                    if (!novo)
                        mesto = session.Get<ParkingMesto>(_mestoId.Value);
                    else
                        mesto = new ParkingMesto();

                    mesto.OznakaMesta = txtOznaka.Text;
                    mesto.GeografakaLokacija = txtLokacija.Text;
                    mesto.Status = txtStatus.Text;
                    mesto.DozDuzina = string.IsNullOrWhiteSpace(txtDozDuzina.Text) ? 0 : decimal.Parse(txtDozDuzina.Text);
                    mesto.Natkrivenost = chkNatkriveno.Checked ? 'D' : 'N';
                    mesto.KameraSenzor = txtKameraSenzor.Text;
                    mesto.TipMesta = cmbTip.SelectedItem.ToString();
                    mesto.Zona = (ParkingZona)cmbZona.SelectedItem;

                    if (novo)
                        session.Save(mesto);
                    else
                        session.Update(mesto);

                    if (mesto.TipMesta == "invaliditet")
                    {
                        var mi = session.Query<MestoOsobaSaInvaliditetom>().FirstOrDefault(x => x.ParkingMestoId == mesto.Id);
                        if (mi == null)
                            mi = new MestoOsobaSaInvaliditetom { ParkingMesto = mesto };
                        mi.NivoPristupacnosti = txtNivoPristupacnosti.Text;
                        session.SaveOrUpdate(mi);
                    }
                    else if (mesto.TipMesta == "punjac_ev")
                    {
                        var mp = session.Query<MestoSaPunjacem>().FirstOrDefault(x => x.ParkingMestoId == mesto.Id);
                        if (mp == null)
                            mp = new MestoSaPunjacem { ParkingMesto = mesto };
                        mp.SnagaPunjaca = string.IsNullOrWhiteSpace(txtSnagaPunjaca.Text) ? 0 : decimal.Parse(txtSnagaPunjaca.Text);
                        mp.TipKonektora = txtTipKonektora.Text;
                        mp.BrojPrikljucaka = string.IsNullOrWhiteSpace(txtBrojPrikljucaka.Text) ? 0 : int.Parse(txtBrojPrikljucaka.Text);
                        mp.RezimiPunjenja = txtRezimiPunjenja.Text;
                        session.SaveOrUpdate(mp);
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
