namespace f21sc_coursework_1.View.HistoryPanel
{
    partial class FormHistoryPanel
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
            this.listBoxHistory = new System.Windows.Forms.ListBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonFav = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonWipeHistory = new System.Windows.Forms.Button();
            this.buttonDeselectAll = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxHistory
            // 
            this.listBoxHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxHistory.FormattingEnabled = true;
            this.listBoxHistory.IntegralHeight = false;
            this.listBoxHistory.Location = new System.Drawing.Point(12, 12);
            this.listBoxHistory.Name = "listBoxHistory";
            this.listBoxHistory.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxHistory.Size = new System.Drawing.Size(227, 341);
            this.listBoxHistory.TabIndex = 0;
            this.listBoxHistory.SelectedValueChanged += new System.EventHandler(this.listBoxHistory_SelectedValueChanged);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(245, 12);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(132, 23);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "Delete from history";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonFav
            // 
            this.buttonFav.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFav.Enabled = false;
            this.buttonFav.Location = new System.Drawing.Point(245, 41);
            this.buttonFav.Name = "buttonFav";
            this.buttonFav.Size = new System.Drawing.Size(132, 23);
            this.buttonFav.TabIndex = 2;
            this.buttonFav.Text = "Add to favorites";
            this.buttonFav.UseVisualStyleBackColor = true;
            this.buttonFav.Click += new System.EventHandler(this.buttonFav_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(245, 330);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(132, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonWipeHistory
            // 
            this.buttonWipeHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWipeHistory.Enabled = false;
            this.buttonWipeHistory.Location = new System.Drawing.Point(245, 180);
            this.buttonWipeHistory.Name = "buttonWipeHistory";
            this.buttonWipeHistory.Size = new System.Drawing.Size(132, 23);
            this.buttonWipeHistory.TabIndex = 4;
            this.buttonWipeHistory.TabStop = false;
            this.buttonWipeHistory.Text = "Delete all history";
            this.buttonWipeHistory.UseVisualStyleBackColor = true;
            this.buttonWipeHistory.Click += new System.EventHandler(this.buttonDeleteAllHistory_Click);
            // 
            // buttonDeselectAll
            // 
            this.buttonDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeselectAll.Enabled = false;
            this.buttonDeselectAll.Location = new System.Drawing.Point(245, 123);
            this.buttonDeselectAll.Name = "buttonDeselectAll";
            this.buttonDeselectAll.Size = new System.Drawing.Size(132, 23);
            this.buttonDeselectAll.TabIndex = 6;
            this.buttonDeselectAll.TabStop = false;
            this.buttonDeselectAll.Text = "Deselect all";
            this.buttonDeselectAll.UseVisualStyleBackColor = true;
            this.buttonDeselectAll.Click += new System.EventHandler(this.buttonDeselectAll_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectAll.Enabled = false;
            this.buttonSelectAll.Location = new System.Drawing.Point(245, 94);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(132, 23);
            this.buttonSelectAll.TabIndex = 5;
            this.buttonSelectAll.TabStop = false;
            this.buttonSelectAll.Text = "Select all";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // FormHistoryPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.buttonDeselectAll);
            this.Controls.Add(this.buttonSelectAll);
            this.Controls.Add(this.buttonWipeHistory);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonFav);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.listBoxHistory);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "FormHistoryPanel";
            this.Text = "History panel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormHistoryPanel_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxHistory;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonFav;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonWipeHistory;
        private System.Windows.Forms.Button buttonDeselectAll;
        private System.Windows.Forms.Button buttonSelectAll;
    }
}