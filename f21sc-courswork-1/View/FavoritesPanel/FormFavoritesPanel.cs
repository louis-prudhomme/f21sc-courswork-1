using f21sc_coursework_1.Events;
using f21sc_coursework_1.Model.Favorites;
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

        public event EventHandler FavoritesPanelFormClosedEvent;
        public event FavoritesDeletedEvent FavoritesDeletedEvent;

        private void ShouldEnableFavoritesDependantControls(bool should)
        {
            this.listBoxFavorites.Enabled = should;

            this.buttonSelectAll.Enabled = should;
            this.buttonDeselectAll.Enabled = should;

            this.buttonRemove.Enabled = should && this.listBoxFavorites.SelectedItems.Count > 0;
        }

        private void SetAllSelected(bool selection)
        {
            this.listBoxFavorites.BeginUpdate();
            for (int i = 0; i < this.listBoxFavorites.Items.Count; i++)
            {
                this.listBoxFavorites.SetSelected(i, selection);
            }
            this.listBoxFavorites.EndUpdate();
        }

        public void UpdateFavoriteItems(List<Fav> favorites)
        {
            this.listBoxFavorites.BeginUpdate();
            if (favorites.Count != 0)
            {
                this.listBoxFavorites.Items.AddRange(favorites.ToArray());
                this.ShouldEnableFavoritesDependantControls(true);
            }
            else
            {
                this.listBoxFavorites.Items.Add("No favorites");
                this.ShouldEnableFavoritesDependantControls(false);
            }
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
            this.buttonRemove.Enabled = this.listBoxFavorites.SelectedItems.Count > 0;
        }

        private void FormFavoritesPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.FavoritesPanelFormClosedEvent(this, EventArgs.Empty);
        }
    }
}
