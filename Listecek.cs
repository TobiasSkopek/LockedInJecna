namespace LockedInJecna;

public class Listecek
{
    public string Barva { get; set; }
    private int _cislo;
    public Lokace Umisteni { get; set; }

    public Listecek(int cislo, string barva, Lokace umisteni)
    {
        _cislo = cislo;
        Barva = barva;
        Umisteni = umisteni;
    }
    
    public int Cislo
    {
        get
        { 
            return _cislo;
        }

        set
        {
            if (value >= 0 && value < 10)
            {
                _cislo = value;
            }
        }
    }
}
