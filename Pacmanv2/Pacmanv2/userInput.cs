using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacmanv2
{
    public partial class userInput : Form
    {

        public string Data
        {
            get { return userName.Text; } // Vill man hämta information dvs test = data så retunerars texten i textbox
            set { userName.Text = value; }// Vill man sätta information dvs data = test så blir textboxens värde test
        }

        Form game = new Form1();

        public userInput()
        {
            InitializeComponent();
            // Maxlängd på namnet
            userName.MaxLength = 12;
            // Positionen där fönstret ska starta
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(game.Width / 2 - (this.Width / 3), (game.Height / 2) - (this.Height / 3));
        }

        public event EventHandler DataAvailable;
        // om man har skrivit in ett namn hämtas den datan från detta form och läggs in i en variabel i Pacman
        protected virtual void OnDataAvailable(EventArgs e)
        {
            EventHandler eh = DataAvailable;
            if (eh != null)
            {
                eh(this, e);
            }
        }

        // Stänger fönstret
        private void label2_Click_1(object sender, EventArgs e)
        {
            OnDataAvailable(null);
            this.Close();
        }
    }
}
