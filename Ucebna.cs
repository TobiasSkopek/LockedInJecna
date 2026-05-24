namespace LockedInJecna;

public class Ucebna : Lokace
{
    public bool Odemceno { get; set; }
    public int Cislo { get; set; }
    public Chodba SousedniChodba { get; set; }

    public Ucebna(int patro, string id, string nazev, bool odemceno, int cislo, Chodba sousedniChodba) : base(patro, id, nazev)
    {
        Odemceno = odemceno;
        Cislo = cislo;
        SousedniChodba = sousedniChodba;
    }
}