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
	public partial class FrmAddAssessmentItem : Form
	{
		private ListBox.ObjectCollection _availableCriteria;
		private List<Criteria> _available;

		private ListBox.ObjectCollection _selectedCriteria;
		private List<Criteria> _selected;

		public FrmAddAssessmentItem()
		{
			InitializeComponent();
			_available = new List<Criteria>();
			_selected = new List<Criteria>();
		}

		public static AssessmentItem ShowAndReturnObject(List<Criteria> available)
		{
			var dlg = new FrmAddAssessmentItem();

			dlg._available = available;

			/*dlg._availableCriteria = new ListBox.ObjectCollection(dlg.lstAvailableCriteria);
			dlg._availableCriteria.Add( available.First() );
			dlg._availableCriteria.Add( "Test" );*/

			dlg.Redraw();

			//dlg._availableCriteria.AddRange( dlg._available.Select ( x => (object) x).ToArray() );

			dlg._selectedCriteria = new ListBox.ObjectCollection(dlg.lstSelectedCriteria);

			// loop in case we need to validate later
			while (true)
			{
				DialogResult ans = dlg.ShowDialog();

				if (ans == DialogResult.OK)
				{
					if (dlg.txtName.Text.Length <= 0)
					{
						MessageBox.Show("You must enter a name.", "Error");
						continue;
					}

					if (dlg.lstSelectedCriteria.Items.Count < 1)
					{
						MessageBox.Show("You must select at least one criteria.", "Error");
						continue;
					}

					AssessmentItem crit = new AssessmentItem
					{
						Name = dlg.txtName.Text,
						Criterion = dlg._selected,
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

		private void lstAvailableCriteria_DoubleClick(object sender, EventArgs e)
		{
			int sel = lstAvailableCriteria.SelectedIndex;
			Criteria crit = _available[ sel ];
			_available.RemoveAt( sel );
			_selected.Add( crit );
			Redraw();
		}

		private void Redraw ()
		{
			lstAvailableCriteria.Items.Clear();
			foreach (var criteria in _available)
			{
				lstAvailableCriteria.Items.Add(criteria);
			}

			lstSelectedCriteria.Items.Clear();
			foreach (var criteria in _selected)
			{
				lstSelectedCriteria.Items.Add(criteria);
			}
		}
	}
}
