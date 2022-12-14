using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace KolmGG
{
    public partial class Registr : Form
    {
        TableLayoutPanel TLP;
        Label user, passwd, confirmPasswd;
        Button register, loginNow;
        TextBox enterUser, enterPasswd, enterConfirmPasswd;
        private SqlConnection cn;
        private SqlCommand cmd;
        private SqlDataReader dr;

        public Registr()
        {
            InitializeComponent();

            this.Size = new Size(400, 400);

            TLP = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 5,
                BackColor = Color.LightSkyBlue,
                Dock = DockStyle.Fill,
                //CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                Name = "TableLayoutPanel1",
                TabIndex = 0
            };


            //TextBoxes
            enterUser = new TextBox
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Center,
                Anchor = AnchorStyles.None,
                Width = 150
            };
            enterPasswd = new TextBox
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Center,
                Anchor = AnchorStyles.None,
                Width = 150
            };
            enterConfirmPasswd = new TextBox
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Center,
                Anchor = AnchorStyles.None,
                Width = 150
            };

            //Buttons
            register = new Button
            {
                Text = "Confirm",
                AutoSize = true,
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
            };
            register.Click += Register_Click;
            loginNow = new Button
            {
                Text = "You Have Account? Login Now",
                AutoSize = true,
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
            };
            loginNow.Click += LoginNow_Click;


            TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));

            TLP.Controls.Add(user = new Label() {
                Text = "Enter User Name",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Fill,
                UseCompatibleTextRendering = true
            }, 0, 0);
            TLP.Controls.Add(passwd = new Label()
            {
                Text = "Enter Password",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Fill,
                UseCompatibleTextRendering = true
            }, 0, 1);
            TLP.Controls.Add(confirmPasswd = new Label()
            {
                Text = "Confirm Password",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Fill,
                UseCompatibleTextRendering = true
            }, 0, 2);

            TLP.Controls.Add(enterUser, 1, 0);
            TLP.Controls.Add(enterPasswd, 1, 1);
            TLP.Controls.Add(enterConfirmPasswd, 1, 2);
            TLP.Controls.Add(register, 0, 3);
            TLP.Controls.Add(loginNow, 0, 4);
            TLP.SetColumnSpan(register, 2);
            TLP.SetColumnSpan(loginNow, 2);
            Controls.Add(TLP);
        }

        private void Register_Click(object sender, EventArgs e)
        {
            if (enterConfirmPasswd.Text != string.Empty || enterPasswd.Text != string.Empty || enterUser.Text != string.Empty)
            {
                if (enterPasswd.Text == enterConfirmPasswd.Text)
                {
                    cmd = new SqlCommand("select * from LoginTable where username='" + enterUser.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into LoginTable values(@username,@password)", cn);
                        cmd.Parameters.AddWithValue("username", enterUser.Text);
                        cmd.Parameters.AddWithValue("password", enterPasswd.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginNow_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void Registr_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane.TTHK\source\repos\TARpv20_RolanMaslennikov\KolmRakendust-master\KolmGG\Database.mdf;Integrated Security=True");
            cn.Open();
        }
    }
}
