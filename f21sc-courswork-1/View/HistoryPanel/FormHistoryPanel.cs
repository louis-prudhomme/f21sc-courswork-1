using f21sc_coursework_1.Events;
using f21sc_coursework_1.Model.HttpCommunications;
using f21sc_courswork_1.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace f21sc_coursework_1.View.HistoryPanel
{
    public partial class FormHistoryPanel : Form, IHistoryPanelView
    {
        public FormHistoryPanel()
        {
            InitializeComponent();
        }

        /* ==================================
         * INHERITED METHODS
         * ==================================*/

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void UpdateHistoryEntries(List<HttpQuery> entries)
        {
            this.listBoxHistory.BeginUpdate();
            this.listBoxHistory.Items.Clear();
            if (entries.Count != 0)
            {
                this.listBoxHistory.Items.AddRange(entries.ToArray());
                this.listBoxHistory.Enabled = true;
            }
            else
            {
                this.listBoxHistory.Items.Add("No history");
                this.listBoxHistory.Enabled = false;
            }
            this.UpdateHistoryDependantControls();
            this.listBoxHistory.EndUpdate();
        }

        /* ==================================
         * INTERNAL METHODS
         * ==================================*/

        /// <summary>
        /// Selects or deselects all items of the list box
        /// </summary>
        /// <param name="selection">true if the items should be all selected, false if none</param>
        private void SetAllSelected(bool selection)
        {
            this.listBoxHistory.BeginUpdate();
            for (int i = 0; i < this.listBoxHistory.Items.Count; i++)
            {
                this.listBoxHistory.SetSelected(i, selection);
            }
            this.listBoxHistory.EndUpdate();
        }

        /// <summary>
        /// Updates all the controls relying in some way on the history list box
        /// </summary>
        private void UpdateHistoryDependantControls()
        {
            this.buttonWipeHistory.Enabled = this.listBoxHistory.Enabled;

            this.buttonSelectAll.Enabled = this.listBoxHistory.Enabled && this.listBoxHistory.SelectedItems.Count != this.listBoxHistory.Items.Count;
            this.buttonDeselectAll.Enabled = this.listBoxHistory.SelectedItems.Count > 0;

            this.buttonJump.Enabled = this.listBoxHistory.SelectedItems.Count > 0;
            this.buttonDelete.Enabled = this.listBoxHistory.SelectedItems.Count > 0;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void ErrorDialog(string error)
        {
            MessageBox.Show(error,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void ShouldBeEnabled(bool should)
        {
            throw new NotImplementedException();
        }

        /* ==================================
         * CONTROL LISTENERS
         * ==================================*/

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.HistoryEntriesDeletedEvent(this, new HistoryEntriesDeletedEventArgs(this
                .listBoxHistory
                .SelectedItems
                .Cast<HttpQuery>()
                .ToList()));
        }

        private void buttonDeleteAllHistory_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Do you really want to wipe your history out ? " +
                "This cannot be reverted.",
                "Confirm history deletion",
                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                this.HistoryWipedEvent(this, EventArgs.Empty);
            }
        }

        private void buttonJump_Click(object sender, EventArgs e)
        {
            if (this.listBoxHistory.SelectedItems.Count > 1)
            {
                this.ErrorDialog("Only one page can be jumped to at a time.");
            } else if (this.listBoxHistory.SelectedItems.Count != 0)
            {
                this.JumpAskedEvent(this, new JumpAskedEventArgs(((HttpQuery)this.listBoxHistory.SelectedItem).Uri));
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHistoryPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ViewClosedEvent(this, EventArgs.Empty);
        }

        private void listBoxHistory_SelectedValueChanged(object sender, EventArgs e)
        {
            this.buttonDelete.Enabled = this.listBoxHistory.SelectedItems.Count > 0;
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            this.SetAllSelected(true);
        }

        private void buttonDeselectAll_Click(object sender, EventArgs e)
        {
            this.SetAllSelected(false);
        }

        private void listBoxHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.buttonJump_Click(this, EventArgs.Empty);
        }

        /* ==================================
         * EVENTS
         * ==================================*/

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler ViewClosedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event HistoryEntriesDeletedEvent HistoryEntriesDeletedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler HistoryWipedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event JumpAskedEvent JumpAskedEvent;
    }
}
