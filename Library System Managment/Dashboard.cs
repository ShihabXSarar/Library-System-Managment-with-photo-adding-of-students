using Addstudent;
using Library_Management_System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using viewStudent;

namespace Library_System_Managment
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void addBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBooks1 dsa = new AddBooks1();
            dsa.Show();

     
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBook vb = new ViewBook();
            vb.Show();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addstudent adds = new addstudent();
            adds.Show();
        }

        private void studentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            student vstudent = new student();
            vstudent.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void issuedBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBooks isb = new IssueBooks();
            isb.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Returnbook rb = new Returnbook();
            rb.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompleteBookDetails cbd = new CompleteBookDetails();
            cbd.Show();
        }
    }
}
