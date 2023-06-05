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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4N5QPIK\SQLEXPRESS;Initial Catalog=HospPat;Integrated Security=True");
        public int PatientID1;

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO pattab VALUES (@Name , @Disease ,@Address , @Mobile)", con);

            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Disease", txtDisease.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
            // cmd.Parameters.AddWithValue("@StudentId", this.StudentID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("New Patient is Successfully Saved in the DataBase", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetPatientsRecord();
            ResetFormControls();

        }

        //MessageBox.Show("Student Information is successfully saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //GetStudentsRecord();
        //ResetFormControls();

    }
    private bool IsValid()
    {
        if (txtName.Text == string.Empty|| txtDisease.Text == string.Empty || txtAddress.Text == string.Empty || txtMobile.Text == string.Empty)
        {
                
            MessageBox.Show("Patient Complete Details are required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
            try
            {
                int a =int.Parse(txtMobile.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mobile Number Should be Valid");
                return false;
            }
            
            return true;

    }

    private void Form2_Load(object sender, EventArgs e)
        {
            GetPatientsRecord();
        }
        public void GetPatientsRecord()
        {

            SqlCommand cmd = new SqlCommand("Select * from pattab", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            PatientRecGrid.DataSource = dt;

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (PatientID1 > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE pattab SET Name=@Name , Disease=@Disease ,Address=@Address ,Mobile= @Mobile WHERE PatientID = @ID", con);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Disease", txtDisease.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("@ID", this.PatientID1);

                // cmd.Parameters.AddWithValue("@StudentId", this.StudentID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Patient information is Successfully Updated in the DataBase", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetPatientsRecord();
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
            PatientID1 = 0;
            txtAddress.Clear();
            txtDisease.Clear();
            txtMobile.Clear();
            txtName.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (PatientID1 > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM pattab WHERE PatientID = @ID", con);

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("@ID", this.PatientID1);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Patient information is Successfully Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetPatientsRecord();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please Select an Patient to delete", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PatientRecGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PatientRecGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                PatientID1 = Convert.ToInt32(PatientRecGrid.SelectedRows[0].Cells[0].Value);
                txtName.Text = PatientRecGrid.SelectedRows[0].Cells[1].Value.ToString();
                txtDisease.Text = PatientRecGrid.SelectedRows[0].Cells[2].Value.ToString();
                txtAddress.Text = PatientRecGrid.SelectedRows[0].Cells[3].Value.ToString();
                txtMobile.Text = PatientRecGrid.SelectedRows[0].Cells[4].Value.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Select From Start");
            }

            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }
        class MyExceptions : Exception
        {
            public MyExceptions(string msg) : base(msg) { }
        }
        private void label8_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide(); 
        }
    }
}
