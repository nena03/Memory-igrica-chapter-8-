using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotsOfFun.Games
{
    public partial class Memory1 : Form
    {
        public Memory1()
        {
            InitializeComponent();
        }

        private void Memory1_Load(object sender, EventArgs e)
        {
            memory2.Play();
        }

        private void memory2_GameOver(object sender, Memory.GameOverEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("You win in " + e.Clicks + " turns.\nPlay again?", "Game over", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                memory2.Play();

            }
        }
    }
}
