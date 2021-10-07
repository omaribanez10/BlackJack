using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
namespace BlackJackGame
{
    class Player 
    {

        private static List<Card> hand = new List<Card>(); //Lista que almacenan las cartas que le pertenecen al usuario

        public static List<Card> Hand()//Se retorna las cartas que son del jugador.
        {    
                return hand;  
        }
       
        public static void AddCart(Card card)
        {
            hand.Add(card); //Se agregan las cartas del jugador a la lista
  
        }

        public static void Init(Card card1, Card card2)//Este método agrega las dos primeras cartas que le pertenecen al usuario. 
        {
            AddCart(card1);
            AddCart(card2);

        }

        public static void PedirCarta(Card card)//Al momento de clickear el boton de solicitar carta este es le metodo que se ejecuta
        {
            AddCart(card);
       
        }

        /**
         * Este método valida la sumatoria del score de las cartas tanto del dealer como del jugador. 
         */
        public static int Check(List<Card> hand)
        {
           
           int conteo_blackjack=0;
       
           for(int i=0; i<hand.Count; i++)
            {
                conteo_blackjack += hand[i].score;   
            }
  
            return conteo_blackjack;
        }

    }
}
