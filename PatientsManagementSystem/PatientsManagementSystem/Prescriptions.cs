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
    public partial class Prescriptions : Form
    {
        public Prescriptions()
        {
            InitializeComponent();
            DisplayPrescription();
            GetDocID();
            GetPatientID();
            GetTestID();
            DisplayPres();
            CountPatients();
            CountTest();
            CountDoctors();
            if (Login.Role== "Doctor")
            {
                RecepLBL.Enabled = false;
                DoctorLBL.Enabled = false;
            }

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
        private void DisplayPrescription()
        {
            Con.Open();
            string Query = "Select * from PrescriptionTBL";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PrescriptionDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Clear()
        {
            DoctorIDCB.SelectedIndex = -1;
            PatientIDCB.SelectedIndex = -1;
            TestIDCB.SelectedIndex = -1;
            DoctorName.Text = "";
            PatientName.Text = "";
            TestNAme.Text = "";
            Medicines.Text= "";
            Cost.Text= "";
          
            //Key = 0;

        }

        /*private void GetDocName()
        {
            Con.Open();
            String Query = "select * from DoctorTBL where DoctorID="+DoctorIDCB.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                DoctorName.Text = dr["DoctorName"].ToString();
            }
            Con.Close();
        }*/



        private void GetPatientID()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select PatientID From PatientTBL", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PatientID", typeof(int));
            dt.Load(rdr);
            PatientIDCB.ValueMember = "PatientID";
            PatientIDCB.DataSource = dt;
            Con.Close();

        }

        private void GetDocID()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select DoctorID From DoctorTBL", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DoctorID", typeof(int));
            dt.Load(rdr);
            DoctorIDCB.ValueMember = "DoctorID";
            DoctorIDCB.DataSource = dt;
            Con.Close();

        }

        private void GetTestID()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select TestNum From TestTBL", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TestNum", typeof(int));
            dt.Load(rdr);
            TestIDCB.ValueMember = "TestNum";
            TestIDCB.DataSource = dt;
            Con.Close();

        }


        private void GetDocName()
        {
            try
            {
                if (DoctorIDCB.SelectedValue != null)
                {
                    Con.Open();
                    string Query = "SELECT * FROM DoctorTBL WHERE DoctorID = @DoctorID";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.Parameters.AddWithValue("@DoctorID", DoctorIDCB.SelectedValue.ToString());

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        DoctorName.Text = reader["DoctorName"].ToString();
                    }
                    else
                    {
                        DoctorName.Text = ""; 
                    }

                    Con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void GetPatientName()
        {
            try
            {
                if (PatientIDCB.SelectedValue != null)
                {
                    Con.Open();
                    string Query = "SELECT * FROM PatientTBL WHERE PatientID = @PatientID";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.Parameters.AddWithValue("@PatientID", PatientIDCB.SelectedValue.ToString());

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        PatientName.Text = reader["PatientName"].ToString();
                    }
                    else
                    {
                        PatientIDCB.Text = "";
                    }

                    Con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void GetTestName()
        {
            try
            {
                if (TestIDCB.SelectedValue != null)
                {
                    Con.Open();
                    string Query = "SELECT * FROM TestTBL WHERE TestNum = @TestNum";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.Parameters.AddWithValue("@TestNum", TestIDCB.SelectedValue.ToString());

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        TestNAme.Text = reader["TestName"].ToString();
                        Cost.Text = reader["TestCost"].ToString();
                    }
                    else
                    {
                        TestNAme.Text = "";
                    }

                    Con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Prescriptions_Load(object sender, EventArgs e)
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

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void DisplayPres()
        {
            Con.Open();
            string Query = "Select * from PrescriptionTBL";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PrescriptionDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        int Key = 0;

        private void AddBTN_Click(object sender, EventArgs e)
        {
            if (PatientName.Text == "" || DoctorName.Text == "" || TestNAme.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into PrescriptionTBL(DoctorID,DoctorName,PatientID,PatientName,LabTestID,LabTestName,Medicines,Cost)values(@DI,@DN,@PI,@PN,@TI,@TN,@M,@C)", Con);
                    cmd.Parameters.AddWithValue("@DI", DoctorIDCB.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@DN", DoctorName.Text);
                    cmd.Parameters.AddWithValue("@PI", PatientIDCB.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@PN", PatientName.Text);
                    cmd.Parameters.AddWithValue("@TI", TestIDCB.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@TN", TestNAme.Text);
                    cmd.Parameters.AddWithValue("@M", Medicines.Text);
                    cmd.Parameters.AddWithValue("@C", Cost.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Prescription Added!");
                    Con.Close();
                    DisplayPres();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DoctorIDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDocName();
        }

        private void PatientIDCB_TextChanged(object sender, EventArgs e)
        {
            GetPatientName();
        }

        private void TestIDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTestName();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PrescriptionDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PrescriptionSummary.Text = "";
            PrescriptionSummary.Text = "\n                                                HOSPITAL MANAGEMENT SYSTEM\n\n"+"                                                                 PRESCRIPTION\n                "+"\n**********************************************************************************"+"\n"+DateTime.Now+"\n\n\n\n                             Doctor: "+PrescriptionDGV.SelectedRows[0].Cells[2].Value.ToString()+"               Patient: "+ PrescriptionDGV.SelectedRows[0].Cells[4].Value.ToString()+"\n\n\n\n                              Test: "+ PrescriptionDGV.SelectedRows[0].Cells[6].Value.ToString()+"                "+"            Medicines: "+ PrescriptionDGV.SelectedRows[0].Cells[7].Value.ToString()+"\n\n\n\n";
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(PrescriptionSummary.Text + "\n", new Font("Cambria", 16, FontStyle.Regular), Brushes.Black, new Point(0, 80));
            //e.Graphics.DrawString("\n\t" + "Thanks", new Font("Cambria", 18, FontStyle.Bold), Brushes.Red, new Point(200, 300));
        }

        private void PrescriptionSummary_TextChanged(object sender, EventArgs e)
        {

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

        private void label10_Click(object sender, EventArgs e)
        {
            Doctors obj = new Doctors();
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

        private void Home_Click(object sender, EventArgs e)
        {

            Home obj = new Home();
            obj.Show();
            this.Hide();
        }
    }
}
