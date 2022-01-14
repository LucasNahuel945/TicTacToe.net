using GUI.ViewModels;
using System;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Collections.Generic;
using System.Windows.Media;

namespace GUI.View
{
    /// <summary>
    /// Lógica de interacción para TicTacToeView.xaml
    /// </summary>
    public partial class TicTacToeView : Window
    {
        private TicTacToeViewModel _vm;
        private Dictionary<int, string> _symbolplayer;
        private MediaPlayer _mediaPlayer;

        public TicTacToeView()
        {
            InitializeComponent();

            this._mediaPlayer = new MediaPlayer();
            StartMusic();

            this._vm = new TicTacToeViewModel();
            DataContext = this._vm;
            
            this._symbolplayer = new Dictionary<int,string>();
            this._symbolplayer.Add(1, "X");
            this._symbolplayer.Add(2, "O");


        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            var position = Convert.ToInt32(btn.Tag);           
            if (this._vm.ExecuteMovement(position))
            {
                PaintView(btn);
                btn.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("La Casilla ya se encuentra pintada, volve a intentar!", "Error");
            }

            var message = _vm.MessageGameEnded();
            if (message != null)
            {
                MessageBoxShow(message);
            }
        }


        private void PaintView(Button sender)
        {
            if (_vm._game.GetIdCurrentPlayer() == 2)
            {
                sender.Content= this._symbolplayer[1];
            }
            else
            {
                sender.Content = this._symbolplayer[2];
            }
        }


        public void MessageBoxShow(string message)
        {
            MessageBoxResult result = MessageBox.Show(message, "TicTacToe", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    ResetGame(); 
                    break;
                case MessageBoxResult.No:
                    this.Close();
                    break;

            }
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }


        public void ResetGame()
        {
            new TicTacToeView().Show();
            this._mediaPlayer.Stop();
            this.Close();
        }

        public void StartMusic()
        {

            string currentDir = Environment.CurrentDirectory;
            string localPath = "../Music/musicaFondo.wav";
            string fullPath = Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath));

            this._mediaPlayer.Open(new Uri(fullPath));
            this._mediaPlayer.Play();
            this._mediaPlayer.Volume = 5 / 100.0f;
        }



    }
}
