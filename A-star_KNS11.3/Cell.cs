using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_star_KNS11._3
{
    class Cell
    {
        
        public int row = 0;
        public int column = 0;
        public bool isWalkable = true;
        public bool isStart = false;
        public bool isFinish = false;
        public int weight = 0;
        public int G=0;
        public int F;
        public int prevrow;
        public int prevcolumn;
        public int H = Int32.MaxValue;
        public bool isPath = false;
    }
}
