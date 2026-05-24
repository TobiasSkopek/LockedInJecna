namespace LockedInJecna;

public class PinGenerator
{
    private Random _rnd = new Random();
    private List<Listecek> _vygenerovane = new List<Listecek>(6);

    public PinGenerator()
    {
        
    }

    /// <summary>
    /// Vygeneruje nahodny PIN a umisti ho do nahodne ucebny. 
    /// </summary>
    /// <param name="umisteni"></param>
    public void VygenerujPin(List<Lokace> umisteni)
    {
        List<string> barvy = new List<string>();
        List<Ucebna> ucebny = new List<Ucebna>();

        foreach (Lokace l in umisteni)
        {
            if (l is Ucebna)
            {
                Ucebna u = l as Ucebna;
                ucebny.Add(u);
            }
        }
            
        barvy.Add("zelená");
        barvy.Add("modrá");
        barvy.Add("červená");
        barvy.Add("bílá");
        barvy.Add("tyrkysová");
        barvy.Add("fialová");
        
        for (int i = 0; i < 6; i++)
        {
            int cisloNaListecku = _rnd.Next(0, 10);
            int indexBarvy = _rnd.Next(0, barvy.Count);
            string vyslednaBarva = barvy[indexBarvy];
            barvy.RemoveAt(indexBarvy);
            int nahodneUmisteni;
            
            do
            {
                nahodneUmisteni = _rnd.Next(0, ucebny.Count);
                
            } while (ucebny[nahodneUmisteni].Odemceno == false);
            
            Ucebna umisteniListecku = ucebny[nahodneUmisteni]; // Vyřešit pokud učebna je zamčená
            ucebny.RemoveAt(nahodneUmisteni);
            
            Listecek novy = new Listecek(cisloNaListecku, vyslednaBarva, umisteniListecku);
            _vygenerovane.Add(novy);
        }
    }

    // konstanty barev pro nápovědu
    const string RESET = "\u001B[0m";
    const string RED = "\u001B[31m";
    const string GREEN = "\u001B[32m";
    const string BLUE = "\u001B[34m";
    const string MAGENTA = "\u001B[35m";
    const string YELLOW = "\u001B[33m";
    const string CYAN = "\u001B[36m";
    const string JECNA_BLUE = "\u001B[38;2;155;191;234m";
    
    /// <summary>
    /// Projde vsechny vygenerovane listecky a vrati napovedu PINu pomoci barev.
    /// </summary>
    /// <returns>Napoveda PINu v barvach</returns>
    public string BarevnaNapoveda()
    {
        string vystup = "";

        foreach (Listecek l in _vygenerovane)
        {
            switch (l.Barva)
            {
                case "zelená":
                    vystup += GREEN + l.Barva + RESET + " ";
                    break;
                case "modrá": vystup += BLUE + l.Barva + RESET + " ";
                    break;
                case "červená": vystup += RED + l.Barva + RESET + " ";
                    break;
                case "bílá": vystup += l.Barva + " ";
                    break;
                case "tyrkysová": vystup += CYAN + l.Barva + RESET + " ";
                    break;
                case "fialová": vystup += MAGENTA + l.Barva + RESET + " ";
                    break;
            }
        }

        return vystup;
    }
    
    /// <summary>
    /// Projde vygenerovane listecky a pokud se nachazi v pozadovane ucebne, vrati hlasku o nalezenem/nenalezenem listecku popr. vypise jeho cislo a barvu.
    /// </summary>
    /// <param name="ktera">Pozadavana ucebna, kterou chceme prohledat</param>
    /// <param name="inventar"></param>
    /// <returns>Cislo na listecku a jeho barva popr. ze se v ucebne zadny listecek nenachazi</returns>
    public string ProhledatUcebnu(Ucebna ktera, Inventar inventar)
    {
        bool jeTam = false;
        string vystup = "";
        
        foreach (Listecek l in _vygenerovane)
        {
            if (l.Umisteni == ktera)
            {
                if (!inventar.Posbirane.Contains(l))
                {
                    inventar.Posbirane.Add(l);
                }
                
                switch (l.Barva)
                {
                    case "zelená":
                        return Vypisy.NalezenyListecek + l.Cislo + " " + GREEN + l.Barva + RESET + " " + Environment.NewLine;
                        break;
                    case "modrá": return Vypisy.NalezenyListecek + l.Cislo +  " " + BLUE + l.Barva + RESET + " " + Environment.NewLine;
                        break;
                    case "červená": return Vypisy.NalezenyListecek + l.Cislo +  " " + RED + l.Barva + RESET + " " + Environment.NewLine;
                        break;
                    case "bílá": return Vypisy.NalezenyListecek + l.Cislo + " " + l.Barva + " " + Environment.NewLine;
                        break;
                    case "tyrkysová": return Vypisy.NalezenyListecek + l.Cislo + " " + CYAN + l.Barva + RESET + " " + Environment.NewLine;
                        break;
                    case "fialová": return Vypisy.NalezenyListecek + l.Cislo + " " + MAGENTA + l.Barva + RESET + " " + Environment.NewLine;
                        break;
                }
            }
        }
        
        return Vypisy.ZadnyListecek;
    }

    /// <summary>
    /// Projde vygenerovane listecky, prevede cislo listecku na string, sestavi z nej PIN a prevede zpet na int.
    /// Porovna zadany PIN od uzivatele s PINem sestavenym z listecku.
    /// </summary>
    /// <param name="zadanyPin">PIN zadany od uzivatele</param>
    /// <returns>V pripade shody se zadanym PINem od uzivatele vrati true.
    /// V pripade neshody se zadanym PINem od uzivatele vrati false.</returns>
    public bool OvereniPinu(int zadanyPin)
    {
        string pin = null;
        bool vystup = false;
        
        foreach (Listecek l in _vygenerovane)
        {
            if (pin == null)
            {
                pin = Convert.ToString(l.Cislo);
            }

            else
            {
              pin += Convert.ToString(l.Cislo);
            }
        }

        if (Convert.ToInt32(pin) == zadanyPin)
        {
            vystup = true;
        }

        if (Convert.ToInt32(pin) != zadanyPin && vystup != true)
        {
            vystup = false;
        }

        return vystup;

    }

}