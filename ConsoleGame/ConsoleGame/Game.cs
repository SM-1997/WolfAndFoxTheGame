using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleGame
{
    internal class Game
    {
        private GameProgress progress = null;

        internal void Play()
        {
            IntroGame();

            PrepareGame();

            while (true)
            {
                switch (Menu())
                {
                    case 1:
                        WolfStory();
                        break;

                    case 2:
                        Utility.print(new string[]{"Questa è una semplice avventura.",
                            "Quando ti verranno poste delle domande, premi il numero corrispondente per dare la risposta!",
                            "Se ti viene chiesto di scrivere una risposta...",
                            "Basta scriverla e premere invio! Se vuoi smettere di provare basta scrivere \"stop\" e premere invio!",
                            "Quando viene raccontata la storia, premi invio per continuare a leggere.",
                            "Il gioco salverà automaticamente i tuoi progressi.",
                            "E divertiti!"});
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("TAO TAO");
                        Environment.Exit(0);
                        break;
                }

            }
        }

        private void WolfStory()
        {
            while (true)
            {
                switch (progress.getLastChapter())
                {
                    case GameProgress.chapter.chapter1:
                        if (FirstChapter.Tell(progress)) progress.WinChapter(GameProgress.chapter.chapter1);
                        else LoseGame();
                        break;
                    case GameProgress.chapter.chapter2:
                        if (SecondChapter.Tell(progress)) progress.WinChapter(GameProgress.chapter.chapter2);
                        else LoseGame();
                        break;
                    case GameProgress.chapter.chapter3:
                        if (ThirdChapter.Tell(progress)) progress.WinChapter(GameProgress.chapter.chapter3);
                        else LoseGame();
                        break;
                    case GameProgress.chapter.finalChapter:
                        if (LastChapter.Tell(progress)) progress.WinChapter(GameProgress.chapter.finalChapter);
                        else LoseGame();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine(System.IO.File.ReadAllText(@"GeneralTexts\GameCompleted.txt"));
                        Console.ReadLine();
                        return;
                }
            }
        }

        private void PrepareGame()
        {
            if (!System.IO.Directory.Exists(@"Saves"))
                System.IO.Directory.CreateDirectory(@"Saves");

            LoadASave();
        }

        private void LoadASave()
        {
            string[] saves = System.IO.Directory.GetFiles(@"Saves");
            Console.Clear();
            Console.WriteLine("Seleziona un salvataggio :");
            Console.WriteLine();
            Console.WriteLine("1) Nuova Partita");
            Console.WriteLine();
            for (int i = 0; i < saves.Length; i++)
            {
                Console.WriteLine(i + 2 + ") " + saves[i].Split("\\")[1].Replace(".xml", ""));
                Console.WriteLine();
            }

            int choice = Utility.MakeChoice(saves.Length + 1);
            if (choice == 1)
            {
                Utility.Loading();
                setNewGame();
            }
            else
            {
                Utility.Loading();
                LoadSaveInfo(saves[choice - 2]);
            }

        }

        private void setNewGame()
        {
            progress = new GameProgress();
        }

        private void LoadSaveInfo(string saveName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@saveName);
            progress = new GameProgress(doc.SelectSingleNode("//Progress"), doc.SelectSingleNode("//Player"));
        }

        private int Menu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(System.IO.File.ReadAllText(@"GeneralTexts\Menu.txt"));
            return Utility.MakeChoice(3);
        }

        internal void LoseGame()
        {
            Console.Clear();
            Console.WriteLine(System.IO.File.ReadAllText(@"GeneralTexts\LoseGame.txt"));
            Console.ReadLine();
        }

        private void IntroGame()
        {
            Console.WriteLine(System.IO.File.ReadAllText(@"GeneralTexts\TitoliTesta.txt"));
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine();
            Console.Write("Premi invio per continuare...");
            Console.ReadLine();
        }

    }
}
