using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_star_KNS11._3
{
    class Grid
    {
        public Cell[,] cells;

        public Grid()
        {
            this.cells = new Cell[6, 6];
            for(int y = 0; y < cells.GetLength(0); y++ )
            {
                for(int x = 0; x < cells.GetLength(1); x++ )
                {
                    cells[y, x] = new Cell();
                }
            }
        }
    }
}
