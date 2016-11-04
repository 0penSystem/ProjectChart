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
    public partial class EventManager : Form
    {
        public Database Database { get; set; }

        public EventManager()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            eventBinding.DataSource = null;
            eventBinding.DataSource = Database.getEvents();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["colEdit"].Index)
            {
                //clicked the edit column.
                var clickedEvent = dataGridView1.Rows[e.RowIndex].DataBoundItem as Event;

                var dlg = new EventEditor() { Database = Database, selectedEvent = clickedEvent };
                dlg.ShowDialog();
                RefreshGrid();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["colDelete"].Index)
            {
                //clicked the delete column.
                var clickedEvent = dataGridView1.Rows[e.RowIndex].DataBoundItem as Event;
                var result = MessageBox.Show(owner: this, text: "Are you sure you want to delete? This cannot be undone.", caption: "Delete", buttons: MessageBoxButtons.OKCancel, icon: MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    Database.deleteEvent(clickedEvent);

                    RefreshGrid();
                }

            }
        }
    }
}

