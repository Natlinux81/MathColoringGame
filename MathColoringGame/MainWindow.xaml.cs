using System;
using System.Collections.Generic;
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

namespace MathColoringGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnMinimizeClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnMaximizeClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }

        }

        // Instantiate random number generator.
        private readonly Random random = new Random();

        // Gernerates a random number within a range

        public int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }        

        private void BtnRollClick(object sender, RoutedEventArgs e)
        {
            string finalImage1 = "DiceSix.png";
            string finalImage2 = "DiceOne.png";


            int number1 = RandomNumber(1, 13);
            
            // Dice1
            if (number1 == 1)
            {
                finalImage1 = "DiceOne.png";
            }
            else if (number1 == 2)
            {
                finalImage1 = "DiceTwo.png";
            }
            else if (number1 == 3)
            {
                finalImage1 = "DiceThree.png"; ;
            }
            else if (number1 == 4)
            {
                finalImage1 = "DiceFour.png";
            }
            else if (number1 == 5)
            {
                finalImage1 = "DiceFive.png";
            }
            else if (number1 == 6)
            {
                finalImage1 = "DiceSix.png";
            }
            // Dice 2
            else if (number1 == 7)
            {
                finalImage2 = "DiceOne.png";
            }
            else if (number1 == 8)
            {
                finalImage2 = "DiceTwo.png";
            }
            else if (number1 == 9)
            {
                finalImage2 = "DiceThree.png"; ;
            }
            else if (number1 == 10)
            {
                finalImage2 = "DiceFour.png";
            }
            else if (number1 == 11)
            {
                finalImage2 = "DiceFive.png";
            }
            else if (number1 == 12)
            {
                finalImage2 = "DiceSix.png";
            }

            Dice1.ImageSource = new BitmapImage(new Uri("Images/" + finalImage1, UriKind.Relative));
            Dice2.ImageSource = new BitmapImage(new Uri("Images/" + finalImage2, UriKind.Relative));
        }
    }
}

       
        

