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

namespace WindowsFormsApplication10
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4N5QPIK\SQLEXPRESS;Initial Catalog=HospPat;Integrated Security=True");
        public int DoctorID1;

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO doctab VALUES (@Name , @Specilization ,@Address , @Mobile)", con);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Specilization", txtSpec.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                // cmd.Parameters.AddWithValue("@StudentId", this.StudentID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New Doctor is Successfully Saved in the DataBase", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDoctorsRecord();
                ResetFormControls();

            }

            //MessageBox.Show("Student Information is successfully saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //GetStudentsRecord();
            //ResetFormControls();

        }
        private bool IsValid()
        {
            if (txtName.Text == string.Empty || txtSpec.Text== string.Empty || txtAddress.Text == string.Empty|| txtMobile.Text == string.Empty)
            {
                MessageBox.Show("Doctor Complete Details is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int a = int.Parse(txtMobile.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mobile Number Should Vaalid");
                return false;
            }
            return true;
            


        }

        private void Form3_Load(object sender, EventArgs e)
        {
            GetDoctorsRecord();
        }
        public void GetDoctorsRecord()
        {

            SqlCommand cmd = new SqlCommand("Select * from doctab", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            DoctorRecGrid.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DoctorID1 > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE doctab SET Name=@Name , Specilization=@Specilization ,Address=@Address ,Mobile= @Mobile WHERE DoctorID = @ID", con);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Specilization", txtSpec.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("@ID", this.DoctorID1);

                // cmd.Parameters.AddWithValue("@StudentId", this.StudentID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Doctor information is Successfully Updated in the DataBase", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDoctorsRecord();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please Select an student to delete", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }
        private void ResetFormControls()
        {
            DoctorID1 = 0;
            txtAddress.Clear();
            txtSpec.Clear();
            txtMobile.Clear();
            txtName.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DoctorID1 > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM doctab WHERE DoctorID = @ID", con);

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("@ID", this.DoctorID1);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Doctor information is Successfully Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDoctorsRecord();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please Select an Doctor to delete", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoctorRecGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                DoctorID1 = Convert.ToInt32(DoctorRecGrid.SelectedRows[0].Cells[0].Value);
                txtName.Text = DoctorRecGrid.SelectedRows[0].Cells[1].Value.ToString();
                txtSpec.Text = DoctorRecGrid.SelectedRows[0].Cells[2].Value.ToString();
                txtAddress.Text = DoctorRecGrid.SelectedRows[0].Cells[3].Value.ToString();
                txtMobile.Text = DoctorRecGrid.SelectedRows[0].Cells[4].Value.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Select Row from Start");
            }
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        class MyExceptions : Exception
        {
            public MyExceptions(string msg) : base(msg) { }
        }
        private void DoctorRecGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
