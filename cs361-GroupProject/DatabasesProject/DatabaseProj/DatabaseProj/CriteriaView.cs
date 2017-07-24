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
    public partial class CriteriaView : Form
    {
        public DbprojDatabase Database { get; set; }
        public CriteriaView()
        {
            Database = new DbprojDatabase();
            InitializeComponent();
        }

        private void CriteriaView_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'moonn52DataSet1.Criteria' table. You can move, or remove it, as needed.
            this.criteriaTableAdapter.Fill(this.moonn52DataSet1.Criteria);
        }

        private void dgvAssessments_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = ((DataGridView)sender).Rows[e.RowIndex];
            Database.EditCriteria(row.Cells[1].EditedFormattedValue.ToString(), Int32.Parse(row.Cells[2].EditedFormattedValue.ToString()), (int)row.Cells[0].Value);
            dgvAssessments.Refresh();
        }

        private void dgvAssessments_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow row = e.Row;
            if (!Database.DeleteCriteria((int)row.Cells[0].Value))
            {
                MessageBox.Show("Error: that criteria must have been used.");
                e.Cancel = true;
            }
            else
            {
                dgvAssessments.Refresh();
            }
        }
    }
}
