using System;
using System.Windows.Forms;
using Infrastructure.Classes;
using Infrastructure.Database;

namespace DatabaseProj
{
    public partial class EditStudent : Form
    {
        public EditStudent()
        {
            InitializeComponent();
        }

        public static Student ShowAndReturnObject(Student s)
        {
            var dlg = new EditStudent();
            dlg.txtFirstName.Text = s.FirstName;
            dlg.txtMiddleName.Text = s.MiddleName;
            dlg.txtLastName.Text = s.LastName;
            dlg.cmbEmphasis.SelectedIndex = s.Emphasis.Id - 1;
            if (s.Status == 0)
            {
                dlg.cmbStatus.Text = "Unknown";
            }
            else
            {
                dlg.cmbStatus.SelectedIndex = (int)s.Status;
            }

            while (true)
            {
                DialogResult ans = dlg.ShowDialog();

                if (ans == DialogResult.OK)
                {
                    if (dlg.txtFirstName.Text.Length <= 0)
                    {
                        MessageBox.Show("You must enter a first name.", "Error");
                        continue;
                    }

                    if (dlg.txtLastName.Text.Length <= 0)
                    {
                        MessageBox.Show("You must enter a last name.", "Error");
                        continue;
                    }

                    if (dlg.txtMiddleName.Text.Length <= 0)
                    {
                        MessageBox.Show("You must enter a middle name.", "Error");
                        continue;
                    }

                    if (dlg.cmbStatus.Text.Length <= 0 || dlg.cmbStatus.SelectedIndex + 1 <= 0)
                    {
                        MessageBox.Show("You must enter a status.", "Error");
                        continue;
                    }

                    if (dlg.cmbEmphasis.Text.Length <= 0 || dlg.cmbEmphasis.SelectedIndex + 1 <= 0)
                    {
                        MessageBox.Show("You must enter an emphasis.", "Error");
                        continue;
                    }

                    Student stud = new Student
                    {
                        UniversityId = s.UniversityId,
                        FirstName = dlg.txtFirstName.Text,
                        LastName = dlg.txtLastName.Text,
                        MiddleName = dlg.txtMiddleName.Text,
                        Status = (Status)(dlg.cmbStatus.SelectedIndex),
                        Emphasis = new Emphasis
                        {
                            Id = dlg.cmbEmphasis.SelectedIndex + 1,
                        },
                    };
                    return stud;
                }
                return null;
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
