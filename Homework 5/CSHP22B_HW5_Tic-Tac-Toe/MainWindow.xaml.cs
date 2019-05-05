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

namespace CSHP22B_HW5_Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _player;

        public MainWindow()
        {
            InitializeComponent();
            ResetBoard();
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            ResetBoard();
        }

        private List<Button> GetButtons()
        {
            UIElementCollection element = uxGrid.Children;
            List<FrameworkElement> elements = element.Cast<FrameworkElement>().ToList();
            List<Button> buttons = elements.OfType<Button>().ToList();
            return buttons;
        }

        private void ResetBoard()
        {
            _player = "X";
            List<Button> buttons = GetButtons();
            foreach (Button button in buttons)
            {
                button.Content = "";
                button.IsEnabled = true;
            }
            uxTurn.Text = _player + "'s turn";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content.ToString() == "")
            {
                (sender as Button).Content = _player;
                NextPlayer();
            }

            CheckGameOver();
        }

        private void NextPlayer()
        {
            _player = (_player == "X") ? "O" : "X";
            uxTurn.Text = _player + "'s turn";
        }

        private void CheckGameOver()
        {
            List<Button> buttons = GetButtons();
            var board = new Dictionary<string, string>();
            string winner = "";

            foreach (Button button in buttons)
            {
                board.Add(button.Tag.ToString(), button.Content.ToString());
            }

            if      (ThreeInARow(board, ref winner, "0,0", "0,1", "0,2")) { EndGame(winner); }
            else if (ThreeInARow(board, ref winner, "1,0", "1,1", "1,2")) { EndGame(winner); }
            else if (ThreeInARow(board, ref winner, "2,0", "2,1", "2,2")) { EndGame(winner); }
            else if (ThreeInARow(board, ref winner, "0,0", "1,0", "2,0")) { EndGame(winner); }
            else if (ThreeInARow(board, ref winner, "0,1", "1,1", "2,1")) { EndGame(winner); }
            else if (ThreeInARow(board, ref winner, "0,2", "1,2", "2,2")) { EndGame(winner); }
            else if (ThreeInARow(board, ref winner, "0,0", "1,1", "2,2")) { EndGame(winner); }
            else if (ThreeInARow(board, ref winner, "0,2", "1,1", "2,0")) { EndGame(winner); }
            else if (NoMovesLeft(buttons)) { EndGame(""); }
        }

        private bool ThreeInARow(Dictionary<string, string> board, ref string winner, string v1, string v2, string v3)
        {
            bool result = false;

            if (board[v1] != "" && 
                board[v1] == board[v2] &&
                board[v2] == board[v3])
            {
                result = true;
                winner = board[v1];
            }

            return result;
        }

        private bool NoMovesLeft(List<Button> buttons)
        {
            foreach (Button button in buttons)
            {
                if(button.Content.ToString() == "") { return false; }
            }

            return true;
        }

        private void EndGame(string winner)
        {
            List<Button> buttons = GetButtons();
            foreach (Button button in buttons)
            {
                button.IsEnabled = false;
            }

            if (winner == "") { uxTurn.Text = "Stalemate."; }
            else { uxTurn.Text = winner + " won."; }
        }
    }
}
