using Microsoft.Office.Interop.PowerPoint;
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
using System.Xml;

namespace ProjectChart.Interface
{
    public partial class MainForm : Form
    {
        public Database _database
        {
            get; set;
        } = new Database();

        internal Microsoft.Office.Interop.PowerPoint.Application Powerpoint;
        internal Presentation ppt;


        public MainForm()
        {
            InitializeComponent();


            Powerpoint = Powerpoint ?? new Microsoft.Office.Interop.PowerPoint.Application();
            Powerpoint.PresentationBeforeSave += Powerpoint_PresentationBeforeSave;

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

        private void miProjectCreate_Click(object sender, EventArgs e)
        {
            Powerpoint = Powerpoint ?? new Microsoft.Office.Interop.PowerPoint.Application();
            ppt = Powerpoint.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoTrue);


            CreateModule.CreateChart(ppt, _database.data);
        }

        private void miProjectUpdate_Click(object sender, EventArgs e)
        {
            UpdateModule.UpdateChart(ppt, _database.data);
        }

        private void miProjectReplace_Click(object sender, EventArgs e)
        {
            if (Powerpoint.Windows.Count == 0)
            {
                return;
            }
            UpdateModule.ReplaceMissing(ppt, _database.data);
        }

        private void Powerpoint_PresentationBeforeSave(Presentation Pres, ref bool Cancel)
        {
            if (Pres == ppt)
            {
                Pres.Tags.Delete("ProjectData");
                Pres.Tags.Add("ProjectData", _database.data.GetXml());
            }
        }

        private void miFileOpenPPT_Click(object sender, EventArgs e)
        {
            if (openPPT.ShowDialog() == DialogResult.OK)
            {

                Powerpoint = Powerpoint ?? new Microsoft.Office.Interop.PowerPoint.Application();
                ppt = Powerpoint.Presentations.Open(openPPT.FileName);



                var xml = ppt.Tags["ProjectData"];
                var data = new XmlDocument();
                data.LoadXml(xml);
                XmlReader n = new XmlNodeReader(data);
                _database = new Database(n);

                txtName.Text = _database.Name;
                dtStart.Value = _database.StartDate;
                dtEnd.Value = _database.EndDate;

            }
        }
    }
}
