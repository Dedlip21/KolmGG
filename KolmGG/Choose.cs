using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolmGG
{
    public partial class Choose : Form
    {
        Button btn1, btn2, btn3, btn4;
        public Choose()
        {
            FlowLayoutPanel FlowLayoutPanel1 = new FlowLayoutPanel();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();

            btn1.Text = "First";
            btn2.Text = "Second";
            btn3.Text = "Third";  
            btn4.Text = "Close";

            btn1.Click += Btn1_Click;
            btn2.Click += Btn2_Click;
            btn3.Click += Btn3_Click;
            btn4.Click += Btn4_Click;
            //btn3.Enabled = false;

            FlowLayoutPanel1.Location = new Point(100, 70);
            FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            FlowLayoutPanel1.Controls.AddRange(new Control[] { btn1, btn2, btn3, btn4});

            Controls.Add(FlowLayoutPanel1);
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            Hide();
            ChooseMode third = new ChooseMode();
            third.ShowDialog();
            third = null;
            Show();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            Hide();
            Second second = new Second();
            second.ShowDialog();
            second = null;
            Show();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Hide();
            First first = new First();
            first.ShowDialog();
            first = null;
            Show();
        }

        private void Choose_Load(object sender, EventArgs e)
        {

        }
    }
}
