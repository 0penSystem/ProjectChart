namespace ProjectChart.Interface
{
    partial class BarManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.barsBinding = new System.Windows.Forms.BindingSource (this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miNewBar = new System.Windows.Forms.ToolStripMenuItem();
            ( (System.ComponentModel.ISupportInitialize) (this.dataGridView1)).BeginInit();
            ( (System.ComponentModel.ISupportInitialize) (this.barsBinding)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            // dataGridView1
            //
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.Columns.AddRange (new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colName,
                this.colStart,
                this.colEnd,
                this.colShape,
                this.colEdit,
                this.colDelete
            });
            this.dataGridView1.DataSource = this.barsBinding;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point (0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size (664, 262);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler (this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler (this.dataGridView1_CellContentDoubleClick);
            //
            // colName
            //
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.FillWeight = 35F;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            //
            // colStart
            //
            this.colStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStart.DataPropertyName = "Start";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.colStart.DefaultCellStyle = dataGridViewCellStyle1;
            this.colStart.FillWeight = 20F;
            this.colStart.HeaderText = "Start Date";
            this.colStart.Name = "colStart";
            this.colStart.ReadOnly = true;
            //
            // colEnd
            //
            this.colEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEnd.DataPropertyName = "End";
            dataGridViewCellStyle2.Format = "d";
            this.colEnd.DefaultCellStyle = dataGridViewCellStyle2;
            this.colEnd.FillWeight = 20F;
            this.colEnd.HeaderText = "End Date";
            this.colEnd.Name = "colEnd";
            this.colEnd.ReadOnly = true;
            //
            // colShape
            //
            this.colShape.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colShape.DataPropertyName = "Shape";
            this.colShape.FillWeight = 10F;
            this.colShape.HeaderText = "Shape";
            this.colShape.Name = "colShape";
            this.colShape.ReadOnly = true;
            //
            // colEdit
            //
            this.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEdit.FillWeight = 10F;
            this.colEdit.HeaderText = "";
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Text = "Edit";
            this.colEdit.UseColumnTextForLinkValue = true;
            //
            // colDelete
            //
            this.colDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDelete.FillWeight = 10F;
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Text = "Delete";
            this.colDelete.UseColumnTextForLinkValue = true;
            //
            // menuStrip1
            //
            this.menuStrip1.Items.AddRange (new System.Windows.Forms.ToolStripItem[]
            {
                this.miNewBar
            });
            this.menuStrip1.Location = new System.Drawing.Point (0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size (664, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            //
            // miNewBar
            //
            this.miNewBar.Name = "miNewBar";
            this.miNewBar.Size = new System.Drawing.Size (63, 20);
            this.miNewBar.Text = "&New Bar";
            this.miNewBar.Click += new System.EventHandler (this.miNewBar_Click);
            //
            // BarManager
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size (664, 286);
            this.Controls.Add (this.dataGridView1);
            this.Controls.Add (this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BarManager";
            this.Text = "Bar Manager";
            ( (System.ComponentModel.ISupportInitialize) (this.dataGridView1)).EndInit();
            ( (System.ComponentModel.ISupportInitialize) (this.barsBinding)).EndInit();
            this.menuStrip1.ResumeLayout (false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout (false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource barsBinding;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miNewBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShape;
        private System.Windows.Forms.DataGridViewLinkColumn colEdit;
        private System.Windows.Forms.DataGridViewLinkColumn colDelete;
    }
}