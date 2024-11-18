using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace truetictacto
{
    /// <summary>
    /// Interaction logic for Startup.xaml
    /// </summary>
    public partial class Startup : Window
    {
        PlayerEnum current;
        public Startup()
        {
            InitializeComponent();
        }

        private void Img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //THE METHOD I FOUND ON THE INTERNET
            if (sender is Image clickedImage)
            {
                var imgSource = clickedImage.Source as BitmapSource;

                if (imgSource != null)
                {
                    string uri = imgSource.ToString();

                    if (uri.Contains("X.png"))
                    {
                        current = PlayerEnum.X;
                    }
                    else if (uri.Contains("Cercle.png"))
                    {
                        current = PlayerEnum.O;
                    }
                    else
                    {
                        MessageBox.Show("Eroor : Unrecognized image !");
                        return;
                    }

                  
                    MessageBox.Show($"Player 1 is {current}");

                    
                    MainWindow mainWindowr = new MainWindow(current);
                    mainWindowr.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error : cant read the source of the image !");
                }
            }
            else
            {
                MessageBox.Show("Error : the object clicked is not an image !");
            }
            
            /*
             * THIS METHOD DID NOT WANTED TO WORK SO I SEARCH ON THE INTERNET TO RESOLVE THE PROBLEM
            try
            {
                Image image = (Image)sender;
                BitmapImage imgSource = (BitmapImage)image.Source;

                if (imgSource.UriSource == new Uri("X.png", UriKind.Relative))
                {
                    current = PlayerEnum.X;
                }
                else if (imgSource.UriSource == new Uri("Cercle.png", UriKind.Relative))
                {
                    current = PlayerEnum.O;
                }

                MainWindow mainWindowr = new MainWindow(current);
                mainWindowr.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }
            */

        }
    }
}
