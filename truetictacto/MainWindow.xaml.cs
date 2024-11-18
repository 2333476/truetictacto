using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace truetictacto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //for the method GamePlayedLabel(), WinRatioX() and WinRatioO()
        private int count = 0;
        private int NumOfWinX = 0;
        private int NumOfWinO = 0;

        Board board = new Board();
        PlayerEnum[,] dataStructure = new PlayerEnum[3, 3];


        int row = 0;
        int col = 0;

        public MainWindow(PlayerEnum current)
        {

            InitializeComponent();

            board.SetGameGrid(GameGrid);
            board.SetimgBackground(imgBackground);


            board.ResetBoard();
           
            board.Current = current;

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
            {
            Image clickedImage = (Image)sender;

             row = Grid.GetRow(clickedImage);
             col = Grid.GetColumn(clickedImage);

            if(board.Select(row, col))
            {
                if(board.Current == PlayerEnum.X)
                {
                    clickedImage.Source = new BitmapImage(new Uri("/image_for_tictacto/X.png", UriKind.Relative));
                    dataStructure[row, col] = PlayerEnum.X;

                }
                else if(board.Current == PlayerEnum.O)
                {
                    clickedImage.Source = new BitmapImage(new Uri("/image_for_tictacto/Cercle.png", UriKind.Relative));
                    dataStructure[row, col] = PlayerEnum.O;


                }

                if (board.CheckWin(row, col))
                {
                    if (board.Current == PlayerEnum.X)
                        NumOfWinX++;
                    else
                        NumOfWinO++;

                    MessageBox.Show($"{board.Current} a gagné !");
                        board.ResetGame();
                        GamePlayedLabel();
                    WinRatioO();
                    WinRatioX();
                    return;
                    
                }
                else if(board.Draw())
                {
                    board.ResetGame();
                    GamePlayedLabel();
                    return;

                }
                else
                {
                    board.Turn();
                    TurnLabel();
                    
                }


            }



        }
        

        private void stkInfo_Loaded(object sender, RoutedEventArgs e)
        {
           
            GamePlayedLabel();
            TurnLabel();

        }
        private void TurnLabel()
        {
            if (board.Current == PlayerEnum.X)
            {
                lblTurn.Content = "Turn: Player X";
            }
            else
            {
                lblTurn.Content = "Turn: Player O";
            }
        }
        private int GamePlayedLabel()
        {
            

            lblGamePlayed.Content = "Games played:" + " " + count;

           return count++;
        }
        private void WinRatioX() {

            if (count > 0)
            {
                lblXWinRatio.Content = "Win Ratio: " + ((NumOfWinO / (double)count) * 100) + "%";
            }
            else
            {
                lblXWinRatio.Content = "Win Ratio: 0%";
            }

        }
        private void WinRatioO() {



            if (count > 0)
            {
                lblOWinRatio.Content = "Win Ratio: " + ((NumOfWinO / (double)count) * 100) + "%";
            }
            else
            {
                lblOWinRatio.Content = "Win Ratio: 0%";
            }

        }



    }
}
