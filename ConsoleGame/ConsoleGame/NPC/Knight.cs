using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    static class Knight
    {

        static bool questCompleted;
        static bool questSubmitted;
        static private string NPCNode = "Knight/";

        public static void Init(GameProgress progress)
        {
            questCompleted = progress.LoadProgressFromNode(NPCNode + "Win");
            questSubmitted = progress.LoadProgressFromNode(NPCNode + "Submitted");
        }

        public static bool Speak(GameProgress progress)
        {
            if (!questSubmitted)
            {
                return SubmitQuest(progress);
            }
            else if (!questCompleted)
            {
                return DoQuest(progress);
            }
            else
            {
                return true;
            }
        }

        private static bool SubmitQuest(GameProgress progress)
        {
            Console.WriteLine(System.IO.File.ReadAllText(@"SecondChapterTxt\ParlaCavaliere.txt"));

            switch (Utility.MakeChoice(2))
            {
                case 1:
                    Utility.print(new string[]{ "Il cavalierie si toglie l'elmo e con tono altezzoso proclama:",
                        "\"IIIIOOO mi chiamo Ser Belvedere, dalle nobilissime virtù, e sono in missione!\"",
                        "\"Devo andare a salvare la mia amata e bellissima fanciulla, ma ho perso la strada...\"",
                        "\"So di chiedervi un grande sforzo, ma potreste aiutarmi?\""});

                    Console.WriteLine(System.IO.File.ReadAllText(@"SecondChapterTxt\SceltaCavaliere.txt"));
                    switch (Utility.MakeChoice(2))
                    {
                        case 1:
                            questSubmitted = true;
                            progress.SetProgressNode(NPCNode + "Submitted", true);
                            return DoQuest(progress);
                        case 2:
                            Utility.print(new string[] { "Il cavalierie vi lascia passare.. andate oltre." });
                            return false;
                    }
                    break;

                case 2:
                    Utility.print(new string[] { "Il cavalierie vi lascia passare.. andate oltre." });
                    return false;
            }
            return true;
        }

        private static bool DoQuest(GameProgress progress)
        {
            Utility.print(new string[]{ "Il cavaliere dice: \"Come vi ho detto sono in missione di salvataggio!\"",
                    "\"Debbo salvare la mia amata chiusa nella Torre di Bresca!\"",
                    "\"Per caso l'avete vista codesta fortezza??\"",
                    "Vi passa una dipinto.."});

            Console.Clear();
            Console.WriteLine(System.IO.File.ReadAllText(@"SecondChapterTxt\Torre.txt"));
            Console.ReadLine();

            Utility.print(new string[]{ "No, mi dispiace.. non l'ho mai vista, tu Lupetto?",
                                     "Lupetto risponde: \"Nemmeno io!\""});

            Utility.print(new string[]{ "Il cavaliere risponde un po' scuro: \"Non mi sorprende...\" ",
                    "\"La strega che ha rapito la principessa Tara ha reso invisibile quel castello con un incatesimo..\"",
                    "\"Questo si può rompere solo rispondendo correttamente a questo indovinello:\"",
                    "\"Ti tiene in vita, ma lo vedi solo quando il mondo si tinge di bianco. Cos'é?\"",
                    "\"Per caso conoscete la risposta?\"",
                    "[Scrivi una risposta...]"}, true, Utility.msDelay, false);

            if (Utility.WriteAnswer("respiro", "La Torre non appare.."))
            {
                winQuest(progress);
                return true;
            }
            else
            {
                Utility.print(new string[] { "Il cavalierie vi lascia passare.. andate oltre." });
            }

            return false;
        }

        private static void winQuest(GameProgress progress)
        {
            Console.Clear();
            Console.WriteLine(System.IO.File.ReadAllText(@"SecondChapterTxt\Fulmine.txt"));
            Console.ReadLine();

            Utility.print(new string[]{ "Un fulmine solca il cielo e piomba nella valle davanti a voi!",
                    "Laggiù, dov'è caduto, appare la torre del dipinto!",
                    "Il cavaliere esclama: \"QUALE SORTILEGIO! AVETE ROTTO L'INCANTESIMO!\"",
                    "\"Non so come ringraziarvi! Tenete questo!\"",
                    "[Hai ottenuto: SACCO DI MONETE]",
                    "Il cavalierie fischia e manda il cavallo al galoppo verso la torre...",
                    "Mentre si allontana grida:\"Vi ringrazio ancora, per aspera ad astra!\""});
            questCompleted = true;
            progress.SetProgressNode(NPCNode + "Win", true);
            progress.Player.AddInventory("SACCO DI MONETE");
        }
    }
}
