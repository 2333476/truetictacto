using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truetictacto
{
    internal class Board
    {
        PlayerEnum[,] dataStructure = new PlayerEnum[3, 3];
        PlayerEnum current;

        public void Turn()
        {
            if (current == PlayerEnum.X)
            {
                current = PlayerEnum.O;
            }
            else
            {
                current = PlayerEnum.X;
            }

        }
          

        
        public bool Select(int row,int col)
        {
            if (dataStructure[row, col] == PlayerEnum.NONE)
            {
            dataStructure[row, col] = current;
                return true; 
            }
            else {

                return false;

            }
        }
        /*
        public bool CheckWin(int row, int col)
        {
            for (int x = 0; x < 3; x++) { 
             
   if ((dataStructure[0 , col] && dataStructure[1, col] && dataStructure[2, col]) == current)
                    {
               
                    }

                
            }
        
            

        }
        */
    }
}

