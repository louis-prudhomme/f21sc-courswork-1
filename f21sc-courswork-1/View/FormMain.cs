using f21sc_courswork_1.Event;
using f21sc_courswork_1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f21sc_courswork_1.View
{
    public partial class FormMain : Form, IMainView
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public event UrlQueriedEvent UrlQueriedEvent;
        public event EventHandler MainFormClosedEvent;

        public void SetHtml(string html)
        {
            if (this.richTextBoxHtmlDisplay.InvokeRequired)
            {
                this.richTextBoxHtmlDisplay.Invoke(new Action(() => this.richTextBoxHtmlDisplay.Text = html));
            } else {
                this.richTextBoxHtmlDisplay.Text = html;
            }
        }

        public void SetStatus(string status)
        {
            this.toolStripStatusLabelHttpStatus.Text = status;
        }

        public void SetCode(int statusCode)
        {
            this.toolStripStatusLabelHttpStatusCode.Text = statusCode.ToString();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            this.UrlQueriedEvent(this, new UrlQueriedEventArgs(this.textBoxUrlInput.Text));

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MainFormClosedEvent(this, EventArgs.Empty);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.MainFormClosedEvent(this, EventArgs.Empty);
        }

        private void textBoxUrlInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.UrlQueriedEvent(this, new UrlQueriedEventArgs(this.textBoxUrlInput.Text));
            }
        }

        public void SetHttpAnswer(HttpAnswer answer)
        {
            this.SetHtml(answer.Html);
            this.SetCode(answer.Code);
            this.SetStatus(answer.Status);
        }
    }
}
