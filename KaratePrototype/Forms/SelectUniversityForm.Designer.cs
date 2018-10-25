namespace KaratePrototype
{
    partial class SelectUniversityForm
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
            this.quitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.universityDescriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.aUBudgetLabel = new System.Windows.Forms.Label();
            this.universityReputationLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.universityLocationLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bucsPointsLabel = new System.Windows.Forms.Label();
            this.universityLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.universityNameLabel = new System.Windows.Forms.Label();
            this.universityListBox = new System.Windows.Forms.ListBox();
            this.startButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.universityLogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.quitButton.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.quitButton.Location = new System.Drawing.Point(12, 425);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(108, 49);
            this.quitButton.TabIndex = 0;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(390, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a Univeristy for your karate club.";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.universityDescriptionTextBox);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.universityLogoPictureBox);
            this.groupBox1.Controls.Add(this.universityNameLabel);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(229, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 387);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info:";
            // 
            // universityDescriptionTextBox
            // 
            this.universityDescriptionTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.universityDescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.universityDescriptionTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.universityDescriptionTextBox.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.universityDescriptionTextBox.Location = new System.Drawing.Point(6, 173);
            this.universityDescriptionTextBox.Name = "universityDescriptionTextBox";
            this.universityDescriptionTextBox.ReadOnly = true;
            this.universityDescriptionTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.universityDescriptionTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.universityDescriptionTextBox.Size = new System.Drawing.Size(286, 119);
            this.universityDescriptionTextBox.TabIndex = 5;
            this.universityDescriptionTextBox.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.aUBudgetLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.universityReputationLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.universityLocationLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.bucsPointsLabel, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 298);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(295, 86);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "BUCS Points:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aUBudgetLabel
            // 
            this.aUBudgetLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.aUBudgetLabel.AutoSize = true;
            this.aUBudgetLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aUBudgetLabel.Location = new System.Drawing.Point(97, 43);
            this.aUBudgetLabel.Name = "aUBudgetLabel";
            this.aUBudgetLabel.Size = new System.Drawing.Size(74, 20);
            this.aUBudgetLabel.TabIndex = 6;
            this.aUBudgetLabel.Text = "AU Budget";
            this.aUBudgetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // universityReputationLabel
            // 
            this.universityReputationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.universityReputationLabel.AutoSize = true;
            this.universityReputationLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.universityReputationLabel.Location = new System.Drawing.Point(97, 22);
            this.universityReputationLabel.Name = "universityReputationLabel";
            this.universityReputationLabel.Size = new System.Drawing.Size(70, 20);
            this.universityReputationLabel.TabIndex = 4;
            this.universityReputationLabel.Text = "Rep Value";
            this.universityReputationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Reputation:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Location:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // universityLocationLabel
            // 
            this.universityLocationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.universityLocationLabel.AutoSize = true;
            this.universityLocationLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.universityLocationLabel.Location = new System.Drawing.Point(97, 1);
            this.universityLocationLabel.Name = "universityLocationLabel";
            this.universityLocationLabel.Size = new System.Drawing.Size(101, 20);
            this.universityLocationLabel.TabIndex = 2;
            this.universityLocationLabel.Text = "Location Name";
            this.universityLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "AU Budget:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bucsPointsLabel
            // 
            this.bucsPointsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bucsPointsLabel.AutoSize = true;
            this.bucsPointsLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bucsPointsLabel.Location = new System.Drawing.Point(97, 64);
            this.bucsPointsLabel.Name = "bucsPointsLabel";
            this.bucsPointsLabel.Size = new System.Drawing.Size(47, 21);
            this.bucsPointsLabel.TabIndex = 7;
            this.bucsPointsLabel.Text = "points";
            this.bucsPointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // universityLogoPictureBox
            // 
            this.universityLogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.universityLogoPictureBox.Location = new System.Drawing.Point(6, 19);
            this.universityLogoPictureBox.Name = "universityLogoPictureBox";
            this.universityLogoPictureBox.Size = new System.Drawing.Size(289, 124);
            this.universityLogoPictureBox.TabIndex = 3;
            this.universityLogoPictureBox.TabStop = false;
            // 
            // universityNameLabel
            // 
            this.universityNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.universityNameLabel.AutoSize = true;
            this.universityNameLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.universityNameLabel.Location = new System.Drawing.Point(6, 146);
            this.universityNameLabel.Name = "universityNameLabel";
            this.universityNameLabel.Size = new System.Drawing.Size(147, 22);
            this.universityNameLabel.TabIndex = 0;
            this.universityNameLabel.Text = "university of test";
            this.universityNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // universityListBox
            // 
            this.universityListBox.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.universityListBox.FormattingEnabled = true;
            this.universityListBox.ItemHeight = 19;
            this.universityListBox.Location = new System.Drawing.Point(12, 30);
            this.universityListBox.Name = "universityListBox";
            this.universityListBox.Size = new System.Drawing.Size(211, 384);
            this.universityListBox.TabIndex = 3;
            this.universityListBox.SelectedIndexChanged += new System.EventHandler(this.universityListBox_SelectedIndexChanged);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.startButton.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startButton.Location = new System.Drawing.Point(422, 425);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(108, 49);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start Game";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // SelectUniversityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(542, 480);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.universityListBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quitButton);
            this.Name = "SelectUniversityForm";
            this.Text = "Select University";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.universityLogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox universityListBox;
        private System.Windows.Forms.RichTextBox universityDescriptionTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label aUBudgetLabel;
        private System.Windows.Forms.Label universityReputationLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label universityLocationLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox universityLogoPictureBox;
        private System.Windows.Forms.Label universityNameLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label bucsPointsLabel;
    }
}

