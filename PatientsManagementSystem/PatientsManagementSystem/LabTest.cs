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
    public partial class LabTest : Form
    {
        public LabTest()
        {
            InitializeComponent();
            Clear();
            DisplayLab();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Documents\hospitalmsdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplayLab()
        {
            Con.Open();
            string Query = "Select * from TestTBL";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            LabDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        int Key = 0;
        private void Clear()
        {
            TName.Text = "";
            LabCost.Text = "";
            Key = 0;

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void LabDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TName.Text = LabDGV.SelectedRows[0].Cells[1].Value.ToString();
            LabCost.Text = LabDGV.SelectedRows[0].Cells[2].Value.ToString();

            if (TName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(LabDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }


        private void AddBTN_Click_1(object sender, EventArgs e)
        {
            if (LabCost.Text == "" || TName.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into TestTBL(TestName,TestCost)values(@TN,@TC)", Con);
                    cmd.Parameters.AddWithValue("@TN", TName.Text);
                    cmd.Parameters.AddWithValue("@TC", LabCost.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Test Added!");
                    Con.Close();
                    DisplayLab();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EditBTN_Click_1(object sender, EventArgs e)
        {
            if (LabCost.Text == "" || TName.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update TestTBL set TestName=@TN,TestCost=@TC where TestNum=@TKey", Con);
                    cmd.Parameters.AddWithValue("@TN", TName.Text);
                    cmd.Parameters.AddWithValue("@TC", LabCost.Text);
                    cmd.Parameters.AddWithValue("@TKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Test Updated!");
                    Con.Close();
                    DisplayLab();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        /*private void DeleteBTN_Click_1(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Lab Test");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from TestTBL where TestNum = @TKey", Con);
                    cmd.Parameters.AddWithValue("@TKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Test Deleted!");
                    Con.Close();
                    DisplayLab();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }*/

        private void LabTest_Load(object sender, EventArgs e)
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

        private void label10_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }
    }
}
