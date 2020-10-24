using f21sc_courswork_1.Event;
using f21sc_courswork_1.Model.HttpCommunications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace f21sc_courswork_1.View.HistoryPanel
{
    public partial class FormHistoryPanel : Form, IHistoryPanelView
    {
        public FormHistoryPanel()
        {
            InitializeComponent();
        }

        public event EventHandler HistoryPanelClosedEvent;
        public event HistoryEntriesDeletedEvent HistoryEntriesDeletedEvent;
        public event EventHandler HistoryWipedEvent;

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFav_Click(object sender, EventArgs e)
        {
            //todo
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.HistoryEntriesDeletedEvent(this, new HistoryEntriesDeletedEventArgs(this.listBoxHistory.SelectedItems.Cast<HttpQuery>().ToList()));
        }

        private void FormHistoryPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.HistoryPanelClosedEvent(this, EventArgs.Empty);
        }

        private void buttonDeleteAllHistory_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Do you really want to wipe your history out ? This cannot be reverted.", "Confirm history deletion", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this.HistoryWipedEvent(this, EventArgs.Empty);
            }
        }

        public void UpdateHistoryEntries(List<HttpQuery> entries)
        {
            this.listBoxHistory.Items.Clear();
            if (entries.Count != 0)
            {
                this.listBoxHistory.Items.AddRange(entries.ToArray());
                this.ShouldEnableHistoryDependantControls(true);
            } else
            {
                this.listBoxHistory.Items.Add("No history");
                this.ShouldEnableHistoryDependantControls(false);
            }
        }

        private void ShouldEnableHistoryDependantControls(bool should)
        {
            this.listBoxHistory.Enabled = should;
            this.buttonWipeHistory.Enabled = should;

            this.buttonSelectAll.Enabled = should;
            this.buttonDeselectAll.Enabled = should;

            this.buttonDelete.Enabled = should && this.listBoxHistory.SelectedItems.Count > 0;
            this.buttonFav.Enabled = should && this.listBoxHistory.SelectedItems.Count > 0;
        }

        private void listBoxHistory_SelectedValueChanged(object sender, EventArgs e)
        {
            this.buttonDelete.Enabled = this.listBoxHistory.SelectedItems.Count > 0;
            this.buttonFav.Enabled = this.listBoxHistory.SelectedItems.Count > 0;
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            this.SetAllSelected(true);
        }

        private void buttonDeselectAll_Click(object sender, EventArgs e)
        {
            this.SetAllSelected(false);
        }

        private void SetAllSelected(bool selection)
        {
            this.listBoxHistory.BeginUpdate();
            for (int i = 0; i < this.listBoxHistory.Items.Count; i++)
            {
                this.listBoxHistory.SetSelected(i, selection);
            }
            this.listBoxHistory.EndUpdate();
        }
    }
}
