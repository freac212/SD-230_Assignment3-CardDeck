using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_SD230_PlayingCards
{
    class Program
    {
        static void Main(string[] args)
        {
            var deckOfCards = Deck.CreateDeck();

            Deck.DealAllCards(deckOfCards);
            deckOfCards = Deck.ShuffleDeck(deckOfCards);
            Deck.DealAllCards(deckOfCards);
            deckOfCards = Deck.DrawCard(deckOfCards);
            Deck.DealAllCards(deckOfCards);

            Console.ReadLine();
        }
    }

    class Deck
    {
        private static Random RdmNum = new Random();
        const int MaxCards = 52;
        // Length of Ranks * Length of Suites
        // I.e. one of the ranks per Suites.

        public static List<Card> CreateDeck()
        {
            var deck = new List<Card>();

            for (int i = 0; i < Enum.GetValues(typeof(Suites)).Length; i++)
            {
                for (int x = 0; x < Enum.GetValues(typeof(Ranks)).Length; x++)
                {
                    deck.Add(new Card((Suites)i, (Ranks)x));
                }
            }
            // Run through each suite, add all ranks,
            return deck;
        }

        internal static List<Card> ShuffleDeck(List<Card> deckOfCards)
        {
            List<Card> shuffledDeck = new List<Card>();
            // Take the deck of cards 
            // -> get a random index 
            // -> place that card into the shuffled deck
            // -> remove that card from the old deck 
            // -> repeat
            do
            {
                var randomNum = RdmNum.Next(0, deckOfCards.Count());

                shuffledDeck.Add(deckOfCards[randomNum]);
                deckOfCards.RemoveAt(randomNum);
            } while (deckOfCards.Any());

            return shuffledDeck;
        }

        internal static void DealAllCards(List<Card> deckOfCards)
        {
            foreach (var item in deckOfCards)
            {
                Console.Write(item.Value + " of ");
                Console.Write(item.Suite);
                Console.WriteLine();
            }

            Console.WriteLine($"==== DECK COUNT: {deckOfCards.Count} ====");
            Console.WriteLine("====== END OF DECK ======");
            Console.WriteLine();
        }

        internal static List<Card> DrawCard(List<Card> deckOfCards)
        {
            // Print the card into "hand", then remove it from the deck.
            var pickedCard = deckOfCards[deckOfCards.Count() - 1];

            Console.WriteLine($"======= Delt Card: ========");
            Console.WriteLine($"{pickedCard.Value} of {pickedCard.Suite}");
            Console.WriteLine("============================");
            Console.WriteLine();

            deckOfCards.RemoveAt(deckOfCards.Count() - 1);
            return deckOfCards;
        }
    }

    // List of possible Suites
    enum Suites
    {
        Spades,
        Clubs,
        Hearts,
        Diamonds
    }

    // List of possible Values
    // A 2 3 4 5 6 7 8 9 10 J Q K
    enum Ranks
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
    }

    class Card
    {
        public Suites Suite { get; set; }
        public Ranks Value { get; set; }

        public Card(Suites suite, Ranks rank)
        {
            Suite = suite;
            Value = rank;
        }
    }
}
