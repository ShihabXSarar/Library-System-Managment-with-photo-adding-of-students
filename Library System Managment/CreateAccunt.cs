using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_System_Managment

{
    public partial class CreateAccuntForm : Form
    {
        string pattern = @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$";
        public CreateAccuntForm()
        {
            InitializeComponent();
        }

        private void btnGoback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textPassword_Leave(object sender, EventArgs e)
        {
            if(Regex.IsMatch(textPassword.Text,pattern)==false)
            {
                textPassword.Focus();
                errorProvider1.SetError(this.textPassword, "Please use uppercase, Lowercase,Number and Special Characters");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textCPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textCPassword_Leave(object sender, EventArgs e)
        {
            if(textCPassword.Text != textPassword.Text)
            {
                textCPassword.Focus();
                errorProvider2.SetError(this.textCPassword, "Passward Mismatch");
            }    
            else
            {
                errorProvider2.Clear();
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (textFname.Text != "" && textLName.Text != "" && cboGender.Text != "" && dateTimePicker1.Text != "" && textUsername.Text != "" && textCPassword.Text != "" && textEmail.Text != "")
            {
                string fname = textFname.Text;
                string lname = textLName.Text;
                string username = textUsername.Text;
                string gender = cboGender.Text;
                string birthday = dateTimePicker1.Text;
                string email = textEmail.Text;
                string pass = textCPassword.Text;
                

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-5903S8A\\SQLEXPRESS; database= master; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = " insert into loginTable (firstname,lastname,gender,email,birthdate,username,pass) values('" + fname + "','" + lname + "','" + gender + "','" + email + "','" + birthday + "','" + username + "','"+ pass +"')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Account Created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else
            {
                MessageBox.Show("Please Fill All the Field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
