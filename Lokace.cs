namespace LockedInJecna;

public abstract class Lokace
{
    public string Id { get; set; }
    public string Nazev { get; set; }
    private int _patro;

    public Lokace(int patro, string id, string nazev)
    {
        _patro = patro;
        Id = id;
        Nazev = nazev;
    }
    
    
    // Property

    public int Patro
    {
        get
        {
            return _patro;
        }

        set
        {
            if (value >= 0 && value <= 4)
            {
                _patro = value;
            }

            else
            {
                _patro = 0;
            }
        }
    }
    
    public virtual string VypisSousedniLokace()
    {
        return "";
    }
}