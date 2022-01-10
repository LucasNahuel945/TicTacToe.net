using GUI.ViewModels;
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
using System.Windows.Shapes;

namespace GUI.View
{
    /// <summary>
    /// Lógica de interacción para TicTacToeView.xaml
    /// </summary>
    public partial class TicTacToeView : Window
    {
        private TicTacToeViewModel _vm;
        public TicTacToeView()
        {
            this._vm = new TicTacToeViewModel();
        }


        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            var position = Convert.ToInt32(btn.Tag);
            if (this._vm.Game(position))
            {
                PaintView(btn);
                btn.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                MessageBox.Show("La Casilla ya se encuentra pintada, volve a intentar!", "Error");
            }

            if (_vm._game.GameOver)
            {
                var message = this._vm.MessageStatusGame();
                if(message != "")
                {
                    Message(message);
                }

            }
        }

        private void PaintView(Button sender)
        {
            if (_vm._game.GetIdCurrentPlayer() == 2)
            {
                sender.Content = "X";

            } else { 

                sender.Content = "O";
            }
        }


        public void Message(string message)
        {
            MessageBoxResult result = MessageBox.Show(message, "TicTacToe", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    //hay que reiniciar
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Oh well, too bad!", "My App");
                    break;

            }
        }
    }
}
