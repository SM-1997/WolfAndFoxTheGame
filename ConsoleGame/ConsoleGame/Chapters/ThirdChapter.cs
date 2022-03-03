using System;

namespace ConsoleGame
{
    internal class ThirdChapter
    {
        internal static bool Tell(GameProgress progress)
        {
            Console.Clear();
            Console.WriteLine(System.IO.File.ReadAllText(@"ThirdChapterTxt\TerzoCapitolo.txt"));
            Console.ReadLine();

            if (!progress.LoadProgressFromNode("ThirdChapter/Intro"))
            {
                Utility.print(new string[]{ "Finite il ponte e vi incamminate lungo un sentiero",
                    "Il sole splende e filtra una luce calda dalle fronde dei rami.",
                    "Lupetto ti cammina a fianco, ogni tanto mette la testa sotto la tua mano."});

                Utility.print(new string[]{ "A un certo punto lungo la via..",
                    "Trovate un incrocio con tre vie: una va a destra, una a sinistra, una continua dritta!",
                    "Lupetto comincia ad annusare...",
                    "\"Sento l'odore di Volpetta!!! Sicuramente è passata di qui... ma non riesco a capire dove sia andata!\""});
                progress.SetProgressNode("ThirdChapter/Intro", true);
            }
            else
            {
                Utility.print(new string[]{ "Lupetto ha sentito l'odore di volpetta quindi deve essere passata di qua...",
                    "Davanti a voi ci sono tre strade: una va a destra, una a sinistra, una continua dritta!"});
            }

            bool loop = true;
            while (loop)
            {
                Utility.print(new string[]{ "Siete all'incrocio..",
                    "Ci sono tre vie: una va a destra, una a sinistra, una continua dritta."});

                Console.WriteLine(System.IO.File.ReadAllText(@"ThirdChapterTxt\3Vie.txt"));
                switch (Utility.MakeChoice(3))
                {
                    case 1:
                        LeftRoad(progress);
                        break;
                    case 2:
                        MiddleRoad(progress);
                        break;
                    case 3:
                        if (RightRoad(progress) == Utility.choice.win)
                            loop = false;
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine(System.IO.File.ReadAllText(@"ThirdChapterTxt\FineTerzoCapitolo.txt"));
            Console.ReadLine();
            return true;
        }

        private static void LeftRoad(GameProgress progress)
        {
            if (!progress.LoadProgressFromNode("ThirdChapter/LeftRoad1"))
            {
                Utility.print(new string[]{ "Vi incamminate lungo la strada a sinistra",
                    "Lupetto sembra più convinto e fiducioso.",
                    "Fino a che.."});
                progress.SetProgressNode("ThirdChapter/LeftRoad1", true);
            }
            else Utility.print(new string[] { "Vi incamminate lungo la strada di sinistra.." });

            if (!progress.LoadProgressFromNode("Bear/Submitted"))
            {
                Utility.print(new string[]{ "Un grande Orso nero si para davanti a voi",
                    "Si siede facendo molto rumore sulla strada e incrocia le braccia pelose e massiccie",
                    "Con voce profonda e lenta dice: \"Hanno rubato il mio miele e nessuno passerà di qui finchè non riavrò il mio miele.\""});

                Utility.print(new string[]{ "Lupetto si fa avanti e dice: \"Ma Orso devo ritrovare la mia Volpetta!\"",
                    "Orso sbuffa e replica: \"E io devo ritrovare il mio miele!\" e incrocia ancora le braccia fuffose."});

                progress.SetProgressNode("Bear/Submitted", true);
            }
            
            if (!progress.LoadProgressFromNode("Bear/Win") && Utility.MakeChoice(SpeakToBear, progress) == Utility.choice.comeBack) return;
            else Utility.print(new string[] { "Siete dall'Orso nero, si sta abboffando di miele contento.." });

            if (Utility.WantComeBack()) return;

            if (!progress.LoadProgressFromNode("ThirdChapter/LeftRoad2"))
            {
                Utility.print(new string[]{ "Lasciate indietro l'Orso Nero fuffoso..",
                    "Lupetto tira un sospiro di sollievo: \"Menomale ci sei tu " + progress.Player.Name + "..\"",
                    "\"Altrimenti non avrei mai riuscito a convincere quel fuffoso testone..\""});

                Utility.print(new string[] { "Continuate nel bosco..",
                    "Sentite un odore umido..",
                    "Sentite l'odore inconfondibile di fungo..",
                    "Lupetto storce il naso.. \"non mi piace questo odore\"" });

                progress.SetProgressNode("ThirdChapter/LeftRoad2", true);
            }

            MushroomHunter.Init(progress);
            if (MushroomHunter.Speak(progress) == Utility.choice.concluded)
                Utility.print(new string[] { "Siete nel bosco pieno di funghi, il fungaiolo è intento a raccoglierli.." });

            if (Utility.WantComeBack()) return;

            if (!progress.LoadProgressFromNode("ThirdChapter/LeftRoad3"))
            {
                Utility.print(new string[]{ "Lasciate indietro il cercatore di funghi dietro di voi..",
                    "Lupetto ti guarda confuso: \"Perchè voi umani siete così ossessionati dai funghi?\"",
                    "Non fai in tempo a rispondere che poco più avanti vedi un'anziana signora a riposare su una panca.."});

                Utility.print(new string[] { "Continuate fino a raggiungerla..",
                    "La vecchia si tiene la testa.. sembra dolorante..",
                    "Lupetto si avvicina e le scondinzola:\"Scusi.. ha mica visto una Volpetta passare di qua?\"" });

                progress.SetProgressNode("ThirdChapter/LeftRoad3", true);
            }

            if (!progress.LoadProgressFromNode("OldWoman/Submitted"))
            {
                Utility.print(new string[]{ "La signora alza lo sguardo:\"No.. mi dispiace..\"",
                    "\"Se fosse passata forse non me ne sarei accorta.. ho troppo malditesta..\"",
                    "Lupetto le risponde:\"Voi umani pensate troppo, ecco perchè vi fa male la testa!\""});

                Utility.print(new string[]{ "La vecchietta, senza che nessuno lo chiedesse, prende fiato e comincia un pippone lunghissimo",
                    "Parlando che lei ha studiato a Tilano, che le fanno male le ossa..",
                    "Che è intollerante al latte, che è un esperta di sicurezza o qualcosa del genere..",
                    "Lupetto annoiato a morte la interrompe bruscamente:\"SIGNORA! Mi dispiace interromperla.. ma dobbiamo andare!\""});

                Utility.print(new string[]{ "La signora lo guarda imbronciata:\"IO HO 20 ANNI!\"",
                    "Lupetto, pur avendo la pelliccia diventa rosso..",
                    "La signora replica:\"Vabbè. Avete qualcosa contro il malditesta?\""});

                progress.SetProgressNode("OldWoman/Submitted", true);
            }

            if (!progress.LoadProgressFromNode("OldWoman/Win")) SpeakToOldWoman(progress);
            else Utility.print(new string[] { "Siete dalla signora che beve la sua tisana,sembra rilassata e tranquilla, vi saluta.." });

            if (Utility.WantComeBack()) return;

            if (!progress.LoadProgressFromNode("ThirdChapter/LeftRoad4"))
            {
                Utility.print(new string[]{ "Lasciate indietro la giovane signora sulla panchina..",
                    "Lupetto dice:\"Quante persone.. Nessuno ha visto Volpetta\"",
                    "\"Eppure ogni tanto sento il suo odore.. Continuamo a cercare!\""});

                Utility.print(new string[] { "Cominciate a vedere attraverso gli alberi un monte davanti a voi..",
                    "Proprio dove la strada comincia ad andare in salita trovate un cartello con scritto \"Montagna del Lago Scaffadolo\"",
                    "\"E' una montagna bellissima, dalla quale si vede l'America, l'Africa, l'Australia...\" e un elenco lunghissimo di paesi."});

                Utility.print(new string[] { "Salite sulla montagna con grande sforzo.. magari da lassù riuscite a vedere Volpetta!",
                    "Arrivate in cima, pronti ad una vista spettacolare..",
                    "C'è una nebbia talmente fitta che non vedete a un palmo dal naso."});

                progress.SetProgressNode("ThirdChapter/LeftRoad4", true);
            }
            else Utility.print(new string[] { "Salite sulla montagna con grande sforzo..",
                    "Magari il tempo si è rasserenato..",
                    "Arrivate in cima ma c'è una nebbia che non si vede niente!",
                    "La strada finise qui.. tornate indietro" });

        }

        private static void MiddleRoad(GameProgress progress)
        {
            if (!progress.LoadProgressFromNode("ThirdChapter/MiddleRoad1"))
            {
                Utility.print(new string[]{ "Vi incamminate lungo la strada centrale",
                    "Lupetto annusa.. sembra sentire qualcosa..",
                    "Più avanti vedete uno strano e grassoccio animale bianco e nero..."});

                Utility.print(new string[]{ "L'animale è un Tasso spanciato al bordo della strada, con un sacco di ammennicoli e cose vicine.",
                    "Ha l'aria di un piantagrane...",
                    "Fa niente.. andate avanti"});

                progress.SetProgressNode("ThirdChapter/MiddleRoad1", true);
            }
            else Utility.print(new string[] { "Vi incamminate lungo la strada centrale.." });

            MikeBadger.Init(progress);
            if (MikeBadger.Speak(progress) == Utility.choice.comeBack) return;
            else Utility.print(new string[] { "Siete da Mike il Tasso in mezzo ai suoi ammenicoli, vi saluta con la zampotta..." });

            if (Utility.WantComeBack()) return;

            if (!progress.LoadProgressFromNode("ThirdChapter/MiddleRoad2"))
            {
                Utility.print(new string[]{ "Lasciate indietro quel pazzo di Mike Il Tasso...",
                    "Il bosco finisce e vi ritrovate in un grande campo fiorito!",
                    "Ci sono milioni di margherite, di non-ti-scordar-di-me e di altri fiori di campo,",
                    "Tantissime farfalle e un bel caldo sole."});

                Utility.print(new string[]{ "Lupetto sembra entusiasta, saltella in mezzo ai fiori e rincorre le farfalle..",
                    "Senti un profumo meraviglioso mentre continui a camminare..",
                    "Fino a che vicino alla strada.. vedi una rosa rossa bellissima, che spicca in mezzo a tutti gli altri fiori."});
                Console.Clear();
                Console.WriteLine(System.IO.File.ReadAllText(@"ThirdChapterTxt\Rosa.txt"));
                Console.ReadLine();
                Utility.print(new string[] { "Anche Lupetto la vede, ci corre vicino per annusarla, ci ficca il nasetto dentro quando.." });

                progress.SetProgressNode("ThirdChapter/MiddleRoad2", true);
            }

            Rose.Init(progress);
            if (Rose.Speak(progress) == Utility.choice.concluded)
                Utility.print(new string[] { "Siete nel campo fiorito dove avete colto la rosa..." });

            if (Utility.WantComeBack()) return;

            if (!progress.LoadProgressFromNode("ThirdChapter/MiddleRoad3"))
            {
                Utility.print(new string[]{ "Uscite dal campo fiorito, il profumo di primavera si allontana...",
                    "Ricomincia il bosco, Lupetto sembra sospettoso..",
                    "Lupetto dice: \"Ho una brutta sensazione..\"",
                    "Proseguite lungo la strada.. guardandovi intorno.."});

                Utility.print(new string[]{ "Vedete che la strada finisce portando un grande Castello, sfarzoso e pieno di arazzi",
                    "Lupetto dice: \"Wow non avevo mai visto una casa così grande!\"",
                    "Camminate assorti guardando il palazzo quando.."});

                Utility.print(new string[]{ "Una talpa spunta dalla terra, proprio davanti a voi!",
                    "Poi un altra! E un altra ancora!",
                    "Ne spuntano tantissime e bloccano la strada!",
                    "La più grande di loro si fa avanti e grida:\"POTA!\""});

                progress.SetProgressNode("ThirdChapter/MiddleRoad3", true);
            }

            if (!progress.LoadProgressFromNode("Mole/Submitted"))
            {
                Utility.print(new string[]{ "Tutte cominciano a gridare: \"POTA! ALTOLA'! POTAPOTA!\"",
                    "Fate qualche passo indietro: \"Che volete?!\"",
                    "La più grande di loro vi grida: \"NON POTETE PASSARE DI QUA, POTA, SIAMO LE GUARDIE DEL CASTELLO!\"",
                    "\"NESSUNO PUO' ENTRARE NELLA REGGIA DEL RE CANE E DELLA REGINA GATTO POTAAAA!!\""});

                Utility.print(new string[]{ "Lupetto spiega:\"Non vogliamo problemi, vogliamo solo ri-trovare Volpetta!\"",
                    "Il capo-Talpa grida: \"POTA NON MI INTERESSANO I TUOI PROBLEMI! POTAPOTA!\"",
                    "\"SE VOLETE PARLARE CON I SOVRANI DOVRETE PORTARE DEI DONI APPROPRIATI!\""});

                progress.SetProgressNode("Mole/Submitted", true);
            }

            if (!progress.LoadProgressFromNode("Mole/Win") && Utility.MakeChoice(SpeakToMole, progress) == Utility.choice.comeBack) return;

            if (!progress.LoadProgressFromNode("ThirdChapter/MiddleRoad4"))
            {
                Utility.print(new string[]{ "Le talpe spariscono sottoterra...",
                    "Tirate un sospiro di sollievo..",
                    "Lupetto sembra eccitato:\"Ma tu conosci questi sovrani?? Magari sanno dove sia Volpetta!!\"",
                    "Proseguite lungo la strada.. arrivate di fronte al castello.."});

                Console.Clear();
                Console.WriteLine(System.IO.File.ReadAllText(@"ThirdChapterTxt\Castello.txt"));
                Console.ReadLine();

                Utility.print(new string[]{ "Le porte si aprono",
                    "Alcuni servitori suonano delle trombe!",
                    "Uno vi si avvicina, prende un bel respiro e vi grida nelle orecchie:\"SIETE DI FRONTE AL RE E LA REGINA!\"",
                    "\"INCHINATEVI DI FRONTE A KING BALU' E QUEEN MINU'!\"",
                    "\"I NOSTRI NOBILISSIMI SOVRANI!\""});

                Utility.print(new string[]{ "Siete entrambi immobili e allibiti...",
                    "Lupetto ti sussurra:\"Quel cane che puzza di profumo e quel gatto ciccione dovrebbero essere il Re e la Regina?\"",
                    "Il servitore di prima grida in faccia a Lupetto: \"SILEEEEENZIO! ADESSO PARLERANNO IL RE E LA REGINA!\""});

                Utility.print(new string[]{ "La regina, spanciata e mezza addormentata sul suo trono sbadiglia..",
                    "Alza la testa e vi guarda..",
                    "Sembra voglia dire qualcosa..",
                    "Apre la bocca..",
                    "\"CCCHEEEEE\""});

                Utility.print(new string[]{ "Il Re, altezzoso come pochi esordisce:\"Ah non mi ero accorto della vostra presenza..\"",
                    "Si accarezza il pelo liscissimo e profumatissimo, si abbassa gli occhiali e vi squadra..",
                    "\"Avete per caso bisogno di qualcosa?\"",
                    "Lupetto sembra parecchio interdetto.."});

                Utility.print(new string[] { "Lupetto si fa avanti:\"Miei sovrani.. Sono qui perchè sto cercando la mia dolce metà..Volpetta\"",
                    "Gli occhi di Lupetto si riempiono di lacrime e la sua voce si rompe..",
                    "\"Però... però non la sto trovando.\"",
                    "\"Ho tanta paura.. mi manca la mia Volpetta.. Non posso vivere senza di lei!\""});

                Utility.print(new string[] { "Nella sala cala il silenzio e i due sovrani sembrano profondamente toccati",
                    "Cominciano a confabulare fra di loro fino a che..",
                    "Queen Minù comincia a parlare:\"Noi... sovrani bellissimi e superiori a tutti voi esseri inferiori..\"",
                    "\"Siamo profondamente toccati da questa sto..\"",
                    "Poi si distrae e comincia a giocare con la tenda del palazzo!"});


                Utility.print(new string[] { "King Balù continua il discorso:\"Siamo dispiaciuti per te e abbiamo deciso di concederti\"",
                    "\"Il lascia passare imperiale!\"",
                    "Hai ottenuto [LASCIAPASSARE]",
                    "King Balù si alza e dice:\"E ADESSO! E' l'ora del bagno, andatevene plebei!\"",
                    "I servitori vi accompagnano fuori dal palazzo.",
                    "La strada finisce qui.. tornate indietro all'incrocio.."});

                progress.Player.AddInventory("LASCIAPASSARE");
                progress.SetProgressNode("ThirdChapter/MiddleRoad4", true);
            }
            else Utility.print(new string[] { "Siete davanti al castello del King Balù e di Queen Minù.. le porte sono chiuse",
                    "La strada finisce qui...",
                    "Tornate indietro"});

        }

        private static Utility.choice RightRoad(GameProgress progress)
        {
            if (!progress.LoadProgressFromNode("ThirdChapter/RightRoad1"))
            {
                Utility.print(new string[]{ "Vi incamminate lungo la strada a destra",
                    "La strada si fa più impervia.. ci sono grandi sassi e rocce ai lati della strada",
                    "A sinistra si alzano sempre più verticali pareti di roccia nuda",
                    "A destra diventa sempre più ripido il dirupo..."});

                Utility.print(new string[]{ "Più avanti sentite chiaccherare alcuni ragazzi",
                    "Lupetto dice:\"Ci sono delle persone qui?? Chissà se hanno visto Volpetta!\"",
                    "Allungate il passo..."});

                Utility.print(new string[]{ "Fate una curva e trovate due ragazzi con grandi zaini guardarsi intorno..",
                    "Sembra stiano cercando qualcosa..",
                    "Lupetto gli va vicino e dice:\"Ciao amici! Avete per caso visto una Volpetta passare di qua??\""});

                progress.SetProgressNode("ThirdChapter/RightRoad1", true);
            }
            else Utility.print(new string[] { "Vi incamminate lungo la strada di destra.." });

            if (!progress.LoadProgressFromNode("Alberti/Submitted"))
            {
                Utility.print(new string[]{ "I due ragazzi si voltano e sorridono:\"No mi dispiace piccolo amico! Nessuna Volpetta!\"",
                    "Lupetto mogio replica:\"Ah.. vabbè. Posso chiedervi cosa state facendo?\"",
                    "Un ragazzo si fa avanti:\"Stiamo arrampicando!! O almeno questo è quello che vorremmo fare..\"",
                    "Lupetto chiede:\"In che senso?\""});

                Utility.print(new string[]{ "Un ragazzo spiega:\"Vedi piccolo amico... Alberto ha perso il moschettone che ci permette di arrampicare!\"",
                    "\"Finchè non lo troviamo non potremmo fare niente..\"",
                    "L'altro ragazzo risponde:\"Io?? Lo hai perso tu Alberto!\"",
                    "Lupetto sembra confuso:\"Aspettate... vi chiamate entrambi Alberto?!\"",
                    "I due Alberto:\"Si!!!\"",
                    "Lupetto piega la testa confuso..."});

                progress.SetProgressNode("Alberti/Submitted", true);
            }

            if (!progress.LoadProgressFromNode("Alberti/Win")) SpeakToAlberti(progress);
            else Utility.print(new string[] { "Siete dai due Alberti che arrampicano, sembrano divertirsi un monte!" });

            if (Utility.WantComeBack()) return Utility.choice.comeBack;

            if (!progress.LoadProgressFromNode("ThirdChapter/RightRoad2"))
            {
                Utility.print(new string[]{ "Lasciate indietro i due Alberti...",
                    "La strada torna a essere più tranquilla",
                    "Lupetto borbotta:\"Ma come fanno due persone a chiamarsi uguali.. ma che cavolo..\""});

                Utility.print(new string[]{ "Continuate a camminare",
                    "Sentite in lontananza profumo di primavera..",
                    "Lupetto esclama: \"" + progress.Player.Name + ".. lo senti anche tu questo odore buonissimo?\"",
                    "Una calda luce vi avvolge.. sentite ridere due ragazzi: un ragazzo e una ragazza.."});

                Utility.print(new string[]{ "Arrivate sulle rive di un lago grandissimo e bellissimo",
                    "Vicino alla strada, stesi su un telo ci sono due ragazzi che ridono, sembrano molto felici..",
                    "Ci andate a parlare.."});

                progress.SetProgressNode("ThirdChapter/RightRoad2", true);
            }

            if (!progress.LoadProgressFromNode("Lovers/Submitted"))
            {
                Utility.print(new string[]{ "Lupetto chiede informazioni ai due ragazzi..",
                    "Rispondono:\"Qui?? Qui siamo sulle rive del lago di Gorda, il lago più grande che c'è! Ahahahaha!\"",
                    "Lupetto ti si avvicina e sussurra:\"A me questi sembrano un po' bevutini..\"",
                    "Il ragazzo vi si avvicina e vi dice sottovoce..."});

                Utility.print(new string[]{ "\"PPSSSSS... Oggi volevo regalare a quella ragazza una rosa e chiederle di filanzarci!\"",
                    "[indica la ragazza stesa sul telo]",
                    "\"Non è bellissima?... Comunque me la sono dimenticata, e non posso chiederglielo senza nemmeno un fiore!\"",
                    "\"Se me ne portate una vi ricompenso con.. con..\"",
                    "Il ragazzo si fruga le tasche... Tu e Lupetto vi guardate confusi...",
                    "\"Questo!\" e vi fa vedere un infuso per fare una tisana \"tanto noi beviamo Spritz!\""});
                progress.SetProgressNode("Lovers/Submitted", true);
            }

            if (!progress.LoadProgressFromNode("Lovers/Win")) SpeakToLovers(progress);
            else Utility.print(new string[] { "Siete dai due ragazzi che ridono sulle rive del Gorda, sembrano davvero innamorati!" });

            if (Utility.WantComeBack()) return Utility.choice.comeBack;

            if (!progress.LoadProgressFromNode("ThirdChapter/RightRoad3"))
            {
                Utility.print(new string[]{ "Camminate e lasciate dietro di voi il lago e i due innamorati..",
                    "Lupetto dice:\"Che carini quei due.. anche io per chiedere a Volpetta di venire nella mia tana..\"",
                    "\"L'ho portata a cena in un ristorante stellato..\"",
                    "\"Dal quale si vedeva tutta Pirenche, la città più bella di voi umani!\"",
                    "\"Eheheh.. non ha saputo dirmi di no!\""});

                Utility.print(new string[]{ "Continuando il sentiero..",
                    "Vedete che la strada termina in un campo, con un grande albero nel mezzo!",
                    "Sotto l' albero c'è una casa lugubre..",
                    "Questa ha un aspetto spettrale e ci sono corvi su tutti i rami dell'albero .."});

                Utility.print(new string[]{ "Due grossi avvoltoio volano di fronte a voi",
                    "Con tono sinistro dicono :\"Fermatevi qui viaggiatori.. questo non è un posto adatto a voi.\"",
                    "Lupetto sembra impaurito, si mette fra le tue gambe.",
                    "Ti sussurra:\"" + progress.Player.Name + " ho paura.. ma sento l'odore di Volpetta!\""});

                Utility.print(new string[]{ "Ti fai avanti:\"Vogliamo passare.. stiamo cercando una Volpe!\"",
                    "Con tono sinistro gli avvoltoi ripetono :\"Fermatevi qui viaggiatori.. questo non è un posto adatto a voi.\""});

                progress.SetProgressNode("ThirdChapter/RightRoad3", true);
            }

            if (Utility.MakeChoice(SpeakToCondors, progress) == Utility.choice.comeBack) return Utility.choice.comeBack;

            Utility.print(new string[] { "Lupetto diventa serio:\"Volpetta deve essere qui da qualche parte.\"",
                "\"Sento il suo odore.. andiamo!\"",
                "Insieme, correte alla casa spettrale.."});

            return Utility.choice.win;
        }


        #region SpeakTo

        private static Utility.choice SpeakToCondors(GameProgress progress)
        {
            Utility.print(new string[] { "Siete davanti agli avvoltoi che vi bloccano la strada..." });

            if (progress.Player.ExistsInInventory("LASCIAPASSARE"))
            {
                Console.WriteLine(System.IO.File.ReadAllText(@"ThirdChapterTxt\CondorConLasciaPassare.txt"));
                switch (Utility.MakeChoice(3))
                {
                    case 1:
                        Utility.print(new string[]{ "Incoraggi Lupetto spaventato..",
                            "Insieme correte incontro agli avvoltoi..",
                            "Vi tirano una beccata in testa per uno e tornate indietro."});
                        return Utility.choice.nothing;

                    case 2:
                        Utility.print(new string[]{ "Gli avvoltoi si guardano basiti..",
                            "\"E' meglio se girate i tacchi e ve ne andate..\""});
                        return Utility.choice.nothing;

                    case 3:
                        Utility.print(new string[]{ "Gli avvoltoi si guardano sbalorditi..",
                            "\"Un lascia passare imperiale..!?\"",
                            "\"Mmmh...\"",
                            "Gli avvoltoi volano via.."});
                        return Utility.choice.win;
                }
            }
            else
            {
                Console.WriteLine(System.IO.File.ReadAllText(@"ThirdChapterTxt\Condor.txt"));
                switch (Utility.MakeChoice(3))
                {
                    case 1:
                        Utility.print(new string[]{ "Incoraggi Lupetto spaventato..",
                            "Insieme correte incontro agli avvoltoi..",
                            "Vi tirano una beccata in testa per uno e tornate indietro."});
                        return Utility.choice.nothing;
                    case 2:
                        Utility.print(new string[]{ "Gli avvoltoi si guardano basiti..",
                            "\"E' meglio se girate i tacchi e ve ne andate..\""});
                        return Utility.choice.nothing;
                    case 3:
                        return Utility.choice.comeBack;
                }
            }
            return Utility.choice.comeBack;
        }

        private static Utility.choice SpeakToLovers(GameProgress progress)
        {
            if (progress.Player.ExistsInInventory("ROSA"))
            {
                Utility.print(new string[] { "Siete vicini al ragazzo innamorato sulla riva del Gorda..." });

                Console.WriteLine(System.IO.File.ReadAllText(@"ThirdChapterTxt\InnamoratoConRosa.txt"));
                switch (Utility.MakeChoice(2))
                {
                    case 1:
                        Utility.print(new string[]{"Il ragazzo esclama:\"Ma è perfetta!\"",
                            "\"Grazie mille: ecco quello che vi avevo promesso..\"",
                            "[Hai ottenuto: INFUSO]",
                            "Il ragazzo si avvicina alla ragazza, le porge la rosa, le parla..",
                            "La ragazza sorride, si alza e lo bacia!"});
                        progress.Player.AddInventory("INFUSO");
                        progress.SetProgressNode("Lovers/Win", true);
                        return Utility.choice.win;
                    case 2:
                        return Utility.choice.nothing;
                }
            }

            Utility.print(new string[] { "Siete vicini al ragazzo innamorato sulla riva del Gorda...",
                "Non potete aiutarlo: non avete una rosa.."});
            return Utility.choice.nothing;
        }

        private static Utility.choice SpeakToAlberti(GameProgress progress)
        {
            if (progress.Player.ExistsInInventory("MOSCHETTONE"))
            {
                Utility.print(new string[] { "Siete vicini agli Alberti che cercano dappertutto il moschettone per arrampicare..." });

                Console.WriteLine(System.IO.File.ReadAllText(@"ThirdChapterTxt\AlbertiConMoschettone.txt"));
                switch (Utility.MakeChoice(2))
                {
                    case 1:
                        Utility.print(new string[]{"I due Alberti saltano di gioia! (sfigati)",
                            "Insieme dicono:\"Grazie Mille amici!! Finalmente possiamo arrampicare!\"",
                            "Un Alberto allunga la mano e vi dice:\"Grazie ragazzi, questo è il minimo con cui posso ricompensarvi!\"",
                            "[Hai ottenuto: CIOCCOLATA]"});
                        progress.Player.AddInventory("CIOCCOLATA");
                        progress.SetProgressNode("Alberti/Win", true);
                        return Utility.choice.win;
                    case 2:
                        return Utility.choice.nothing;
                }
            }

            Utility.print(new string[] { "Siete vicini ali Alberti che cercano dappertutto il moschettone per arrampicare...",
                "Non potete aiutarli: non avete un moschettone.."});
            return Utility.choice.nothing;

        }

        private static Utility.choice SpeakToBear(GameProgress progress)
        {
            Utility.print(new string[] { "Siete davanti all'Orso Nero che blocca la strada..." });

            if (progress.Player.ExistsInInventory("MIELE"))
            {
                Console.WriteLine(System.IO.File.ReadAllText(@"ThirdChapterTxt\OrsoConMiele.txt"));
                switch (Utility.MakeChoice(3))
                {
                    case 1:
                        Utility.print(new string[]{"L'Orso fa gli occhi a cuore e allunga le braccia:",
                            "\"MA E' PROPRIO IL MIO MIELE!! GRAZIE MILLE!!\"" ,
                            "Si fa da parte e comincia a mangiare il miele felice."});
                        progress.SetProgressNode("Bear/Win", true);
                        return Utility.choice.win;

                    case 2:
                        return Utility.choice.comeBack;
                }
                return Utility.choice.nothing;
            }
            else
            {
                Console.WriteLine(System.IO.File.ReadAllText(@"ThirdChapterTxt\Orso.txt"));
                switch (Utility.MakeChoice(2))
                {
                    case 1:
                        Utility.print(new string[]{ "Tu e Lupetto prendete la rincorsa insieme",
                        "Correte forte e spingete ma... rimbalzate sulla pancia dell'Orso nero che incrocia ancora di più le braccia."});
                        return Utility.choice.nothing;
                    case 2:
                        return Utility.choice.comeBack;
                }
                return Utility.choice.nothing;
            }

        }

        private static Utility.choice SpeakToMole(GameProgress progress)
        {
            Utility.print(new string[] { "Siete davanti alle talpe che vi blocca la strada..." });

            if (progress.Player.ExistsInInventory("CIOCCOLATA") && progress.Player.ExistsInInventory("BALSAMO"))
            {
                Console.WriteLine(System.IO.File.ReadAllText(@"ThirdChapterTxt\TalpeConDoni.txt"));
                switch (Utility.MakeChoice(3))
                {
                    case 1:
                        Utility.print(new string[]{ "Alzi le braccia per sembrare più grosso..",
                        "Lupetto mostra i denti e abbassa le orecchie..",
                        "Una talpa grida: \"Qualsiasi cosa stiate facendo siamo cieche POTA!\""});
                        return Utility.choice.nothing;

                    case 2:
                        Utility.print(new string[]{ "Alzi le braccia per sembrare più grosso..",
                        "Lupetto mostra i denti e abbassa le orecchie..",
                        "Una talpa grida: \"Qualsiasi cosa stiate facendo siamo cieche POTA!\""});
                        return Utility.choice.nothing;

                    case 3:
                        Utility.print(new string[]{ "Il capo-Talpa dice: \"Mmmh... sembrano dei doni accettabili..\"",
                        "\"La cioccolata per la nostra tondissima Regina..\"",
                        "\"Il balsamo per il nostro bellissimo Re..\"",
                        "Una talpa grida: \"POTA! FACCIAMOLI PASSARE!\""});
                        progress.SetProgressNode("Mole/Win", true);
                        return Utility.choice.win;
                }
                return Utility.choice.nothing;
            }
            else
            {
                Console.WriteLine(System.IO.File.ReadAllText(@"ThirdChapterTxt\Talpe.txt"));
                switch (Utility.MakeChoice(3))
                {
                    case 1:
                        Utility.print(new string[]{ "Alzi le braccia per sembrare più grosso..",
                        "Lupetto mostra i denti e abbassa le orecchie..",
                        "Una talpa grida: \"Qualsiasi cosa stiate facendo siamo cieche POTA!\""});
                        return Utility.choice.nothing;
                    case 2:
                        Utility.print(new string[]{ "Alzi le braccia per sembrare più grosso..",
                        "Lupetto mostra i denti e abbassa le orecchie..",
                        "Una talpa grida: \"Qualsiasi cosa stiate facendo siamo cieche POTA!\""});
                        return Utility.choice.nothing;
                    case 3:
                        return Utility.choice.comeBack;
                }
                return Utility.choice.nothing;
            }
        }

        private static Utility.choice SpeakToOldWoman(GameProgress progress)
        {
            if (progress.Player.ExistsInInventory("INFUSO"))
            {
                Utility.print(new string[] { "Siete vicini alla ventenne anziana con il malditesta..."});

                Console.WriteLine(System.IO.File.ReadAllText(@"ThirdChapterTxt\DonnaConInfuso.txt"));
                switch (Utility.MakeChoice(3))
                {
                    case 1:
                        Utility.print(new string[] { "Siete vicini alla ventenne anziana col malditesta... le date l'infuso per la tisana",
                            "La giovane anziana esclama:\"UAU! Questo si che mi farà stare meglio!\"",
                            "Lupetto ti sussurra:\"Ma è solo acqua calda calda colorata..\"",
                            "La donna vi sorride:\"Vi ringrazio, vi do questo piccolo dono come segno della mia gratitudine!\""});

                        Utility.print(new string[] { "La giovane anziana vi allunga la mano..",
                            "Avete ottenuto: [BALSAMO]",
                            "La donna vi sorride:\"Tenelo pure! Tanto è per capelli lisci, io come vedete sono ricciola!\""});
                        progress.Player.AddInventory("BALSAMO");
                        progress.SetProgressNode("OldWoman/Win", true);
                        return Utility.choice.win;

                    case 2:
                        return Utility.choice.nothing;
                }
                return Utility.choice.nothing;
            }
            else
            {
                Utility.print(new string[] { "Siete vicini alla ventenne anziana...",
                    "Non potete aiutarla: non avete niente contro il malditesta.."});
                return Utility.choice.nothing;
            }

        }

        #endregion

    }
}