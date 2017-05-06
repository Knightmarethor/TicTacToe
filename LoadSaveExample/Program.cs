using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoadSaveExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var save = new SaveGame()
            {
                Grid = "XOXXOXOXOOX",
                GridHright = 4,
                GridWidth = 6,
                IsPlayer1Human = true,
                IsPlayer2Human = false,
                Player1Name = "Dan",
                Player2Name = "Thatcher"
            };


            var serializer = new XmlSerializer(typeof(SaveGame));
            
            // Save!
            using (var fs = File.Create("MySave.txt"))
            {
                serializer.Serialize(fs, save);
                fs.Flush();
            }


            save.Player1Name = "OMFG";

            // Load!
            using (var fs = File.OpenRead("MySave.txt"))
            {
                save = serializer.Deserialize(fs) as SaveGame;
            }




        }
    }
}
