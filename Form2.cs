using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private int N;
        private Button[,] buttons;
        public Form2(int n)
        {
            N = n;
            InitializeComponent();
            int buttonSize = 600 / n;
            buttons = new Button[n, n];
            Random random = new Random();
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int fontSize = 600 / (n*2);
                    int rnd = random.Next(1, 3);
                    buttons[i, j] = new Button();
                    buttons[i, j].Location = new Point(j*buttonSize,i*buttonSize);
                    buttons[i, j].Text = rnd == 1 ? "_" : "|";
                    buttons[i, j].Size = new Size(buttonSize, buttonSize);
                    buttons[i, j].Click += (EventHandler)ClickButton;
                    buttons[i, j].Font = new Font("French Script MT", fontSize);

                    this.Controls.Add(buttons[i, j]);
                }
            }
           
            
        }
        public void ClickButton(object sender, EventArgs e)
        {
            
            Button button = (Button)sender;
            int ibutton = button.Location.X / (600 / N);
            int jbutton = button.Location.Y / (600 / N);
         //   MessageBox.Show(ibutton + "  "+ button.Location.X + "   " + button.Location.Y + "  " + jbutton);
            ChangeText(button);
            for (int i = 0; i < N; i++)
            {
                ChangeText(buttons[i, ibutton]);
                ChangeText(buttons[jbutton, i]);
            }
            if (IsGameOver())
            {
                MessageBox.Show("YOU WON!!!!!!");
                Close();
            }
        }
        public void ChangeText(Button btn)
        {
            if (btn.Text == "_")
                btn.Text = "|";
            else
                btn.Text = "_";
        }
        public bool IsGameOver()
        {
            Button btn = buttons[0, 0];
            foreach (Button button in buttons)
            {
                if(btn.Text != button.Text)
                    return false;
            }
            return true;
        }
    }
}
