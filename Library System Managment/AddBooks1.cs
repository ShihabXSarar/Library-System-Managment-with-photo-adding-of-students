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
    public partial class AddBooks1 : Form
    {
        public AddBooks1()
        {
            InitializeComponent();
        }
        private void AddBooks1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (textbookname.Text != "" && textauthor.Text != "" && textbpub.Text != "" && dateTimePicker1.Text != "" && textbprice.Text != "" && textbquantity.Text != "")
            {
                string Bookn = textbookname.Text;
                string bauthor = textauthor.Text;
                string bpublication = textbpub.Text;
                string bdate = dateTimePicker1.Text;
                Int64 price = Int64.Parse(textbprice.Text);
                Int64 bquantity = Int64.Parse(textbquantity.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-5903S8A\\SQLEXPRESS; database= master; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = " insert into NewBookP (bname,baurthorname,bpublication, bpdate, bprice,bquan) values('" + Bookn + "','" + bauthor + "','" + bpublication + "','" + bdate + "'," + price + "," + bquantity + ")";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Book Added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textbookname.Clear();
                textauthor.Clear();
                textbpub.Clear();
                textbprice.Clear();
                textbquantity.Clear();
            }
            else
            {
                MessageBox.Show("Any Textfield can't be epmty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This will Delete Your Unsaved Data","Are you sure?",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                this.Close();
            }
            
        }
    }
}
