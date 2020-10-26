using f21sc_coursework_1.Events;
using f21sc_coursework_1.Events.Favorites;
using f21sc_courswork_1.Model.Favorites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace f21sc_coursework_1.View.FavoritesPanel
{
    public partial class FormFavoritesPanel : Form, IFavoritesPanelView
    {
        public FormFavoritesPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler FavoritesPanelFormClosedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event FavoritesDeletedEvent FavoritesDeletedEvent;

        /// <summary>
        /// Enables or disables the listbox items-dependant controls 
        /// </summary>
        private void UpdateFavoritesDependantControls()
        {
            this.buttonRemove.Enabled = this.listBoxFavorites.SelectedItems.Count > 0;
            this.buttonSelectAll.Enabled = this.listBoxFavorites.SelectedItems.Count != this.listBoxFavorites.Items.Count;
            this.buttonDeselectAll.Enabled = this.listBoxFavorites.SelectedItems.Count > 0;
        }

        /// <summary>
        /// Selects or deselects all items of the list box
        /// </summary>
        /// <param name="selection">true if the items should be all selected, false if none</param>
        private void SetAllSelected(bool selection)
        {
            this.listBoxFavorites.BeginUpdate();
            for (int i = 0; i < this.listBoxFavorites.Items.Count; i++)
            {
                this.listBoxFavorites.SetSelected(i, selection);
            }
            this.listBoxFavorites.EndUpdate();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="favorites"></param>
        public void UpdateFavoriteItems(List<Fav> favorites)
        {
            this.listBoxFavorites.BeginUpdate();
            this.listBoxFavorites.Items.Clear();
            if (favorites.Count != 0)
            {
                this.listBoxFavorites.Items.AddRange(favorites.ToList().ToArray());
                this.listBoxFavorites.Enabled = true;
            }
            else
            {
                this.listBoxFavorites.Items.Add("No favorites");
                this.listBoxFavorites.Enabled = false;
            }
            this.UpdateFavoritesDependantControls();
            this.listBoxFavorites.EndUpdate();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDeselectAll_Click(object sender, EventArgs e)
        {
            this.SetAllSelected(false);
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            this.SetAllSelected(true);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            this.FavoritesDeletedEvent(this, new FavoritesDeletedEventArgs(this.listBoxFavorites
                .SelectedItems
                .Cast<Fav>()
                .ToList()));
        }

        private void listBoxFavorites_SelectedValueChanged(object sender, EventArgs e)
        {
            this.UpdateFavoritesDependantControls();
        }

        private void FormFavoritesPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.FavoritesPanelFormClosedEvent(this, EventArgs.Empty);
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
