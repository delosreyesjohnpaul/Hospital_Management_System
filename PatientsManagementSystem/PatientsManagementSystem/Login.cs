using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;

namespace PatientsManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Documents\hospitalmsdb.mdf;Integrated Security=True;Connect Timeout=30");
        public static string Role;

        private void pmsLABEl_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void ResetLB_Click(object sender, EventArgs e)
        {
            RoleCB.SelectedIndex = 0;
            UserName.Text = "";
            Password.Text = "";
        }

        private void LoginBTN_Click(object sender, EventArgs e)
        {
            if(RoleCB.SelectedIndex ==-1)
            {
                MessageBox.Show("Select Your Position");
            }
            else if(RoleCB.SelectedIndex ==0)
            {
                if(UserName.Text == "" || Password.Text == "")
                {
                    MessageBox.Show("Enter Both Admin Name and Password");
                }else if(UserName.Text == "Admin" && Password.Text== "Password")
                {
                    Role = "Admin";
                    Home obj = new Home();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Admin Name and Password");
                }
            }
            else if(RoleCB.SelectedIndex ==1) 
            {
                if (UserName.Text == "" || Password.Text == "")
                {
                    MessageBox.Show("Enter Both Doctor Name and Password");
                }
                else
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from DoctorTBL where DoctorName='"+UserName.Text+"' and DoctorPassword='"+Password.Text+"'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Role = "Doctor";
                        Home obj = new Home();
                        obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Doctor Not Found");

                    }

                    Con.Close();

                }
           
            }
            else
            {
                if (UserName.Text == "" || Password.Text == "")
                {
                    MessageBox.Show("Enter Both Receptionist Name and Password");
                }
                else
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from ReceptionistTBL where RecepName='"+UserName.Text+"' and RecepPassword='"+Password.Text+"'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Role = "Receptionist";
                        Home obj = new Home();
                        obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Receptionist Not Found");

                    }

                    Con.Close();

                }
            }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
