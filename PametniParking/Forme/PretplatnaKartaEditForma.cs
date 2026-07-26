using NHibernate;
using PametniParking.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PametniParking.Forme
{
    public partial class PretplatnaKartaEditForma : Form
    {
        private readonly int? _kartaId;

        public PretplatnaKartaEditForma()
        {
            InitializeComponent();
            _kartaId = null;
        }

        public PretplatnaKartaEditForma(int kartaId)
        {
            InitializeComponent();
            _kartaId = kartaId;
        }

        private void PretplatnaKartaEditForma_Load(object sender, EventArgs e)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var korisnici = session.Query<Korisnik>().ToList();
                cmbKorisnik.DataSource = korisnici;
                cmbKorisnik.DisplayMember = "Email";
                cmbKorisnik.ValueMember = "Id";

                var zone = session.Query<ParkingZona>().ToList();
                clbZone.Items.Clear();
                foreach (var zona in zone)
                    clbZone.Items.Add(zona);
                clbZone.DisplayMember = "Naziv";

                if (_kartaId.HasValue)
                {
                    this.Text = "Izmena pretplatne karte";
                    var karta = session.Get<PretplatnaKarta>(_kartaId.Value);
                    txtTipPretplate.Text = karta.TipPretplate;
                    dtpPocetak.Value = karta.PocetakVazenja;
                    dtpKraj.Value = karta.KrajVazenja;
                    txtCena.Text = karta.Cena.ToString();
                    txtMaksBrVozila.Text = karta.MaksBrVozila.ToString();
                    cmbKorisnik.SelectedItem = karta.Korisnik;

                    var izabraneZoneIds = session.Query<PretplatnaKartaZona>()
                        .Where(z => z.Karta.Id == karta.Id)
                        .Select(z => z.Zona.Id)
                        .ToList();

                    for (int i = 0; i < clbZone.Items.Count; i++)
                    {
                        var zona = (ParkingZona)clbZone.Items[i];
                        if (izabraneZoneIds.Contains(zona.Id))
                            clbZone.SetItemChecked(i, true);
                    }
                }
                else
                {
                    this.Text = "Dodavanje nove pretplatne karte";
                    dtpPocetak.Value = DateTime.Now;
                    dtpKraj.Value = DateTime.Now.AddMonths(6);
                }
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
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
            decimal cena = 0;
            if (!string.IsNullOrWhiteSpace(txtCena.Text) && !decimal.TryParse(txtCena.Text, out cena))
            {
                MessageBox.Show("Cena mora biti broj.");
                return;
            }
            int maksBrVozila = 1;
            if (!string.IsNullOrWhiteSpace(txtMaksBrVozila.Text) && !int.TryParse(txtMaksBrVozila.Text, out maksBrVozila))
            {
                MessageBox.Show("Maksimalan broj vozila mora biti ceo broj.");
                return;
            }

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    PretplatnaKarta karta;
                    bool novo = !_kartaId.HasValue;
                    if (!novo)
                        karta = session.Get<PretplatnaKarta>(_kartaId.Value);
                    else
                        karta = new PretplatnaKarta();

                    karta.TipPretplate = txtTipPretplate.Text;
                    karta.PocetakVazenja = dtpPocetak.Value;
                    karta.KrajVazenja = dtpKraj.Value;
                    karta.Cena = cena;
                    karta.MaksBrVozila = maksBrVozila;
                    karta.Korisnik = (Korisnik)cmbKorisnik.SelectedItem;

                    if (novo)
                        session.Save(karta);
                    else
                        session.Update(karta);

                    // Obrisati postojece veze karta-zona pa ponovo dodati po trenutnom izboru
                    var postojece = session.Query<PretplatnaKartaZona>().Where(z => z.Karta.Id == karta.Id).ToList();
                    foreach (var stara in postojece)
                        session.Delete(stara);

                    foreach (var stavka in clbZone.CheckedItems)
                    {
                        var zona = (ParkingZona)stavka;
                        var veza = new PretplatnaKartaZona { Karta = karta, Zona = zona };
                        session.Save(veza);
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
