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
using System.Xml.Linq;

namespace PatientsManagementSystem
{
    public partial class Patients : Form
    {
        public Patients()
        {
            InitializeComponent();
            DisplayPatient();
            if (Login.Role== "Receptionist")
            {
                RecepLBL.Enabled = false;
                DoctorLBL.Enabled = false;
                LabLBL.Enabled = false;
            }
            else if (Login.Role== "Doctor")
            {
                RecepLBL.Enabled = false;
                DoctorLBL.Enabled = false;
            }
            CountTest();
            CountDoctors();
            CountPatients();
            

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Documents\hospitalmsdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void CountPatients()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PatientTBL", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            PatLBL.Text = dt.Rows[0][0].ToString();
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
        private void DisplayPatient()
        {
            Con.Open();
            string Query = "Select * from PatientTBL";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PatientDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        int Key = 0;
        private void Clear()
        {
            PName.Text = "";
            PGenderCB.SelectedIndex = -1;
            PHIVCB.SelectedIndex = -1;
            PAdd.Text = "";
            PPhone.Text = "";
            PAller.Text = "";
            Key = 0;

        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Patients_Load(object sender, EventArgs e)
        {

        }

        private void AddBTN_Click(object sender, EventArgs e)
        {
            if (PName.Text == "" || PAller.Text == "" || PAdd.Text == "" || PPhone.Text == "" || PGenderCB.SelectedIndex == -1 || PHIVCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into PatientTBL(PatientName,PatientGender,PatientDOB,PatientAddress,PatientPhone,PatientHIV,PatientAllergy)values(@PN,@PG,@PD,@PA,@PP,@PH,@PAL)", Con);
                    cmd.Parameters.AddWithValue("@PN", PName.Text);
                    cmd.Parameters.AddWithValue("@PG", PGenderCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PD", PDOBDT.Value.Date);
                    cmd.Parameters.AddWithValue("@PA", PAdd.Text);
                    cmd.Parameters.AddWithValue("@PP", PPhone.Text);
                    cmd.Parameters.AddWithValue("@PH", PHIVCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PAL", PAller.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Added!");
                    Con.Close();
                    DisplayPatient();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EditBTN_Click(object sender, EventArgs e)
        {
            if (PName.Text == "" || PAller.Text == "" || PAdd.Text == "" || PPhone.Text == "" || PGenderCB.SelectedIndex == -1 || PHIVCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update PatientTBL set PatientName=@PN,PatientGender=@PG,PatientDOB=@PD,PatientAddress=@PA,PatientPhone=@PP,PatientHIV=@PH,PatientAllergy=@PAL where PatientID=@PKey", Con);
                    cmd.Parameters.AddWithValue("@PN", PName.Text);
                    cmd.Parameters.AddWithValue("@PG", PGenderCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PD", PDOBDT.Value.Date);
                    cmd.Parameters.AddWithValue("@PA", PAdd.Text);
                    cmd.Parameters.AddWithValue("@PP", PPhone.Text);
                    cmd.Parameters.AddWithValue("@PH", PHIVCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PAL", PAller.Text);
                    cmd.Parameters.AddWithValue("@PKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Added!");
                    Con.Close();
                    DisplayPatient();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void PatientDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PName.Text = PatientDGV.SelectedRows[0].Cells[1].Value.ToString();
            PGenderCB.SelectedItem = PatientDGV.SelectedRows[0].Cells[2].Value.ToString();
            PDOBDT.Text = PatientDGV.SelectedRows[0].Cells[3].Value.ToString();
            PAdd.Text = PatientDGV.SelectedRows[0].Cells[4].Value.ToString();
            PPhone.Text = PatientDGV.SelectedRows[0].Cells[5].Value.ToString();
            PHIVCB.SelectedItem = PatientDGV.SelectedRows[0].Cells[6].Value.ToString();
            PAller.Text = PatientDGV.SelectedRows[0].Cells[7].Value.ToString();

            if (PName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(PatientDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Patient");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from PatientTBL where PatientID = @PKey", Con);
                    cmd.Parameters.AddWithValue("@PKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Deleted!");
                    Con.Close();
                    DisplayPatient();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
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

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
