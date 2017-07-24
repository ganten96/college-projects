using Infrastructure.Classes;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProj
{
    public partial class ViewStudent : Form
    {
        public DbprojDatabase db = new DbprojDatabase();
        private Student s;
        public ViewStudent(Student stud)
        {
            InitializeComponent();
            s = stud;
            populateAssessmentTree();
            txtFirstName.Text = s.FirstName;
            txtMiddleName.Text = s.MiddleName;
            txtLastName.Text = s.LastName;
            txtStatus.Text = s.Status.ToString();
            txtEmphasis.Text = s.Emphasis.Name;
            populateAssessmentComboBox();
            populateSemesterCombo();
        }

        private void populateAssessmentComboBox()
        {
            List<AssessmentItem> items = db.GetAllAssessments();
            AssessmentCombo.DataSource = items;
            AssessmentCombo.DisplayMember = "Name";
            AssessmentCombo.ValueMember = "Id";
        }

        private void populateAssessmentTree()
        {
            TreeView assessmentTree = AssessmentTree;

            List<ResultList> temp = s.StudentAssessmentItems.Select(x => x.Value).ToList();
            int max = temp.Select(x => x.Scores).SelectMany(x => x).Max();
            int min = temp.Select(x => x.Scores).SelectMany(x => x).Min();
            double avg = temp.Select(x => x.Scores).SelectMany(x => x).Average();
            double aAvg = temp.Select(x => x.Scores).Select(x => x.Average()).Average();
            List<double> aAvgs = temp.Select(x => x.Scores).Select(x => x.Average()).ToList();

            Console.WriteLine();
            rtbStats.Text = "Max: " + max + "\n";
            rtbStats.Text += "Min: " + min + "\n";
            rtbStats.Text += "Average (Criteria): " + avg.ToString("F2") + "\n";
            rtbStats.Text += "Average (Assessment): " + aAvg.ToString("F2") + "\n";
            rtbStats.Text += "CSV Average: " + aAvgs.Select(x => x.ToString("F2")).Aggregate((x, y) => x + ", " + y) + "\n";

            foreach(KeyValuePair<SemesterAssessment, ResultList> key in s.StudentAssessmentItems)
            {
                TreeNode node = assessmentTree.Nodes.Add(key.Key.AssessmentItem.Name);

                foreach(int score in key.Value.Scores)
                {
                    if(key.Value.FacultyName.Equals(""))
                    {
                        key.Value.FacultyName = "N/A";
                    }
                    node.Nodes.Add(key.Value.FacultyName + " - " + score + " Semester Start Date - " + key.Key.Semester.StartDate.ToShortDateString());
                }
            }
            
        }

        private void populateSemesterCombo()
        {
            SemesterComboBox.DataSource = db.GetAllSemesters();
            SemesterComboBox.ValueMember = "Id";
            SemesterComboBox.DisplayMember = "StartDate";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.db.Dispose();
            this.Dispose();
            this.Close();
        }

        private void AssessmentCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(AssessmentCombo.SelectionLength != 0)
            {
                int assessmentId = (int)AssessmentCombo.SelectedValue;
                List<Criteria> criteria = db.GetCriteriasForAssessment(assessmentId);
                CriteraComboBox.DataSource = criteria;
                CriteraComboBox.ValueMember = "Id";
                CriteraComboBox.DisplayMember = "Name";
            }
        }

        private void AddAssessment_Click(object sender, EventArgs e)
        {
            
            try
            {
                int assessmentId = (int)AssessmentCombo.SelectedValue;
                int critId = (int)CriteraComboBox.SelectedValue;
                int semesterId = (int)SemesterComboBox.SelectedValue;
                string facultyName = txtFaculty.Text;
                int score = Int32.Parse(ScoreDomainUpDown.Text);
                bool isSuccess = db.InsertStudentAssessment(s.UniversityId, assessmentId, critId, score, semesterId, facultyName);
                if(!isSuccess)
                {
                    MessageBox.Show("An error occurred while inserting the assessment.", "Error");
                    return;
                }
                else
                {
                    AssessmentTree.Nodes.Clear();
                    Emphasis emph = s.Emphasis;
                    s = db.GetStudentInfoByStudentId(s.UniversityId);
                    s.Emphasis = emph;
                    populateAssessmentTree();
                }
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Invalid integer for score. Please input an integer.", "Error");
                return;
            }
            
        }
    }
}
