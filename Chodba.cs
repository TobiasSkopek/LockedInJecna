namespace LockedInJecna;

public class Chodba : Lokace
{
    public List<Ucebna> Ucebny = new List<Ucebna>();
    public List<Lokace> OstatniLokace = new List<Lokace>();
    
    public Chodba(int patro, string id, string nazev) : base(patro, id, nazev)
    {
        
    }
    
    /// <summary>
    /// Vypise sousedni lokace dane lokace, do kterych se lze premistit.
    /// </summary>
    /// <returns>Nazvy sousednich lokaci, do kterych je mozny presun</returns>
    public override string VypisSousedniLokace()
    {
        string nazvy = "";
        
        foreach (Lokace l in OstatniLokace)
        {
            if (l is Chodba)
            {
                nazvy += l.Nazev + "[" + l.Patro + "]" + Environment.NewLine;
            }

            if (l is Prujezd p)
            {
                nazvy += p.Nazev + "[" + p.CisloPozadavku + "]" + Environment.NewLine;
            }
        }

        return nazvy;
    }
}
