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

namespace viewStudent
{
    public partial class student : Form
    {
        public student()
        {
            InitializeComponent();
        }

        private void textsearch_TextChanged(object sender, EventArgs e)
        {
            if( textsearch.Text !="")
            {
                label1.Visible = false;
                label2.Visible = false;
                Image img = Image.FromFile("E:/Shihab/Slides/Liberay Management System/Searching.gif");
                pictureBox1.Image = img;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-5903S8A\\SQLEXPRESS; database= master; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from StudentInfo where stuid LIKE '"+textsearch.Text+"%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {

                label1.Visible = true;
                label2.Visible = true;
                Image img = Image.FromFile("E:/Shihab/Slides/Liberay Management System/search.gif");
                pictureBox1.Image = img;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-5903S8A\\SQLEXPRESS; database= master; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from StudentInfo";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void student_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= DESKTOP-5903S8A\\SQLEXPRESS; database= master; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from StudentInfo";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        int sid;
        int rowid;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                sid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());

            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= DESKTOP-5903S8A\\SQLEXPRESS; database= master; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from StudentInfo where stuid = " + sid + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            rowid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
            textSname.Text = ds.Tables[0].Rows[0][0].ToString();
            textSID.Text = ds.Tables[0].Rows[0][1].ToString();
            textSdept.Text = ds.Tables[0].Rows[0][2].ToString();
            textSsem.Text = ds.Tables[0].Rows[0][3].ToString();
            textScontact.Text = ds.Tables[0].Rows[0][4].ToString();
            textSemail.Text = ds.Tables[0].Rows[0][5].ToString();

        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be updated. Are you sure?", "Update Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string Name = textSname.Text;
                int sid = int.Parse(textSID.Text);
                string dept = textSdept.Text;
                string sem = textSsem.Text;
                Int64 contact = Int64.Parse(textScontact.Text);
                string email = textSemail.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-5903S8A\\SQLEXPRESS; database= master; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update StudentInfo set stname = '" + Name + "',stuid = '" + sid + "',stdep = '" + dept + "', stsem = '" + sem + "', stcontact = " + contact + " ,stemail = '" + email + "' where stuid = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This Student Info will be Deleted. Are you sure?", "Delete Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-5903S8A\\SQLEXPRESS; database= master; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete from StudentInfo where Stuid = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void rfsbtn_Click(object sender, EventArgs e)
        {
            textsearch.Clear();
            panel2.Visible = false;
        }
    }
}
