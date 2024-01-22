using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PatientsManagementSystem
{
    public partial class Receptionists : Form
    {
        public Receptionists()
        {
            InitializeComponent();
            DisplayRec();
            Clear();
            CountDoctors();
            CountTest();
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
        private void Receptionists_Load(object sender, EventArgs e)
        {

        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Receptionist");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from ReceptionistTBL where RecepID = @RKey", Con);
                    cmd.Parameters.AddWithValue("@RKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Receptionist Deleted!");
                    Con.Close();
                    DisplayRec();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void DisplayRec()
        {
            Con.Open();
            string Query = "Select * from ReceptionistTBL";
            SqlDataAdapter sda = new SqlDataAdapter(Query,Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ReceptionistDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void AddBTN_Click(object sender, EventArgs e)
        {
            if (RName.Text == "" || RPass.Text == "" || RPhone.Text == "" || RAdd.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ReceptionistTBL(RecepName,RecepPhone,RecepAddress,RecepPassword)values(@RN,@RP,@RA,@RPA)", Con);
                    cmd.Parameters.AddWithValue("@RN", RName.Text);
                    cmd.Parameters.AddWithValue("@RP", RPhone.Text);
                    cmd.Parameters.AddWithValue("@RA", RAdd.Text);
                    cmd.Parameters.AddWithValue("@RPA", RPass.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Receptionist Added!");
                    Con.Close();
                    DisplayRec();
                    Clear();

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }
        int Key = 0;
        private void ReceptionistDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RName.Text = ReceptionistDGV.SelectedRows[0].Cells[1].Value.ToString();
            RPhone.Text = ReceptionistDGV.SelectedRows[0].Cells[2].Value.ToString();
            RAdd.Text = ReceptionistDGV.SelectedRows[0].Cells[3].Value.ToString();
            RPass.Text = ReceptionistDGV.SelectedRows[0].Cells[4].Value.ToString();

            if(RName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ReceptionistDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
            
        }

        private void EditBTN_Click(object sender, EventArgs e)
        {
            if (RName.Text == "" || RPass.Text == "" || RPhone.Text == "" || RAdd.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update ReceptionistTBL set RecepName=@RN,RecepPhone=@RP,RecepAddress=@RA,RecepPassword=@RPA where RecepID=@RKey", Con);
                    cmd.Parameters.AddWithValue("@RN", RName.Text);
                    cmd.Parameters.AddWithValue("@RP", RPhone.Text);
                    cmd.Parameters.AddWithValue("@RA", RAdd.Text);
                    cmd.Parameters.AddWithValue("@RPA", RPass.Text);
                    cmd.Parameters.AddWithValue("@RKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Receptionist Updated!");
                    Con.Close();
                    DisplayRec();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void Clear()
        {
            RName.Text = "";
            RPhone.Text = "";
            RAdd.Text = "";
            RPass.Text = "";

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Patients obj = new Patients();
            obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Doctors obj = new Doctors();
            obj.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Login obj = new Login();
                obj.Show();
                this.Hide();
            }
        }
    }
}
