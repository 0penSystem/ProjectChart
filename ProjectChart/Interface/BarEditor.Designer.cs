namespace ProjectChart.Interface
{
    partial class BarEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider (this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cbShape = new System.Windows.Forms.ComboBox();
            ( (System.ComponentModel.ISupportInitialize) (this.errorProvider)).BeginInit();
            this.SuspendLayout();
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point (34, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size (35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point (14, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size (55, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Start Date";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point (17, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size (52, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "End Date";
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point (75, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size (200, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler (this.txtName_Validating);
            //
            // dtStart
            //
            this.dtStart.Location = new System.Drawing.Point (75, 38);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size (200, 20);
            this.dtStart.TabIndex = 1;
            //
            // dtEnd
            //
            this.dtEnd.Location = new System.Drawing.Point (75, 64);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size (200, 20);
            this.dtEnd.TabIndex = 2;
            this.dtEnd.Value = new System.DateTime (2016, 11, 4, 14, 17, 32, 0);
            //
            // btnSave
            //
            this.btnSave.Anchor = ( (System.Windows.Forms.AnchorStyles) ( (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point (129, 125);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size (75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler (this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.Anchor = ( (System.Windows.Forms.AnchorStyles) ( (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Location = new System.Drawing.Point (211, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size (75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler (this.btnCancel_Click);
            //
            // errorProvider
            //
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point (31, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size (38, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Shape";
            //
            // cbShape
            //
            this.cbShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShape.FormattingEnabled = true;
            this.cbShape.Items.AddRange (new object[]
            {
                "Rectangle",
                "Rounded Rectangle",
                "Ramp"
            });
            this.cbShape.Location = new System.Drawing.Point (75, 90);
            this.cbShape.Name = "cbShape";
            this.cbShape.Size = new System.Drawing.Size (200, 21);
            this.cbShape.TabIndex = 3;
            //
            // BarEditor
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size (298, 160);
            this.ControlBox = false;
            this.Controls.Add (this.cbShape);
            this.Controls.Add (this.label4);
            this.Controls.Add (this.btnCancel);
            this.Controls.Add (this.btnSave);
            this.Controls.Add (this.dtEnd);
            this.Controls.Add (this.dtStart);
            this.Controls.Add (this.txtName);
            this.Controls.Add (this.label3);
            this.Controls.Add (this.label2);
            this.Controls.Add (this.label1);
            this.MinimumSize = new System.Drawing.Size (305, 170);
            this.Name = "BarEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bar Editor";
            ( (System.ComponentModel.ISupportInitialize) (this.errorProvider)).EndInit();
            this.ResumeLayout (false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox cbShape;
        private System.Windows.Forms.Label label4;
    }
}