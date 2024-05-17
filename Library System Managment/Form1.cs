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

namespace Library_System_Managment
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

        private void textUsername_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void textUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (textUsername.Text == "Username")
            {
                textUsername.Clear();
            }
        }

        private void textPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if(textPassword.Text == "Password")
            {
                textPassword.Clear();
                textPassword.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textUsername.Text == "Username")
            {
                CreateAccuntForm fm = new CreateAccuntForm();
                fm.Show();
            }
           else  if (textUsername.Text == "Username")
            {
                CreateAccuntForm fm = new CreateAccuntForm();
                fm.Show();
            }
        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-5903S8A\\SQLEXPRESS; database = master; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from loginTable where username = '"+textUsername.Text+"' and pass='"+textPassword.Text+"' ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count!=0)
            {
                this.Hide();
                Dashboard dash = new Dashboard();
                dash.Show();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
