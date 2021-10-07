using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BlackJackGame
{   
    class Dealer
    {
       private static List<Card> deck = new List<Card>(52);   //Lista que almacena el mazo de cartas que genera el juego.
       private static List<Card> hand = new List<Card>();//Lista que almacena las cartas del dealer.
       private static List<Card> deckDesordenado = new List<Card>();//Lista que almacena las cartas una vez que se haya desordenado el mazo.

        public static List<Card> Hand()//Método que retorna la lista de cartas que pertenecen al dealer.
        {
            return hand;
        }

       
        public static void Generate()
        {
            List<string> symbolsList = new List<string>{"2","3","4","5","6","7","8","9","10","J","Q","K","A"};//Lista con los simbolos de cada una de las cartas.
            List<string> suitsList = new List<string>{ "♠", "♦", "♥", "♣" };//Lista con los iconos de las cartas.

            int count = 0;
            foreach (string symbol in symbolsList){ //Se recorren las dos listas, se crean las cartas y se agregan al mazo.
                foreach (string suit in suitsList){
                  
                    Card card = new Card(suit, symbol, count);//Se crea cada carta
                    deck.Add(card);//Se agrega la carta creada a la lista.
                    count++;
                                  
                }
            }

            deckDesordenado = Randomize(deck); //Se desordena el mazo de cartas.
                  
            Player.Init(Deal(deckDesordenado), Deal(deckDesordenado)); //Se inicializa la mano de cartas para el usuario.
            Init(deckDesordenado);//Se inicializa la mano de cartas para el dealer.
            
        }
        public static void PedirCartaPlayer() //Método que se activa cuando el usuario oprime el boton solicitar carta.
        {
            Player.PedirCarta(Deal(deckDesordenado));
        }
        public static void PedirCartaDealer()
        {
            Init(deckDesordenado);
        }
        private static List<Card> Randomize(List<Card> deck)//Método para desordenar el mazo de cartas.
        {
            List<Card> deckDesordenado = new List<Card>(52);
            Random aleatorio = new Random();

            while (deck.Count > 0)
            {
                
                int val = aleatorio.Next(0, deck.Count - 1);
                if(val == 13 || val == 18 || val == 21) {
                    deckDesordenado.Add(deck[deck.Count-1]);
                    deck.RemoveAt(deck.Count - 1);
                }
                else{
                    deckDesordenado.Add(deck[val]);
                    deck.RemoveAt(val);
                }

            }

            return deckDesordenado;
        }
     

        public static Card Deal(List<Card> deck)//Toma la última carta del mazo y se la agrega a la mano del dealer.
        {
            Card ultima = deck.Last();
            deck.RemoveAt(deck.Count - 1);
            return ultima;
        }

        public static void AddCard(Card card)//Agrega la carta a la mano del dealer
        {
            hand.Add(card);
        }

        public static void Init(List<Card> deck)//Cuando se inicia el juego, se le asignan 2 cartas al dealer, pero solo se muestra 1.
        {
            AddCard(Deal(deck));
            AddCard(Deal(deck));

        }
    }

}
