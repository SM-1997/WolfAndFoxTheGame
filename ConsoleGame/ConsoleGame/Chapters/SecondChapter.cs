using System;

namespace ConsoleGame
{
    internal class SecondChapter
    {
        internal static bool Tell(GameProgress progress)
        {
            Console.Clear();
            Console.WriteLine(System.IO.File.ReadAllText(@"SecondChapterTxt\SecondoCapitolo.txt"));
            Console.ReadLine();

            Utility.print(new string[]{ "Stai seguendo il sentiero, con Lupetto al tuo fianco.",
                "Proprio mentre ti stai chiedendo a cosa andrai incontro che..",
                "Lontano, più avanti sul sentiero vedi una alta e grande figura.." });

            Utility.print(new string[]{ "Vi avvicinate..",
                "Fino a che non riuscite a scorgere meglio chi o cosa è: ",
                "Un grande cavallo bianco bellissimo, con sopra un cavaliere in armatura!" });

            if (!Utility.MakeChoice(FaceTheKnight)) return false;

            Utility.print(new string[]{ "Il cavaliere si gira, vi guarda..",
                "Si alza la visiera dell'elmo e vi dice..",
                "\"Scusatemi immensamente vossignori, non volevo in alcun modo impedirvi di proseguire!\"",
                "\"A dir il vero, mi sono perso in questa selva!\"" });

            Knight.Init(progress);
            Knight.Speak(progress);

            Utility.print(new string[]{ "Lasciate dietro di voi il cavalierie..",
                "Continuate lungo la strada, cominciate a sentire il rumore di un fiume.",
                "Lupetto dice: \"" + progress.Player.Name + ".. non sono mai stato in questa parte di bosco.\"",
                "\"Sento l'acqua che scorre più avanti.. IO NON SO NUOTARE!\"" });

            Utility.print(new string[]{ "Proseguite fino a che non vedete un grande fiume.. sembra profondo!",
                "Lupetto esclama: \"Guarda! C'è un ponte laggiù!\""});
            Console.Clear();
            Console.WriteLine(System.IO.File.ReadAllText(@"SecondChapterTxt\Ponte.txt"));
            Console.ReadLine();

            Utility.print(new string[] { "Vi avvicinate al ponte, state per salirci quando.." });

            Utility.print(new string[]{ "Vi si para davanti un uomo alto e grosso che con aria annoiata dice:",
                "\"Questo è il ponte del nostro Re Cane e della nostra Regina Gatto\"",
                "\"E in nome dei nostri Sovrani per passare dovete pagare 10 monete d'oro!\"" });

            while (true)
            {
                if (Utility.MakeChoice(SpeakToKeeper, progress) == Utility.choice.comeBack)
                {
                    Utility.print(new string[]{ "Tornando indietro ritrovate il cavaliere, che continua a guardarsi intorno.",
                        "Andate a parlarci.." });

                    if (Knight.Speak(progress))
                    {
                        Utility.print(new string[]{ "Ritorni al ponte e il guardiano vi si para davanti",
                            "Ripete la solita frase sul Re Cane e la Regina Gatto e vi porge la mano aperta aspettando il denaro.." });
                    }
                }
                else break;
            }

            Utility.print(new string[]{ "Il guardiano si fa da parte e vi lascia passare!",
                "Lupetto saltella sul ponte:\"Alla faccia del re Cane della regina Gatto!\"",
                "\"" + progress.Player.Name + "...non so come ringraziarti. Senza di te non sarei mai arrivato fin qui.\"",
                "\"..mi manca molto la mia Volpetta... secondo te sta bene vero?\"" });

            Console.WriteLine(System.IO.File.ReadAllText(@"SecondChapterTxt\ConversazioneFinale.txt"));
            switch (Utility.MakeChoice(2))
            {
                case 1:
                    Utility.print(new string[]{ "Lupetto sorride e ti lecca una mano..",
                        "\"Allora andiamo cosa stiamo aspettando?\" e comincia a correre lungo il ponte scodinzolando."});
                    break;
                case 2:
                    Utility.print(new string[]{ "Lupetto si blocca e ti guarda sconsolato.",
                        "I suoi occhi si riempiono di lacrime: \"Volpetta..\"",
                        "\"La troverò. Fosse l'ultima cosa che faccio!\" e comincia a correre sul ponte." });
                    break;
            }

            Console.Clear();
            Console.WriteLine(System.IO.File.ReadAllText(@"SecondChapterTxt\FineSecondoCapitolo.txt"));
            Console.ReadLine();
            return true;
        }

        private static Utility.choice FaceTheKnight()
        {
            Console.WriteLine(System.IO.File.ReadAllText(@"SecondChapterTxt\Cavaliere.txt"));
            switch (Utility.MakeChoice(3))
            {
                case 1:
                    Utility.print(new string[]{ "Ti fai avanti e gli dici",
                        "\"Ei tu! Noi dobbiamo passare! Liberaci la strada marrano!\""});
                    return Utility.choice.win;

                case 2:
                    Utility.print(new string[]{ "Lupetto gli corre incontro mostrando i denti!",
                        "Il cavallo si agita, ma il cavaliere sguaina la spada..",
                        "Lupetto si avvicina ma il cavaliere, veloce e terribile, infilza il povero Lupo." });
                    return Utility.choice.fail;

                case 3:
                    Utility.print(new string[]{ "Ti guardi intorno... non sembra ci siano altre strade!",
                        "Chiedi a Lupetto se conosce altre strade: scuote la testa.",
                        "Sembra non ci siano alternative.." });
                    return Utility.choice.nothing;
            }
            return Utility.choice.nothing;
        }

        private static Utility.choice SpeakToKeeper(GameProgress progress)
        {
            if (progress.Player.ExistsInInventory("SACCO DI MONETE"))
            {
                Console.WriteLine(System.IO.File.ReadAllText(@"SecondChapterTxt\GuardianoConMonete.txt"));
                switch (Utility.MakeChoice(3))
                {
                    case 1:
                        Utility.print(new string[]{"Ti avvicini e gridi:\"Lasciaci passare subito! Dobbiamo salvare una nostra amica!\"",
                        "Il guardiano scocciato ripete:\"Questo è il ponte del nostro Re Cane e della nostra Regina Gatto..\"",
                        "\"E in nome dei nostri Sovrani per passare dovete pagare 10 monete d'oro..\"" ,
                        "\"Queste sono le regole: o pagate o non passate.\""});
                        return Utility.choice.nothing;

                    case 2:
                        Utility.print(new string[]{ "Lo spingi, ma non si smuove di un centrimetro...",
                        "Il guardiano ti guarda male, non sembra aver gradito.."});
                        return Utility.choice.nothing;

                    case 3:
                        Utility.print(new string[]{ "Porgete le monete al guardiano, le accetta e vi lascia passare!",
                        "Attraversate il ponte!"});
                        return Utility.choice.win;
                }
                return Utility.choice.nothing;
            }
            else
            {
                Console.WriteLine(System.IO.File.ReadAllText(@"SecondChapterTxt\Guardiano.txt"));
                switch (Utility.MakeChoice(3))
                {
                    case 1:
                        Utility.print(new string[]{"Ti avvicini e gridi:\"Lasciaci passare subito! Dobbiamo salvare una nostra amica!\"",
                        "Il guardiano scocciato ripete:\"Questo è il ponte del nostro Re Cane e della nostra Regina Gatto..\"",
                        "\"E in nome dei nostri Sovrani per passare dovete pagare 10 monete d'oro..\"" ,
                        "\"Queste sono le regole: o pagate o non passate.\""});
                        return Utility.choice.nothing;

                    case 2:
                        Utility.print(new string[]{ "Lo spingi, ma non si smuove di un centrimetro...",
                        "Il guardiano ti guarda male, non sembra aver gradito.."});
                        return Utility.choice.nothing;

                    case 3:
                        Utility.print(new string[]{ "Tu e Lupetto vi guardate: non c'è niente da fare...",
                        "Tornate indietro.."});
                        return Utility.choice.comeBack;
                }
                return Utility.choice.nothing;
            }

        }

    }
}