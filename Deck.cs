using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotsOfFun.Games
{
    public partial class Deck : Component
    {
        public Deck()
        {
            InitializeComponent();
        }

        public Deck(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public enum Suit
        { Hearts, Spades, Diamonds, Clubs };
        public enum FaceValue
        { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };
        private Suit[] m_suits = { Suit.Clubs, Suit.Diamonds, Suit.Hearts, Suit.Spades };
        [Category("Game")]
        [Description("The suits in the deck.")]

        public Suit[] Suits
        {
            get { return m_suits; }
            set
            {
                m_suits = value;
                this.MakeDeck();
            }
        }

        private FaceValue[] m_faceValues = { FaceValue.Ace, FaceValue.Two, FaceValue.Three, FaceValue.Four, FaceValue.Five, FaceValue.Six, FaceValue.Seven, FaceValue.Eight, FaceValue.Nine, FaceValue.Ten, FaceValue.Jack, FaceValue.Queen, FaceValue.King };
        [Category("Game")]
        [Description("The face values in the deck.")]
        public FaceValue[] FaceValues
        {
            get { return m_faceValues; }
            set
            {
                m_faceValues = value;
                this.MakeDeck();
            }

        }
        System.Collections.ArrayList m_cards = new System.Collections.ArrayList();
        public void MakeDeck()
        {
            // Dispose of the existing cards.
            //
            for (int count = 0; count < m_cards.Count; count++)
            {
                ((Card)m_cards[count]).Dispose();
            }
            m_cards.Clear();
            // Add the new cards.
            for (int asuit = 0; asuit < m_suits.Length; asuit++)
            {
                for (int avalue = 0; avalue < m_faceValues.Length; avalue++)
                {
                    m_cards.Add(new Card(m_suits[asuit], m_faceValues[avalue]));
                }
            }
        }
        public void Shuffle()
        {
            System.Random rgen = new System.Random();
            System.Collections.ArrayList newdeck = new System.Collections.ArrayList();
            while (m_cards.Count > 0)
            {
                // Remove one from m_cards.
                int toremove = rgen.Next(0, m_cards.Count - 1);
                Card remove = (Card)m_cards[toremove];
                m_cards.Remove(remove);
                // Add it to the new deck.
                newdeck.Add(remove);
            }
            // Replace old deck with new deck.
            m_cards = newdeck;
        }




        public int Count
        {
            get { return m_cards.Count; }
        }


        public Card this[int indexer]
        {
            get
            {
                if ((indexer >= 0) && (indexer < m_cards.Count))
                {
                    return ((Card)m_cards[indexer]);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index out of range.");
                }
            }
        }

    }
}
