using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    static class MikeBadger
    {

        static bool questCompleted;
        static bool questSubmitted;
        static private string NPCNode = "MikeBadger/";
        static private IDictionary<string, int> SayingList = new Dictionary<string, int>();

        public static void Init(GameProgress progress)
        {
            questCompleted = progress.LoadProgressFromNode(NPCNode + "Win");
            questSubmitted = progress.LoadProgressFromNode(NPCNode + "Submitted");
        }

        public static Utility.choice Speak(GameProgress progress)
        {
            if (!questSubmitted)
            {
                return SubmitQuest(progress);
            }
            else if (!questCompleted)
            {
                return DoQuest(progress, true);
            }
            else
            {
                return Utility.choice.nothing;
            }
        }

        private static Utility.choice SubmitQuest(GameProgress progress)
        {
            Utility.print(new string[]{ "Il Tasso si butta in mezzo alla strada",
                    "Con aria di sfida dice: \"Ehehe scommetto che non riuscirete a battermi al mio gioco!\"",
                    "Tu e Lupetto vi guardate... in coro rispondete: \"Non ci interessa\" e proseguite"});

            Utility.print(new string[]{ "Il Tasso vi rincorre con affanno",
                    "\"Gno aspettate!! Facciamo un patto: se giocate e vincete vi ricompenserò con del buonissimo miele!\"",
                    "\"Giurin giurello!! Se vincerete vi darò il miele, tant'è vero che mi chiamo Mike!\""});

            Console.WriteLine(System.IO.File.ReadAllText(@"ThirdChapterTxt\ParlaMike.txt"));
            switch (Utility.MakeChoice(2))
            {
                case 1:
                    questSubmitted = true;
                    progress.SetProgressNode(NPCNode + "Submitted", true);
                    return DoQuest(progress, false);
                case 2:
                    Utility.print(new string[] { "Tornate indietro all'incrocio..." });
                    return Utility.choice.comeBack;
            }
            return Utility.choice.nothing;
        }

        private static Utility.choice DoQuest(GameProgress progress, bool intro)
        {
            if (intro)
                Utility.print(new string[]{ "Da lontano vedete Mike il Tasso aspettarvi fiducioso..",
                    "Vi avvicinate e ci parlate.."});

            Utility.print(new string[] { "Il Tasso contento comincia a spiegarvi il gioco gesticolando affannosamente",
                 "\"ALLORA...Il gioco è questo.. io comincio un proverbio! E VOI LO DOVETE FINIRE!\"",
                 "\"Se riuscite a indovinare tutti i proverbi vincerete e vi darò il miele!!\"",
                 "\"Se sbagliate una volta perdete e dovrete ricominciare!\"",
                 "\"Siete pronti??? COMINCIAMO!\""});

            switch (SayingGame())
            {
                case Utility.choice.fail:
                    Utility.print(new string[] { "Avete perso mauhauha!",
                    "Volete rigiocare??"}, true, Utility.msDelay, false);

                    Console.WriteLine(System.IO.File.ReadAllText(@"GeneralTexts\SioNo.txt"));
                    switch (Utility.MakeChoice(2))
                    {
                        case 1:
                            DoQuest(progress, false);
                            break;
                        case 2:
                            Utility.print(new string[] { "Tornate indietro all'incrocio..." });
                            return Utility.choice.comeBack;
                    }
                    break;

                case Utility.choice.win:
                    winQuest(progress);
                    return Utility.choice.win;
            }

            return Utility.choice.nothing;
        }

        private static Utility.choice SayingGame()
        {
            InitializeSayingList();

            if (PlaySayingGame())
                return Utility.choice.win;
            else
                return Utility.choice.fail;
        }

        private static bool PlaySayingGame()
        {
            foreach (KeyValuePair<string, int> kvp in SayingList)
            {
                Utility.print(new string[] { kvp.Key.Split('|')[0] }, true, Utility.msDelay, false);
                string s = "Proverbi/" + kvp.Key.Split('|')[1] + ".txt";
                Console.WriteLine(System.IO.File.ReadAllText(@"ThirdChapterTxt\\Proverbi\\" + kvp.Key.Split('|')[1] + ".txt"));
                if (Utility.MakeChoice(4) != kvp.Value) return false;
            }
            return true;
        }

        private static void InitializeSayingList()
        {
            SayingList.Clear();
            SayingList.Add("Campa Cavallo..|CampaCavallo", 1);
            SayingList.Add("Chi mangia secco..|ChiMangiaSecco", 2);
            SayingList.Add("Da monte Lupo si vede Capraia..|DaMonteLupoSiVedeCapraia", 2);
            SayingList.Add("Ha visto più soffitti lei..|HaVistoPiùSoffittiLei", 1);
            SayingList.Add("Meglio un morto in casa..|MeglioUnMortoInCasa", 3);
            SayingList.Add("Né per scherzo né per burla..|NePerScherzoNePerBurla", 2);
            SayingList.Add("Parlare con te..|ParlareConTe", 3);
            SayingList.Add("Quando l'acqua tocca il culo..|QuandoLacquaToccaIlCulo", 2);
            SayingList.Add("Senza Lilleri..|SenzaLilleri", 1);
        }

        private static void winQuest(GameProgress progress)
        {
            Utility.print(new string[] { "Accipigna ma siete fortissimi!!",
                "Cavolacci... ve lo siete guadagnati! Ecco a voi il miele!",
                "[Hai ottenuto: MIELE]"});

            questCompleted = true;
            progress.SetProgressNode(NPCNode + "Win", true);
            progress.Player.AddInventory("MIELE");
        }
    }
}
