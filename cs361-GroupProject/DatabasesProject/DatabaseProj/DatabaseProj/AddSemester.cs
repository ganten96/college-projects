using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infrastructure.Classes;
using Infrastructure.Database;
namespace DatabaseProj
{
    public partial class AddSemester : Form
    {
        DbprojDatabase db { get; set; }
        public AddSemester()
        {
            InitializeComponent();
            db = new DbprojDatabase();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Semester s = new Semester
            {
                StartDate = DateTime.Parse(semesterDate.Text).Date
            };
            if (!db.AddSemester(s))
            {
                MessageBox.Show("Error adding semester.", "Error");
            }
            else
            {
                Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
