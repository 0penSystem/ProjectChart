using Microsoft.Office.Interop.PowerPoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;




namespace ProjectChart
{
    public partial class Form1 : Form
    {




        private Project currentProject = new Project();

        internal Microsoft.Office.Interop.PowerPoint.Application Powerpoint;
        internal Presentation ppt;

        internal Project CurrentProject
        {
            get
            {
                return currentProject;
            }

            set
            {
                currentProject = value;
            }
        }

        

        public Form1()
        {
            InitializeComponent();
                    }

        private void ActivateControls()
        {
            textBoxProjectName.Enabled = true;
            StartDatePicker.Enabled = true;
            EndDatePicker.Enabled = true;
            tabControl1.Enabled = true;
            BarGrid.DataSource = CurrentProject.data.Tables["Bars"];
            EventGrid.DataSource = currentProject.data.Tables["Events"];
            CreateSlideBTN.Enabled = true;
           
        }


        private void NewProject_Click(object sender, EventArgs e)
        {
            CurrentProject = new Project();

            ActivateControls();

            currentProject.Name = "New Project";
            currentProject.StartDate = DateTime.Now;
            currentProject.EndDate = DateTime.Now;

        }

        private void textBoxProjectName_TextChanged(object sender, EventArgs e)
        {
            currentProject.Name = textBoxProjectName.Text;
        }

        private void StartDatePicker_ValueChanged(object sender, EventArgs e)
        {
            currentProject.StartDate = StartDatePicker.Value;
        }

        private void EndDatePicker_ValueChanged(object sender, EventArgs e)
        {
            currentProject.EndDate = EndDatePicker.Value;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateBarList()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

       
        private void projectBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BarName_TextChanged(object sender, EventArgs e)
        {
        }

        private void BarStart_ValueChanged(object sender, EventArgs e)
        {
        }

        private void BarEnd_ValueChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load selected bar
        }

        private void EventGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void SaveProject_Click(object sender, EventArgs e)
        {
           DialogResult d = ProjectSave.ShowDialog();
            if (d == DialogResult.OK)
            {

                currentProject.data.WriteXml(ProjectSave.FileName);
            }
        }

        private void OpenProject_Click(object sender, EventArgs e)
        {
            DialogResult d = ProjectOpen.ShowDialog();
            if (d == DialogResult.OK)
            {


                ActivateControls();
                currentProject = new Project();
                currentProject.data.ReadXml(ProjectOpen.FileName);
                ActivateControls();

                textBoxProjectName.Text = currentProject.data.Tables["Project"].Rows[1].Field<string>("Project Name");
                StartDatePicker.Value = currentProject.data.Tables["Project"].Rows[1].Field<DateTime>("Start Date");
                EndDatePicker.Value = currentProject.data.Tables["Project"].Rows[1].Field<DateTime>("End Date");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //TODO: IMPLEMENT POWERPOINT CODE
            Powerpoint = new Microsoft.Office.Interop.PowerPoint.Application();
            ppt = Powerpoint.Presentations.Add                (Microsoft.Office.Core.MsoTriState.msoTrue);
            
            CreateModule.CreateChart(ppt, currentProject.data);

        }

        




    }
}
