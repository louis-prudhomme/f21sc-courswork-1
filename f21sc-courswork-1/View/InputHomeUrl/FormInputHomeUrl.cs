using f21sc_coursework_1.Events;
using System;
using System.Windows.Forms;

namespace f21sc_coursework_1.View.InputHomeUrl
{
    public partial class FormInputHomeUrl : Form, IInputHomeUrlView
    {
        public FormInputHomeUrl()
        {
            InitializeComponent();
        }

        public event EventHandler HomeUrlCancelledEvent;
        public event UrlSentEvent HomeUrlSubmittedEvent;
        
        public event UrlSentEvent UrlSentEvent;

        public void SetUrlFeedback(string feedback)
        {
            this.labelFeedback.Visible = feedback.Length > 0;
            this.labelFeedback.Text = feedback;
        }

        public void UpdateUrl(string url)
        {
            this.textBoxInputUrl.Text = url;

            this.buttonOk.Enabled = true;
            this.buttonOk.Focus();
        }

        public void ShouldEnableOk(bool should)
        {
            this.buttonOk.Enabled = should;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormInputHomeUrl_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.HomeUrlCancelledEvent(this, EventArgs.Empty);
        }

        private void textBoxInputUrl_TextChanged(object sender, EventArgs e)
        {
            this.buttonTestUrl.Enabled = this.textBoxInputUrl.Text.Length > 0;
            this.buttonOk.Enabled = false;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.HomeUrlSubmittedEvent(this, new UrlSentEventArgs(this.textBoxInputUrl.Text));
            this.Close();
        }

        private void buttonTestUrl_Click(object sender, EventArgs e)
        {
            this.UrlSentEvent(this, new UrlSentEventArgs(this.textBoxInputUrl.Text));
        }

        private void textBoxInputUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.UrlSentEvent(this, new UrlSentEventArgs(this.textBoxInputUrl.Text));
                this.labelFeedback.Focus();
            }
        }

        /// <summary>
        /// Displays an error dialog using <see cref="MessageBox"/>
        /// </summary>
        /// <param name="error">Error description to display</param>
        public void ErrorDialog(string error)
        {
            MessageBox.Show(error,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
