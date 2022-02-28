using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


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

            NewGame();
        }

        int cellCounter;
        int roundCounter;

        private MarkTyp[] mResults;
        private bool mPlayer1Turn;
        //private bool mGameEnded;        

        //Starts a new game an clear all values back to the start
        public void NewGame()

        {
            cellCounter = 0;
            roundCounter = 1;

            // Create a new blanck aray of free cells
            mResults = new MarkTyp[180];

            for (var i = 0; i < mResults.Length; i++)
                mResults[i] = MarkTyp.Free;

            // make sure Player1 is starts The game
            mPlayer1Turn = true;

            // interate every Cell on the grid
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                // Change background to default values
                button.Background = Brushes.White;
            });

            // make sure the game hasn´t finished
            //mGameEnded = false;
        }

        // Ends the game
        private void GameEnded()
        {
            if (roundCounter >= 6)
            {
                Round.Text = "5";
                MessageBox.Show("Ende");
                //mGameEnded = true;
                ClearAll();                
                NewGame();
                mPlayer1Turn ^= true;

            }
        }

        // reset all fields
        private void ClearAll()
        {
            Round.Text = "1";          
            
            p1round1.Text = "0";
            p1round2.Text = "0";
            p1round3.Text = "0";
            p1round4.Text = "0";
            p1round5.Text = "0";
            p1TotalResult.Text = "0";

            p2round1.Text = "0";
            p2round2.Text = "0";
            p2round3.Text = "0";
            p2round4.Text = "0";
            p2round5.Text = "0";
            p2TotalResult.Text = "0";
        }

        // counts the rounds when player2 turn ends
        public void CountRounds()
        {
            if (mPlayer1Turn)
            {

            }
            else
            {
                roundCounter++;
                Round.Text = roundCounter.ToString();
            }
        }

        // add Totalresulst by Player selectet cells
        public void PlayerResult()
        {
            
        }

        // count cells by player click cell
        public void CountCells()
        {           
            if (mPlayer1Turn && roundCounter == 1)
            {
                cellCounter++;
                p1round1.Text = cellCounter.ToString();
            }
            if (!(mPlayer1Turn) && roundCounter == 1)
            {
                cellCounter++;
                p2round1.Text = cellCounter.ToString();
            }

            if (mPlayer1Turn && roundCounter == 2)
            {
                cellCounter++;
                p1round2.Text = cellCounter.ToString();
            }
            if (!(mPlayer1Turn) && roundCounter == 2)
            {
                cellCounter++;
                p2round2.Text = cellCounter.ToString();
            }

            if (mPlayer1Turn && roundCounter == 3)
            {
                cellCounter++;
                p1round3.Text = cellCounter.ToString();
            }
            if (!(mPlayer1Turn) && roundCounter == 3)
            {
                cellCounter++;
                p2round3.Text = cellCounter.ToString();
            }

            if (mPlayer1Turn && roundCounter == 4)
            {
                cellCounter++;
                p1round4.Text = cellCounter.ToString();
            }
            if (!(mPlayer1Turn) && roundCounter == 4)
            {
                cellCounter++;
                p2round4.Text = cellCounter.ToString();
            }

            if (mPlayer1Turn && roundCounter == 5)
            {
                cellCounter++;
                p1round5.Text = cellCounter.ToString();
            }
            if (!(mPlayer1Turn) && roundCounter == 5)
            {
                cellCounter++;
                p2round5.Text = cellCounter.ToString();
            }
        }

        private void BtnExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Drag Window by MouseDown
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        // Minimize the Window on Click MinimizeButton
        private void BtnMinimizeClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // Maximize Window on Click MaximizeButton
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
        private readonly Random dice = new Random();
        
        // shuffle the dices
        private void BtnRollClick(object sender, RoutedEventArgs e)
        {
            string finalImage1 = "DiceSix.png";
            string finalImage2 = "DiceOne.png";

            // Gernerate Numbers in Range
            int number1 = dice.Next(1, 7);
            int number2 = dice.Next(1, 7);

            // switch Pictures by case
            switch (number1)
            {
                case 1:
                    finalImage1 = "DiceOne.png";
                    break;
                case 2:
                    finalImage1 = "DiceTwo.png";
                    break;
                case 3:
                    finalImage1 = "DiceThree.png";
                    break;
                case 4:
                    finalImage1 = "DiceFour.png";
                    break;
                case 5:
                    finalImage1 = "DiceFive.png";
                    break;
               case 6:
                    finalImage1 = "DiceSix.png";
                    break;                    
                default:
                    finalImage1 = "DiceSix.png";
                    break;
            }
            Dice1.ImageSource = new BitmapImage(new Uri("Images/" + finalImage1, UriKind.Relative));

            switch (number2)
            {
                case 1:
                    finalImage2 = "DiceOne.png";
                    break;
                case 2:
                    finalImage2 = "DiceTwo.png";
                    break;
                case 3:
                    finalImage2 = "DiceThree.png";
                    break;
                case 4:
                    finalImage2 = "DiceFour.png";
                    break;
                case 5:
                    finalImage2 = "DiceFive.png";
                    break;
                case 6:
                    finalImage2 = "DiceSix.png";
                    break;
                default:
                    finalImage2 = "DiceOne.png";
                    break;
            }
            Dice2.ImageSource = new BitmapImage(new Uri("Images/" + finalImage2, UriKind.Relative));
        }

        // Handesl Cell click event                  
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //cast the sender to Cell
            var button = (Button)sender;

            // bind the cells position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 10);

            // dont`t do anything if the cellalready has a value in it
            if (mResults[index] != MarkTyp.Free)
                return;

            // set the cell value based on which players turn it is (Compact if else statement)
            mResults[index] = mPlayer1Turn ? MarkTyp.Player1Red : MarkTyp.Player2Blue;

            // set cell color to the result
            button.Background = mPlayer1Turn ? Brushes.Red : Brushes.Blue;

            //count selectet cells per player
            CountCells();                      
        }
        
        // Handel count cells
        private void BtnEndTurnClick(object sender, RoutedEventArgs e)
        {
            // check how many cells the Player marks
            PlayerResult();            

            //count rounds
            CountRounds();

            // Check if game is end
            GameEnded();
            
            mPlayer1Turn ^= true;

            cellCounter = 0;
        }
                
    }   
}

       
        

