using f21sc_courswork_1.Event;
using f21sc_courswork_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace f21sc_courswork_1.View
{
    public partial class FormMain : Form, IMainView
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public event EventHandler MainFormClosedEvent;

        public event UrlQueriedEvent UrlQueriedEvent;
        public event EventHandler ReloadAskedEvent;
        
        public event EventHandler DeleteAllHistoryEvent;
        public event EventHandler BackwardAskedEvent;
        public event EventHandler ForwardAskedEvent;

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

        public void SetTitle(string title)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.Text = title));
            } else
            {
                this.Text = title;
            }
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
            this.SetTitle("Browser – " + answer.Title);
            this.SetCode(answer.Code);
            this.SetStatus(answer.Status);
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            this.ReloadAskedEvent(this, EventArgs.Empty);
        }

        public void EnableReload()
        {
            this.buttonReload.Enabled = true;
            this.reloadToolStripMenuItem.Enabled = true;
        }

        public void DisableReload()
        {
            this.buttonReload.Enabled = false;
            this.reloadToolStripMenuItem.Enabled = false;
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ReloadAskedEvent(this, EventArgs.Empty);
        }

        private void recentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.UrlQueriedEvent(this, new UrlQueriedEventArgs(((ToolStripMenuItem)sender).Text));
        }

        private void eraseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DeleteAllHistoryEvent(this, EventArgs.Empty);
        }

        public void UpdateUrl(string url)
        {
            if (this.textBoxUrlInput.InvokeRequired)
            {
                this.textBoxUrlInput.Invoke(new Action(() => this.textBoxUrlInput.Text = url));
            }
            else
            {
                this.textBoxUrlInput.Text = url;
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.BackwardAskedEvent(this, EventArgs.Empty);
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            this.ForwardAskedEvent(this, EventArgs.Empty);
        }

        public void DisableBackward()
        {
            this.buttonBackward.Enabled = false;
        }

        public void EnableBackward()
        {
            this.buttonBackward.Enabled = true;
        }

        public void DisableForward()
        {
            this.buttonForward.Enabled = false;
        }

        public void EnableForward()
        {
            this.buttonForward.Enabled = true;
        }

        public void UpdateRecent(List<HttpQuery> recentQueries)
        {
            if (this.menuStrip1.InvokeRequired)
            {
                this.menuStrip1.Invoke(new Action(() =>
                {
                    this.recentToolStripMenuItem.Enabled = recentQueries.Count > 0;
                    this.recentToolStripMenuItem.DropDownItems.Clear();
                    this.recentToolStripMenuItem.DropDownItems.AddRange(recentQueries.Select(query => this.MakeRecentToolStripItem(query)).ToArray());
                }));
            } else
            {
                this.recentToolStripMenuItem.DropDownItems.AddRange(recentQueries.Select(query => this.MakeRecentToolStripItem(query)).ToArray());
            }
        }

        private ToolStripMenuItem MakeRecentToolStripItem(HttpQuery recent)
        {
            ToolStripMenuItem toolStrip = new ToolStripMenuItem(recent.Host)
            {
                Tag = recent.Uri,
                ToolTipText = String.Format("Consulted on the {0} at {1}", recent.IssuedAt.ToString("dd/MM"), recent.IssuedAt.ToString("HH:mm")),
                Name = recent.TimestampIssuedAt.ToString()
            };
            toolStrip.Click += this.recentToolStripMenuItem_Click;

            return toolStrip;
        }
    }
}
