namespace LockedInJecna;

public class Hra
{
    public bool Vyhrane { get; set; }
    private bool _konec;
    public Start Start;
    
    private Presun _pres1 = new Presun();
    Vypisy _vypisy = new Vypisy();
    
    public bool Konec
    {
        get { return _konec; }
        set { _konec = value; }
    }
    
    public Hra()
    {
        Start = new Start();
    }
    
    /// <summary>
    /// Nastavuje hru na prohranou, ukonci herni smycku a vypise hlasku o prohre.
    /// </summary>
    /// <returns>Textovy retezec, ktery oznamuje prohru</returns>
    public string Prohrano()
    {
        Vyhrane = false;
        _konec = true;
        return Vypisy.Prohrano;
    }

    /// <summary>
    /// Nastavuje hru na vyhranou, ukoncuje herni smycku a vypise hlasku o vyhre.
    /// </summary>
    /// <returns>Textovy retezec, ktery oznamuje vyhru</returns>
    public string Vyhrano()
    {
        Vyhrane = true;
        _konec = true;
        return Vypisy.Vyhrano;
    }
    
    /// <summary>
    /// Zahajuje hru inicializaci vsech objektu, vypsanim loga a uvodu do konzole vc. nalezeni obalky.
    /// Obsahuje také hlavní herní smyčku.
    /// </summary>
    public void NovaHra()
    {
        Start.Inicializace();
        _vypisy.VypisDoKonzole(Vypisy.Logo);
        _vypisy.VypisDoKonzole(Vypisy.JakZahajit + Environment.NewLine);
        _vypisy.ZiskejVstup("");
        _vypisy.SmazObsahKonzole();
        UvodDoHry();
        NalezenaObalka();
        
        // Herní smycka
        
        while (_konec == false)
        {
            _pres1.NabidkaPresunu(Start, _vypisy);
            CinnostUcebna();
            Start.T1.Autentizace(Start, _vypisy, _pres1);
            
            if (Start.T1.SpravnyPin)
            {
                _vypisy.VypisPoPismenech(Vyhrano());
            }
        }
    }

    /// <summary>
    /// Vypise do konzole uvodni pribeh a hlavni ukol pro hrace.
    /// </summary>
    public void UvodDoHry()
    {
        _vypisy.VypisPoPismenech(Vypisy.Pribeh + Environment.NewLine);
        _vypisy.VypisDoKonzole(Environment.NewLine + Vypisy.Ukol);
    }

    /// <summary>
    /// Zpracuje nalezeni obalky, vyzve hrace k vyberu z moznosti a podle volby vyhlasi prohru nebo ukaze napovedu k PINu.
    /// </summary>
    public void NalezenaObalka()
    {
        int vstup = 0;
        
        while (vstup != 1 && vstup != 2)
        {
            bool chybnyVstup = false;

            try
            {
                vstup = Convert.ToInt32(_vypisy.ZiskejVstup(Vypisy.NalezenaObalka));
            }
            
            catch (FormatException)
            {
                chybnyVstup = true;
            }
            
            catch (OverflowException)
            {
                chybnyVstup = true;
            }

            if (vstup != 1 && vstup != 2 || chybnyVstup)
            {
                _vypisy.VypisDoKonzole(Vypisy.SpatnyPrikaz);
            }
        }
        
        if (vstup == 1)
        {
            Prohrano();
            _vypisy.SmazObsahKonzole();
            _vypisy.VypisPoPismenech(Vypisy.Prohrano);
        }

        if (vstup == 2)
        {
            _vypisy.SmazObsahKonzole();
            _vypisy.VypisPoPismenech(Vypisy.Dopis1 + Start.P1.BarevnaNapoveda() + Environment.NewLine);
        }
    }
    
    /// <summary>
    /// Vyzve hrace k volbe mezi prohledanim a opustenim ucebny. Nasledne prohleda ucebnu nebo premisti uzivatele na chodbu.
    /// V metode je cyklus, ktery se opakuje dokud uzivatel ucebnu neopusti.
    /// </summary>
    public void CinnostUcebna()
    {
        while (_pres1.VUcebne && Start.AktualniLokace is Ucebna u)
        {
            _vypisy.VypisDoKonzole("");
            string? vstup = _vypisy.ZiskejVstup(Vypisy.NabidkaCinnostiUcebna);

            if (vstup?.ToLower() == "s")
            {
                _vypisy.VypisDoKonzole("");
                _vypisy.VypisDoKonzole(Start.P1.ProhledatUcebnu(u, Start.Inv1));
            }

            if (vstup?.ToLower() == "e")
            {
                _pres1.ZmenaLokace(u.SousedniChodba, Start);
                _pres1.VUcebne = false;
            }

            if (vstup?.ToLower() != "s" && vstup?.ToLower() != "e")
            {
                _vypisy.VypisDoKonzole(Vypisy.NeznamyPrikaz);
            }
        }
    }
}
