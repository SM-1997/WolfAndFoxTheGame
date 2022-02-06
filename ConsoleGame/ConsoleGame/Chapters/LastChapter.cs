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
            Console.WriteLine(System.IO.File.ReadAllText(@"FirstChapterTxt\LastChapter.txt"));
            Console.ReadLine();

            /*
             * La strega ha fatto incantesimo perchè invidiosa => si chiama distanza e vuole separare le cose
             * 'voglio separare le cose che ??'
             * La volpe è invisibile, non può toccarvi e vi dice che gridava ma non la sentivi.
             * Cercava di raggiungervi ma non c'era verso.
             * Che Lupetto gli è mancato tanto e che adesso staremo sempre insieme.
             */

            return true;
        }

    }
}
