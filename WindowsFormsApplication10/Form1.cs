using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text == string.Empty) throw new MyExceptions("UserName is required");
                else if (txtPass.Text == string.Empty) throw new MyExceptions("Password is required");
                else if (txtUserName.Text != "admin") throw new MyExceptions("Invalid Username !");
                else if (txtPass.Text != "admin123") throw new MyExceptions("Invalid Password !");
                Form4 f2 = new Form4();
                f2.Show();
                this.Hide();
            }
            catch (Exception error)
            {
                MessageBox.Show($"{error.Message}");
            }

           
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }
        class MyExceptions : Exception
        {
            public MyExceptions(string msg) : base(msg) { }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }
    }

}

