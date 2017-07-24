using System;
using System.Windows.Forms;
using Infrastructure.Classes;

namespace DatabaseProj
{
	public partial class FrmAddCriteria : Form
	{
		public FrmAddCriteria()
		{
			InitializeComponent();
		}

		public static Criteria ShowAndReturnObject()
		{
			var dlg = new FrmAddCriteria();

			// loop in case we need to validate later
			while (true)
			{
				DialogResult ans = dlg.ShowDialog();

				if ( ans == DialogResult.OK )
				{
					if ( dlg.txtName.Text.Length <= 0 )
					{
						MessageBox.Show( "You must enter a name.", "Error" );
						continue;
					}

					int score;
					if (dlg.dudMaxScore.Text.Length <= 0 || !int.TryParse( dlg.dudMaxScore.Text, out score ) || score < 0)
					{
						MessageBox.Show("You must enter a valid score that is a number greater than or equal to 0.", "Error");
						continue;
					}

					Criteria crit = new Criteria
					{
						Name = dlg.txtName.Text,
						MaxScore = score,
					};

					return crit;
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
