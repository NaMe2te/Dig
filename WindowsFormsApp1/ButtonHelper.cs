using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class ButtonHelper : Button
    {
        public void CreateButton(Button btn,Form frm, int x, int y, int size, EventHandler evh)
        {
            Random random = new Random();
            int rnd = random.Next(1, 2);
            btn = new Button();
            btn.Text = rnd == 2 ? "-" : "|";
            btn.Size = new System.Drawing.Size(size, size);
            btn.Click += evh;
            frm.Controls.Add(btn);
        }
    }
}
