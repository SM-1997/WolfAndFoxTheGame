using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    static class MushroomHunter
    {

        static bool questCompleted;
        static bool questSubmitted;
        static private string NPCNode = "MushroomHunter/";

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
                return Utility.choice.concluded;
            }
        }

        private static Utility.choice SubmitQuest(GameProgress progress)
        {
            Utility.print(new string[]{ "Vicino al sentiero vedete un ometto seduto su un sasso..",
                    "Con vicino a sé una grande gerla vuota, e l'aria affranta..",
                    "Scuote la testa.."});

            Utility.print(new string[]{ "Lupetto gli corre incontro e gli chiede di Volpetta",
                    "L'ometto risponde \"No, non ho visto nessuno passare oggi.. tranne quella maledetta strega!\"",
                    "\"E' passata volando e solo per dispetto mi ha lanciato un incantesimo.\""});

            Utility.print(new string[]{ "L'ometto continua \"Mi sto scervellando, ma non riesco a trovare la soluzione per romperlo.\"",
                    "\"Per romperlo devo risolvere un indovinello..\"",
                    "\"Ma non ci riesco.. so che non è un problema vostro, ma potreste aiutarmi?\"",
                    "\"Per ricompensarvi non ho niente con me.. se non questo che ho trovato per terra.\"",
                    "[Vi mostra un moschettone per arrampicare]"});

            Console.WriteLine(System.IO.File.ReadAllText(@"GeneralTexts\SioNo.txt"));
            switch (Utility.MakeChoice(2))
            {
                case 1:
                    progress.SetProgressNode(NPCNode + "Submitted", true);
                    return DoQuest(progress, false);

                case 2:
                    Utility.print(new string[]{"Il fungaiolo alza le spalle..",
                            "\"Capisco... non preoccupatevi!\""});
                    return Utility.choice.nothing;
            }
            return Utility.choice.nothing;
        }

        private static Utility.choice DoQuest(GameProgress progress, bool intro)
        {
            if (intro)
                Utility.print(new string[]{ "Ripercorrete la strada che vi porta nel campo fiorito",
                    "Tornate a parlare con la Rosa.."});

            Utility.print(new string[]{ "Il fungaiolo spiega:\"L'indovinello è questo:\"",
                    "\"Belli o brutti li puoi fare, ma a nessuno li puoi mostrare\"",
                    "[Scrivi una risposta...]"}, true, Utility.msDelay, false);

            if (Utility.WriteAnswer("sogni", "Non succede niente.."))
            {
                winQuest(progress);
                return Utility.choice.win;
            }
            else
            {
                Utility.print(new string[]{"Il fungaiolo alza le spalle..",
                            "\"Capisco... non preoccupatevi!\""});
            }

            return Utility.choice.nothing;
        }

        private static void winQuest(GameProgress progress)
        {
            Utility.print(new string[]{ "Cominciano ad apparire funghi grossi e pieni un po' ovunque!",
                    "\"Guardate!! FUNGHI! Avete rotto l'incantesimo, adesso posso raccoglierli finalmente!\"",
                    "[Hai ottenuto: MOSCHETTONE]"});
            questCompleted = true;
            progress.SetProgressNode(NPCNode + "Win", true);
            progress.Player.AddInventory("MOSCHETTONE");
        }
    }
}
