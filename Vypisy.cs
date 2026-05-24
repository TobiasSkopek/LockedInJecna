namespace LockedInJecna;

public class Vypisy
{
    // konstanty barev pro výpisy
    const string RESET = "\u001B[0m";
    const string RED = "\u001B[31m";
    const string GREEN = "\u001B[32m";
    const string BLUE = "\u001B[34m";
    const string MAGENTA = "\u001B[35m";
    const string YELLOW = "\u001B[33m";
    const string CYAN = "\u001B[36m";
    const string JECNA_BLUE = "\u001B[38;2;155;191;234m";

    /// <summary>
    /// Vypisuje, co se po uzivateli pozaduje a ziskava vstup od uzivatele.
    /// </summary>
    /// <param name="prikaz">Prikaz, ktery uzivateli rika, co ma zadat.</param>
    /// <returns>Zadany prikaz</returns>
    public string ZiskejVstup(string prikaz)
    {
        Console.Write(prikaz + RED + Environment.NewLine + "-> ");
        string vstup = Console.ReadLine();
        Console.Write(RESET);
        return vstup;
    }
    
    public const string Logo =(JECNA_BLUE + @"
┌───────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
│                                                                                                               │
│    _      ____   _____ _  ________ _____                                  __________________________          │
│   | |    / __ \ / ____| |/ /  ____|  __ \                                |   ____________________   |         │
│   | |   | |  | | |    | ' /| |__  | |  | |                               |  |                    |  |         │
│   | |   | |  | | |    |  < |  __| | |  | |                               |  |                    |  |         │
│   | |___| |__| | |____| . \| |____| |__| |                               |  |                    |  |         │
│   |______\____/ \_____|_|\_\______|_____/                                |  |                    |  |         │
│                                                     ___                  |  |                    |  |         │
│                                  ____              /  /                __|__|____________________|__|__       │
│                                 |____|            /__/                |              ____              |      │
│   _____  _   _          _ ______ _____ _   _      __                  |             |    |             |      │
│  |_   _|| \ | |        | |  ____/ ____| \ | |    /  \                 |             |_  _|             |      │
│    | |  |  \| |   _    | | |___| |    |  \| |   / /\ \                |               ||               |      │
│    | |  |     |  | |   | | |___| |    |     |  / /__\ \               |               ||               |      │
│   _| |_ | |\  |  | |___| | |___| |____| |\  | / /    \ \              |                                |      │
│  |_____||_| \_|  | ____|_|______\_____|_| \_|/_/      \_\             |________________________________|      │
│                                                                                                               │
└───────────────────────────────────────────────────────────────────────────────────────────────────────────────┘


" + RESET);

    public const string JakZahajit = "Pro zahájení hry, stiskněte klávesu ENTER.";
    
    public const string Pribeh = "Představ si běžný páteční školní den v SPŠE Ječná. " +
                                 "\nPrávě ti skončila poslední hodina (suplovaná fyzika) a ty se těšíš na víkend. " +
                                 "\nVšichni už odešli domů a ze školy odcházíš ty jako poslední. " +
                                 "\nU východu přikládáš svůj ISIC ke čtečce, ale právě tady zjišťuješ, že dnes nikam neodcházíš! ";

    public const string Ukol = @"Na odchodovém terminálu se ukazuje: " + BLUE + @"
┌───────────────────────────────────────────┐
│         PRO OTEVŘENÍ DVEŘÍ ZADEJ          │
│              ŠESTIMÍSTNÝ PIN              │
└───────────────────────────────────────────┘
" + RESET;
    
    public const string NalezenaObalka = "Na zemi leží bílá obálka, co s ní uděláš?\nVezmu a vyhodím do koše [1]\nOtevřu a přečtu si obsah[2]";
    public const string SpatnyPrikaz = YELLOW + "Zadal jsi špatný příkaz, zkus to znovu\n" + RESET;
    public const string Dopis1 = "Jednotlivá čísla PINu jsem napsal na barevné papírky a schoval je do kmenových učeben v 1. - 3. patře. \nPIN srovnej podle následujících barev: \n";
    public const string Prohrano = RED + "Tímto jsi prohrál a jsi po celý víkend uvězněný ve škole.\nGratuluji!" + RESET;

    public const string Vyhrano = GREEN +
                                  "Tímto jsi vyřešil hádánku a můžeš úspěšně opustit školu. Venku už sice zapadlo slunce, ale vůně čerstvého vzduchu je k nezaplacení. \nKoukej sprintovat na metro/tramvaj než si to ten zámek zase rozmyslí a budeš muset ponocovat u Luboše v učebně 8.";
    public const string RozcestnikPodlazi = "Kam se vydáš? (Pro přesun do jiného podlaží zadej číslo v závorce)";
    public const string RozcestnikPodlaziAUceben = "Kam se vydáš? (Pro přesun do jiného podlaží zadej číslo v závorce, pro zobrazení učeben zadej písmeno u)";
    public const string RozcestnikUceben = "Kam se vydáš? (Zadej číslo učebny)";
    public const string PresunDo4Np =
        YELLOW + "\nTy chceš cupitat ještě těch dalších 34 schodů? Tam se dneska ale nedostaneš! \nZkus zadat nějaké z pater na seznamu." + RESET;

    public const string UzamcenaUcebna = YELLOW + "Tato učebna je uzamčena. Vyber si jinou ze seznamu." + RESET;
    public const string UcebnaNeexistuje = YELLOW + "Tato učebna neexistuje nebo není na tomto patře. Vyber si jinou ze seznamu." + RESET;

    public const string PatroNeexistuje =
        YELLOW + "\nKam to chceš jít, studente? Takové patro na Ječné není. Radši si vyber ze seznamu" + RESET;

    public const string NabidkaChodeb =
        "SEZNAM CHODEB:";

    public const string NabidkaUceben = "SEZNAM UČEBEN: ";

    public const string NabidkaCinnostiUcebna =
        "Co budeš dělat? Pro prohledání učebny zadej s, pro odchod z učebny stiskni e";
    public const string NeznamyPrikaz = YELLOW + "Neznámý příkaz, zkus to znovu." + RESET;
    public const string InventarListecku = "INVENTÁŘ LÍSTEČKŮ:";
    public const string NalezenyListecek = "Úspěch, našel jsi lísteček: ";
    public const string ZadnyListecek = "Smůla, tady žádný lísteček není. Zkus prohledat jinou učebnu.";
    public const string ZadanoPismeno = YELLOW + "Zadal jsi písmeno místo čísla!" + RESET;
    public const string ZadneUcebny = "Zde se nenachází žádné učebny.";
    public const string PozadavekNaPin = "Zadejte PIN ve formátu ";
    public const string OpusteniTerminalu = "Pro odchod od terminálu zadej 9";
    public const string SpravnyPin = BLUE + @"
┌───────────────────────────────────────────┐
│      /         PIN JE SPRÁVNÝ             │
│    \/          ZÁMEK ODBLOKOVÁN           │
└───────────────────────────────────────────┘
" + RESET;
    public const string NespravnyPin = BLUE + @"
┌───────────────────────────────────────────┐
│    |           NESPRÁVNÝ PIN              │
│    .         ZKUSTE TO ZNOVU              │
└───────────────────────────────────────────┘
" + RESET;

    /// <summary>
    /// Vypise do konzole pozadovany text.
    /// </summary>
    /// <param name="text">Pozadovany text na vypsani</param>
    public void VypisDoKonzole(string text)
    {
        Console.WriteLine(text);
    }

    /// <summary>
    /// Smaze obsah konzole.
    /// </summary>
    public void SmazObsahKonzole()
    {
        Console.Clear();
    }

    /// <summary>
    /// Vypise do konzole pozadovany text postupne po pismenech.
    /// </summary>
    /// <param name="text">Pozadovany text na vypsani</param>
    public void VypisPoPismenech(string text)
    {
        foreach (char p in text)
        {
            Console.Write(p);
            Thread.Sleep(25);
        }
    }

}