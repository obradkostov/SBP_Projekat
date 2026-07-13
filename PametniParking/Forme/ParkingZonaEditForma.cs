using NHibernate;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PametniParking.Forme
{
    public partial class ParkingZonaEditForma : Form
    {
        private readonly int? _zonaId; // null = dodavanje nove, ima vrednost = izmena postojece

        public ParkingZonaEditForma()
        {
            InitializeComponent();
            _zonaId = null;
        }
        public ParkingZonaEditForma(int zonaId)
        {
            InitializeComponent();
            _zonaId = zonaId;
        }
        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtNaziv.Text) || string.IsNullOrWhiteSpace(txtPodrucje.Text) ||
               string.IsNullOrWhiteSpace(txtTarifa.Text) || string.IsNullOrWhiteSpace(txtMaxVreme.Text) ||
               string.IsNullOrWhiteSpace(txtPravila.Text) || cmbTip.SelectedItem == null)
            {
                MessageBox.Show("Sva polja moraju biti popunjena.");
                return;
            }
            try
            {
                using(ISession session = NHibernateHelper.OpenSession())
                    using(ITransaction transaction = session.BeginTransaction())
                {
                    ParkingZona zona;
                    if (_zonaId.HasValue)
                    {
                        zona = session.Get<ParkingZona>(_zonaId.Value);
                    }
                    else
                    {
                        zona = new ParkingZona();
                    }
                    zona.Naziv = txtNaziv.Text;
                    zona.GeografskoPodrucje = txtPodrucje.Text;
                    zona.OsnovnaTarifa = decimal.Parse(txtTarifa.Text);
                    zona.MaxVremeZadrzavanja = int.Parse(txtMaxVreme.Text);
                    zona.PravilaNaplate = txtPravila.Text;
                    zona.TipZone = cmbTip.SelectedItem.ToString();
                    if (!_zonaId.HasValue)
                    {
                        session.Save(zona);
                    }
                    else
                    {
                        session.Update(zona);
                    }
                    transaction.Commit();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska"+ex.Message);
                return;
            }
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ParkingZonaEditForma_Load(object sender, EventArgs e)
        {
            cmbTip.Items.Clear();
            cmbTip.Items.AddRange(new object[] {
                "crvena", "zuta", "zelena", "komercijalna",
                "rezidencijalna", "garazna", "specijalna"
            });
            if (_zonaId.HasValue)
            {
                this.Text = "Izmena zone";
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var zona = session.Get<ParkingZona>(_zonaId.Value);
                    txtNaziv.Text = zona.Naziv;
                    txtPodrucje.Text = zona.GeografskoPodrucje;
                    txtTarifa.Text = zona.OsnovnaTarifa.ToString();
                    txtMaxVreme.Text = zona.MaxVremeZadrzavanja.ToString();
                    txtPravila.Text = zona.PravilaNaplate;
                    cmbTip.SelectedItem = zona.TipZone;
                }
            }
            else
            {
                this.Text = "Dodavanje nove zone";
            }
        }
    }
}
