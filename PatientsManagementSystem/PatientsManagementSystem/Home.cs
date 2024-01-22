using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientsManagementSystem
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            if (Login.Role== "Receptionist")
            {
                RecepLBL.Enabled = false;
                DoctorLBL.Enabled = false;
                LabLBL.Enabled = false;
                PresLBL.Enabled = false;
            } else if (Login.Role== "Doctor")
            {
                RecepLBL.Enabled = false;
                DoctorLBL.Enabled = false;
            }
            CountPatients();
            CountDoctors();
            CountTest();
            CountCovid();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Documents\hospitalmsdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void CountPatients()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PatientTBL", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            PatientsLBL.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void CountCovid()
        {
            string Status = "Positive";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PatientTBL where PatientHIV = '"+Status+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            HIVLBL.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void CountDoctors()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from DoctorTBL", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DocLBL.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void CountTest()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from TestTBL", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            LabTestLBL.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void PatientLBL_Click(object sender, EventArgs e)
        {
            Patients obj = new Patients();
            obj.Show();
            this.Hide();
        }

        private void DoctorLBL_Click(object sender, EventArgs e)
        {
            Doctors obj = new Doctors();
            obj.Show();
            this.Hide();
        }

        private void LabLBL_Click(object sender, EventArgs e)
        {
            LabTest obj = new LabTest();
            obj.Show();
            this.Hide();
        }

        private void RecepLBL_Click(object sender, EventArgs e)
        {
            Receptionists obj = new Receptionists();
            obj.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Login obj = new Login();
                obj.Show();
                this.Hide();
            }
        }

        private void PresLBL_Click(object sender, EventArgs e)
        {
            Prescriptions obj = new Prescriptions();
            obj.Show();
            this.Hide();
        }
    }
}
