namespace LockedInJecna;

public class Start
{

    public List<Lokace> Lokace = new List<Lokace>();
    private Lokace _aktualniLokace = null;
    public PinGenerator P1;
    public Prujezd Pr1;
    public Inventar Inv1;
    public Terminal T1;
    private Random _rnd = new Random();
    
    public Lokace AktualniLokace
    {
        get { return _aktualniLokace; }
        set { _aktualniLokace = value; }
    }
    
    public Start()
    {
    }
    
    /// <summary>
    /// Nahodne generuje, zda je ucebna odemcena nebo zamcena.
    /// </summary>
    public void VygenerujZamceni()
    {
        int pocetLichych = 0;
        int pocetUceben = 0; 
        
       foreach (Lokace l in Lokace)
       {
           if (l is Ucebna)
           {
               pocetUceben++;
           }
       }

       foreach (Lokace l in Lokace)
       {
           int nahodneC = _rnd.Next(0, 10);
           
           if (nahodneC % 2 != 0 && (pocetLichych < pocetUceben - 6) && l is Ucebna)
           {
               pocetLichych++;
               Ucebna? u = l as Ucebna;

               u?.Odemceno = false;
           }
       }
    }
    

    /// <summary>
    /// Vytvori vsechny potrebne instance, propoji navzajem lokace a vola metody potrebne na zacatku hry.
    /// </summary>
    public void Inicializace()
    {
        
        // Vytvoření průjezdu s hlavním vchodem
        Pr1 = new Prujezd(0, "prujezd", "Hlavní vchod a průjezd pro auta", 9);
        Lokace.Add(Pr1);
        
        AktualniLokace = Pr1;
        
        // Vytvoření inventáře
        Inv1 = new Inventar();
        
        // Vytvoření chodeb
        Chodba ch0 = new Chodba(0, "chodba0", "Chodba v přízemí");
        Lokace.Add(ch0);
        Chodba ch1 = new Chodba(1, "chodba1", "Chodba v 1. patře");
        Lokace.Add(ch1);
        Chodba ch2 = new Chodba(2, "chodba2", "Chodba v 2. patře");
        Lokace.Add(ch2);
        Chodba ch3 = new Chodba(3, "chodba3", "Chodba ve 3. patře");
        Lokace.Add(ch3);
        
        // Propojení průjezdu s chodbami;
        Pr1.OstatniLokace.Add(ch0);
        Pr1.OstatniLokace.Add(ch1);
        Pr1.OstatniLokace.Add(ch2);
        Pr1.OstatniLokace.Add(ch3);
        
        // Nastavení aktuální lokace
        AktualniLokace = Pr1;
        
        // Propojení chodeb k přesunu
        ch0.OstatniLokace.Add(ch1);
        ch0.OstatniLokace.Add(ch2);
        ch0.OstatniLokace.Add(ch3);
        ch0.OstatniLokace.Add(Pr1);
        ch1.OstatniLokace.Add(ch0);
        ch1.OstatniLokace.Add(ch2);
        ch1.OstatniLokace.Add(ch3);
        ch1.OstatniLokace.Add(Pr1);
        ch2.OstatniLokace.Add(ch0);
        ch2.OstatniLokace.Add(ch1);
        ch2.OstatniLokace.Add(ch3);
        ch2.OstatniLokace.Add(Pr1);
        ch3.OstatniLokace.Add(ch0);
        ch3.OstatniLokace.Add(ch1);
        ch3.OstatniLokace.Add(ch2);
        ch3.OstatniLokace.Add(Pr1);
        
        // Vytvoření učeben 1NP a propojení s chodbami v 1NP
        Ucebna u1 = new Ucebna(1, "ucebna1", "Učebna 1", true, 1, ch1);
        Lokace.Add(u1);
        Ucebna u2 = new Ucebna(1, "ucebna2", "Učebna 2", true, 2, ch1);
        Lokace.Add(u2);
        Ucebna u3 = new Ucebna(1, "ucebna3", "Učebna 3", true, 3, ch1);
        Lokace.Add(u3);
        Ucebna u4 = new Ucebna(1, "ucebna4", "Učebna 4", true, 4, ch1);
        Lokace.Add(u4);
        Ucebna u5 = new Ucebna(1, "ucebna5", "Učebna 5", true, 5, ch1);
        Lokace.Add(u5);
        
        ch1.Ucebny.Add(u1);
        ch1.Ucebny.Add(u2);
        ch1.Ucebny.Add(u3);
        ch1.Ucebny.Add(u4);
        ch1.Ucebny.Add(u5);
        
        // Vytvoření učeben 2NP a propojení s chodbami v 2NP
        Ucebna u6 = new Ucebna(2, "ucebna6", "Učebna 6", true, 6, ch2);
        Lokace.Add(u6);
        Ucebna u7 = new Ucebna(2, "ucebna7", "Učebna 7", true, 7, ch2);
        Lokace.Add(u7);
        Ucebna u8 = new Ucebna(2, "ucebna8", "Učebna 8", true, 8, ch2);
        Lokace.Add(u8);
        Ucebna u9 = new Ucebna(2, "ucebna9", "Učebna 9", true, 9, ch2);
        Lokace.Add(u9);
        Ucebna u11 = new Ucebna(2, "ucebna11", "Učebna 11", true, 11, ch2);
        Lokace.Add(u11);
        Ucebna u12 = new Ucebna(2, "ucebna12", "Učebna 12", true, 12, ch2);
        Lokace.Add(u12);
        Ucebna u13 = new Ucebna(2,"ucebna13", "Učebna 13", true, 13, ch2);
        Lokace.Add(u13);
        
        ch2.Ucebny.Add(u6);
        ch2.Ucebny.Add(u7);
        ch2.Ucebny.Add(u8);
        ch2.Ucebny.Add(u9);
        ch2.Ucebny.Add(u11);
        ch2.Ucebny.Add(u12);
        ch2.Ucebny.Add(u13);
        
        // Vytvoření učeben 3NP a propojení s chodbami v 3NP
        Ucebna u14 = new Ucebna(3, "ucebna14", "Učebna 14", true, 14, ch3);
        Lokace.Add(u14);
        Ucebna u15 = new Ucebna(3, "ucebna15", "Učebna 15", true, 15, ch3);
        Lokace.Add(u15);
        Ucebna u16 = new Ucebna(3, "ucebna16", "Učebna 16", true, 16, ch3);
        Lokace.Add(u16);
        
        ch3.Ucebny.Add(u14);
        ch3.Ucebny.Add(u15);
        ch3.Ucebny.Add(u16);
        
        // Vytvoření náhodného uzamčení učeben
        VygenerujZamceni();
        
        // Vytvoření generátoru PIN a samotné vygenerování PIN kódu
        P1 = new PinGenerator();
        P1.VygenerujPin(Lokace);
        
        // Vytvoření odchodového terminálu a propojení s průjezdem
        T1 = new Terminal(0, "terminal", "Odchodový terminál");
        Lokace.Add(T1);
        Pr1.OstatniLokace.Add(T1);
        T1.OstatniLokace.Add(Pr1);
    }
}