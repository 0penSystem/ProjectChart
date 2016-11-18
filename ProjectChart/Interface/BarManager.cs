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
    public partial class BarManager : Form
    {

        public Database Database { get; set; }

        public BarManager()
        {
            InitializeComponent();

        }


        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);

            RefreshGrid();
        }



        private void RefreshGrid()
        {
            barsBinding.DataSource = null;
            barsBinding.DataSource = Database.getBars();

        }

        private void dataGridView1_CellContentClick (object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["colEdit"].Index)
            {
                //clicked the edit column.
                var bar = dataGridView1.Rows[e.RowIndex].DataBoundItem as Bar;

                var dlg = new BarEditor() { Database = Database, selectedBar = bar };
                dlg.ShowDialog();
                RefreshGrid();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["colDelete"].Index)
            {
                //clicked the delete column.
                var bar = dataGridView1.Rows[e.RowIndex].DataBoundItem as Bar;
                var result = MessageBox.Show (owner: this, text: "Are you sure you want to delete? This cannot be undone.", caption: "Delete", buttons: MessageBoxButtons.OKCancel, icon: MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    Database.deleteBar (bar);

                    RefreshGrid();
                }

            }
        }

        private void miNewBar_Click (object sender, EventArgs e)
        {
            var dlg = new BarEditor() { Database = Database };
            dlg.ShowDialog (this);

            RefreshGrid();

        }

        private void dataGridView1_CellContentDoubleClick (object sender, DataGridViewCellEventArgs e)
        {
            var bar = dataGridView1.Rows[e.RowIndex].DataBoundItem as Bar;

            var dlg = new BarEditor() { Database = Database, selectedBar = bar };
            dlg.ShowDialog();
            RefreshGrid();
        }
    }
}
