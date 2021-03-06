﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace A_star_KNS11._3
{
    class Grid
    {
        public Cell[,] cells;
        public bool[,] Neighbors;
        public bool[,] Checked;
        public Grid()
        {
            this.cells = new Cell[6, 6];
            for(int y = 0; y < cells.GetLength(0); y++ )
            {
                for(int x = 0; x < cells.GetLength(1); x++ )
                {
                    cells[y, x] = new Cell();
                    cells[y, x].column = y;
                    cells[y, x].row = x;//Присваивание расположения клетки
                }
            }
            Neighbors = new bool[cells.GetLength(0), cells.GetLength(1)];
            Checked = new bool[cells.GetLength(0), cells.GetLength(1)];//Инициализируем массив с соседями
        }
        public void SearchPath()
        {
            int endi=0;
            int endj=0;
            int starti = 0;
            int startj = 0;

            for (int i = 0; i < cells.GetLength(0); i++)//Ищем координаты конца
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (cells[i, j].isFinish == true)
                    {
                        endi = i;
                        endj = j;
                        break;
                    }
                }
            }
            
            for (int i = 0; i < cells.GetLength(0); i++)//Ищем координаты начала
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (cells[i, j].isStart == true)
                    {
                        starti = i;
                        startj = j;
                        break;
                    }
                }
            }

            List<Cell> open= new List<Cell>();
            open.Add(cells[starti, startj]);
            Cell startcell;
            List<Cell> close = new List<Cell>();
            int it = 0;

            while (!open.Contains(cells[endi,endj]))//Работаем с соседями
            {
                int min = Int32.MaxValue;
                
                for(int i=0;i<open.Count;i++)
                {
                    if(min<open[i].F)
                    {
                        min = open[i].F;
                        it = i;
                    }
                }

                close.Add(open[it]);
                startcell = open[it];
                open.RemoveAt(it);
                

                //Checked[startcell.column, startcell.row] = true;//Синие соседи(сосед у которого уже искали соседей)
                for (int i = 0; i < cells.GetLength(0); i++)
                {
                    for (int j = 0; j < cells.GetLength(1); j++)
                    {

                        if (//Ищем ближайшего соседа
                            (
                                (startcell.column - 1 == i && startcell.row - 1 == j) ||
                                (startcell.column - 1 == i && startcell.row == j) ||
                                (startcell.column - 1 == i && startcell.row + 1 == j) ||
                                (startcell.column == i && startcell.row + 1 == j) ||
                                (startcell.column + 1 == i && startcell.row + 1 == j) ||
                                (startcell.column + 1 == i && startcell.row == j) ||
                                (startcell.column + 1 == i && startcell.row - 1 == j) ||
                                (startcell.column == i && startcell.row - 1 == j)
                                ) && !close.Contains(cells[i,j])
                                &&cells[i,j].isWalkable)
                        {
                            if (!open.Contains(cells[i, j]))

                            { 
                                open.Add(cells[i, j]);

                                cells[i, j].prevcolumn = startcell.column;
                                cells[i, j].prevrow = startcell.row;//Делаем стрелку на предыдущего

                                
                                // Neighbors[i, j] = true;//зелёные соседи

                                if (//По диагонали или по вртикалям, добавляем 10 или 14
                                    (cells[i, j].row - 1 == cells[i, j].prevrow && cells[i, j].column == cells[i, j].prevcolumn) ||
                                    (cells[i, j].row == cells[i, j].prevrow && cells[i, j].column + 1 == cells[i, j].prevcolumn) ||
                                    (cells[i, j].row + 1 == cells[i, j].prevrow && cells[i, j].column == cells[i, j].prevcolumn) ||
                                    (cells[i, j].row == cells[i, j].prevrow && cells[i, j].column - 1 == cells[i, j].prevcolumn)
                                    )
                                {
                                    cells[i, j].G = cells[cells[i, j].prevcolumn, cells[i, j].prevrow].G + 10;
                                }
                                else
                                {
                                    cells[i, j].G = cells[cells[i, j].prevcolumn, cells[i, j].prevrow].G + 14;
                                }

                                cells[i, j].F = (Math.Abs(cells[i, j].column - endi) 
                                               + Math.Abs(cells[i, j].row - endj)) * 10;//Считаем сколько до конца
                                cells[i, j].H = cells[i, j].G + cells[i, j].F;//Сумма
                            }

                            
                            if(cells[i, j].G<startcell.G)
                            {
                                cells[i, j].prevcolumn = startcell.column;
                                cells[i, j].prevrow = startcell.row;//Делаем стрелку на предыдущего

                                if (//По диагонали или по вртикалям, добавляем 10 или 14
                                    (cells[i, j].row - 1 == cells[i, j].prevrow && cells[i, j].column == cells[i, j].prevcolumn) ||
                                    (cells[i, j].row == cells[i, j].prevrow && cells[i, j].column + 1 == cells[i, j].prevcolumn) ||
                                    (cells[i, j].row + 1 == cells[i, j].prevrow && cells[i, j].column == cells[i, j].prevcolumn) ||
                                    (cells[i, j].row == cells[i, j].prevrow && cells[i, j].column - 1 == cells[i, j].prevcolumn)
                                    )
                                {
                                    cells[i, j].G = cells[cells[i, j].prevcolumn, cells[i, j].prevrow].G + 10;
                                }
                                else
                                {
                                    cells[i, j].G = cells[cells[i, j].prevcolumn, cells[i, j].prevrow].G + 14;
                                }

                                cells[i, j].F = (Math.Abs(cells[i, j].column - endi)
                                               + Math.Abs(cells[i, j].row - endj)) * 10;//Считаем сколько до конца
                                cells[i, j].H = cells[i, j].G + cells[i, j].F;//Сумма
                            }

                            /*if(open.Contains(cells[endi,endj]))
                            {
                                goto point;
                            }*/

                        }
                    }
                }
            }
            //point:
            {
                int tempprevi = cells[endi, endj].prevcolumn;//Обратный поиск путя
                int tempprevj = cells[endi, endj].prevrow;
                int i;
                int j;
                for (; !cells[tempprevi, tempprevj].isStart;)
                {
                    cells[tempprevi, tempprevj].isPath = true;

                    i = cells[tempprevi, tempprevj].prevcolumn;
                    j = cells[tempprevi, tempprevj].prevrow;
                    tempprevi = i;
                    tempprevj = j;
                }
            }

        }
    }
}
