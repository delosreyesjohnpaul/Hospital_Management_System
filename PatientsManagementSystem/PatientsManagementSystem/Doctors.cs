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
    public partial class Doctors : Form
    {
        public Doctors()
        {
            InitializeComponent();
            DisplayDoc();
            CountPatients();
            CountTest();
            CountDoctors();
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
        private void DisplayDoc()
        {
            Con.Open();
            string Query = "Select * from DoctorTBL";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DoctorDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void Clear()
        {
            DName.Text = "";
            DPhone.Text = "";
            DAdd.Text = "";
            DExp.Text = "";
            DPass.Text = "";
            DGenderCB.SelectedIndex = -1;
            DSpecCB.SelectedIndex = -1;
            Key = 0;

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Doctors_Load(object sender, EventArgs e)
        {

        }

        private void AddBTN_Click(object sender, EventArgs e)
        {
            if (DName.Text == "" || DPass.Text == "" || DPhone.Text == "" || DAdd.Text == "" || DGenderCB.SelectedIndex == -1 || DSpecCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into DoctorTBL(DoctorName,DoctorDOB,DoctorGender,DoctorSpec,DoctorExperience,DoctorPhone,DoctorAddress,DoctorPassword)values(@DN,@DDOB,@DG,@DS,@DE,@DP,@DA,@DPA)", Con);
                    cmd.Parameters.AddWithValue("@DN", DName.Text);
                    cmd.Parameters.AddWithValue("@DDOB", DDOBDT.Value.Date);
                    cmd.Parameters.AddWithValue("@DG", DGenderCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DS", DSpecCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DE", DExp.Text);
                    cmd.Parameters.AddWithValue("@DP", DPhone.Text);
                    cmd.Parameters.AddWithValue("@DA", DAdd.Text);
                    cmd.Parameters.AddWithValue("@DPA", DPass.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Added!");
                    Con.Close();
                    DisplayDoc();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;

        private void DoctorDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DName.Text = DoctorDGV.SelectedRows[0].Cells[1].Value.ToString();
            DDOBDT.Text = DoctorDGV.SelectedRows[0].Cells[2].Value.ToString();
            DGenderCB.SelectedItem = DoctorDGV.SelectedRows[0].Cells[3].Value.ToString();
            DSpecCB.SelectedItem = DoctorDGV.SelectedRows[0].Cells[4].Value.ToString();
            DExp.Text = DoctorDGV.SelectedRows[0].Cells[5].Value.ToString();
            DPhone.Text = DoctorDGV.SelectedRows[0].Cells[6].Value.ToString();
            DAdd.Text = DoctorDGV.SelectedRows[0].Cells[7].Value.ToString();
            DPass.Text = DoctorDGV.SelectedRows[0].Cells[8].Value.ToString();

            if (DName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DoctorDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void EditBTN_Click(object sender, EventArgs e)
        {
            if (DName.Text == "" || DPass.Text == "" || DPhone.Text == "" || DAdd.Text == "" || DGenderCB.SelectedIndex == -1 || DSpecCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update DoctorTBL set DoctorName=@DN,DoctorDOB=@DDOB,DoctorGender=@DG,DoctorSpec=@DS,DoctorExperience=@DE,DoctorPhone=@DP,DoctorAddress=@DA,DoctorPassword=@DPA where DoctorID=@DKey", Con);
                    cmd.Parameters.AddWithValue("@DN", DName.Text);
                    cmd.Parameters.AddWithValue("@DDOB", DDOBDT.Value.Date);
                    cmd.Parameters.AddWithValue("@DG", DGenderCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DS", DSpecCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DE", DExp.Text);
                    cmd.Parameters.AddWithValue("@DP", DPhone.Text);
                    cmd.Parameters.AddWithValue("@DA", DAdd.Text);
                    cmd.Parameters.AddWithValue("@DPA", DPass.Text);
                    cmd.Parameters.AddWithValue("@DKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Edited!");
                    Con.Close();
                    DisplayDoc();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Doctor");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from DoctorTBL where DoctorID = @DKey", Con);
                    cmd.Parameters.AddWithValue("@DKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Deleted!");
                    Con.Close();
                    DisplayDoc();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();

        }

        private void label11_Click(object sender, EventArgs e)
        {
            LabTest obj = new LabTest();
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

        private void label9_Click(object sender, EventArgs e)
        {
            Patients obj = new Patients();
            obj.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
    }
}
