using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Utility
    {
        public const int msDelay = 1200;

        public enum choice
        {
            win,
            fail,
            nothing,
            comeBack,
            concluded
        }

        public static int MakeChoice(int numberOfChoice)
        {
            int choice = 0;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= numberOfChoice)
                    return choice;
            }
        }

        public static bool MakeChoice(Func<choice> function)
        {
            while (true)
            {
                switch (function())
                {
                    case choice.win:
                        return true;
                    case choice.fail:
                        return false;
                }
            }
        }

        public static choice MakeChoice(Func<GameProgress, choice> function, GameProgress progress)
        {
            while (true)
            {
                switch (function(progress))
                {
                    case choice.win:
                        return choice.win;
                    case choice.fail:
                        return choice.fail;
                    case choice.comeBack:
                        return choice.comeBack;
                }
            }
        }

        public static void print(string[] phrases)
        {
            Console.Clear();
            foreach (string s in phrases)
            {
                Console.WriteLine(s);
                System.Threading.Thread.Sleep(msDelay);
            }
            Console.ReadLine();
        }

        public static void print(string[] phrases, bool clear, int msDelay, bool readLine)
        {
            if (clear) Console.Clear();
            foreach (string s in phrases)
            {
                Console.WriteLine(s);
                System.Threading.Thread.Sleep(msDelay);
            }
            if (readLine) Console.ReadLine();
        }

        internal static void Loading()
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("Caricamento in Corso");
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);
        }

        internal static bool WriteAnswer(string correctAnswer, string wrongAnswerSentence)
        {
            while (true)
            {
                string attempt = Console.ReadLine();
                if (attempt.ToLower() == "stop") return false;
                if (attempt.ToLower().Contains(correctAnswer.ToLower())) return true;
                else Console.WriteLine(wrongAnswerSentence);
            }
        }

        internal static bool WantComeBack()
        {
            Console.WriteLine("Vuoi tornare indietro o proseguire?");
            Console.WriteLine("1) Tornare indietro \n2) Proseguire ");

            if (MakeChoice(2) == 1)
                return true;
            else
                return false;
        }
    }
}
