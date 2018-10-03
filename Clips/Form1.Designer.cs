namespace Clips
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtView = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainerV = new System.Windows.Forms.SplitContainer();
            this.btnNew = new System.Windows.Forms.Button();
            this.checkMinimize = new System.Windows.Forms.CheckBox();
            this.btnRemoveIndent = new System.Windows.Forms.Button();
            this.splitContainerH = new System.Windows.Forms.SplitContainer();
            this.btnClear = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lstClips = new Clips.VisualStylesListView();
            this.clmNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerV)).BeginInit();
            this.splitContainerV.Panel1.SuspendLayout();
            this.splitContainerV.Panel2.SuspendLayout();
            this.splitContainerV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerH)).BeginInit();
            this.splitContainerH.Panel1.SuspendLayout();
            this.splitContainerH.Panel2.SuspendLayout();
            this.splitContainerH.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.Location = new System.Drawing.Point(12, 253);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(60, 23);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPaste.Location = new System.Drawing.Point(78, 253);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(60, 23);
            this.btnPaste.TabIndex = 2;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(225, 253);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtView
            // 
            this.txtView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtView.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtView.Location = new System.Drawing.Point(12, 12);
            this.txtView.Multiline = true;
            this.txtView.Name = "txtView";
            this.txtView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtView.Size = new System.Drawing.Size(549, 228);
            this.txtView.TabIndex = 3;
            this.txtView.TextChanged += new System.EventHandler(this.txtView_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(56, 253);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(317, 20);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(380, 251);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveUp.Image")));
            this.btnMoveUp.Location = new System.Drawing.Point(489, 253);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(33, 23);
            this.btnMoveUp.TabIndex = 4;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveDown.Image")));
            this.btnMoveDown.Location = new System.Drawing.Point(528, 253);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(33, 23);
            this.btnMoveDown.TabIndex = 5;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Name:";
            // 
            // splitContainerV
            // 
            this.splitContainerV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerV.Location = new System.Drawing.Point(3, 3);
            this.splitContainerV.Name = "splitContainerV";
            this.splitContainerV.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerV.Panel1
            // 
            this.splitContainerV.Panel1.Controls.Add(this.btnNew);
            this.splitContainerV.Panel1.Controls.Add(this.checkMinimize);
            this.splitContainerV.Panel1.Controls.Add(this.lstClips);
            this.splitContainerV.Panel1.Controls.Add(this.btnCopy);
            this.splitContainerV.Panel1.Controls.Add(this.btnMoveDown);
            this.splitContainerV.Panel1.Controls.Add(this.btnPaste);
            this.splitContainerV.Panel1.Controls.Add(this.btnMoveUp);
            this.splitContainerV.Panel1.Controls.Add(this.btnDelete);
            this.splitContainerV.Panel1MinSize = 150;
            // 
            // splitContainerV.Panel2
            // 
            this.splitContainerV.Panel2.Controls.Add(this.btnRemoveIndent);
            this.splitContainerV.Panel2.Controls.Add(this.txtView);
            this.splitContainerV.Panel2.Controls.Add(this.label1);
            this.splitContainerV.Panel2.Controls.Add(this.txtName);
            this.splitContainerV.Panel2.Controls.Add(this.btnSave);
            this.splitContainerV.Panel2MinSize = 150;
            this.splitContainerV.Size = new System.Drawing.Size(578, 571);
            this.splitContainerV.SplitterDistance = 285;
            this.splitContainerV.SplitterWidth = 2;
            this.splitContainerV.TabIndex = 12;
            this.splitContainerV.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(159, 253);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(60, 23);
            this.btnNew.TabIndex = 7;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // checkMinimize
            // 
            this.checkMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkMinimize.AutoSize = true;
            this.checkMinimize.Location = new System.Drawing.Point(358, 257);
            this.checkMinimize.Name = "checkMinimize";
            this.checkMinimize.Size = new System.Drawing.Size(107, 17);
            this.checkMinimize.TabIndex = 6;
            this.checkMinimize.Text = "Minimize on copy";
            this.checkMinimize.UseVisualStyleBackColor = true;
            // 
            // btnRemoveIndent
            // 
            this.btnRemoveIndent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveIndent.Location = new System.Drawing.Point(461, 251);
            this.btnRemoveIndent.Name = "btnRemoveIndent";
            this.btnRemoveIndent.Size = new System.Drawing.Size(100, 23);
            this.btnRemoveIndent.TabIndex = 2;
            this.btnRemoveIndent.Text = "Remove indent";
            this.btnRemoveIndent.UseVisualStyleBackColor = true;
            this.btnRemoveIndent.Click += new System.EventHandler(this.btnRemoveIndent_Click);
            // 
            // splitContainerH
            // 
            this.splitContainerH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerH.Location = new System.Drawing.Point(0, 0);
            this.splitContainerH.Name = "splitContainerH";
            // 
            // splitContainerH.Panel1
            // 
            this.splitContainerH.Panel1.Controls.Add(this.btnClear);
            this.splitContainerH.Panel1.Controls.Add(this.textBox1);
            // 
            // splitContainerH.Panel2
            // 
            this.splitContainerH.Panel2.Controls.Add(this.splitContainerV);
            this.splitContainerH.Panel2MinSize = 520;
            this.splitContainerH.Size = new System.Drawing.Size(981, 577);
            this.splitContainerH.SplitterDistance = 401;
            this.splitContainerH.SplitterWidth = 2;
            this.splitContainerH.TabIndex = 13;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(289, 541);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear clipboard";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Font = new System.Drawing.Font("Lucida Console", 9F);
            this.textBox1.Location = new System.Drawing.Point(12, 15);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(377, 514);
            this.textBox1.TabIndex = 0;
            // 
            // lstClips
            // 
            this.lstClips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstClips.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmNumber,
            this.clmName});
            this.lstClips.FullRowSelect = true;
            this.lstClips.Location = new System.Drawing.Point(12, 12);
            this.lstClips.MultiSelect = false;
            this.lstClips.Name = "lstClips";
            this.lstClips.Size = new System.Drawing.Size(549, 230);
            this.lstClips.TabIndex = 0;
            this.lstClips.UseCompatibleStateImageBehavior = false;
            this.lstClips.View = System.Windows.Forms.View.Details;
            this.lstClips.SelectedIndexChanged += new System.EventHandler(this.lstClips_SelectedIndexChanged);
            this.lstClips.DoubleClick += new System.EventHandler(this.lstClips_DoubleClick);
            // 
            // clmNumber
            // 
            this.clmNumber.Text = "#";
            this.clmNumber.Width = 46;
            // 
            // clmName
            // 
            this.clmName.Text = "Name";
            this.clmName.Width = 394;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 577);
            this.Controls.Add(this.splitContainerH);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 400);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clips";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Form1_Layout);
            this.splitContainerV.Panel1.ResumeLayout(false);
            this.splitContainerV.Panel1.PerformLayout();
            this.splitContainerV.Panel2.ResumeLayout(false);
            this.splitContainerV.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerV)).EndInit();
            this.splitContainerV.ResumeLayout(false);
            this.splitContainerH.Panel1.ResumeLayout(false);
            this.splitContainerH.Panel1.PerformLayout();
            this.splitContainerH.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerH)).EndInit();
            this.splitContainerH.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private VisualStylesListView lstClips;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtView;
        private System.Windows.Forms.ColumnHeader clmNumber;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainerV;
        private System.Windows.Forms.Button btnRemoveIndent;
        private System.Windows.Forms.CheckBox checkMinimize;
        private System.Windows.Forms.SplitContainer splitContainerH;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnNew;
    }
}

