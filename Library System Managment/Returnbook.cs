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
    public partial class Returnbook : Form
    {
        public Returnbook()
        {
            InitializeComponent();
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            textSearchID.Clear();
        }
        int qunt;

        private void Searchstbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= DESKTOP-5903S8A\\SQLEXPRESS; database= master; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from IRBook where studentID = " + textSearchID.Text + " and book_return_date IS NULL ";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            if (DS.Tables[0].Rows.Count !=0)
            {
                dataGridView1.DataSource = DS.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid Student ID Or No Book Issued", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //book quantity trace---------------
            cmd.CommandText = "select bquan from NewBookP";
            SqlDataAdapter DA1 = new SqlDataAdapter(cmd);
            DataSet DS1 = new DataSet();
            DA1.Fill(DS1);
            qunt = int.Parse(DS1.Tables[0].Rows[0][0].ToString());

            //book quantity trace---------------
        }
        string bname;
        String bdate;
        Int64 rowid;
        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            textBOOKNAME.Text = bname;
            textISSUEDATE.Text = bdate;
        }

        private void Returnbook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            textSearchID.Clear();
        }

        private void RETURNbtn_Click(object sender, EventArgs e)
        {
            
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= DESKTOP-5903S8A\\SQLEXPRESS; database= master; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update IRBook set book_return_date = '" + dateTimePicker1.Text + "' where studentID ="+textSearchID.Text+" and idcount = "+rowid+ " ";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "update NewBookP set bquan = " + qunt + " where bname = '"+ bname+"'";
            cmd.ExecuteNonQuery();
            con.Close();


            MessageBox.Show("Return Succesful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Returnbook_Load(this, null);
        }

        private void textSearchID_TextChanged(object sender, EventArgs e)
        {
            if (textSearchID.Text == "")
            {
                panel2.Visible = false;
                dataGridView1.DataSource = null;
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure,Exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void CANCELbtn_Click(object sender, EventArgs e)
        {
            textSearchID.Clear();
        }
    }
}

