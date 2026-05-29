namespace LockedInJecna;

public class Prujezd : Lokace
{

    public List<Lokace> OstatniLokace = new List<Lokace>();
    private int _cisloPozadavku;
    public Prujezd(int patro, string id, string nazev, int cisloPozadavku) : base(patro, id, nazev)
    {
        _cisloPozadavku = cisloPozadavku;
    }
    
    /// <summary>
    /// Vypisuje sousedni lokace dane lokace, do kterych se lze premistit.
    /// </summary>
    /// <returns>Nazvy sousednich lokaci, do kterych je mozny presun</returns>
    public override string VypisSousedniLokace()
    {
        string nazvy = "";
        
        foreach (Lokace l in OstatniLokace)
        {

            if (l is Terminal)
            {
                nazvy += l.Nazev + "[P]" + Environment.NewLine;
            }

            else
            {
                nazvy += l.Nazev + "[" + l.Patro + "]" + Environment.NewLine;  
            }
        }

        return nazvy;
    }

    public int CisloPozadavku
    {
        get { return _cisloPozadavku; }
        set { _cisloPozadavku = value; }
    }
}
