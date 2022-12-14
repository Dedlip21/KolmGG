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
        Button btn1, btn2, btn3, btn4, btnReg, btnLogin;
        Label lblName;
        
        public Choose()
        {
            FlowLayoutPanel FlowLayoutPanel1 = new FlowLayoutPanel();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();
            btnReg = new Button();
            btnLogin = new Button();

            btn1.Text = "Pildi vaatamine";
            btn2.Text = "Matemaatika test";
            btn3.Text = "Mälumäng";
            btnReg.Text = "Registration";
            btnLogin.Text = "Login";
            btn4.Text = "Välja";

            lblName = new Label
            {
                Text = "Username: ",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 14, FontStyle.Bold),
            };

            btn1.Click += Btn1_Click;
            btn2.Click += Btn2_Click;
            btn3.Click += Btn3_Click;
            btn4.Click += Btn4_Click;
            btnReg.Click += BtnReg_Click;
            btnLogin.Click += BtnLogin_Click;
            //btn3.Enabled = false;

            FlowLayoutPanel1.Location = new Point(100, 70);
            FlowLayoutPanel1.AutoSize = true;
            FlowLayoutPanel1.BackColor = Color.LightSkyBlue;
            FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            FlowLayoutPanel1.Controls.AddRange(new Control[] { btn1, btn2, btn3, btnReg, btnLogin, btn4, lblName });


            Controls.Add(FlowLayoutPanel1);
            //Controls.Add(lblName);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Hide();
            Login login = new Login();
            login.ShowDialog();
            login = null;
            Show();
        }

        private void BtnReg_Click(object sender, EventArgs e)
        {
            Hide();
            Registr reg = new Registr();
            reg.ShowDialog();
            reg = null;
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
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            Hide();
            Second second = new Second();
            second.ShowDialog();
            second = null;
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Hide();
            First first = new First();
            first.ShowDialog();
            first = null;
        }

        private void Choose_Load(object sender, EventArgs e)
        {

        }
    }
}
