using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class FirstChapter
    {
        internal static bool Tell(GameProgress progress)
        {
            Console.Clear();
            Console.WriteLine(System.IO.File.ReadAllText(@"FirstChapterTxt\PrimoCapitolo.txt"));
            Console.ReadLine();

            Utility.print(new string[]{ "Oggi è proprio una bella giornata,",
                "il sole splende e gli uccellini cantano.",
                "Hai deciso di fare una passeggiata.",
                "Stai camminando sola nella foresta quando a un certo punto..",
                "Compare un Lupo!" });

            Console.WriteLine(System.IO.File.ReadAllText(@"FirstChapterTxt\CompareUnLupo.txt"));
            switch (Utility.MakeChoice(3))
            {
                case 1:
                    Utility.print(new string[]{ "Il lupo ti corre dietro fino a raggiungerti..",
                                    "Poi esclama: \"Ma dove scappi! Aspetta! Ho bisogno del tuo aiuto!!\" " });
                    break;

                case 2:
                    Utility.print(new string[]{ "Il lupo ti si avvicina e ti dice: \"Ciao!\" ",
                                    "Poi preoccupato esclama: \"Ho bisogno del tuo aiuto!\"",
                                    "\"Mi potresti aiutare?\" " });
                    break;

                case 3:
                    Utility.print(new string[]{"Il lupo si avvicina e ti guarda... ",
                                    "Poi ti dice: \"Ciao... tutto bene?\" ",
                                    "\"Io no...ho bisogno del tuo aiuto!\" "});
                    break;
            }

            Console.WriteLine(System.IO.File.ReadAllText(@"FirstChapterTxt\MiAiuterai.txt"));
            switch (Utility.MakeChoice(3))
            {
                case 1:
                    Utility.print(new string[]{ "Il lupo ti guarda confuso: \"eh?\" ",
                                    "Poi scuote la testa: \"Vabbè... ho un problema più grave adesso.\"",
                                    "\"Ho perso la mia Volpetta..\"" ,
                                    "\"Doveva tornare nella tana ma è ieri non è tornata...!\"",
                                    "\"Mi potresti aiutare a ritrovarla perfavore?\" " });
                    break;

                case 2:
                    Utility.print(new string[]{ "Il lupo esclama preoccupato: \"Ho perso la mia volpetta!!\" ",
                                    "\"Doveva tornare nella tana ma è ieri non è tornata...!\"",
                                    "\"Mi potresti aiutare a ritrovarla perfavore?\""});
                    break;

                case 3:
                    Utility.print(new string[]{ "Il lupo grida: \"DEVO RITROVARE LA MIA VOLPETTA!!\" ",
                                    "\"Doveva tornare nella tana ma è ieri non è tornata...!\"",
                                    "\"Mi potresti aiutare a ritrovarla perfavore?\""});
                    break;
            }

            Console.WriteLine(System.IO.File.ReadAllText(@"FirstChapterTxt\SiNoForse.txt"));
            switch (Utility.MakeChoice(3))
            {
                case 1:
                    Utility.print(new string[]{ "Il lupo ti lecca e ti dice: \"Grazie mille allora!!\" ",
                                    "\"Hai idee su cosa fare??\" ",
                                    "Ti guarda e comincia a scodinzolare."});
                    break;

                case 2:
                    Utility.print(new string[]{ "Il lupo diventa serio...",
                                    "Mostra i denti...",
                                    "Comincia a ringhiare... ",
                                    "...ti salta addosso e ti sbrana!"});
                    return false;
                case 3:
                    Utility.print(new string[]{ "Il lupo si avvicina...",
                                    "Mostra i denti...",
                                    "Comincia a ringhiare... ",
                                    "Dice: \"Ci tengo molto alla mia volpetta...\""});
                    if (!ConvinceTheWolf()) return false;
                    break;
            }

            FinalChoices();

            Console.Clear();
            Console.WriteLine("Mentre camminate uno a fianco all'altro il lupo dice \"...come ti chiami?\" ");
            Console.WriteLine();
            progress.Player.ChooseName();
            progress.InitProgress();
            Utility.print(new string[]{ "Il lupo ti dice: \"Grazie del tuo aiuto " + progress.Player.Name + "..\" ",
                                    "\"Tu puoi chiamarmi Lupetto!\" "});
            Console.Clear();

            Console.WriteLine(System.IO.File.ReadAllText(@"FirstChapterTxt\FinePrimoCapitolo.txt"));
            Console.ReadLine();

            return true;
        }

        private static void FinalChoices()
        {
            Console.Clear();
            Console.WriteLine(System.IO.File.ReadAllText(@"FirstChapterTxt\ScelteFinali.txt"));
            switch (Utility.MakeChoice(3))
            {
                case 1:
                    Utility.print(new string[]{ "Il lupo dice: \"E NULLA!\" ",
                                    "\"Ieri sera sono tornato nella tana, e la mia Volpetta non c'era..\"",
                                    "\"Ho aspettato tutta la notte e ho ululato il suo nome ai quattro venti!\""});
                    
                    Console.Clear();
                    Console.WriteLine(System.IO.File.ReadAllText(@"FirstChapterTxt\LupoLuna.txt"));
                    Console.ReadLine();

                    Utility.print(new string[]{ "\"Ma non è servito a niente!\"",
                                "\"Sono tanto preoccupato..\""});

                    FinalChoices();
                    break;

                case 2:
                    Utility.print(new string[] { "Il lupo dice: \"Certo! Eccola!\" ", "Ti passa una foto.." });
                    Console.Clear();
                    Console.WriteLine(System.IO.File.ReadAllText(@"FirstChapterTxt\FotoVolpe.txt"));
                    Console.ReadLine();
                    FinalChoices();
                    break;

                case 3:
                    Utility.print(new string[] { "Il lupo sospira mentre guarda l'orizzonte:",
                        "\"Spero tanto di poterla rivedere presto.\"",
                        "Insieme vi incamminate lungo il sentiero..." });
                    break;
            }
        }

        private static bool ConvinceTheWolf()
        {
            Console.WriteLine(System.IO.File.ReadAllText(@"FirstChapterTxt\ConvinciLupo.txt"));
            int choice = Utility.MakeChoice(2);
            switch (choice)
            {
                case 1:
                    Utility.print(new string[]{ "Il lupo ti lecca e ti dice: \"Grazie mille allora!!\" ",
                                    "\"Hai idee su cosa fare??\" ",
                                    "Ti guarda e comincia a scodinzolare."});
                    break;

                case 2:
                    Utility.print(new string[]{ "Il lupo diventa serio...",
                                    "Mostra i denti...",
                                    "Comincia a ringhiare... ",
                                    "...ti salta addosso e ti sbrana!"});
                    return false;
            }
            return true;
        }

    }
}
