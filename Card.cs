using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame
{
    class Card
    {
        //Se declaran las variables con sus respectivos getters and setters de la clase Card.
        public string suit { get; set; }
        public string symbol { get; set; }
        public int score { get; set; }
        public String color { get; set; }
        
        //Constructor de la clase Card.
        public Card(String Suit, String Symbol, int contador)
        {
            suit = Suit;
            symbol = Symbol;

            if (contador >= 26)//Cuando se crean 26 cartas negras el juego entra y crea las 26 rojas 
            {
                color = "Roja";
            }
            else
            {
                color = "Negra";//Se crean las cartas negras
            }

            switch (symbol) //Acá se le asigna el valor numerico a las cartas.
            {
                case "J":
                case "Q":
                case "K":
                    score = 10;
                    break;
                case "A":
                    score = 11;
                    break;
                default:
                    score = Convert.ToInt16(symbol);//Convierto el simbolo de un string a un int solo para la cartas con simbolos numericos "2" => 2.
                    break;
            }
        }

        public Card()
        {
        }
    }
}
