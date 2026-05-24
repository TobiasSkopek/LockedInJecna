namespace LockedInJecna;

public class Hra
{
    public bool Vyhrane { get; set; }
    private bool _konec = false;
    public Start Start;
    private Presun _pres1 = new Presun();
    
    public bool Konec
    {
        get { return _konec; }
        set { _konec = value; }
    }

    Vypisy vypisy = new Vypisy();
    
    
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
        vypisy.VypisDoKonzole(Vypisy.Logo);
        vypisy.VypisDoKonzole(vypisy.ZiskejVstup(Vypisy.JakZahajit + Environment.NewLine));
        vypisy.SmazObsahKonzole();
        UvodDoHry();
        NalezenaObalka();
        
        // Herní smycka
        
        while (_konec == false)
        {
            _pres1.NabidkaPresunu(Start, vypisy);
            CinnostUcebna();
            Start.T1.Autentizace(Start, vypisy, _pres1);
            
            if (Start.T1.SpravnyPin)
            {
                vypisy.VypisPoPismenech(Vyhrano());
            }
        }
    }

    /// <summary>
    /// Vypise do konzole uvodni pribeh a hlavni ukol pro hrace.
    /// </summary>
    public void UvodDoHry()
    {
        vypisy.VypisPoPismenech(Vypisy.Pribeh + Environment.NewLine);
        vypisy.VypisDoKonzole(Environment.NewLine + Vypisy.Ukol);
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
                vstup = Convert.ToInt32(vypisy.ZiskejVstup(Vypisy.NalezenaObalka));
            }
            catch (FormatException e)
            {
                chybnyVstup = true;
            }

            if (vstup != 1 && vstup != 2 || chybnyVstup == true)
            {
                vypisy.VypisDoKonzole(Vypisy.SpatnyPrikaz);
            }
        }
        
        if (vstup == 1)
        {
            Prohrano();
            vypisy.SmazObsahKonzole();
            vypisy.VypisPoPismenech(Vypisy.Prohrano);
        }

        if (vstup == 2)
        {
            vypisy.SmazObsahKonzole();
            vypisy.VypisPoPismenech(Vypisy.Dopis1 + Start.P1.BarevnaNapoveda() + Environment.NewLine);
        }
    }
    
    /// <summary>
    /// Vyzve hrace k volbe mezi prohledanim a opustenim ucebny. Nasledne prohleda ucebnu nebo premisti uzivatele na chodbu.
    /// V metode je cyklus, ktery se opakuje dokud uzivatel ucebnu neopusti.
    /// </summary>
    public void CinnostUcebna()
    {
        while (_pres1.VUcebne == true && Start.AktualniLokace is Ucebna)
        {
            Ucebna? u = Start.AktualniLokace as Ucebna;

            vypisy.VypisDoKonzole("");
            string vstup = vypisy.ZiskejVstup(Vypisy.NabidkaCinnostiUcebna);

            if (vstup.ToLower() == "s")
            {
                vypisy.VypisDoKonzole("");
                vypisy.VypisDoKonzole(Start.P1.ProhledatUcebnu(u, Start.Inv1));
            }

            if (vstup.ToLower() == "e")
            {
                _pres1.ZmenaLokace(u.SousedniChodba, Start);
                _pres1.VUcebne = false;
            }

            if (vstup.ToLower() != "s" && vstup.ToLower() != "e")
            {
                vypisy.VypisDoKonzole(Vypisy.NeznamyPrikaz);
            }
        }
    }
}