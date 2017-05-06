using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadSaveExample
{
    public class SaveGame
    {
        public String Player1Name { get; set; }
        public String Player2Name { get; set; }
        public Boolean IsPlayer1Human { get; set; }
        public Boolean IsPlayer2Human { get; set; }


        public Int32 GridWidth { get; set; }
        public Int32 GridHright { get; set; }
        public String Grid { get; set; }
    }
}
