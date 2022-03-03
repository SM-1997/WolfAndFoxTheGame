using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class LastChapter
    {
        internal static bool Tell(GameProgress progress)
        {
            Console.Clear();
            Console.WriteLine(System.IO.File.ReadAllText(@"LastChapterTxt\UltimoCapitolo.txt"));
            Console.ReadLine();

            Utility.print(new string[] { "Insieme.. camminate fino alla casa..",
                   "Arrivate alla porta..",
                   "Lupetto è sempre più convinto: \"" + progress.Player.Name + " è qui! Volpetta è qui!\"",
                   "\"Ne sono certo! Finalmente!!\""});

            Utility.print(new string[] { "\"Entriamo presto!\"",
                   "Aprite la porta ed entrate, cominciate a gridare:\"Volpettaaa!! Dove sei???\"",
                   "Un brivido vi percorre la schiena, una porta si spalanca!",
                   "Una donna brutta e anziana, vestita di nero vi punta contro il suo bastone!"});

            Utility.print(new string[] { "Con voce roca vi dice:\"Come osate entrare nella mia dimora?!\"",
                   "Lupetto si fa avanti e le dice:\"So che Volpetta è qui! La rivoglio indietro! Dov'è?!\"",
                   "\"Se le hai fatto del male la pagherai molto cara!\""});

            Utility.print(new string[] { "La signora sorride con un ghigno inquietante..",
                   "\"Volpetta? Chi? Colei che ami? Che dispiacere sia sparita, così nel nulla!\"",
                   "Lupetto corre da te: \"Ti prego " + progress.Player.Name + " aiutami!\"",
                   "Ti fai avanti.."});


            if (Utility.MakeChoice(speakToWitch, progress) == Utility.choice.win)
            {
                Utility.print(new string[] { "Lupetto ti guarda smarrito e spaventato",
                    "\"Ti prego " + progress.Player.Name + ", siamo nelle tue mani.\"",
                    "La Strega si fa avanti.."});

                Utility.print(new string[]{ "\"L'indovinello è questo:\"",
                    "\"Fa male di più quando è perso, ma anche quando non c'è affatto.\"",
                    "\"Sono il più difficile da esprimere e il più difficile da ignorare.\"",
                    "\"Sono ciò che costa niente e che vale tutto, non pesa nulla ma può durare una vita.\"",
                    "\"Sono ciò che una persona non può possedere ma due possono condividere...\"," +
                    "\"Cosa sono?\"",
                    "[Scrivi una risposta...]"}, true, Utility.msDelay, false);

                Utility.WriteAnswer("amore", "Volpetta non appare..", false);
            }

            Utility.print(new string[] { "La strega scompare in un vortice di fumo mentre vi grida",
                "\"Per questa volta avete vinto!\"",
                "...",
                "...",
                "...",
                "Volpetta appare proprio davanti a voi!!!" });

            Console.Clear();
            Console.WriteLine(System.IO.File.ReadAllText(@"LastChapterTxt\Volpetta.txt"));
            Console.ReadLine();

            Utility.print(new string[] {"Lupetto le corre incontro: \"Volpetta!!\"",
                   "Volpetta:\"Finalmente mi vedete!! Lupetto!!\"",
                   "I due finalmente si riabbracciano e si leccano il musetto."});

            Utility.print(new string[] { "Volpetta vi spiega:\"E' stato orribile..\"",
                   "\"Stavo tornando alla nostra tana ed mi sono sentita svenire..\"",
                   "\"Mi sono svegliata qui tutta sola, con quella brutta strega che mi ha spiegato tutto..\"",
                   "\"E' stato bruttissimo: gridavo ma non mi sentivi, ero davanti a voi ma non mi vedevate..\""});

            Utility.print(new string[] { "\"Ma io sapevo che ce l'avresti fatta Lupetto..\"",
                   "\"Grazie Lupetto.. e grazie anche a te! Chi sei?\"",
                   "Stai per aprire bocca quando Lupetto dice: \"E' " + progress.Player.Name + "!\"",
                   "\"Senza non sarei mai riuscito ad arrivare fin qui..\"",
                   "Lupetto ti guarda felice:\"Ti ringrazio immensamente di aver vinto la Distanza!\""});

            Utility.print(new string[] { "Tutti e tre insieme uscite da quella lugubre casa",
                   "Lupetto ti lecca la mano:\"Le nostre strade qui si separano.. ma ti sarò per sempre debitore.\"",
                   "Volpetta e Lupetto camminano vicini verso la foresta.. \"Torniamo a casa.\""});

            Console.Clear();
            Console.WriteLine(System.IO.File.ReadAllText(@"LastChapterTxt\FineUltimoCapitolo.txt"));
            Console.ReadLine();

            return true;
        }

        private static Utility.choice speakToWitch(GameProgress progress)
        {

            Console.WriteLine(System.IO.File.ReadAllText(@"LastChapterTxt\Strega.txt"));
            switch (Utility.MakeChoice(3))
            {
                case 1:
                    Utility.print(new string[]{"\"Io... io sono...\"",
                        "\"UNA STREGA!\"" ,
                        "\"Il mio nome è...\"",
                        "\"...\"",
                        "\"...\"",
                        "\"...\"",
                        "\"Distanza.\""});
                    Utility.print(new string[]{"\"Il mio destino è sempre stato di essere lontana da tutto e tutti..\"",
                        "\"Voi esseri di questo mondo non apprezzate le cose che avete..\"",
                        "\"..finche non le perdete! Io vi sto facendo solo un favore!\"",
                        "\"Ovunque io guardi vedo solo ingrati che non si meritano ciò che hanno..\"",
                        "\"..e voi sicuramente non sarete diversi!\""});
                    return Utility.choice.nothing;

                case 2:
                    Utility.print(new string[]{ "\"Qui! Vicino a voi!\"",
                        "\"Vi sta chiamando probabilmente, che infausto destino non poterla sentire..\" ",
                        "\"Proprio in questa stanza! Invisibile ai vostri occhi! Inudibile dalle vostre orecchie!\"",
                        "\"Irrangiungibile, anche se sempre con voi!\"",
                        "\"Quale distetta, la distanza eh?\""});
                    return Utility.choice.nothing;

                case 3:
                    Utility.print(new string[]{ "\"Volpetta è nascosta dal mio incantesimo..\"",
                        "\"Per romperlo dovrete risolvere un indovinello..\"",
                        "\"Ma non mi basta.. vi lascerò in pace ad una sola condizione.\"",
                        "\"Avrete 3 tentativi, se li esaurirete senza indovinare Volpetta rimarrà invisibile per sempre!\"",
                        "\"Volete cominciare adesso?\""}, true, Utility.msDelay, false);

                    Console.WriteLine(System.IO.File.ReadAllText(@"GeneralTexts\SioNo.txt"));
                    
                    if (Utility.MakeChoice(2) == 2)
                    {
                        return Utility.choice.nothing;
                    }
                    else
                        return Utility.choice.win;
            }
            return Utility.choice.win;

        }
    }
}
