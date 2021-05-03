using System;
using System.Collections.Generic;
using System.Text;

namespace Monpoke
{
    class Monpoke
    {
        public string Name { get; set; }
        public int AP { get; set; }
        public int HP { get; set; }

        public Monpoke(string name, int attackPower, int hitPoints)
        {
            Name = name;
            AP = attackPower;
            HP = hitPoints;
        }
        
    }
}
