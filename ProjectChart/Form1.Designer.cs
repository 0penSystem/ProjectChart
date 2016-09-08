namespace ProjectChart
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBars = new System.Windows.Forms.TabPage();
            this.BarGrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.tabEvents = new System.Windows.Forms.TabPage();
            this.EventGrid = new System.Windows.Forms.DataGridView();
            this.NewProject = new System.Windows.Forms.Button();
            this.OpenProject = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProjectName = new System.Windows.Forms.TextBox();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SaveProject = new System.Windows.Forms.Button();
            this.CreateSlideBTN = new System.Windows.Forms.Button();
            this.ProjectSave = new System.Windows.Forms.SaveFileDialog();
            this.ProjectOpen = new System.Windows.Forms.OpenFileDialog();
            this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projectDAta = new ProjectChart.ProjectDAta();
            this.tabControl1.SuspendLayout();
            this.tabBars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarGrid)).BeginInit();
            this.tabEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EventGrid)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectDAta)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBars);
            this.tabControl1.Controls.Add(this.tabEvents);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(0, 147);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(641, 351);
            this.tabControl1.TabIndex = 0;
            // 
            // tabBars
            // 
            this.tabBars.Controls.Add(this.BarGrid);
            this.tabBars.Controls.Add(this.label4);
            this.tabBars.Location = new System.Drawing.Point(4, 22);
            this.tabBars.Name = "tabBars";
            this.tabBars.Padding = new System.Windows.Forms.Padding(3);
            this.tabBars.Size = new System.Drawing.Size(633, 325);
            this.tabBars.TabIndex = 0;
            this.tabBars.Text = "Bars";
            this.tabBars.UseVisualStyleBackColor = true;
            // 
            // BarGrid
            // 
            this.BarGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BarGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BarGrid.Location = new System.Drawing.Point(3, 3);
            this.BarGrid.Name = "BarGrid";
            this.BarGrid.Size = new System.Drawing.Size(627, 319);
            this.BarGrid.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 0;
            // 
            // tabEvents
            // 
            this.tabEvents.Controls.Add(this.EventGrid);
            this.tabEvents.Location = new System.Drawing.Point(4, 22);
            this.tabEvents.Name = "tabEvents";
            this.tabEvents.Padding = new System.Windows.Forms.Padding(3);
            this.tabEvents.Size = new System.Drawing.Size(633, 325);
            this.tabEvents.TabIndex = 1;
            this.tabEvents.Text = "Events";
            this.tabEvents.UseVisualStyleBackColor = true;
            // 
            // EventGrid
            // 
            this.EventGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EventGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventGrid.Location = new System.Drawing.Point(3, 3);
            this.EventGrid.Name = "EventGrid";
            this.EventGrid.Size = new System.Drawing.Size(627, 319);
            this.EventGrid.TabIndex = 0;
            this.EventGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EventGrid_CellContentClick);
            // 
            // NewProject
            // 
            this.NewProject.AutoSize = true;
            this.NewProject.Location = new System.Drawing.Point(3, 3);
            this.NewProject.Name = "NewProject";
            this.NewProject.Size = new System.Drawing.Size(75, 23);
            this.NewProject.TabIndex = 1;
            this.NewProject.Text = "New Project";
            this.NewProject.UseVisualStyleBackColor = true;
            this.NewProject.Click += new System.EventHandler(this.NewProject_Click);
            // 
            // OpenProject
            // 
            this.OpenProject.AutoSize = true;
            this.OpenProject.Location = new System.Drawing.Point(84, 3);
            this.OpenProject.Name = "OpenProject";
            this.OpenProject.Size = new System.Drawing.Size(79, 23);
            this.OpenProject.TabIndex = 2;
            this.OpenProject.Text = "Open Project";
            this.OpenProject.UseVisualStyleBackColor = true;
            this.OpenProject.Click += new System.EventHandler(this.OpenProject_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Project Name";
            // 
            // textBoxProjectName
            // 
            this.textBoxProjectName.Enabled = false;
            this.textBoxProjectName.Location = new System.Drawing.Point(93, 50);
            this.textBoxProjectName.Name = "textBoxProjectName";
            this.textBoxProjectName.Size = new System.Drawing.Size(200, 20);
            this.textBoxProjectName.TabIndex = 4;
            this.textBoxProjectName.TextChanged += new System.EventHandler(this.textBoxProjectName_TextChanged);
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Enabled = false;
            this.StartDatePicker.Location = new System.Drawing.Point(93, 76);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(200, 20);
            this.StartDatePicker.TabIndex = 6;
            this.StartDatePicker.ValueChanged += new System.EventHandler(this.StartDatePicker_ValueChanged);
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Enabled = false;
            this.EndDatePicker.Location = new System.Drawing.Point(93, 102);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(200, 20);
            this.EndDatePicker.TabIndex = 7;
            this.EndDatePicker.ValueChanged += new System.EventHandler(this.EndDatePicker_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "End Date";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.NewProject);
            this.flowLayoutPanel1.Controls.Add(this.OpenProject);
            this.flowLayoutPanel1.Controls.Add(this.SaveProject);
            this.flowLayoutPanel1.Controls.Add(this.CreateSlideBTN);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(641, 37);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // SaveProject
            // 
            this.SaveProject.AutoSize = true;
            this.SaveProject.Location = new System.Drawing.Point(169, 3);
            this.SaveProject.Name = "SaveProject";
            this.SaveProject.Size = new System.Drawing.Size(79, 23);
            this.SaveProject.TabIndex = 3;
            this.SaveProject.Text = "Save Project";
            this.SaveProject.UseVisualStyleBackColor = true;
            this.SaveProject.Click += new System.EventHandler(this.SaveProject_Click);
            // 
            // CreateSlideBTN
            // 
            this.CreateSlideBTN.AutoSize = true;
            this.CreateSlideBTN.Enabled = false;
            this.CreateSlideBTN.Location = new System.Drawing.Point(254, 3);
            this.CreateSlideBTN.Name = "CreateSlideBTN";
            this.CreateSlideBTN.Size = new System.Drawing.Size(130, 23);
            this.CreateSlideBTN.TabIndex = 4;
            this.CreateSlideBTN.Text = "Create Powerpoint Slide";
            this.CreateSlideBTN.UseVisualStyleBackColor = true;
            this.CreateSlideBTN.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ProjectSave
            // 
            this.ProjectSave.Filter = "xml files|*.xml";
            this.ProjectSave.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // projectBindingSource
            // 
            this.projectBindingSource.DataMember = "Project";
            this.projectBindingSource.DataSource = this.projectDAta;
            // 
            // projectDAta
            // 
            this.projectDAta.DataSetName = "ProjectDAta";
            this.projectDAta.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 498);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.textBoxProjectName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabBars.ResumeLayout(false);
            this.tabBars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarGrid)).EndInit();
            this.tabEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EventGrid)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectDAta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBars;
        private System.Windows.Forms.TabPage tabEvents;
        private System.Windows.Forms.Button NewProject;
        private System.Windows.Forms.Button OpenProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProjectName;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button SaveProject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView BarGrid;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView EventGrid;
        private System.Windows.Forms.SaveFileDialog ProjectSave;
        private System.Windows.Forms.OpenFileDialog ProjectOpen;
        private System.Windows.Forms.BindingSource projectBindingSource;
        private ProjectDAta projectDAta;
        private System.Windows.Forms.Button CreateSlideBTN;
    }
}

