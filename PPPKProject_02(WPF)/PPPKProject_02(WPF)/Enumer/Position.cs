using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPKProject_02_WPF_.Enumer
{
    public class Position
    {
        public int IDPosition { get; set; }
        public string Title { get; set; }

        public override string ToString() => $"{Title}";
    }
}
