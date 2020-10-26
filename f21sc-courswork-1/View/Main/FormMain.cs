using f21sc_coursework_1.Events;
using f21sc_coursework_1.Events.Favorites;
using f21sc_coursework_1.Model;
using f21sc_coursework_1.Model.HttpCommunications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace f21sc_coursework_1.View
{
    public partial class FormMain : Form, IMainView
    {
        /// <summary>
        /// List of the <see cref="ToolTip"/> generated in <see cref="MakeRecentToolStripItem(HttpQuery)"/>
        /// </summary>
        private readonly List<ToolTip> generatedToolTips;

        public FormMain()
        {
            InitializeComponent();
            this.generatedToolTips = new List<ToolTip>();
        }

        /* ==================================
         * IMPLEMENTED METHODS
         * ==================================*/

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
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

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void UpdateRecent(List<HttpQuery> recentQueries)
        {
            if (this.menuStripUp.InvokeRequired)
            {
                this.menuStripUp.Invoke(new Action(() => this.UpdateRecentToolStrip(recentQueries)));
            }
            else
            {
                this.UpdateRecentToolStrip(recentQueries);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void IsCurrentAFav(bool isFav)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.UpdateFavoritesControls(isFav)));
            }
            else
            {
                this.UpdateFavoritesControls(isFav);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="should"></param>
        public void ShouldBeEnabled(bool should)
        {
            this.Enabled = should;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="error"></param>
        public void ErrorDialog(string error)
        {
            MessageBox.Show(error,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        /* ==================================
         * INTERNAL METHODS
         * ==================================*/

        /// <summary>
        /// Updates a lot of controls with the received information 
        /// Does the heavy-lifting for <see cref="SetCurrentState(HttpAnswer, Node{HttpQuery})"/>
        /// </summary>
        /// <param name="answer">State of the HTML displayer</param>
        /// <param name="current">State of the navigation</param>
        private void UpdateControls(HttpAnswer answer, Node<HttpQuery> current)
        {
            this.Text = "Browser – " + answer.Title;
            this.richTextBoxHtmlDisplay.Text = answer.Html;

            this.toolStripStatusLabelHttpStatusCode.Text = current.Center.StatusCode.ToString();
            this.toolStripStatusLabelHttpStatus.Text = current.Center.Status;

            this.buttonFav.Enabled = current.HasCenter;
            this.buttonReload.Enabled = current.HasCenter;

            this.favToolStripMenuItem.Enabled = current.HasCenter;
            this.reloadToolStripMenuItem.Enabled = current.HasCenter;

            this.generatedToolTips.ForEach(tooltip => tooltip.Dispose());
            this.UpdateNavigationControls(this.buttonBackward, current.Left);
            this.UpdateNavigationControls(this.buttonForward, current.Right);
            this.textBoxUrlInput.Text = current.Center.Uri.AbsoluteUri;
        }

        /// <summary>
        /// Updates one navigation control at a time with the related <see cref="HttpQuery"/>
        /// </summary>
        /// <param name="navigationControl">Either the backward or the forward <see cref="Button"/></param>
        /// <param name="query">Current corresponding <see cref="HttpQuery"/> or null</param>
        private void UpdateNavigationControls(Button navigationControl, HttpQuery query)
        {
            navigationControl.Enabled = query != null;
            if (query != null)
            {
                this.generatedToolTips.Add(new ToolTip());
                this.generatedToolTips[this.generatedToolTips.Count - 1]
                    .SetToolTip(navigationControl, query.Title);
            }
        }

        /// <summary>
        /// Updates the recent tool strip menu item by clearing the previous entries and adding the new ones
        /// Does the heavy-lifting for <see cref="UpdateRecent(List{HttpQuery})"/>
        /// </summary>
        /// <param name="recentQueries">New entries to display</param>
        private void UpdateRecentToolStrip(List<HttpQuery> recentQueries)
        {
            this.recentToolStripMenuItem.DropDownItems.Clear();
            this.recentToolStripMenuItem.DropDownItems
                .AddRange(recentQueries
                .Select(query => this.MakeRecentToolStripItem(query))
                .ToArray());
            this.ShouldHistoryControlsBeEnabled(this.recentToolStripMenuItem.DropDownItems.Count > 0);
        }

        /// <summary>
        /// Updates the history-related controls
        /// </summary>
        /// <param name="should">Whether the controls should be activated or not</param>
        private void ShouldHistoryControlsBeEnabled(bool should)
        {
            this.recentToolStripMenuItem.Enabled = should;
            this.allHistoryToolStripMenuItem.Enabled = should;
            this.eraseHistoryToolStripMenuItem.Enabled = should;
        }

        /// <summary>
        /// Generates a new <see cref="ToolStripMenuItem"/> with an history entry
        /// </summary>
        /// <param name="entry"><see cref="HttpQuery"/> representing the history entry</param>
        /// <returns>New <see cref="ToolStripMenuItem"/></returns>
        private ToolStripMenuItem MakeRecentToolStripItem(HttpQuery entry)
        {
            ToolStripMenuItem toolStrip = new ToolStripMenuItem(entry.IssuedAt.ToString("HH:mm") + " - " + entry.Title)
            {
                Tag = entry.Uri.ToString(),
                ToolTipText = entry.Uri.AbsoluteUri,
                Name = entry.TimestampIssuedAt.ToString()
            };
            toolStrip.Click += this.recentToolStripMenuItem_Click;

            return toolStrip;
        }

        /// <summary>
        /// Updates the favorites-related controls depending on whether the current site is a favorite or not
        /// Does the heavy-lifting for <see cref="IsCurrentAFav(bool)"/>
        /// </summary>
        /// <param name="isFav">Whether the current site is a fav</param>
        private void UpdateFavoritesControls(bool isFav)
        {
            // remove all listeners on these controls
            this.buttonFav.Click -= this.AddFavoriteEventHandler;
            this.buttonFav.Click -= this.RemoveFavoriteEventHandler;
            this.favToolStripMenuItem.Click -= this.AddFavoriteEventHandler;
            this.favToolStripMenuItem.Click -= this.RemoveFavoriteEventHandler;

            // change their text and functions
            this.buttonFav.Text = !isFav ? "Make fav" : "Unfav";
            this.favToolStripMenuItem.Text = !isFav ? "Add to favorites" : "Remove from favorites";
            if (isFav)
            {
                this.buttonFav.Click += this.RemoveFavoriteEventHandler;
                this.favToolStripMenuItem.Click += this.RemoveFavoriteEventHandler;
            } else { 
                this.buttonFav.Click += this.AddFavoriteEventHandler;
                this.favToolStripMenuItem.Click += this.AddFavoriteEventHandler;
            }
        }

        /* ==================================
         * CONTROL LISTENERS
         * ==================================*/

        /// <summary>
        /// Listener for user demand of adding the current site of favorites
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Empty</param>
        private void AddFavoriteEventHandler(object sender, EventArgs e)
        {
            this.FavInputAskedEvent(this, new FavInputAskedEventArgs(this.textBoxUrlInput.Text));
        }

        /// <summary>
        /// Listener for user demand of removing the current site of favorites
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Empty</param>
        private void RemoveFavoriteEventHandler(object sender, EventArgs e)
        {
            this.RemoveFavEvent(this, EventArgs.Empty);
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
                " This cannot be reverted and it will not affect your current navigation.",
                "Confirm history deletion",
                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                this.WipeHistoryEvent(this, EventArgs.Empty);
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

        private void personalizeHomeURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.HomeUrlInputAskedEvent(this, EventArgs.Empty);
        }


        private void allHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.HistoryPanelAskedEvent(this, EventArgs.Empty);
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.HomeAskedEvent(this, EventArgs.Empty);
        }

        private void goToHomePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.HomeAskedEvent(this, EventArgs.Empty);
        }

        private void seeAllFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FavoritesPanelAskedEvent(this, EventArgs.Empty);
        }

        private void textBoxUrlInput_TextChanged(object sender, EventArgs e)
        {
            this.reloadToolStripMenuItem.Enabled = false;
            this.buttonReload.Enabled = false;

            this.buttonFav.Enabled = false;
            this.favToolStripMenuItem.Enabled = false;
        }

        /* ==================================
         * EVENTS
         * ==================================*/

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler MainFormClosedEvent;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler HomeUrlInputAskedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler HistoryPanelAskedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler FavoritesPanelAskedEvent;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event UrlSentEvent UrlSentEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler ReloadAskedEvent;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler WipeHistoryEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler HomeAskedEvent;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler BackwardAskedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler ForwardAskedEvent;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event FavInputAskedEvent FavInputAskedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler RemoveFavEvent;
    }
}
