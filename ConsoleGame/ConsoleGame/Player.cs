using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleGame
{
    class Player
    {
        private string name = "";
        private List<string> inventory = new List<string>();

        public string Name { get => name; set => name = value; }
        public List<string> Inventory { get => inventory; set => inventory = value; }

        public Player(XmlNode save)
        {
            this.name = save.SelectSingleNode("//name").InnerText;

            foreach (XmlNode obj in save.SelectNodes("//inventory/obj"))
                this.Inventory.Add(obj.InnerText);
        }

        public Player()
        {
        }

        public void ChooseName()
        {
            Console.WriteLine("Digita il tuo nome e poi premi invio...");
            string name = Console.ReadLine();
            Console.WriteLine("Il tuo nome è " + name + "?");
            Utility.print(new string[] { "1) Si", "2) No" }, false, 1, false);

            switch (Utility.MakeChoice(2))
            {
                case 1:
                    this.name = name;
                    break;

                case 2:
                    ChooseName();
                    break;
            }
        }

        internal void AddInventory(string Item)
        {
            inventory.Add(Item);
            System.IO.File.Open(@"Saves\\" + name + ".xml", System.IO.FileMode.Open).Close();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Saves\\" + name + ".xml");

            XmlElement xmlElement = doc.CreateElement("obj");
            xmlElement.InnerText = Item;
            doc.SelectSingleNode("//Player/inventory").AppendChild(xmlElement);
        }

        internal bool ExistsInInventory(string Item)
        {
             return inventory.Contains(Item);
        }

    }
}
