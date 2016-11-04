using ProjectChart.DataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectChart.Interface
{
    public partial class BarEditor : Form
    {
        public Database Database { get; set; }
        public Bar selectedBar { get; set; }

        public BarEditor()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (selectedBar != null)
            {
                txtName.Text = selectedBar.Name;
                dtStart.Value = selectedBar.Start;
                dtEnd.Value = selectedBar.End;
                ValidateChildren();
            }
            else
            {
                dtStart.Value = DateTime.Now;
                dtEnd.Value = DateTime.Now + TimeSpan.FromDays(1);
                
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                //all children are valid, can proceed to save.
                var bar = new Bar(selectedBar?.Id ?? -1)
                {
                    Name = txtName.Text,
                    Start = dtStart.Value,
                    End = dtEnd.Value
                };

                if (bar.Id == -1)
                {
                    Database.addBar(bar);
                }
                else
                {
                    Database.updateBar(bar);
                }


                Close();
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            var name = sender as TextBox;

            if (string.IsNullOrEmpty(name.Text))
            {
                errorProvider.SetError(name, "Name must not be empty.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(name, "");
                e.Cancel = false;
            }


        }

        private void dtEnd_Validating(object sender, CancelEventArgs e)
        {
            var end = sender as DateTimePicker;
            if (end.Value < dtStart.Value)
            {
                errorProvider.SetError(end, "End date must come after Start date.");
                e.Cancel = true;
            }
            if(end.Value < Database.StartDate || end.Value > Database.EndDate)
            {
                errorProvider.SetError(end, "End date must be within project scope.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(end, "");
                e.Cancel = false;
            }


        }

        private void dtStart_Validating(object sender, CancelEventArgs e)
        {
            var start = sender as DateTimePicker;
            if (start.Value < dtStart.Value)
            {
                errorProvider.SetError(start, "End date must come after Start date.");
                e.Cancel = true;
            }
            if (start.Value < Database.EndDate || start.Value > Database.StartDate)
            {
                errorProvider.SetError(start, "End date must be within project scope.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(start, "");
                e.Cancel = false;
            }
        }
    }
}
