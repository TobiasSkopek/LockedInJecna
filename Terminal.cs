namespace LockedInJecna;

public class Terminal : Lokace
{
    public List<Lokace> OstatniLokace = new List<Lokace>();
    
    public Terminal(int patro, string id, string nazev) : base(patro, id, nazev)
    {
    }
    
    public bool SpravnyPin;
    
    /// <summary>
    /// Zpracuje zadany PIN od uzivatele. Pokud je spravny, vypise ze je spravny. Pokud je nespravny, vypise, ze je nespravny.
    /// Pokud uzivatel zada 9, premisti se do prujezdu.
    /// </summary>
    /// <param name="start">Instance tridy Start</param>
    /// <param name="vypisy">Instance tridy Vypisy</param>
    /// <param name="presun">Instance tridy Presun</param>
    public void Autentizace(Start start, Vypisy vypisy, Presun presun)
    { 
        bool spatnyPrikaz = true;
        
        while (start.AktualniLokace is Terminal && spatnyPrikaz && SpravnyPin == false)
        {
            try
            {
                int pinUzivatele = Convert.ToInt32(vypisy.ZiskejVstup("(" + Vypisy.OpusteniTerminalu + ")" +
                                                                      Environment.NewLine + Vypisy.PozadavekNaPin +
                                                                      start.P1.BarevnaNapoveda()));

                bool vysledekOvereni = start.P1.OvereniPinu(pinUzivatele);
                
                if (pinUzivatele == 9)
                {
                    presun.ZmenaLokace(start.Pr1, start);
                }
                
                else
                {
                    if (vysledekOvereni)
                    {
                        vypisy.SmazObsahKonzole();
                        vypisy.VypisDoKonzole(Vypisy.SpravnyPin);
                        SpravnyPin = true;
                    }

                    if (vysledekOvereni == false)
                    {
                        vypisy.VypisDoKonzole(Vypisy.NespravnyPin);
                        SpravnyPin = false;
                    }
                }
            }
            catch (FormatException)
            {
                vypisy.VypisDoKonzole(Vypisy.ZadanoPismeno);
                vypisy.VypisDoKonzole("");
                spatnyPrikaz = true;
            }
            catch (OverflowException)
            {
                vypisy.VypisDoKonzole(Vypisy.ZadanoPismeno);
                vypisy.VypisDoKonzole("");
                spatnyPrikaz = true; 
            }
        }
    }

    /// <summary>
    /// Vypisuje sousední lokace terminalu.
    /// </summary>
    /// <returns>Nazvy sousednich lokaci, do kterych je mozny presun</returns>
    public override string VypisSousedniLokace()
    {
        string nazvy = "";
        
        foreach (Lokace l in OstatniLokace)
        {
            if (l is Prujezd)
            {
                nazvy += l.Nazev + "[9]" + Environment.NewLine;
            }
        }

        return nazvy;
    }
}
