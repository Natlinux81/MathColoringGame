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
        int diceResult;

        private MarkTyp[] mResults;
        private bool mPlayer1Turn;
        

        //Starts a new game an clear all values back to the start
        public void NewGame()
        {     
            cellCounter = 0;
            roundCounter = 1;

            

            // Create a new blanck aray of free cells
            mResults = new MarkTyp[420];

            for (var i = 0; i < mResults.Length; i++)
                mResults[i] = MarkTyp.Free;

            // make sure Player1 is starts The game
            mPlayer1Turn = true;            

            // interate every Cell on the grid
            Container.Children.Cast<CheckBox>().ToList().ForEach(checkbox =>
            {
                // Change background to default values
                checkbox.Background = Brushes.White;                
            });
        }

        // Ends the game
        private void GameEnded()
        {
            if (roundCounter >= 6)
            {
                Round.Text = "5";
                CheckWinner();
                ClearAll();
                NewGame();

                mPlayer1Turn ^= true;

            }
        }

        public void CheckWinner()
        {
            int endResult1 = int.Parse(p1TotalResult.Text);
            int endResult2 = int.Parse(p2TotalResult.Text);

            if (endResult1 > endResult2)
            {
                MessageBox.Show("The Winner is Player 1!");
            }
            if (endResult1 < endResult2)
            {
                MessageBox.Show("The Winner is Player 2!");
            }
            if (endResult1 == endResult2)
            {
                MessageBox.Show("The Game ended in a draw!");
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
            // text to int
            int p1result1 = int.Parse(p1round1.Text);
            int p1result2 = int.Parse(p1round2.Text);
            int p1result3 = int.Parse(p1round3.Text);
            int p1result4 = int.Parse(p1round4.Text);
            int p1result5 = int.Parse(p1round5.Text);

            int p2result1 = int.Parse(p2round1.Text);
            int p2result2 = int.Parse(p2round2.Text);
            int p2result3 = int.Parse(p2round3.Text);
            int p2result4 = int.Parse(p2round4.Text);
            int p2result5 = int.Parse(p2round5.Text);

            int totalResult1 = p1result1 + p1result2 + p1result3 + p1result4 + p1result5;
            p1TotalResult.Text = Convert.ToString(totalResult1);

            int totalResult2 = p2result1 + p2result2 + p2result3 + p2result4 + p2result5;
            p2TotalResult.Text = Convert.ToString(totalResult2);
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


        // Instantiate random number generator.
        private readonly Random dice = new Random();

        // shuffle the dices
        private void BtnRollClick(object sender, RoutedEventArgs e)
        {           
           
            BtnStartRoll.Visibility = Visibility.Hidden;

            Container.Children.Cast<CheckBox>().ToList().ForEach(checkbox =>
            {
                // uncheck all Checkboxes
                checkbox.IsChecked = false;
            });

            string finalImage1 = "Dice9.png";
            string finalImage2 = "Dice2.png";



            // Gernerate Numbers in Range
            int number1 = dice.Next(2, 10);
            int number2 = dice.Next(2, 10);

            // switch Pictures by case
            switch (number1)
            {
                case 2:
                    finalImage1 = "Dice2.png";
                    break;
                case 3:
                    finalImage1 = "Dice3.png";
                    break;
                case 4:
                    finalImage1 = "Dice4.png";
                    break;
                case 5:
                    finalImage1 = "Dice5.png";
                    break;
                case 6:
                    finalImage1 = "Dice6.png";
                    break;
                case 7:
                    finalImage1 = "Dice7.png";
                    break;
                case 8:
                    finalImage1 = "Dice8.png";
                    break;
                case 9:
                    finalImage1 = "Dice9.png";
                    break;
                default:
                    finalImage1 = "Dice9.png";
                    break;
            }
            Dice1.ImageSource = new BitmapImage(new Uri("Images/" + finalImage1, UriKind.Relative));

            switch (number2)
            {
                case 2:
                    finalImage2 = "Dice2.png";
                    break;
                case 3:
                    finalImage2 = "Dice3.png";
                    break;
                case 4:
                    finalImage2 = "Dice4.png";
                    break;
                case 5:
                    finalImage2 = "Dice5.png";
                    break;
                case 6:
                    finalImage2 = "Dice6.png";
                    break;
                case 7:
                    finalImage2 = "Dice7.png";
                    break;
                case 8:
                    finalImage2 = "Dice8.png";
                    break;
                case 9:
                    finalImage2 = "Dice9.png";
                    break;
                default:
                    finalImage2 = "Dice9.png";
                    break;
            }
            Dice2.ImageSource = new BitmapImage(new Uri("Images/" + finalImage2, UriKind.Relative));

            diceResult = number1 * number2;
            


        }



        // Handesl Cell click event                  
        private void Button_Click(object sender, RoutedEventArgs e)
        {            
           
            if (diceResult > 0 && diceResult != cellCounter)
            {
            
                
                //cast the sender to Cell
                var checkbox = (CheckBox)sender;
                

                // bind the cells position in the array
                var column = Grid.GetColumn(checkbox);
                var row = Grid.GetRow(checkbox);

                var index = column + (row * 20);

                // dont`t do anything if the cellalready has a value in it
                if (mResults[index] != MarkTyp.Free)
                    return;

                // set the cell value based on which players turn it is (Compact if else statement)
                mResults[index] = mPlayer1Turn ? MarkTyp.Player1Red : MarkTyp.Player2Blue;

                // set cell color to the result
                checkbox.Background = mPlayer1Turn ? Brushes.Red : Brushes.Blue;               
                //count selectet cells per player
                CountCells();
            }


        }

        // Handel count cells
        private void BtnEndTurnClick(object sender, RoutedEventArgs e)
        {
            BtnStartRoll.Visibility = Visibility.Visible;

            diceResult = 0;

            // check how many cells the Player marks
            PlayerResult();

            //count rounds
            CountRounds();

            // Check if game is end
            GameEnded();

            mPlayer1Turn ^= true;            

            cellCounter = 0;
        }


        // CheckBox check by holding MousButton
        private void CheckBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var checkbox = sender as CheckBox;
                if (checkbox != null)
                {
                    checkbox.IsChecked = !checkbox.IsChecked;
                    checkbox.ReleaseMouseCapture();                    
                }
            }
        }

        private void CheckBox_MouseEnter(object sender, MouseEventArgs e)
        {
            var checkbox = sender as CheckBox;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (checkbox != null)
                {
                    checkbox.IsChecked = !checkbox.IsChecked;
                }
            }
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
    }   
}

       
        

