namespace LockedInJecna;

public class Presun
{
   private bool _vUcebne;
   private Vypisy _vypisy = new Vypisy();
   public bool VUcebne 
   { 
       get { return _vUcebne; }
       set { _vUcebne = value; }
   }

   /// <summary>
    /// Premisti hrace na jinou lokaci, smaze obsah konzole a vypise aktualni lokaci a nalezene listecky.
    /// </summary>
    /// <param name="kam">Cilova lokace</param>
    /// <param name="start">Instance tridy Start</param>
    public void ZmenaLokace(Lokace kam, Start start)
    {
        start.AktualniLokace = kam;
        _vypisy.SmazObsahKonzole();
        _vypisy.VypisDoKonzole(Environment.NewLine + "AKTUÁLNÍ LOKACE: " + start.AktualniLokace.Nazev + Environment.NewLine + "NALEZENÉ LÍSTEČKY:" + Environment.NewLine + start.Inv1.VypisPosbiranych() + Environment.NewLine + "──────────────────────────────");
    }
    

    /// <summary>
    /// Nabizi uzivateli mista, kam se muze presunout. Prijima vstupy od uzivatele, zpracovava je a vola metodu pro zmenu lokace.
    /// </summary>
    /// <param name="start">Instance tridy Start</param>
    /// <param name="vypisy">Instance tridy Vypisy</param>
    public void NabidkaPresunu(Start start, Vypisy vypisy)
    { 
        
        bool spatnaVolba = false;
        
            do
            {
                vypisy.VypisDoKonzole(Environment.NewLine + Vypisy.NabidkaChodeb);
                vypisy.VypisDoKonzole(start.AktualniLokace.VypisSousedniLokace());
                
                string? vstup = null;

                if (start.AktualniLokace is Chodba ch && ch.Patro != 0)
                {
                    vstup = vypisy.ZiskejVstup(Vypisy.RozcestnikPodlaziAUceben);
                }

                if (start.AktualniLokace is Prujezd || start.AktualniLokace is Chodba ch1 && ch1.Patro == 0)
                {
                    vstup = vypisy.ZiskejVstup(Vypisy.RozcestnikPodlazi);
                }
                
                if (vstup?.ToLower() == "p" && start.AktualniLokace is Prujezd)
                {
                    ZmenaLokace(start.T1, start);
                }
                
                else if (vstup?.ToLower() == "u" && start.AktualniLokace is Chodba chodba && chodba.Patro != 0)
                {
                    bool spatnaVolbaU = false;
                        
                    do
                    {
                        vypisy.VypisDoKonzole(Environment.NewLine + Vypisy.NabidkaUceben);

                        foreach (Lokace l in chodba.Ucebny)
                        { 
                            vypisy.VypisDoKonzole(l.Nazev);
                        }

                        int vstupU;

                        try
                        {
                            vstupU = Convert.ToInt32(vypisy.ZiskejVstup(Vypisy.RozcestnikUceben));
                        }
                        catch (FormatException)
                        {
                            vypisy.VypisDoKonzole(Vypisy.ZadanoPismeno);
                            spatnaVolbaU = true;
                            continue;
                        }
                        catch (OverflowException)
                        {
                            vypisy.VypisDoKonzole(Vypisy.UcebnaNeexistuje);
                            spatnaVolbaU = true;
                            continue;
                        }
                            
                        bool nalezena = false;

                        foreach (Ucebna u in chodba.Ucebny)
                        {
                            if (u.Cislo == vstupU && u.Odemceno) 
                            {
                                ZmenaLokace(u, start);
                                spatnaVolbaU = false;
                                nalezena = true;
                                _vUcebne = true;
                            }

                            if (u.Cislo == vstupU && u.Odemceno == false)
                            {
                                vypisy.SmazObsahKonzole();
                                vypisy.VypisDoKonzole(Vypisy.UzamcenaUcebna);
                                nalezena = true; 
                            }
                        }
                            
                        if (nalezena == false)
                        {
                            vypisy.SmazObsahKonzole();
                            vypisy.VypisDoKonzole(Vypisy.UcebnaNeexistuje);
                        }

                    } while (spatnaVolbaU);
                }
                
                else
                {
                    int? vstupP;

                    try
                    {
                        vstupP = Convert.ToInt32(vstup);
                    }
                    catch (FormatException)
                    {
                        vypisy.SmazObsahKonzole();
                        vypisy.VypisDoKonzole(Vypisy.SpatnyPrikaz);
                        continue;
                    }
                    catch (OverflowException)
                    {
                        vypisy.SmazObsahKonzole();
                        vypisy.VypisDoKonzole(Vypisy.SpatnyPrikaz);
                        continue;
                    }
                    
                    foreach (Lokace l in start.Lokace)
                    {
                        if (l.Patro == vstupP && l is Chodba)
                        {
                            ZmenaLokace(l, start);
                            spatnaVolba = false;
                        }

                        if (vstupP == 9 && l is Prujezd)
                        {
                            ZmenaLokace(l, start);
                            spatnaVolba = false;
                        }
                    }

                    if (vstupP == 4)
                    {
                        vypisy.VypisDoKonzole(Vypisy.PresunDo4Np);
                        spatnaVolba = true;
                    }

                    if (vstupP > 4 && vstupP != 9)
                    {
                        vypisy.VypisDoKonzole(Vypisy.PatroNeexistuje);
                        spatnaVolba = true;
                    }
                }

            } while (spatnaVolba && _vUcebne == false);
    }
}
