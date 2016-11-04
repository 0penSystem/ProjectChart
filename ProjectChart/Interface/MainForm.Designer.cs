namespace ProjectChart.Interface
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.saveXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miBarAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miBarManage = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miEventAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miEventsManage = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openXML = new System.Windows.Forms.OpenFileDialog();
            this.miProjectUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.miProjectReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.openPPT = new System.Windows.Forms.OpenFileDialog();
            this.miFileLoadXml = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileOpenPPT = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miProjectCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.barsToolStripMenuItem,
            this.eventsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(304, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileNew,
            this.miFileOpenPPT,
            this.toolStripSeparator2,
            this.saveXMLToolStripMenuItem,
            this.miFileLoadXml,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // miFileNew
            // 
            this.miFileNew.Name = "miFileNew";
            this.miFileNew.Size = new System.Drawing.Size(167, 22);
            this.miFileNew.Text = "&New Project";
            this.miFileNew.Click += new System.EventHandler(this.miFileNew_Click);
            // 
            // saveXMLToolStripMenuItem
            // 
            this.saveXMLToolStripMenuItem.Name = "saveXMLToolStripMenuItem";
            this.saveXMLToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveXMLToolStripMenuItem.Text = "&Save XML";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miProjectCreate,
            this.miProjectUpdate,
            this.miProjectReplace});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "&Project";
            // 
            // barsToolStripMenuItem
            // 
            this.barsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miBarAdd,
            this.miBarManage});
            this.barsToolStripMenuItem.Name = "barsToolStripMenuItem";
            this.barsToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.barsToolStripMenuItem.Text = "&Bars";
            // 
            // miBarAdd
            // 
            this.miBarAdd.Name = "miBarAdd";
            this.miBarAdd.Size = new System.Drawing.Size(152, 22);
            this.miBarAdd.Text = "&Add";
            this.miBarAdd.Click += new System.EventHandler(this.miBarAdd_Click);
            // 
            // miBarManage
            // 
            this.miBarManage.Name = "miBarManage";
            this.miBarManage.Size = new System.Drawing.Size(152, 22);
            this.miBarManage.Text = "&Manage";
            this.miBarManage.Click += new System.EventHandler(this.miBarManage_Click);
            // 
            // eventsToolStripMenuItem
            // 
            this.eventsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEventAdd,
            this.miEventsManage});
            this.eventsToolStripMenuItem.Name = "eventsToolStripMenuItem";
            this.eventsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.eventsToolStripMenuItem.Text = "&Events";
            // 
            // miEventAdd
            // 
            this.miEventAdd.Name = "miEventAdd";
            this.miEventAdd.Size = new System.Drawing.Size(152, 22);
            this.miEventAdd.Text = "&Add";
            this.miEventAdd.Click += new System.EventHandler(this.miEventAdd_Click);
            // 
            // miEventsManage
            // 
            this.miEventsManage.Name = "miEventsManage";
            this.miEventsManage.Size = new System.Drawing.Size(152, 22);
            this.miEventsManage.Text = "&Manage";
            this.miEventsManage.Click += new System.EventHandler(this.miEventsManage_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHelpAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // miHelpAbout
            // 
            this.miHelpAbout.Name = "miHelpAbout";
            this.miHelpAbout.Size = new System.Drawing.Size(152, 22);
            this.miHelpAbout.Text = "&About";
            this.miHelpAbout.Click += new System.EventHandler(this.miHelpAbout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Project Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(89, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 0;
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(89, 61);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 20);
            this.dtStart.TabIndex = 1;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(89, 87);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(200, 20);
            this.dtEnd.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "End Date";
            // 
            // miProjectUpdate
            // 
            this.miProjectUpdate.Name = "miProjectUpdate";
            this.miProjectUpdate.Size = new System.Drawing.Size(159, 22);
            this.miProjectUpdate.Text = "&Update Slide";
            this.miProjectUpdate.Click += new System.EventHandler(this.miProjectUpdate_Click);
            // 
            // miProjectReplace
            // 
            this.miProjectReplace.Name = "miProjectReplace";
            this.miProjectReplace.Size = new System.Drawing.Size(159, 22);
            this.miProjectReplace.Text = "Replace &Missing";
            this.miProjectReplace.Click += new System.EventHandler(this.miProjectReplace_Click);
            // 
            // openPPT
            // 
            this.openPPT.DefaultExt = "pptx";
            this.openPPT.Filter = "\"Powerpoint Files|*.ppt,*.pptx\"";
            // 
            // miFileLoadXml
            // 
            this.miFileLoadXml.Name = "miFileLoadXml";
            this.miFileLoadXml.Size = new System.Drawing.Size(167, 22);
            this.miFileLoadXml.Text = "&Load XML";
            this.miFileLoadXml.Click += new System.EventHandler(this.miFileLoadXml_Click);
            // 
            // miFileOpenPPT
            // 
            this.miFileOpenPPT.Name = "miFileOpenPPT";
            this.miFileOpenPPT.Size = new System.Drawing.Size(167, 22);
            this.miFileOpenPPT.Text = "Open &Powerpoint";
            this.miFileOpenPPT.Click += new System.EventHandler(this.miFileOpenPPT_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
            // 
            // miProjectCreate
            // 
            this.miProjectCreate.Name = "miProjectCreate";
            this.miProjectCreate.Size = new System.Drawing.Size(159, 22);
            this.miProjectCreate.Text = "&Create Slide";
            this.miProjectCreate.Click += new System.EventHandler(this.miProjectCreate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 131);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(320, 170);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miFileNew;
        private System.Windows.Forms.ToolStripMenuItem saveXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miHelpAbout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem miBarAdd;
        private System.Windows.Forms.ToolStripMenuItem miBarManage;
        private System.Windows.Forms.ToolStripMenuItem miEventAdd;
        private System.Windows.Forms.ToolStripMenuItem miEventsManage;
        private System.Windows.Forms.OpenFileDialog openXML;
        private System.Windows.Forms.ToolStripMenuItem miProjectUpdate;
        private System.Windows.Forms.ToolStripMenuItem miProjectReplace;
        private System.Windows.Forms.OpenFileDialog openPPT;
        private System.Windows.Forms.ToolStripMenuItem miFileLoadXml;
        private System.Windows.Forms.ToolStripMenuItem miFileOpenPPT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miProjectCreate;
    }
}