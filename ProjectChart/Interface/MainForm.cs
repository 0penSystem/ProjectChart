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
    public partial class MainForm : Form
    {
        public Database _database
        {
            get; set;
        } = new Database();

        public MainForm()
        {
            InitializeComponent();
            txtName.Text = "";
            dtStart.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now + TimeSpan.FromDays(1);
        }

        private void miHelpAbout_Click(object sender, EventArgs e)
        {
            var abt = new AboutBox();
            abt.ShowDialog(this);
        }

        private void miBarAdd_Click(object sender, EventArgs e)
        {
            var dlg = new BarEditor() { Database = _database };
            dlg.ShowDialog(this);
        }

        private void miFileNew_Click(object sender, EventArgs e)
        {
            _database = new Database();
            txtName.Text = "";
            dtStart.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now + TimeSpan.FromDays(1);

        }

        private void miBarManage_Click(object sender, EventArgs e)
        {
            var dlg = new BarManager() { Database = _database };
            dlg.ShowDialog(this);
        }

        private void miEventAdd_Click(object sender, EventArgs e)
        {
            var dlg = new EventEditor() { Database = _database };
            dlg.ShowDialog(this);
        }

        private void miEventsManage_Click(object sender, EventArgs e)
        {
            var dlg = new EventManager() { Database = _database };
            dlg.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void miFileLoadXml_Click(object sender, EventArgs e)
        {
            DialogResult d = openXML.ShowDialog();
            if (d == DialogResult.OK)
            {

                _database = new Database(openXML.FileName);
                txtName.Text = _database.Name;
                dtStart.Value = _database.StartDate;
                dtEnd.Value = _database.EndDate;
                

            }
        }
    }
}
