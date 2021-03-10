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
    public partial class Memory : UserControl
    {
        public Memory()
        {
            InitializeComponent();
        }
        private int m_rows = 2;
        [Category("Game")]
        [Description("Number of rows in the grid.")]
        public int Rows
        {
            get
            {
                return m_rows;
            }
            set
            {
                if (value > 0)
                {
                    m_rows = value;
                    this.Refresh();
                }
            }
        }
        private int m_columns = 2;
        [Category("Game")]
        [Description("Number of columns in the grid.")]
        public int Columns
        {
            get { return m_columns; }
            set
            {
                if (value > 0)
                {
                    m_columns = value;
                    this.Refresh();
                }
            }
        }
        private Deck m_deck;
        [Category("Game")]
        [Description("The deck used to fill the grid with cards.")]
        public Deck Deck
        {
            get { return m_deck; }
            set { m_deck = value; }
        }
        private const int m_spacing = 10;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            int height = LotsOfFun.Games.Card.FixedHeight;
            int width = LotsOfFun.Games.Card.FixedWidth;
            this.Width = (width + m_spacing) * m_columns + m_spacing;
            this.Height = (height + m_spacing) * m_rows + m_spacing;
            //this.Refresh();
            Graphics g = this.CreateGraphics();
            for (int row = 0; row < m_rows; row++)
            {
                for (int column = 0; column < m_columns; column++)
                {
                    g.DrawRectangle(System.Drawing.Pens.Gray, column * (width + m_spacing) + m_spacing, row * (height + m_spacing) + m_spacing, width, height);
                }
            }
        }
        private int m_clicks = 0;
        public class GameOverEventArgs : System.EventArgs
        {
            private readonly int m_clicks;
            public GameOverEventArgs(int clicks)
            {
                m_clicks = clicks;
            }
            public int Clicks
            {
                get { return m_clicks; }
            }
        }
        public delegate void
        GameOverHandler(object sender, GameOverEventArgs e);
        public event GameOverHandler GameOver;
        [DefaultEvent("GameOver")]
        
        public class DeckGridIncompatibilityException : System.ApplicationException
        {

            public DeckGridIncompatibilityException() : base() { }
            public DeckGridIncompatibilityException(string message) : base(message) { }
            public DeckGridIncompatibilityException(string message, Exception innerException) : base(message, innerException) { }
        }
        private void CardOver(object sender, System.EventArgs e)
        {
            Card card = (Card)sender;
            card.FaceUp = !card.FaceUp;
            card.Refresh();
            m_clicks++;
            CheckForPair();
            if ((this.Controls.Count == 0) && (GameOver != null))
            {
                GameOver(this, new GameOverEventArgs(m_clicks));
            }
        }

        public void Play()
        {
            foreach (Control control in this.Controls)
            {
                control.Click -= new System.EventHandler(this.CardOver);
            }
            this.Controls.Clear();

            if (m_deck != null)
            {
                if (m_deck.Count != (m_rows * m_columns))
                {
                    throw new DeckGridIncompatibilityException(String.Format("Cards: {0} Cells: {1}", m_deck.Count, m_rows * m_columns));
                }
                m_clicks = 0;
                m_deck.Shuffle();
                int cardCounter = 0;
                for (int row = 0; row < m_rows; row++)
                {
                    for (int column = 0; column < m_columns; column++)
                    {
                        Card card =(Card) m_deck[cardCounter];
                        card.FaceUp = false;
                        card.Click += new System.EventHandler(this.CardOver);
                        this.Controls.Add(card);
                        card.Left = column * (Card.FixedWidth + m_spacing)
                        + m_spacing;
                        card.Top = row * (Card.FixedHeight + m_spacing)
                        + m_spacing;
                        cardCounter++;
                    }
                }
            }
        }
        private void CheckForPair()
        {
            System.Threading.Thread.Sleep(500);
            int nfaceup = 0;
            Card[] cards = new Card[2];
            for (int i = 0; i < this.Controls.Count; i++)
            {
                Card card = (Card)this.Controls[i];
                if (card.FaceUp)
                {
                    cards[nfaceup] = card;
                    nfaceup++;
                }
            }
            if (nfaceup == 2)
            {
                if (cards[0].FaceValues == cards[1].FaceValues)
                {
                    this.Controls.Remove(cards[0]);
                    this.Controls.Remove(cards[1]);
                    cards[0].Click -= new System.EventHandler(this.CardOver);
                    cards[1].Click -= new System.EventHandler(this.CardOver);
                    this.Refresh();
                }
                else
                {
                    cards[0].FaceUp = false;
                }
            }
        }



    }
}
