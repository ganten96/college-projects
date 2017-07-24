using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infrastructure.Database;
using Infrastructure.Classes;

namespace DatabaseProj
{
    public partial class frmAssessmentView : Form
    {

        public DbprojDatabase Database { get; set; }
        public BindingList<AssessmentItem> AssessmentItems { get; set; }
        public frmAssessmentView()
        {
            Database = new DbprojDatabase();
            InitializeComponent();
        }

        private void frmAssessmentView_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'moonn52DataSet.AssessmentItem' table. You can move, or remove it, as needed.
            this.assessmentItemTableAdapter.Fill(this.moonn52DataSet.AssessmentItem);
        }

        private void dgvAssessments_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = ((DataGridView)sender).Rows[e.RowIndex];
            Database.EditAssessment(row.Cells[1].EditedFormattedValue.ToString(), (int)row.Cells[0].Value);
            dgvAssessments.Refresh();
        }

        private void dgvAssessments_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow row = e.Row;
            if (!Database.DeleteAssessment((int)row.Cells[0].Value))
            {
                MessageBox.Show("Error: that assessment must have been taken.");
                e.Cancel = true;
            }
            else
            {
                dgvAssessments.Refresh();
            }
        }
    }
}
