namespace LotsOfFun.Games
{
    partial class Memory1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.card1 = new LotsOfFun.Games.Card();
            this.memory2 = new LotsOfFun.Games.Memory();
            this.deck1 = new LotsOfFun.Games.Deck(this.components);
            this.card2 = new LotsOfFun.Games.Card();
            this.card3 = new LotsOfFun.Games.Card();
            this.card4 = new LotsOfFun.Games.Card();
            this.SuspendLayout();
            // 
            // card1
            // 
            this.card1.BackColor = System.Drawing.Color.White;
            this.card1.FaceUp = true;
            this.card1.FaceValues = LotsOfFun.Games.Card.FaceValue.Ace;
            this.card1.Location = new System.Drawing.Point(71, 52);
            this.card1.Name = "card1";
            this.card1.Size = new System.Drawing.Size(60, 75);
            this.card1.Suits = LotsOfFun.Games.Card.Suit.Spades;
            this.card1.TabIndex = 1;
            // 
            // memory2
            // 
            this.memory2.Columns = 4;
            this.memory2.Deck = null;
            this.memory2.Location = new System.Drawing.Point(59, 41);
            this.memory2.Name = "memory2";
            this.memory2.Rows = 4;
            this.memory2.Size = new System.Drawing.Size(290, 350);
            this.memory2.TabIndex = 0;
            this.memory2.GameOver += new LotsOfFun.Games.Memory.GameOverHandler(this.memory2_GameOver);
            // 
            // deck1
            // 
            this.deck1.FaceValues = new LotsOfFun.Games.Deck.FaceValue[] {
        LotsOfFun.Games.Deck.FaceValue.Jack,
        LotsOfFun.Games.Deck.FaceValue.Ace,
        LotsOfFun.Games.Deck.FaceValue.Queen,
        LotsOfFun.Games.Deck.FaceValue.King};
            this.deck1.Suits = new LotsOfFun.Games.Deck.Suit[] {
        LotsOfFun.Games.Deck.Suit.Hearts,
        LotsOfFun.Games.Deck.Suit.Diamonds,
        LotsOfFun.Games.Deck.Suit.Hearts,
        LotsOfFun.Games.Deck.Suit.Spades};
            // 
            // card2
            // 
            this.card2.BackColor = System.Drawing.Color.White;
            this.card2.FaceUp = true;
            this.card2.FaceValues = LotsOfFun.Games.Card.FaceValue.Jack;
            this.card2.Location = new System.Drawing.Point(209, 135);
            this.card2.Name = "card2";
            this.card2.Size = new System.Drawing.Size(60, 75);
            this.card2.Suits = LotsOfFun.Games.Card.Suit.Hearts;
            this.card2.TabIndex = 2;
            // 
            // card3
            // 
            this.card3.BackColor = System.Drawing.Color.White;
            this.card3.FaceUp = true;
            this.card3.FaceValues = LotsOfFun.Games.Card.FaceValue.King;
            this.card3.Location = new System.Drawing.Point(139, 219);
            this.card3.Name = "card3";
            this.card3.Size = new System.Drawing.Size(60, 75);
            this.card3.Suits = LotsOfFun.Games.Card.Suit.Diamonds;
            this.card3.TabIndex = 3;
            // 
            // card4
            // 
            this.card4.BackColor = System.Drawing.Color.White;
            this.card4.FaceUp = true;
            this.card4.FaceValues = LotsOfFun.Games.Card.FaceValue.Queen;
            this.card4.Location = new System.Drawing.Point(279, 306);
            this.card4.Name = "card4";
            this.card4.Size = new System.Drawing.Size(60, 75);
            this.card4.Suits = LotsOfFun.Games.Card.Suit.Clubs;
            this.card4.TabIndex = 4;
            // 
            // Memory1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.card4);
            this.Controls.Add(this.card3);
            this.Controls.Add(this.card2);
            this.Controls.Add(this.card1);
            this.Controls.Add(this.memory2);
            this.Name = "Memory1";
            this.Text = "Memory1";
            this.Load += new System.EventHandler(this.Memory1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Memory memory2;
        private Deck deck1;
        private Card card1;
        private Card card2;
        private Card card3;
        private Card card4;
    }
}