namespace LockedInJecna;

public class Inventar
{
    public List<Listecek> Posbirane = new List<Listecek>();

    public Inventar()
    {
    }

    /// <summary>
    /// Projde list posbiranych listecku a vypise cislo a barvu.
    /// </summary>
    /// <returns>Cislo a barva vsech posbiranych listecku.</returns>
    public string VypisPosbiranych()
    {
        string vystup = "";
        
        foreach (Listecek l in Posbirane)
        {
            vystup += l.Cislo + " " + l.Barva + Environment.NewLine;
        }

        return vystup;
    }
}