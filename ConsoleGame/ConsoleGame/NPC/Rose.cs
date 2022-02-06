using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    static class Rose
    {

        static bool questCompleted;
        static bool questSubmitted;
        static private string NPCNode = "Rose/";

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
            Utility.print(new string[]{"\"Leva subito il tuo naso dai miei petali\" sentite gridare!",
                    "Lupetto fa un salto indietro: \"Tu parli?!\"",
                    "La rosa altezzosa risponde:\"E certo! Io non sono una rosa qualsiasi..\"",
                    "\"Anzi una volta un piccolo grande uomo che sarebbe morto per me..\""});

            Utility.print(new string[]{"\"E disse anche 'Certamente, un qualsiasi passante crederebbe che la mia rosa vi rassomigli,",
                    "ma lei, lei sola, è più importante di tutte voi, perché è lei che ho innaffiata.",
                    "Perché è lei che ho messa sotto la campana di vetro. Perché è lei che ho riparata col paravento.",
                    "Perché è lei che ho ascoltato lamentarsi o vantarsi, o anche qualche volta tacere.' \""});

            Utility.print(new string[]{"La rosa dopo questo discorso altezzoso scoppia in lacrime e vi dice",
                    "\"Vi prego portatemi con voi! Non so che fare qui da sola, voglio tornare a essere importante per qualcuno!\"",
                    "\"Che ne so, potrei sigillare un amore ad esempio!\"",
                    "\"Mi portereste con voi?\""});

            Console.WriteLine(System.IO.File.ReadAllText(@"GeneralTexts\SioNo.txt"));
            switch (Utility.MakeChoice(2))
            {
                case 1:
                    Utility.print(new string[]{"La Rosa commossa vi dice \"Davvero??\"",
                            "\"Grazie mille, avete il cuore d'oro... solo che..\""});
                    progress.SetProgressNode(NPCNode + "Submitted", true);
                    return DoQuest(progress, false);

                case 2:
                    Utility.print(new string[]{"La Rosa singhiozza.. \"Capisco...\""});
                    return Utility.choice.nothing;
            }
            return Utility.choice.nothing;
        }

        private static Utility.choice DoQuest(GameProgress progress, bool intro)
        {
            if (intro)
                Utility.print(new string[]{ "Ripercorrete la strada che vi porta nel campo fiorito",
                    "Tornate a parlare con la Rosa.."});

            Utility.print(new string[]{ "La Rosa dice: \"Voi pensate che basti raccogliermi..\"",
                    "\"Invece una strega cattiva mi ha incatenato a questa terra con un incantesimo..\"",
                    "\"Ho sentito che quella strega è così cattiva che ha reso invisibile la torre di una principessa..\"",
                    "\"Così che il cavaliere innamorato di lei non la potesse più trovare!\""});

            Utility.print(new string[]{ "La Rosa continua: \"Per potermi raccogliere..\"",
                    "\"Dovete rompere l'incantesimo rispondendo a questo indovinello:\"",
                    "\"Esisto solo prima d'essere nato, appena nato son già trapassato. Chi sono?\"",
                    "[Scrivi una risposta...]"}, true, Utility.msDelay, false);

            if (Utility.WriteAnswer("domani", "La rosa non si può raccogliere.."))
            {
                winQuest(progress);
                return Utility.choice.win;
            }
            else
            {
                Utility.print(new string[] { "La Rosa vi guarda tristissima.." });
            }

            return Utility.choice.nothing;
        }

        private static void winQuest(GameProgress progress)
        {
            Utility.print(new string[]{ "La rosa esclama: \"Mi sento libera e piena di vita!\"",
                    "\"Avete rotto l'incantesimo! Adesso potete raccogliermi!\"",
                    "[Hai ottenuto: ROSA]"});
            questCompleted = true;
            progress.SetProgressNode(NPCNode + "Win", true);
            progress.Player.AddInventory("ROSA");
        }
    }
}
