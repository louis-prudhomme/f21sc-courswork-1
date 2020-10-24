using f21sc_courswork_1.Event;
using System;
using System.Windows.Forms;

namespace f21sc_courswork_1.View
{
    public partial class FormInputHomeUrl : Form, IInputHomeUrlView
    {
        public FormInputHomeUrl()
        {
            InitializeComponent();
        }

        public event EventHandler UrlInputFormCanceledEvent;
        public event UrlSentEvent UrlInputFormSubmittedEvent;
        public event UrlSentEvent UrlSentEvent;

        public void SetUrlFeedback(string feedback)
        {
            this.labelFeedback.Visible = feedback.Length > 0;
            this.labelFeedback.Text = feedback;
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
            this.UrlInputFormCanceledEvent(this, EventArgs.Empty);
        }

        private void textBoxInputUrl_TextChanged(object sender, EventArgs e)
        {
            this.buttonTestUrl.Enabled = this.textBoxInputUrl.Text.Length > 0;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.UrlInputFormSubmittedEvent(this, new UrlSentEventArgs(this.textBoxInputUrl.Text));
        }

        private void buttonTestUrl_Click(object sender, EventArgs e)
        {
            this.UrlSentEvent(this, new UrlSentEventArgs(this.textBoxInputUrl.Text));
        }
    }
}
