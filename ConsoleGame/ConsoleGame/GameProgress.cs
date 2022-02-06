using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleGame
{
    class GameProgress
    {
        private Player player;
        internal Player Player { get => player; }

        public enum chapter
        {
            chapter1,
            chapter2,
            chapter3,
            finalChapter
        }

        private bool winChapter1 = false;
        private bool winChapter2 = false;
        private bool winChapter3 = false;
        private bool winFinalChapter = false;


        public GameProgress(XmlNode progressNode, XmlNode playerNode)
        {
            this.player = new Player(playerNode);
            string s = progressNode.SelectSingleNode("//winChapter1").InnerText;
            this.winChapter1 = bool.Parse(progressNode.SelectSingleNode("//winChapter1").InnerText);
            this.winChapter2 = bool.Parse(progressNode.SelectSingleNode("//winChapter2").InnerText);
            this.winChapter3 = bool.Parse(progressNode.SelectSingleNode("//winChapter3").InnerText);
            this.winFinalChapter = bool.Parse(progressNode.SelectSingleNode("//winFinalChapter").InnerText);
        }

        public GameProgress()
        {
            this.player = new Player();
        }

        public chapter? getLastChapter()
        {
            if (!winChapter1) return chapter.chapter1;
            if (!winChapter2) return chapter.chapter2;
            if (!winChapter3) return chapter.chapter3;
            if (!winFinalChapter) return chapter.finalChapter;
            return null;
        }

        public void WinChapter(chapter c)
        {
            switch (c)
            {
                case chapter.chapter1:
                    this.winChapter1 = true;
                    SetProgressNode("winChapter1", true);
                    break;
                case chapter.chapter2:
                    this.winChapter2 = true;
                    SetProgressNode("winChapter2", true);
                    break;
                case chapter.chapter3:
                    this.winChapter3 = true;
                    SetProgressNode("winChapter3", true);
                    break;
                case chapter.finalChapter:
                    this.winFinalChapter = true;
                    SetProgressNode("winFinalChapter", true);
                    break;
            }
        }

        internal void InitProgress()
        {
            if (System.IO.Directory.GetFiles(@"Saves").FirstOrDefault(x => x == (player.Name + ".xml")) is null)
            {
                System.IO.File.Create(@"Saves\\" + player.Name + ".xml").Close();
                System.IO.File.WriteAllText(@"Saves\\" + player.Name + ".xml", System.IO.File.ReadAllText(@"GeneralTexts\SaveSchema.txt"));
                System.IO.File.Open(@"Saves\\" + player.Name + ".xml", System.IO.FileMode.Open).Close();
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(@"Saves\\" + player.Name + ".xml");
            SetValueNode("//Player/name", player.Name);
            
            doc.Save(@"Saves\\" + player.Name + ".xml");
        }

        internal bool LoadProgressFromNode(string nodeToLoad)
        {
            System.IO.File.Open(@"Saves\\" + player.Name + ".xml", System.IO.FileMode.Open).Close();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Saves\\" + player.Name + ".xml");

            return bool.Parse(doc.SelectSingleNode("//Progress/" + nodeToLoad).InnerText);
        }

        internal void SetProgressNode(string nodeToLoad, bool value)
        {
            System.IO.File.Open(@"Saves\\" + player.Name + ".xml", System.IO.FileMode.Open).Close();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Saves\\" + player.Name + ".xml");

            doc.SelectSingleNode("//Progress/" + nodeToLoad).InnerText = value.ToString();
            doc.Save(@"Saves\\" + player.Name + ".xml");
        }

        internal string LoadValueFromNode(string nodeToLoad)
        {
            System.IO.File.Open(@"Saves\\" + player.Name + ".xml", System.IO.FileMode.Open).Close();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Saves\\" + player.Name + ".xml");

            return doc.SelectSingleNode(nodeToLoad).InnerText;
        }

        internal void SetValueNode(string nodeToLoad, string value)
        {
            System.IO.File.Open(@"Saves\\" + player.Name + ".xml", System.IO.FileMode.Open).Close();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Saves\\" + player.Name + ".xml");

            doc.SelectSingleNode(nodeToLoad).InnerText = value;
            doc.Save(@"Saves\\" + player.Name + ".xml");
        }

    }
}
