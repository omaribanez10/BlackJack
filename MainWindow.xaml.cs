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


namespace BlackJackGame
{

    public partial class MainWindow : Window
    {
        private static List<Card> hand_player = new List<Card>();
        private static List<Card> hand_dealer = new List<Card>();

        private static int scorePlayer = 0;
        private static int scoreDealer = 0;
        private static int victorias = 0;
        private static int derrotas = 0;
        private static int contadorVecesUsuarioPideCarta = 1;
      

        public MainWindow()
        {
            InitializeComponent();
            IniciarJuego();
            btnJugarNuevaPartida.Visibility = Visibility.Hidden;
            btnSolicitarCarta.IsEnabled = false;
            btnPlantarse.IsEnabled = false;

        }
        private void IniciarJuego()
        {
            Dealer.Generate();
            btnJugar.IsEnabled = true;
            OcultarCartas();
        }

        private void OcultarCartas()
        {
            CardPlayer1.Visibility = Visibility.Hidden;   
            
            CardPlayer2.Visibility = Visibility.Hidden;
     
            CardPlayer3.Visibility = Visibility.Hidden;
            lblScore3.Content = "";
            lblSymbol3.Content = "";
            lblSuit3.Content = "";
            lblColor3.Content = "";

            CardPlayer4.Visibility = Visibility.Hidden;
            lblScore4.Content = "";
            lblSymbol4.Content = "";
            lblSuit4.Content = "";
            lblColor4.Content = "";

            CardDealer1.Visibility = Visibility.Hidden;

            CardDealer2.Visibility = Visibility.Hidden;
            lblSymbolDealer2.Content = "";
            lblSuitDealer2.Content = "";
            lblColorDealer2.Content = "";
            lblScoreDealer2.Content = "";

            CardDealer3.Visibility = Visibility.Hidden;
            lblSymbolDealer3.Content = "";
            lblSuitDealer3.Content = "";
            lblColorDealer3.Content = "";
            lblScoreDealer3.Content = "";

            CardDealer4.Visibility = Visibility.Hidden;
            lblSymbolDealer4.Content = "";
            lblSuitDealer4.Content = "";
            lblColorDealer4.Content = "";
            lblScoreDealer4.Content = "";

        }

        private void btnJugarNuevaPartida_Click(object sender, RoutedEventArgs e)
        {
            btnJugarNuevaPartida.IsEnabled = false;
            btnSolicitarCarta.IsEnabled = true;
            btnPlantarse.IsEnabled = true;

            hand_player.Clear();
            hand_dealer.Clear();
            IniciarJuego();
            MostrarCartasEnTablero();
            contadorVecesUsuarioPideCarta = 1;
        }


        private void btnJugar_Click(object sender, RoutedEventArgs e)
        {
            
            btnJugar.Visibility = Visibility.Hidden;
            btnSolicitarCarta.IsEnabled = true;
            btnPlantarse.IsEnabled = true;
            MostrarCartasEnTablero();
        }


        private void btnPedir_Click(object sender, RoutedEventArgs e)
        {
            
            Dealer.PedirCartaPlayer();
            hand_player = Player.Hand();
            scorePlayer = Player.Check(hand_player);
            lblPuntajeJugador.Content = scorePlayer;

            switch (contadorVecesUsuarioPideCarta)
            {
                case 1:
                    lblScore3.Content = hand_player[2].symbol;
                    lblSuit3.Content = hand_player[2].suit;
                    lblSymbol3.Content = hand_player[2].symbol;
                    lblColor3.Content = hand_player[2].color;
                    CardPlayer3.Visibility = Visibility.Visible;

                    break;

                case 2:
                    lblScore4.Content = hand_player[3].symbol;
                    lblSuit4.Content = hand_player[3].suit;
                    lblSymbol4.Content = hand_player[3].symbol;
                    lblColor4.Content = hand_player[3].color;
                    CardPlayer4.Visibility = Visibility.Visible;
                    break;
            }

            
            if (scorePlayer == 21)
            {
                TerminarJuego("Felicidades has ganado.", 1);
               
            }
            else if (scorePlayer > 21)
            {
                TerminarJuego("Lo sentimos, has perdido.", 2);      
            }


            contadorVecesUsuarioPideCarta++;
        }
        private void TerminarJuego(String mensaje, int victoriaODerrota)
        {
            MessageBox.Show(mensaje);
            btnSolicitarCarta.IsEnabled = false;
            btnPlantarse.IsEnabled = false;
            btnJugarNuevaPartida.Visibility = Visibility.Visible;
            btnJugarNuevaPartida.IsEnabled = true;

            switch (victoriaODerrota)
            {
                case 1:
                    victorias++;
                    lblGanadas.Content = victorias;
                    break;
                case 2:
                    derrotas++;
                    lblPerdidas.Content = derrotas;
                  
                    break;
                default:
                    break;

            }
        }
        private void MostrarCartasEnTablero()
        {
        
            hand_player = Player.Hand();
            hand_dealer = Dealer.Hand();

            switch (hand_player.Count)
            {
                case 2:
                        lblScore1.Content = hand_player[0].symbol;
                        lblSuit1.Content = hand_player[0].suit;
                        lblSymbol1.Content = hand_player[0].symbol;
                        lblColor1.Content = hand_player[0].color;
                        CardPlayer1.Visibility = Visibility.Visible;

                        lblScore2.Content = hand_player[1].symbol;
                        lblSuit2.Content = hand_player[1].suit;
                        lblSymbol2.Content = hand_player[1].symbol;
                        lblColor2.Content = hand_player[1].color;
                        CardPlayer2.Visibility = Visibility.Visible;

                        lblScoreDealer1.Content = hand_dealer[0].symbol;
                        lblSuitDealer1.Content = hand_dealer[0].suit;
                        lblSymbolDealer1.Content = hand_dealer[0].symbol;
                        lblColorDealer1.Content = hand_dealer[0].color;
                        CardDealer1.Visibility = Visibility.Visible;

                    break;
            }

            scorePlayer = Player.Check(hand_player);
            lblPuntajeJugador.Content = scorePlayer;

            if (scorePlayer == 21)
            {
                TerminarJuego("Felicidades has ganado.", 1);

            }
          
            
        }

        private void btnPlantarse_Click(object sender, RoutedEventArgs e)
        {
            btnSolicitarCarta.IsEnabled = false;
            configurarJuegoDealer(hand_dealer);
        }

        private void configurarJuegoDealer(List<Card> hand_dealer)
        {
            Dealer.PedirCartaDealer();

            int score = 0;
            int marcador = 0;
            for(int i=0; i< hand_dealer.Count; i++)
            {
                score = score + hand_dealer[i].score;
                if (score <= 16 &&  i==0)
                {
                    marcador = hand_dealer[0].score + hand_dealer[1].score;

                    lblScoreDealer2.Content = hand_dealer[1].symbol;
                    lblSuitDealer2.Content = hand_dealer[1].suit;
                    lblSymbolDealer2.Content = hand_dealer[1].symbol;
                    lblColorDealer2.Content = hand_dealer[1].color;
                    CardDealer2.Visibility = Visibility.Visible;
                }
                else if (score <= 16 && i == 1)
                {
                    marcador = hand_dealer[0].score + hand_dealer[1].score + hand_dealer[2].score;
                    lblScoreDealer3.Content = hand_dealer[2].symbol;
                    lblSuitDealer3.Content = hand_dealer[2].suit;
                    lblSymbolDealer3.Content = hand_dealer[2].symbol;
                    lblColorDealer3.Content = hand_dealer[2].color;
                    CardDealer3.Visibility = Visibility.Visible;
                }
                else if (score <= 16 && i == 2)
                {
                    marcador = hand_dealer[0].score + hand_dealer[1].score + hand_dealer[2].score + hand_dealer[3].score;
                    lblScoreDealer4.Content = hand_dealer[3].symbol;
                    lblSuitDealer4.Content = hand_dealer[3].suit;
                    lblSymbolDealer4.Content = hand_dealer[3].symbol;
                    lblColorDealer4.Content = hand_dealer[3].color;
                    CardDealer4.Visibility = Visibility.Visible;
                }
            }

            scoreDealer = marcador;
            lblPuntajeJugador.Content = scorePlayer;

            if (scoreDealer == scorePlayer)
            {
                TerminarJuego("Es un empate.", 3);

            }
            else if (scoreDealer > scorePlayer && scoreDealer<=21)
            {
                TerminarJuego("Lo sentimos has perdido.", 2);

            }
            else if (scoreDealer < scorePlayer || scoreDealer>21)
            {
              
                TerminarJuego("!Felicidades has ganado!.", 1);
               
            }

        }
    }
}