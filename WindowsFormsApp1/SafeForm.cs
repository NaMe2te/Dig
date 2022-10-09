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
    public partial class SafeForm : Form
    {
        private const int sizeButton = 100;
        private int _n;
        private Button[,] _buttons;
        public SafeForm(int n)
        {
            InitializeComponent();
            _n = n;
            _buttons = new Button[n, n];
            Random rm = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    _buttons[i, j] = new Button();
                    _buttons[i, j].Location = new Point(j * sizeButton,i * sizeButton);
                    _buttons[i, j].Text = rm.Next(1, 3) == 1 ? "---" : "1";
                    _buttons[i, j].Size = new Size(sizeButton, sizeButton);
                    _buttons[i, j].Click += ClickButton;

                    Controls.Add(_buttons[i, j]);
                }
        }
        
        public void ClickButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int rowButton = button.Location.X / 100;
            int columnButton = button.Location.Y / 100;
            
            ChangeHandlePosition(button);
            for (int i = 0; i < _n; i++)
            {
                ChangeHandlePosition(_buttons[i, rowButton]);
                ChangeHandlePosition(_buttons[columnButton, i]);
            }
            if (IsOver()) Close();
        }
        public void ChangeHandlePosition(Button btn)
        {
            if (btn.Text == "---")
            {
                btn.Text = "1";
                return;
            }
            btn.Text = "---";
        }
        public bool IsOver()
        {
            Button btn = _buttons[0, 0];
            foreach (Button button in _buttons)
            {
                if(btn.Text != button.Text)
                    return false;
            }
            return true;
        }
    }
}
