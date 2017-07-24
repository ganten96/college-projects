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

namespace DatabaseProj
{
	public partial class FrmAddStudent : Form
	{
		public FrmAddStudent()
		{
			InitializeComponent();
		}

		public static Student ShowAndReturnObject()
		{
			var dlg = new FrmAddStudent();

			// loop in case we need to validate later
			while (true)
			{
				DialogResult ans = dlg.ShowDialog();
			    
				if ( ans == DialogResult.OK )
				{
					if ( dlg.txtFirstName.Text.Length <= 0 )
					{
						MessageBox.Show( "You must enter a first name.", "Error" );
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
						FirstName = dlg.txtFirstName.Text,
						LastName = dlg.txtLastName.Text,
						MiddleName = dlg.txtMiddleName.Text,
						Status = (Status) (dlg.cmbStatus.SelectedIndex + 1),
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
