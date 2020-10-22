namespace f21sc_courswork_1.View
{
    partial class FormMain
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearchInput = new System.Windows.Forms.TextBox();
            this.richTextBoxHtmlDisplay = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Location = new System.Drawing.Point(352, 10);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(85, 23);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "Search !";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearchInput
            // 
            this.textBoxSearchInput.Location = new System.Drawing.Point(12, 12);
            this.textBoxSearchInput.Name = "textBoxSearchInput";
            this.textBoxSearchInput.Size = new System.Drawing.Size(334, 20);
            this.textBoxSearchInput.TabIndex = 1;
            this.textBoxSearchInput.Text = "https://www.lingscars.com/";
            // 
            // richTextBoxHtmlDisplay
            // 
            this.richTextBoxHtmlDisplay.Location = new System.Drawing.Point(12, 38);
            this.richTextBoxHtmlDisplay.Name = "richTextBoxHtmlDisplay";
            this.richTextBoxHtmlDisplay.ReadOnly = true;
            this.richTextBoxHtmlDisplay.Size = new System.Drawing.Size(425, 400);
            this.richTextBoxHtmlDisplay.TabIndex = 2;
            this.richTextBoxHtmlDisplay.Text = "";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 450);
            this.Controls.Add(this.richTextBoxHtmlDisplay);
            this.Controls.Add(this.textBoxSearchInput);
            this.Controls.Add(this.buttonSearch);
            this.Name = "FormMain";
            this.Text = "Browser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearchInput;
        private System.Windows.Forms.RichTextBox richTextBoxHtmlDisplay;
    }
}

