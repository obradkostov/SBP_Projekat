using NHibernate;

namespace PametniParkingLibrary;

public static class DTOManager
{
    #region ParkingZona

    public static Result<List<ParkingZonaView>, string> VratiSveZone()
    {
        ISession? s = null;
        List<ParkingZonaView> zone = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<ParkingZona> sveZone = from z in s.Query<ParkingZona>() select z;

            foreach (ParkingZona z in sveZone)
            {
                zone.Add(new ParkingZonaView(z));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve zone.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return zone;
    }

    public static async Task<Result<ParkingZonaView, string>> VratiZonuAsync(int id)
    {
        ISession? s = null;
        ParkingZonaView zonaView = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ParkingZona z = await s.LoadAsync<ParkingZona>(id);
            zonaView = new ParkingZonaView(z);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti zonu sa zadatim id-em.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return zonaView;
    }

    public static async Task<Result<bool, string>> DodajZonuAsync(ParkingZonaView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ParkingZona z = new()
            {
                Naziv = p.Naziv,
                GeografskoPodrucje = p.GeografskoPodrucje,
                TipZone = p.TipZone,
                OsnovnaTarifa = p.OsnovnaTarifa,
                MaxVremeZadrzavanja = p.MaxVremeZadrzavanja,
                PravilaNaplate = p.PravilaNaplate
            };

            await s.SaveOrUpdateAsync(z);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati zonu.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    public static async Task<Result<ParkingZonaView, string>> AzurirajZonuAsync(ParkingZonaView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ParkingZona z = s.Load<ParkingZona>(p.Id);
            z.Naziv = p.Naziv;
            z.GeografskoPodrucje = p.GeografskoPodrucje;
            z.TipZone = p.TipZone;
            z.OsnovnaTarifa = p.OsnovnaTarifa;
            z.MaxVremeZadrzavanja = p.MaxVremeZadrzavanja;
            z.PravilaNaplate = p.PravilaNaplate;

            await s.UpdateAsync(z);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati zonu.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return p;
    }

    public static async Task<Result<bool, string>> ObrisiZonuAsync(int id)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ParkingZona z = await s.LoadAsync<ParkingZona>(id);

            await s.DeleteAsync(z);
            await s.FlushAsync();
        }
        catch (Exception e)
        {
            return ErrorHandler.HandleError(e);
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    #endregion
    #region Vozilo

    public static Result<List<VoziloView>, string> VratiSvaVozila()
    {
        ISession? s = null;
        List<VoziloView> vozila = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<Vozilo> svaVozila = from v in s.Query<Vozilo>() select v;

            foreach (Vozilo v in svaVozila)
            {
                vozila.Add(new VoziloView(v));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sva vozila.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return vozila;
    }

    public static async Task<Result<VoziloView, string>> VratiVoziloAsync(string registarskaOznaka)
    {
        ISession? s = null;
        VoziloView voziloView = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Vozilo v = await s.LoadAsync<Vozilo>(registarskaOznaka);
            voziloView = new VoziloView(v);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti vozilo sa zadatom oznakom.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return voziloView;
    }

    public static async Task<Result<bool, string>> DodajVoziloAsync(VoziloView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Korisnik? korisnik = null;
            if (p.KorisnikId.HasValue)
            {
                korisnik = await s.LoadAsync<Korisnik>(p.KorisnikId.Value);
            }

            Vozilo v = new()
            {
                RegistarskaOznaka = p.RegistarskaOznaka,
                DrzavaRegistracije = p.DrzavaRegistracije,
                Marka = p.Marka,
                Model = p.Model,
                TipVozila = p.TipVozila,
                Dimenzije = p.Dimenzije,
                Pogon = p.Pogon,
                Korisnik = korisnik
            };

            await s.SaveOrUpdateAsync(v);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati vozilo.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    public static async Task<Result<VoziloView, string>> AzurirajVoziloAsync(VoziloView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Vozilo v = s.Load<Vozilo>(p.RegistarskaOznaka);
            v.DrzavaRegistracije = p.DrzavaRegistracije;
            v.Marka = p.Marka;
            v.Model = p.Model;
            v.TipVozila = p.TipVozila;
            v.Dimenzije = p.Dimenzije;
            v.Pogon = p.Pogon;

            if (p.KorisnikId.HasValue)
            {
                v.Korisnik = await s.LoadAsync<Korisnik>(p.KorisnikId.Value);
            }
            else
            {
                v.Korisnik = null;
            }

            await s.UpdateAsync(v);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati vozilo.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return p;
    }

    public static async Task<Result<bool, string>> ObrisiVoziloAsync(string registarskaOznaka)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Vozilo v = await s.LoadAsync<Vozilo>(registarskaOznaka);

            await s.DeleteAsync(v);
            await s.FlushAsync();
        }
        catch (Exception e)
        {
            return ErrorHandler.HandleError(e);
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    #endregion
    #region Korisnik

    public static Result<List<KorisnikView>, string> VratiSveKorisnike()
    {
        ISession? s = null;
        List<KorisnikView> korisnici = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<Korisnik> sviKorisnici = from k in s.Query<Korisnik>() select k;

            foreach (Korisnik k in sviKorisnici)
            {
                korisnici.Add(new KorisnikView(k));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve korisnike.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return korisnici;
    }

    public static async Task<Result<KorisnikView, string>> VratiKorisnikaAsync(int id)
    {
        ISession? s = null;
        KorisnikView korisnikView = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Korisnik k = await s.LoadAsync<Korisnik>(id);
            korisnikView = new KorisnikView(k);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti korisnika sa zadatim id-em.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return korisnikView;
    }

    public static async Task<Result<bool, string>> DodajFizickoLiceAsync(KorisnikView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            FizickoLice fl = new()
            {
                Email = p.Email,
                Adresa = p.Adresa,
                StatusNaloga = p.StatusNaloga,
                Ime = p.Ime,
                Prezime = p.Prezime,
                Jmbg = p.Jmbg
            };

            await s.SaveOrUpdateAsync(fl);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati fizičko lice.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    public static async Task<Result<bool, string>> DodajPravnoLiceAsync(KorisnikView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            PravnoLice pl = new()
            {
                Email = p.Email,
                Adresa = p.Adresa,
                StatusNaloga = p.StatusNaloga,
                Naziv = p.Naziv,
                Pib = p.Pib,
                MaticniBroj = p.MaticniBroj,
                KontaktOsoba = p.KontaktOsoba,
                Sediste = p.Sediste
            };

            await s.SaveOrUpdateAsync(pl);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati pravno lice.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    public static async Task<Result<KorisnikView, string>> AzurirajKorisnikaAsync(KorisnikView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Korisnik k = await s.GetAsync<Korisnik>(p.Id);
            k.Email = p.Email;
            k.Adresa = p.Adresa;
            k.StatusNaloga = p.StatusNaloga;

            if (k is FizickoLice fl)
            {
                fl.Ime = p.Ime;
                fl.Prezime = p.Prezime;
                fl.Jmbg = p.Jmbg;
            }
            else if (k is PravnoLice pl)
            {
                pl.Naziv = p.Naziv;
                pl.Pib = p.Pib;
                pl.MaticniBroj = p.MaticniBroj;
                pl.KontaktOsoba = p.KontaktOsoba;
                pl.Sediste = p.Sediste;
            }

            await s.UpdateAsync(k);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati korisnika.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return p;
    }

    public static async Task<Result<bool, string>> ObrisiKorisnikaAsync(int id)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Korisnik k = await s.LoadAsync<Korisnik>(id);

            await s.DeleteAsync(k);
            await s.FlushAsync();
        }
        catch (Exception e)
        {
            return ErrorHandler.HandleError(e);
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    #endregion
    #region Telefon

    public static Result<List<TelefonView>, string> VratiSveTelefone()
    {
        ISession? s = null;
        List<TelefonView> telefoni = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<Telefon> sviTelefoni = from t in s.Query<Telefon>() select t;

            foreach (Telefon t in sviTelefoni)
            {
                telefoni.Add(new TelefonView(t));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve telefone.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return telefoni;
    }

    public static async Task<Result<TelefonView, string>> VratiTelefonAsync(int id)
    {
        ISession? s = null;
        TelefonView telefonView = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Telefon t = await s.LoadAsync<Telefon>(id);
            telefonView = new TelefonView(t);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti telefon sa zadatim id-em.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return telefonView;
    }

    public static async Task<Result<bool, string>> DodajTelefonAsync(TelefonView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Korisnik korisnik = await s.LoadAsync<Korisnik>(p.KorisnikId);

            Telefon t = new()
            {
                BrojTelefona = p.BrojTelefona,
                Korisnik = korisnik
            };

            await s.SaveOrUpdateAsync(t);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati telefon.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    public static async Task<Result<TelefonView, string>> AzurirajTelefonAsync(TelefonView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Telefon t = await s.GetAsync<Telefon>(p.Id);
            t.BrojTelefona = p.BrojTelefona;
            t.Korisnik = await s.LoadAsync<Korisnik>(p.KorisnikId);

            await s.UpdateAsync(t);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati telefon.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return p;
    }

    public static async Task<Result<bool, string>> ObrisiTelefonAsync(int id)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Telefon t = await s.LoadAsync<Telefon>(id);

            await s.DeleteAsync(t);
            await s.FlushAsync();
        }
        catch (Exception e)
        {
            return ErrorHandler.HandleError(e);
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    #endregion
    #region ParkingMesto

    public static Result<List<ParkingMestoView>, string> VratiSvaPM()
    {
        ISession? s = null;
        List<ParkingMestoView> mesta = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<ParkingMesto> svaMesta = from m in s.Query<ParkingMesto>() select m;

            foreach (ParkingMesto m in svaMesta)
            {
                ParkingMestoView view = new(m);
                PopuniDodatneAtributePM(s, m, view);
                mesta.Add(view);
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sva parking mesta.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return mesta;
    }

    public static async Task<Result<ParkingMestoView, string>> VratiPMAsync(int id)
    {
        ISession? s = null;
        ParkingMestoView mestoView = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ParkingMesto m = await s.LoadAsync<ParkingMesto>(id);
            mestoView = new ParkingMestoView(m);
            PopuniDodatneAtributePM(s, m, mestoView);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti parking mesto sa zadatim id-em.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return mestoView;
    }

    // Pomocna funkcija - ucitava dodatne atribute (invaliditet ili punjac) unutar iste sesije
    private static void PopuniDodatneAtributePM(ISession s, ParkingMesto m, ParkingMestoView view)
    {
        if (m.TipMesta == "invaliditet")
        {
            MestoOsobaSaInvaliditetom? prosireno = s.Query<MestoOsobaSaInvaliditetom>()
                .FirstOrDefault(x => x.ParkingMesto!.Id == m.Id);
            if (prosireno != null)
            {
                view.NivoPristupacnosti = prosireno.NivoPristupacnosti;
            }
        }
        else if (m.TipMesta == "punjac_ev")
        {
            MestoSaPunjacem? prosireno = s.Query<MestoSaPunjacem>()
                .FirstOrDefault(x => x.ParkingMesto!.Id == m.Id);
            if (prosireno != null)
            {
                view.SnagaPunjaca = prosireno.SnagaPunjaca;
                view.TipKonektora = prosireno.TipKonektora;
                view.BrojPrikljucaka = prosireno.BrojPrikljucaka;
                view.RezimiPunjenja = prosireno.RezimiPunjenja;
            }
        }
    }

    // Dodaje mesto bez dodatnih atributa (standardna, rezervisana, stanari, dostavna_vozila, taxi)
    public static async Task<Result<bool, string>> DodajPMAsync(ParkingMestoView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ParkingZona zona = await s.LoadAsync<ParkingZona>(p.ZonaId);

            ParkingMesto m = new()
            {
                OznakaMesta = p.OznakaMesta,
                GeografskaLokacija = p.GeografskaLokacija,
                Status = p.Status,
                TipMesta = p.TipMesta,
                DozDuzina = p.DozDuzina,
                Natkrivenost = p.Natkrivenost,
                KameraSenzor = p.KameraSenzor,
                Zona = zona
            };

            await s.SaveOrUpdateAsync(m);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati parking mesto.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    // Dodaje mesto sa invaliditet atributima
    public static async Task<Result<bool, string>> DodajPMInvaliditetAsync(ParkingMestoView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ParkingZona zona = await s.LoadAsync<ParkingZona>(p.ZonaId);

            ParkingMesto m = new()
            {
                OznakaMesta = p.OznakaMesta,
                GeografskaLokacija = p.GeografskaLokacija,
                Status = p.Status,
                TipMesta = "invaliditet",
                DozDuzina = p.DozDuzina,
                Natkrivenost = p.Natkrivenost,
                KameraSenzor = p.KameraSenzor,
                Zona = zona
            };

            await s.SaveOrUpdateAsync(m);

            MestoOsobaSaInvaliditetom prosireno = new()
            {
                ParkingMesto = m,
                NivoPristupacnosti = p.NivoPristupacnosti
            };

            await s.SaveOrUpdateAsync(prosireno);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati parking mesto za osobe sa invaliditetom.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    // Dodaje mesto sa punjacem za EV
    public static async Task<Result<bool, string>> DodajPMPunjacAsync(ParkingMestoView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ParkingZona zona = await s.LoadAsync<ParkingZona>(p.ZonaId);

            ParkingMesto m = new()
            {
                OznakaMesta = p.OznakaMesta,
                GeografskaLokacija = p.GeografskaLokacija,
                Status = p.Status,
                TipMesta = "punjac_ev",
                DozDuzina = p.DozDuzina,
                Natkrivenost = p.Natkrivenost,
                KameraSenzor = p.KameraSenzor,
                Zona = zona
            };

            await s.SaveOrUpdateAsync(m);

            MestoSaPunjacem prosireno = new()
            {
                ParkingMesto = m,
                SnagaPunjaca = p.SnagaPunjaca ?? 0,
                TipKonektora = p.TipKonektora,
                BrojPrikljucaka = p.BrojPrikljucaka ?? 0,
                RezimiPunjenja = p.RezimiPunjenja
            };

            await s.SaveOrUpdateAsync(prosireno);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati parking mesto sa punjačem.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    public static async Task<Result<ParkingMestoView, string>> AzurirajPMAsync(ParkingMestoView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ParkingMesto m = s.Load<ParkingMesto>(p.Id);
            m.OznakaMesta = p.OznakaMesta;
            m.GeografskaLokacija = p.GeografskaLokacija;
            m.Status = p.Status;
            m.TipMesta = p.TipMesta;
            m.DozDuzina = p.DozDuzina;
            m.Natkrivenost = p.Natkrivenost;
            m.KameraSenzor = p.KameraSenzor;
            m.Zona = await s.LoadAsync<ParkingZona>(p.ZonaId);

            await s.UpdateAsync(m);

            if (m.TipMesta == "invaliditet")
            {
                MestoOsobaSaInvaliditetom? prosireno = s.Query<MestoOsobaSaInvaliditetom>()
                    .FirstOrDefault(x => x.ParkingMesto!.Id == m.Id);
                if (prosireno != null)
                {
                    prosireno.NivoPristupacnosti = p.NivoPristupacnosti;
                    await s.UpdateAsync(prosireno);
                }
            }
            else if (m.TipMesta == "punjac_ev")
            {
                MestoSaPunjacem? prosireno = s.Query<MestoSaPunjacem>()
                    .FirstOrDefault(x => x.ParkingMesto!.Id == m.Id);
                if (prosireno != null)
                {
                    prosireno.SnagaPunjaca = p.SnagaPunjaca ?? prosireno.SnagaPunjaca;
                    prosireno.TipKonektora = p.TipKonektora;
                    prosireno.BrojPrikljucaka = p.BrojPrikljucaka ?? prosireno.BrojPrikljucaka;
                    prosireno.RezimiPunjenja = p.RezimiPunjenja;
                    await s.UpdateAsync(prosireno);
                }
            }

            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati parking mesto.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return p;
    }

    public static async Task<Result<bool, string>> ObrisiPMAsync(int id)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            MestoOsobaSaInvaliditetom? invaliditet = s.Query<MestoOsobaSaInvaliditetom>()
                .FirstOrDefault(x => x.ParkingMesto!.Id == id);
            if (invaliditet != null)
            {
                await s.DeleteAsync(invaliditet);
            }

            MestoSaPunjacem? punjac = s.Query<MestoSaPunjacem>()
                .FirstOrDefault(x => x.ParkingMesto!.Id == id);
            if (punjac != null)
            {
                await s.DeleteAsync(punjac);
            }

            await s.FlushAsync();

            ParkingMesto m = await s.LoadAsync<ParkingMesto>(id);
            await s.DeleteAsync(m);
            await s.FlushAsync();
        }
        catch (Exception e)
        {
            return ErrorHandler.HandleError(e);
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    #endregion
    #region Senzor

    public static Result<List<SenzorView>, string> VratiSveSenzore()
    {
        ISession? s = null;
        List<SenzorView> senzori = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<Senzor> sviSenzori = from sz in s.Query<Senzor>() select sz;

            foreach (Senzor sz in sviSenzori)
            {
                SenzorView view = new(sz);
                PopuniDodatneAtributeSenzor(s, sz, view);
                senzori.Add(view);
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve senzore.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return senzori;
    }

    public static async Task<Result<SenzorView, string>> VratiSenzorAsync(int id)
    {
        ISession? s = null;
        SenzorView senzorView = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Senzor sz = await s.LoadAsync<Senzor>(id);
            senzorView = new SenzorView(sz);
            PopuniDodatneAtributeSenzor(s, sz, senzorView);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti senzor sa zadatim id-em.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return senzorView;
    }

    private static void PopuniDodatneAtributeSenzor(ISession s, Senzor sz, SenzorView view)
    {
        if (sz.TipSenzora == "video")
        {
            VideoSenzor? prosireno = s.Query<VideoSenzor>()
                .FirstOrDefault(x => x.Senzor!.Id == sz.Id);
            if (prosireno != null)
            {
                view.Rezolucija = prosireno.Rezolucija;
                view.UgaoPokrivanja = prosireno.UgaoPokrivanja;
                view.PrepRegOznaka = prosireno.PrepRegOznaka;
            }
        }
    }

    // Dodaje senzor bez dodatnih atributa (magnetni, ultrazvucni, opticki, kombinovani)
    public static async Task<Result<bool, string>> DodajSenzorAsync(SenzorView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ParkingMesto mesto = await s.LoadAsync<ParkingMesto>(p.ParkingMestoId);

            Senzor sz = new()
            {
                Proizvodjac = p.Proizvodjac,
                Model = p.Model,
                SerijskiBroj = p.SerijskiBroj,
                DatumInstalacije = p.DatumInstalacije,
                Status = p.Status,
                TipSenzora = p.TipSenzora,
                ParkingMesto = mesto
            };

            await s.SaveOrUpdateAsync(sz);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati senzor.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    // Dodaje video senzor (sa dodatnim atributima)
    public static async Task<Result<bool, string>> DodajVideoSenzorAsync(SenzorView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ParkingMesto mesto = await s.LoadAsync<ParkingMesto>(p.ParkingMestoId);

            Senzor sz = new()
            {
                Proizvodjac = p.Proizvodjac,
                Model = p.Model,
                SerijskiBroj = p.SerijskiBroj,
                DatumInstalacije = p.DatumInstalacije,
                Status = p.Status,
                TipSenzora = "video",
                ParkingMesto = mesto
            };

            await s.SaveOrUpdateAsync(sz);

            VideoSenzor prosireno = new()
            {
                Senzor = sz,
                Rezolucija = p.Rezolucija,
                UgaoPokrivanja = p.UgaoPokrivanja ?? 0,
                PrepRegOznaka = p.PrepRegOznaka ?? 'N'
            };

            await s.SaveOrUpdateAsync(prosireno);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati video senzor.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    public static async Task<Result<SenzorView, string>> AzurirajSenzorAsync(SenzorView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Senzor sz = s.Load<Senzor>(p.Id);
            sz.Proizvodjac = p.Proizvodjac;
            sz.Model = p.Model;
            sz.SerijskiBroj = p.SerijskiBroj;
            sz.DatumInstalacije = p.DatumInstalacije;
            sz.Status = p.Status;
            sz.TipSenzora = p.TipSenzora;
            sz.ParkingMesto = await s.LoadAsync<ParkingMesto>(p.ParkingMestoId);

            await s.UpdateAsync(sz);

            if (sz.TipSenzora == "video")
            {
                VideoSenzor? prosireno = s.Query<VideoSenzor>()
                    .FirstOrDefault(x => x.Senzor!.Id == sz.Id);
                if (prosireno != null)
                {
                    prosireno.Rezolucija = p.Rezolucija;
                    prosireno.UgaoPokrivanja = p.UgaoPokrivanja ?? prosireno.UgaoPokrivanja;
                    prosireno.PrepRegOznaka = p.PrepRegOznaka ?? prosireno.PrepRegOznaka;
                    await s.UpdateAsync(prosireno);
                }
            }

            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati senzor.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return p;
    }

    public static async Task<Result<bool, string>> ObrisiSenzorAsync(int id)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Senzor sz = await s.LoadAsync<Senzor>(id);

            await s.DeleteAsync(sz);
            await s.FlushAsync();
        }
        catch (Exception e)
        {
            return ErrorHandler.HandleError(e);
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    #endregion
    #region Dogadjaj

    public static Result<List<DogadjajView>, string> VratiSveDogadjaje()
    {
        ISession? s = null;
        List<DogadjajView> dogadjaji = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<Dogadjaj> sviDogadjaji = from d in s.Query<Dogadjaj>() select d;

            foreach (Dogadjaj d in sviDogadjaji)
            {
                dogadjaji.Add(new DogadjajView(d));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve događaje.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return dogadjaji;
    }

    public static async Task<Result<DogadjajView, string>> VratiDogadjajAsync(int id)
    {
        ISession? s = null;
        DogadjajView dogadjajView = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Dogadjaj d = await s.LoadAsync<Dogadjaj>(id);
            dogadjajView = new DogadjajView(d);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti događaj sa zadatim id-em.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return dogadjajView;
    }

    public static async Task<Result<bool, string>> DodajDogadjajAsync(DogadjajView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Senzor senzor = await s.LoadAsync<Senzor>(p.SenzorId);

            Dogadjaj d = new()
            {
                RedniBroj = p.RedniBroj,
                TipDogadjaja = p.TipDogadjaja,
                VremeNastanka = p.VremeNastanka,
                OcitanaVrednost = p.OcitanaVrednost,
                NivoPouzdanosti = p.NivoPouzdanosti,
                Potvrda = p.Potvrda,
                Senzor = senzor
            };

            await s.SaveOrUpdateAsync(d);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati događaj.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    public static async Task<Result<DogadjajView, string>> AzurirajDogadjajAsync(DogadjajView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Dogadjaj d = s.Load<Dogadjaj>(p.Id);
            d.RedniBroj = p.RedniBroj;
            d.TipDogadjaja = p.TipDogadjaja;
            d.VremeNastanka = p.VremeNastanka;
            d.OcitanaVrednost = p.OcitanaVrednost;
            d.NivoPouzdanosti = p.NivoPouzdanosti;
            d.Potvrda = p.Potvrda;
            d.Senzor = await s.LoadAsync<Senzor>(p.SenzorId);

            await s.UpdateAsync(d);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati događaj.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return p;
    }

    public static async Task<Result<bool, string>> ObrisiDogadjajAsync(int id)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Dogadjaj d = await s.LoadAsync<Dogadjaj>(id);

            await s.DeleteAsync(d);
            await s.FlushAsync();
        }
        catch (Exception e)
        {
            return ErrorHandler.HandleError(e);
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    #endregion
    #region Parkiranje

    public static Result<List<ParkiranjeView>, string> VratiSvaParkiranja()
    {
        ISession? s = null;
        List<ParkiranjeView> parkiranja = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<Parkiranje> svaParkiranja = from pk in s.Query<Parkiranje>() select pk;

            foreach (Parkiranje pk in svaParkiranja)
            {
                parkiranja.Add(new ParkiranjeView(pk));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sva parkiranja.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return parkiranja;
    }

    public static async Task<Result<ParkiranjeView, string>> VratiParkiranjeAsync(int id)
    {
        ISession? s = null;
        ParkiranjeView parkiranjeView = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Parkiranje pk = await s.LoadAsync<Parkiranje>(id);
            parkiranjeView = new ParkiranjeView(pk);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti parkiranje sa zadatim id-em.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return parkiranjeView;
    }

    public static async Task<Result<bool, string>> DodajParkiranjeAsync(ParkiranjeView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Vozilo vozilo = await s.LoadAsync<Vozilo>(p.VoziloOznaka);
            ParkingMesto mesto = await s.LoadAsync<ParkingMesto>(p.ParkingMestoId);
            ParkingZona zona = await s.LoadAsync<ParkingZona>(p.ZonaId);

            PretplatnaKarta? karta = null;
            if (p.KartaId.HasValue)
            {
                karta = await s.LoadAsync<PretplatnaKarta>(p.KartaId.Value);
            }

            Parkiranje pk = new()
            {
                DatumVremePocetka = p.DatumVremePocetka,
                ObracunatiIznos = p.ObracunatiIznos,
                Vozilo = vozilo,
                ParkingMesto = mesto,
                Zona = zona,
                Karta = karta
            };

            await s.SaveOrUpdateAsync(pk);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati parkiranje.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    public static async Task<Result<ParkiranjeView, string>> AzurirajParkiranjeAsync(ParkiranjeView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Parkiranje pk = s.Load<Parkiranje>(p.Id);
            pk.DatumVremePocetka = p.DatumVremePocetka;
            pk.ObracunatiIznos = p.ObracunatiIznos;
            pk.Vozilo = await s.LoadAsync<Vozilo>(p.VoziloOznaka);
            pk.ParkingMesto = await s.LoadAsync<ParkingMesto>(p.ParkingMestoId);
            pk.Zona = await s.LoadAsync<ParkingZona>(p.ZonaId);
            pk.Karta = p.KartaId.HasValue ? await s.LoadAsync<PretplatnaKarta>(p.KartaId.Value) : null;

            await s.UpdateAsync(pk);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati parkiranje.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return p;
    }

    public static async Task<Result<bool, string>> ObrisiParkiranjeAsync(int id)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Parkiranje pk = await s.LoadAsync<Parkiranje>(id);

            await s.DeleteAsync(pk);
            await s.FlushAsync();
        }
        catch (Exception e)
        {
            return ErrorHandler.HandleError(e);
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    #endregion
    #region PretplatnaKarta

    public static Result<List<PretplatnaKartaView>, string> VratiSveKarte()
    {
        ISession? s = null;
        List<PretplatnaKartaView> karte = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<PretplatnaKarta> sveKarte = from k in s.Query<PretplatnaKarta>() select k;

            foreach (PretplatnaKarta k in sveKarte)
            {
                karte.Add(new PretplatnaKartaView(k));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve pretplatne karte.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return karte;
    }

    public static async Task<Result<PretplatnaKartaView, string>> VratiKartuAsync(int id)
    {
        ISession? s = null;
        PretplatnaKartaView kartaView = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            PretplatnaKarta k = await s.LoadAsync<PretplatnaKarta>(id);
            kartaView = new PretplatnaKartaView(k);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti pretplatnu kartu sa zadatim id-em.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return kartaView;
    }

    public static async Task<Result<bool, string>> DodajKartuAsync(PretplatnaKartaView p)
    {
        ISession? s = null;

        if (p.ZoneId == null || p.ZoneId.Count == 0)
        {
            return "Potrebno je izabrati bar jednu zonu.";
        }

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Korisnik korisnik = await s.LoadAsync<Korisnik>(p.KorisnikId);

            PretplatnaKarta k = new()
            {
                TipPretplate = p.TipPretplate,
                PocetakVazenja = p.PocetakVazenja,
                KrajVazenja = p.KrajVazenja,
                Cena = p.Cena,
                MaksBrVozila = p.MaksBrVozila,
                Korisnik = korisnik
            };

            await s.SaveOrUpdateAsync(k);

            foreach (int zonaId in p.ZoneId)
            {
                ParkingZona zona = await s.LoadAsync<ParkingZona>(zonaId);
                PretplatnaKartaZona veza = new()
                {
                    Karta = k,
                    Zona = zona
                };
                await s.SaveOrUpdateAsync(veza);
            }

            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati pretplatnu kartu.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    public static async Task<Result<PretplatnaKartaView, string>> AzurirajKartuAsync(PretplatnaKartaView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            PretplatnaKarta k = s.Load<PretplatnaKarta>(p.Id);
            k.TipPretplate = p.TipPretplate;
            k.PocetakVazenja = p.PocetakVazenja;
            k.KrajVazenja = p.KrajVazenja;
            k.Cena = p.Cena;
            k.MaksBrVozila = p.MaksBrVozila;
            k.Korisnik = await s.LoadAsync<Korisnik>(p.KorisnikId);

            await s.UpdateAsync(k);

            // Obrisi postojece veze karta-zona pa ponovo dodaj po trenutnom izboru
            List<PretplatnaKartaZona> postojece = s.Query<PretplatnaKartaZona>()
                .Where(x => x.Karta!.Id == k.Id).ToList();

            foreach (PretplatnaKartaZona stara in postojece)
            {
                await s.DeleteAsync(stara);
            }

            await s.FlushAsync(); 

            if (p.ZoneId != null)

                if (p.ZoneId != null)
            {
                foreach (int zonaId in p.ZoneId)
                {
                    ParkingZona zona = await s.LoadAsync<ParkingZona>(zonaId);
                    PretplatnaKartaZona veza = new()
                    {
                        Karta = k,
                        Zona = zona
                    };
                    await s.SaveOrUpdateAsync(veza);
                }
            }

            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati pretplatnu kartu.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return p;
    }

    public static async Task<Result<bool, string>> ObrisiKartuAsync(int id)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            List<PretplatnaKartaZona> veze = s.Query<PretplatnaKartaZona>()
                .Where(x => x.Karta!.Id == id).ToList();

            foreach (PretplatnaKartaZona veza in veze)
            {
                await s.DeleteAsync(veza);
            }

            PretplatnaKarta k = await s.LoadAsync<PretplatnaKarta>(id);
            await s.DeleteAsync(k);
            await s.FlushAsync();
        }
        catch (Exception e)
        {
            return ErrorHandler.HandleError(e);
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    #endregion
    #region FiksnaTarifa

    public static Result<List<FiksnaTarifaView>, string> VratiSveFiksneTarife()
    {
        ISession? s = null;
        List<FiksnaTarifaView> tarife = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<FiksnaTarifa> sveTarife = from t in s.Query<FiksnaTarifa>() select t;

            foreach (FiksnaTarifa t in sveTarife)
            {
                tarife.Add(new FiksnaTarifaView(t));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve fiksne tarife.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return tarife;
    }

    public static async Task<Result<FiksnaTarifaView, string>> VratiFiksnuTarifuAsync(int id)
    {
        ISession? s = null;
        FiksnaTarifaView tarifaView = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            FiksnaTarifa t = await s.LoadAsync<FiksnaTarifa>(id);
            tarifaView = new FiksnaTarifaView(t);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti fiksnu tarifu sa zadatim id-em.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return tarifaView;
    }

    public static async Task<Result<bool, string>> DodajFiksnuTarifuAsync(FiksnaTarifaView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ParkingZona zona = await s.LoadAsync<ParkingZona>(p.ZonaId);

            FiksnaTarifa t = new()
            {
                TipDana = p.TipDana,
                NazivIntervala = p.NazivIntervala,
                VremeOd = p.VremeOd,
                VremeDo = p.VremeDo,
                IznosTarife = p.IznosTarife,
                Zona = zona
            };

            await s.SaveOrUpdateAsync(t);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati fiksnu tarifu.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    public static async Task<Result<FiksnaTarifaView, string>> AzurirajFiksnuTarifuAsync(FiksnaTarifaView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            FiksnaTarifa t = s.Load<FiksnaTarifa>(p.Id);
            t.TipDana = p.TipDana;
            t.NazivIntervala = p.NazivIntervala;
            t.VremeOd = p.VremeOd;
            t.VremeDo = p.VremeDo;
            t.IznosTarife = p.IznosTarife;
            t.Zona = await s.LoadAsync<ParkingZona>(p.ZonaId);

            await s.UpdateAsync(t);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati fiksnu tarifu.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return p;
    }

    public static async Task<Result<bool, string>> ObrisiFiksnuTarifuAsync(int id)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            FiksnaTarifa t = await s.LoadAsync<FiksnaTarifa>(id);

            await s.DeleteAsync(t);
            await s.FlushAsync();
        }
        catch (Exception e)
        {
            return ErrorHandler.HandleError(e);
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    #endregion

    #region DinamickaTarifa

    public static Result<List<DinamickaTarifaView>, string> VratiSveDinamickeTarife()
    {
        ISession? s = null;
        List<DinamickaTarifaView> tarife = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<DinamickaTarifa> sveTarife = from t in s.Query<DinamickaTarifa>() select t;

            foreach (DinamickaTarifa t in sveTarife)
            {
                tarife.Add(new DinamickaTarifaView(t));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve dinamičke tarife.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return tarife;
    }

    public static async Task<Result<DinamickaTarifaView, string>> VratiDinamickuTarifuAsync(int id)
    {
        ISession? s = null;
        DinamickaTarifaView tarifaView = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            DinamickaTarifa t = await s.LoadAsync<DinamickaTarifa>(id);
            tarifaView = new DinamickaTarifaView(t);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti dinamičku tarifu sa zadatim id-em.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return tarifaView;
    }

    public static async Task<Result<bool, string>> DodajDinamickuTarifuAsync(DinamickaTarifaView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ParkingZona zona = await s.LoadAsync<ParkingZona>(p.ZonaId);

            DinamickaTarifa t = new()
            {
                PocetakVazenja = p.PocetakVazenja,
                KrajVazenja = p.KrajVazenja,
                RazlogPromene = p.RazlogPromene,
                InicijatorPromene = p.InicijatorPromene,
                PopunjenostZone = p.PopunjenostZone,
                TrajanjeParkiranja = p.TrajanjeParkiranja,
                IznosTarife = p.IznosTarife,
                Zona = zona
            };

            await s.SaveOrUpdateAsync(t);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati dinamičku tarifu.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    public static async Task<Result<DinamickaTarifaView, string>> AzurirajDinamickuTarifuAsync(DinamickaTarifaView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            DinamickaTarifa t = s.Load<DinamickaTarifa>(p.Id);
            t.PocetakVazenja = p.PocetakVazenja;
            t.KrajVazenja = p.KrajVazenja;
            t.RazlogPromene = p.RazlogPromene;
            t.InicijatorPromene = p.InicijatorPromene;
            t.PopunjenostZone = p.PopunjenostZone;
            t.TrajanjeParkiranja = p.TrajanjeParkiranja;
            t.IznosTarife = p.IznosTarife;
            t.Zona = await s.LoadAsync<ParkingZona>(p.ZonaId);

            await s.UpdateAsync(t);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati dinamičku tarifu.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return p;
    }

    public static async Task<Result<bool, string>> ObrisiDinamickuTarifuAsync(int id)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            DinamickaTarifa t = await s.LoadAsync<DinamickaTarifa>(id);

            await s.DeleteAsync(t);
            await s.FlushAsync();
        }
        catch (Exception e)
        {
            return ErrorHandler.HandleError(e);
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    #endregion
}
