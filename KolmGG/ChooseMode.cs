using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static KolmGG.Third;

namespace KolmGG
{
    public partial class ChooseMode : Form
    {



        Label selectMode;
        Button selectEasy, selectHard;

        //false = hard
        //public bool chooseMode;
        public ChooseMode()
        {
            InitializeComponent();
            this.Size = new Size(150, 150);

            selectMode = new Label()
            {
                Text = "Select game mode",
                Font = new Font("Comic-Sans", 30, FontStyle.Bold),
                Location = new Point(75, Top),
            };
            selectEasy = new Button()
            {
                Text = "Easy mode",
                Font = new Font("Comic-Sans", 30, FontStyle.Bold),
                Location = new Point(50, 75),
            };
            selectHard = new Button
            {
                Text = "Hard mode",
                Font = new Font("Comic-Sans", 30, FontStyle.Bold),
                Location = new Point(100, 75),
            };

            selectHard.Click += SelectHard_Click;
            selectEasy.Click += SelectEasy_Click;

            Controls.Add(selectMode);
            Controls.Add(selectEasy);
            Controls.Add(selectHard);
        }


        public static bool chooseMode;
        public void SelectEasy_Click(object sender, EventArgs e)
        {
            chooseMode = true;
            Third third = new Third();
            third.Show();

            this.Hide();
        }

        public void SelectHard_Click(object sender, EventArgs e)
        {
            chooseMode = false;
            Third third = new Third();
            third.Show();

            this.Hide();
        }

        private void ChooseMode_Load(object sender, EventArgs e)
        {

        }
    }
}
