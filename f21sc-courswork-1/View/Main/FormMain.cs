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
        public event EventHandler HomeUrlInputAskedEvent;
        public event EventHandler HistoryPanelAskedEvent;

        public event UrlSentEvent UrlSentEvent;
        public event EventHandler ReloadAskedEvent;
        
        public event EventHandler WipeHistoryEvent;
        public event EventHandler BackwardAskedEvent;
        public event EventHandler ForwardAskedEvent;

        public void SetCurrentState(HttpAnswer answer, Node<HttpQuery> current)
        {
            if (this.InvokeRequired)
            {
                this.textBoxUrlInput.Invoke(new Action(() => this.UpdateControls(answer, current)));
            }
            else
            {
                this.UpdateControls(answer, current);
            }
        }

        private void UpdateControls(HttpAnswer answer, Node<HttpQuery> current)
        {
            this.Text = "Browser – " + answer.Title;
            this.richTextBoxHtmlDisplay.Text = answer.Html;

            this.toolStripStatusLabelHttpStatusCode.Text = current.Center.StatusCode.ToString();
            this.toolStripStatusLabelHttpStatus.Text = current.Center.Status;

            this.buttonReload.Enabled = current.HasCenter;

            this.UpdateNavigationControls(this.buttonBackward, current.Left);
            this.UpdateNavigationControls(this.buttonForward, current.Right);
            this.textBoxUrlInput.Text = current.Center.Uri.AbsoluteUri;
        }

        private void UpdateNavigationControls(Button navigationControl, HttpQuery query)
        {
            navigationControl.Enabled = query != null;
            if (query != null)
            {
                new ToolTip().SetToolTip(navigationControl, query.Title);
            }
        }

        public void UpdateRecent(List<HttpQuery> recentQueries)
        {
            if (this.menuStripUp.InvokeRequired)
            {
                this.menuStripUp.Invoke(new Action(() =>
                {
                    this.recentToolStripMenuItem.DropDownItems.Clear();
                    this.recentToolStripMenuItem.DropDownItems.AddRange(recentQueries.Select(query => this.MakeRecentToolStripItem(query)).ToArray());
                    this.ShouldHistoryControlsBeEnabled(this.recentToolStripMenuItem.DropDownItems.Count > 0);
                }));
            }
            else
            {
                this.recentToolStripMenuItem.DropDownItems.Clear();
                this.recentToolStripMenuItem.DropDownItems.AddRange(recentQueries.Select(query => this.MakeRecentToolStripItem(query)).ToArray());
                this.ShouldHistoryControlsBeEnabled(this.recentToolStripMenuItem.DropDownItems.Count > 0);
            }
        }

        private void ShouldHistoryControlsBeEnabled(bool should)
        {
            this.recentToolStripMenuItem.Enabled = should;
            this.eraseHistoryToolStripMenuItem.Enabled = should;
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

        public void ShouldBeEnabled(bool should)
        {
            this.Enabled = should;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            this.UrlSentEvent(this, new UrlSentEventArgs(this.textBoxUrlInput.Text));
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
                this.UrlSentEvent(this, new UrlSentEventArgs(this.textBoxUrlInput.Text));
            }
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            this.ReloadAskedEvent(this, EventArgs.Empty);
        }
        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ReloadAskedEvent(this, EventArgs.Empty);
        }

        private void recentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.UrlSentEvent(this, new UrlSentEventArgs(((ToolStripMenuItem)sender).Text));
        }

        private void eraseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Do you really want to wipe your history out ?" +
                " This cannot be reverted and it will not affect your current navigation.", "Confirm history deletion", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this.WipeHistoryEvent(this, EventArgs.Empty);
            }
        }
        public void DisplayErrorDialog(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.BackwardAskedEvent(this, EventArgs.Empty);
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            this.ForwardAskedEvent(this, EventArgs.Empty);
        }

        private void personalizeHomeURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.HomeUrlInputAskedEvent(this, EventArgs.Empty);
        }


        private void allHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.HistoryPanelAskedEvent(this, EventArgs.Empty);
        }
    }
}
