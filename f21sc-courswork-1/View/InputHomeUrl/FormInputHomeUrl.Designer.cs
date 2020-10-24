namespace f21sc_courswork_1.View
{
    partial class FormInputHomeUrl
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
            this.textBoxInputUrl = new System.Windows.Forms.TextBox();
            this.buttonTestUrl = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelFeedback = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxInputUrl
            // 
            this.textBoxInputUrl.Location = new System.Drawing.Point(12, 11);
            this.textBoxInputUrl.Name = "textBoxInputUrl";
            this.textBoxInputUrl.Size = new System.Drawing.Size(269, 20);
            this.textBoxInputUrl.TabIndex = 0;
            this.textBoxInputUrl.TextChanged += new System.EventHandler(this.textBoxInputUrl_TextChanged);
            // 
            // buttonTestUrl
            // 
            this.buttonTestUrl.Enabled = false;
            this.buttonTestUrl.Location = new System.Drawing.Point(287, 9);
            this.buttonTestUrl.Name = "buttonTestUrl";
            this.buttonTestUrl.Size = new System.Drawing.Size(75, 23);
            this.buttonTestUrl.TabIndex = 1;
            this.buttonTestUrl.Text = "Test !";
            this.buttonTestUrl.UseVisualStyleBackColor = true;
            this.buttonTestUrl.Click += new System.EventHandler(this.buttonTestUrl_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(115, 54);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(196, 54);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelFeedback
            // 
            this.labelFeedback.AutoSize = true;
            this.labelFeedback.Location = new System.Drawing.Point(12, 34);
            this.labelFeedback.Name = "labelFeedback";
            this.labelFeedback.Size = new System.Drawing.Size(0, 13);
            this.labelFeedback.TabIndex = 4;
            this.labelFeedback.Visible = false;
            // 
            // FormInputHomeUrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 89);
            this.Controls.Add(this.labelFeedback);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonTestUrl);
            this.Controls.Add(this.textBoxInputUrl);
            this.Name = "FormInputHomeUrl";
            this.Text = "Personalize Home URL";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormInputHomeUrl_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInputUrl;
        private System.Windows.Forms.Button buttonTestUrl;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelFeedback;
    }
}