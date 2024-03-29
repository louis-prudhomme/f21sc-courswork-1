﻿namespace f21sc_coursework_1.View.FavoritesPanel
{
    partial class FormFavoritesPanel
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
            this.listBoxFavorites = new System.Windows.Forms.ListBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonDeselectAll = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonJump = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxFavorites
            // 
            this.listBoxFavorites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFavorites.FormattingEnabled = true;
            this.listBoxFavorites.IntegralHeight = false;
            this.listBoxFavorites.Location = new System.Drawing.Point(12, 12);
            this.listBoxFavorites.Name = "listBoxFavorites";
            this.listBoxFavorites.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFavorites.Size = new System.Drawing.Size(227, 337);
            this.listBoxFavorites.TabIndex = 1;
            this.listBoxFavorites.SelectedValueChanged += new System.EventHandler(this.listBoxFavorites_SelectedValueChanged);
            this.listBoxFavorites.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxFavorites_MouseDoubleClick);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(245, 12);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(132, 23);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = "Delete from favorites";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(245, 326);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(132, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonDeselectAll
            // 
            this.buttonDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeselectAll.Enabled = false;
            this.buttonDeselectAll.Location = new System.Drawing.Point(245, 122);
            this.buttonDeselectAll.Name = "buttonDeselectAll";
            this.buttonDeselectAll.Size = new System.Drawing.Size(132, 23);
            this.buttonDeselectAll.TabIndex = 10;
            this.buttonDeselectAll.TabStop = false;
            this.buttonDeselectAll.Text = "Deselect all";
            this.buttonDeselectAll.UseVisualStyleBackColor = true;
            this.buttonDeselectAll.Click += new System.EventHandler(this.buttonDeselectAll_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectAll.Enabled = false;
            this.buttonSelectAll.Location = new System.Drawing.Point(245, 93);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(132, 23);
            this.buttonSelectAll.TabIndex = 9;
            this.buttonSelectAll.TabStop = false;
            this.buttonSelectAll.Text = "Select all";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Location = new System.Drawing.Point(245, 41);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(132, 23);
            this.buttonEdit.TabIndex = 11;
            this.buttonEdit.Text = "Edit favorite";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonJump
            // 
            this.buttonJump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonJump.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonJump.Enabled = false;
            this.buttonJump.Location = new System.Drawing.Point(245, 297);
            this.buttonJump.Name = "buttonJump";
            this.buttonJump.Size = new System.Drawing.Size(132, 23);
            this.buttonJump.TabIndex = 12;
            this.buttonJump.Text = "Jump to";
            this.buttonJump.UseVisualStyleBackColor = true;
            this.buttonJump.Click += new System.EventHandler(this.buttonJump_Click);
            // 
            // FormFavoritesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.buttonJump);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDeselectAll);
            this.Controls.Add(this.buttonSelectAll);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.listBoxFavorites);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "FormFavoritesPanel";
            this.Text = "Favorites panel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormFavoritesPanel_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxFavorites;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonDeselectAll;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonJump;
    }
}