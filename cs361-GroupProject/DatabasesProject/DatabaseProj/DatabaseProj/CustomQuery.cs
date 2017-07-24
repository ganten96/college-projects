using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infrastructure.Database;

namespace DatabaseProj
{
	public partial class CustomQuery : Form
	{
		public DbprojDatabase Database { get; set; }

		public CustomQuery()
		{
			Database = new DbprojDatabase();
			InitializeComponent();
		}

		private void btnQuery_Click(object sender, EventArgs e)
		{
            PopulateRows(txtQuery.Text);
		}

        public void PopulateRows(string query)
        {
            IEnumerable<object> d = Database.RawQuery(query);
            List<string> cols = GetRows(d);

            dgvQuery.ColumnCount = cols.Count;
            DataGridViewCellStyle style = dgvQuery.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.Navy;
            style.ForeColor = Color.White;
            style.Font = new Font(dgvQuery.Font, FontStyle.Bold);

            dgvQuery.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvQuery.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvQuery.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuery.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dgvQuery.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvQuery.GridColor = SystemColors.ActiveBorder;
            dgvQuery.RowHeadersVisible = true;
            dgvQuery.AllowUserToAddRows = false;

            for (int i = 0; i < cols.Count; i++)
            {
                dgvQuery.Columns[i].Name = cols[i];
            }

            dgvQuery.Rows.Clear();
            foreach (dynamic row in d)
            {
                int index = dgvQuery.Rows.Add();
                DataGridViewRow dgvr = dgvQuery.Rows[index];
                foreach (KeyValuePair<string, dynamic> valuePair in row)
                {
                    dgvr.Cells[valuePair.Key].Value = valuePair.Value.ToString();
                }
            }
        }

		private List<string> GetRows (IEnumerable<object> d)
		{
			List<string> ret = new List<string>();
			foreach (dynamic row in d)
			{
				foreach (KeyValuePair<string, dynamic> valuePair in row)
				{
					ret.Add(valuePair.Key);
				}

				return ret;
			}

			return ret;
		}

        private void tsmiCriterionAverage_Click(object sender, EventArgs e)
        {
            
        }

        private void tsmiCriterionAverageAll_Click(object sender, EventArgs e)
        {
            PopulateRows("CALL GetAllCriteriaPerAssessmentAverageScore();");
        }

        private void tsmiCriterionAverageOne_Click(object sender, EventArgs e)
        {
            PopulateRows("CALL GetAllCriteriaPerAssessmentAverageScore();");
        }

        private void tsmiAssessmentAverage_Click(object sender, EventArgs e)
        {
            PopulateRows("CALL AverageOverAllAssessment();");
        }

        private void assessmentItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateRows("CALL `GetAllAssessments`();");
        }

        private void topFiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateRows("CALL AverageOverAllAssessmentItemsTopFive();");
        }

        private void bottomFiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateRows("CALL AverageOverAllAssessmentItemsBottomFive();");
        }

        private void criteriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateRows("CALL `GetAllCriteria`();");
        }

        private void semestersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateRows("CALL `GetAllSemesters`();");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateRows("CALL `GetStudentsLikeFirstAndLastName`('', '', '');");
        }
    }
}
