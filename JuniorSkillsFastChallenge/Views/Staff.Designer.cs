namespace JuniorSkillsFastChallenge.Views
{
    partial class Staff
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.ParticipantsGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurnameNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompetenceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SponsorsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchoolColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParticipantsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(825, 426);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.SearchBox);
            this.tabPage2.Controls.Add(this.ParticipantsGrid);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(817, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Participant";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(743, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 20);
            this.button2.TabIndex = 3;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Search);
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(603, 18);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(139, 20);
            this.SearchBox.TabIndex = 2;
            // 
            // ParticipantsGrid
            // 
            this.ParticipantsGrid.AllowUserToAddRows = false;
            this.ParticipantsGrid.AllowUserToDeleteRows = false;
            this.ParticipantsGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ParticipantsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParticipantsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.EmailColumn,
            this.SurnameNameColumn,
            this.CompetenceColumn,
            this.SponsorsColumn,
            this.SchoolColumn,
            this.CountryColumn});
            this.ParticipantsGrid.Location = new System.Drawing.Point(16, 44);
            this.ParticipantsGrid.MultiSelect = false;
            this.ParticipantsGrid.Name = "ParticipantsGrid";
            this.ParticipantsGrid.ReadOnly = true;
            this.ParticipantsGrid.RowHeadersVisible = false;
            this.ParticipantsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ParticipantsGrid.ShowCellToolTips = false;
            this.ParticipantsGrid.ShowEditingIcon = false;
            this.ParticipantsGrid.ShowRowErrors = false;
            this.ParticipantsGrid.Size = new System.Drawing.Size(782, 337);
            this.ParticipantsGrid.TabIndex = 1;
            this.ParticipantsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditParticipant);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RegisterParticipant);
            // 
            // IDColumn
            // 
            this.IDColumn.Frozen = true;
            this.IDColumn.HeaderText = "ID";
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            this.IDColumn.Visible = false;
            // 
            // EmailColumn
            // 
            this.EmailColumn.Frozen = true;
            this.EmailColumn.HeaderText = "Email";
            this.EmailColumn.Name = "EmailColumn";
            this.EmailColumn.ReadOnly = true;
            this.EmailColumn.Width = 175;
            // 
            // SurnameNameColumn
            // 
            this.SurnameNameColumn.Frozen = true;
            this.SurnameNameColumn.HeaderText = "Surname & Name";
            this.SurnameNameColumn.Name = "SurnameNameColumn";
            this.SurnameNameColumn.ReadOnly = true;
            this.SurnameNameColumn.Width = 150;
            // 
            // CompetenceColumn
            // 
            this.CompetenceColumn.Frozen = true;
            this.CompetenceColumn.HeaderText = "Competence";
            this.CompetenceColumn.Name = "CompetenceColumn";
            this.CompetenceColumn.ReadOnly = true;
            // 
            // SponsorsColumn
            // 
            this.SponsorsColumn.Frozen = true;
            this.SponsorsColumn.HeaderText = "Sponsors";
            this.SponsorsColumn.Name = "SponsorsColumn";
            this.SponsorsColumn.ReadOnly = true;
            this.SponsorsColumn.Width = 155;
            // 
            // SchoolColumn
            // 
            this.SchoolColumn.Frozen = true;
            this.SchoolColumn.HeaderText = "School";
            this.SchoolColumn.Name = "SchoolColumn";
            this.SchoolColumn.ReadOnly = true;
            // 
            // CountryColumn
            // 
            this.CountryColumn.Frozen = true;
            this.CountryColumn.HeaderText = "Country";
            this.CountryColumn.Name = "CountryColumn";
            this.CountryColumn.ReadOnly = true;
            // 
            // Staff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 450);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Staff";
            this.Text = "Staff";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParticipantsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.DataGridView ParticipantsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurnameNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompetenceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SponsorsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchoolColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryColumn;
    }
}