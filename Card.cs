using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace LotsOfFun.Games
{
    public partial class Card : UserControl
    {
        SortedList m_images = new SortedList();
        public Card()
        {
            InitializeComponent();
           

            m_images.Add(Suit.Clubs, new Icon("C:\\Users\\Pc\\source\\repos\\GamesLibrary\\GamesLibrary\\Clubs.ico")); 
            m_images.Add(Suit.Diamonds, new Icon("C:\\Users\\Pc\\source\\repos\\GamesLibrary\\GamesLibrary\\Diamonds.ico"));
            m_images.Add(Suit.Hearts, new Icon("C:\\Users\\Pc\\source\\repos\\GamesLibrary\\GamesLibrary\\Hearts.ico"));
            m_images.Add(Suit.Spades, new Icon("C:\\Users\\Pc\\source\\repos\\GamesLibrary\\GamesLibrary\\Spades.ico"));
            
        }
        public enum FaceValue
        { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };
        public enum Suit
        { Hearts, Spades, Diamonds, Clubs };


        private FaceValue m_faceValue = FaceValue.Two;
        [Category("Game")]
        [Description("Face value of the card.")]
        public FaceValue FaceValues
        {
            get { return m_faceValue; }
            set
            {
                m_faceValue = value;
                this.Refresh();

            }
        }
        private Suit m_suit = Suit.Spades;
        [Category("Game")]
        [Description("Suit (Hearts, Spades, Diamonds, Clubs)")]
        public Suit Suits
        {
            get { return m_suit; }
            set
            {
                m_suit = value;
                this.Refresh();
            }
        }
        private bool m_faceUp = true;
        [Category("Game")]
        [Description("Is the card face up?")]
        public bool FaceUp
        {
            get { return m_faceUp; }
            set
            {
                m_faceUp = value;
                this.Refresh();
            }
        }
        
        private Deck.Suit suit1;
        private Deck.FaceValue faceValue1;

        public Card(Suit suit, FaceValue faceValue) : this()
        {
            m_suit = suit;
            m_faceValue = faceValue;
        }

        public Card(Deck.Suit suit1, Deck.FaceValue faceValue1)
        {
            this.suit1 = suit1;
            this.faceValue1 = faceValue1;
        }
        public const int FixedWidth = 60;
        public const int FixedHeight = 75;

        private void Card_Paint(object sender, PaintEventArgs e)
        {
          
            
                Graphics g = CreateGraphics();
                e.Graphics.DrawRectangle(System.Drawing.Pens.Black, 0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
                if (m_faceUp)
                {
                    BackColor = Color.White;
                    g.DrawString(m_faceValue.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 3, 3);
                    g.DrawIcon((Icon)m_images[m_suit], 14, 40);
                }
                else

                { BackColor = Color.Blue; }
            

           
        }

        private void Card_SizeChanged(object sender, EventArgs e)
        {
            Size = new Size(FixedWidth, FixedHeight);
        }
    }
}
