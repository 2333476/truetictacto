using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Controls;


namespace truetictacto
{
    internal class Board
    {

        PlayerEnum[,] dataStructure = new PlayerEnum[3, 3];
        PlayerEnum current;

        public PlayerEnum Current
        {
            get { return current; }
            set { current = value; }
        }

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

        public bool CheckWin(int row, int col)
        {
            if (current == PlayerEnum.NONE)
            {
                return false;
            }
            if (dataStructure[row, 0] == current && dataStructure[row, 1] == current && dataStructure[row, 2] == current)
            {
                return true;
            }

            if (dataStructure[0, col] == current && dataStructure[1, col] == current && dataStructure[2, col] == current)
            {
                return true;
            }

            if (row == col && dataStructure[0, 0] == current && dataStructure[1, 1] == current && dataStructure[2, 2] == current)
            {
                return true;
            }

            if (row + col == 2 && dataStructure[0, 2] == current && dataStructure[1, 1] == current && dataStructure[2, 0] == current)
            {
                return true;
            }

            return false;
        }

        public void ResetBoard()
        {

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    dataStructure[row, col] = PlayerEnum.NONE;
                }
            }


        }
        private Grid gameGrid;
        private Image imgBackground;

        public void SetGameGrid(Grid grid)
        {
            gameGrid = grid;
        }
        public void SetimgBackground(Image img)
        {
            imgBackground = img;
        }

        public void ResetGame()
        {
            ResetBoard();
            /////SOLUTION FORM THE INTERNET/////////////////////////

            foreach (var element in gameGrid.Children)
            {
                if (element is Image image)
                {
                    if (image != imgBackground)
                        ///////////////////////////////////////
                    {
                        image.Source = new BitmapImage(new Uri("/image_for_tictacto/blank_image.png", UriKind.Relative));
                    }
                }
            }

            gameGrid.UpdateLayout();
        }


        public bool Draw()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (dataStructure[row, col] == PlayerEnum.NONE)
                    {
                        return false; 
                    }
                }
            }
            if (!Winner())
            {
                MessageBox.Show("Draw... no player has won");
                ResetGame();
                return true;
            }

            return false; 


        }



        //had to do this method because CheckWin have 2 parameters (row,col)
        //but i could not access them in the Draw method because it is outside the for loops
        public bool Winner()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (CheckWin(row, col)) 
                        return true;
                }
            }
            return false;


        }

    }
}

