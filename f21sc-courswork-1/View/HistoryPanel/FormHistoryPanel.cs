using f21sc_coursework_1.Events;
using f21sc_coursework_1.Model.HttpCommunications;
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

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler HistoryPanelClosedEvent;
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

            this.buttonSelectAll.Enabled = this.listBoxHistory.SelectedItems.Count != this.listBoxHistory.Items.Count;
            this.buttonDeselectAll.Enabled = this.listBoxHistory.SelectedItems.Count > 0;

            this.buttonDelete.Enabled = this.listBoxHistory.SelectedItems.Count > 0;
            this.buttonFav.Enabled = this.listBoxHistory.SelectedItems.Count > 0;
        }

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
            this.HistoryEntriesDeletedEvent(this, new HistoryEntriesDeletedEventArgs(this
                .listBoxHistory
                .SelectedItems
                .Cast<HttpQuery>()
                .ToList()));
        }

        private void FormHistoryPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.HistoryPanelClosedEvent(this, EventArgs.Empty);
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
    }
}
