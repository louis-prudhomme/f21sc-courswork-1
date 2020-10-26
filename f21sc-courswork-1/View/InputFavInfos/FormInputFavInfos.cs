using f21sc_coursework_1.Events;
using f21sc_coursework_1.Events.Favorites;
using System;
using System.Linq;
using System.Windows.Forms;

namespace f21sc_courswork_1.View.InputFavInfos
{
    public partial class FormInputFavInfos : Form, IInputFavInfosView
    {
        public FormInputFavInfos()
        {
            InitializeComponent();
        }

        /* ==================================
         * INHERITED METHODS
         * ==================================*/

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

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void ShouldBeEnabled(bool should)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="url"></param>
        public void UpdateUrl(string url)
        {
            this.textBoxUrl.Text = url;
            this.labelFeedback.Text = "The URL has been successfully validated";

            this.buttonOk.Enabled = true;
            this.buttonTest.Enabled = false;
            
            this.buttonOk.Focus();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void PresetFav(string name, string url)
        {
            this.textBoxUrl.Text = url;
            this.textBoxName.Text = name;
        }

        /* ==================================
         * CONTROL LISTENERS
         * ==================================*/

        /// <summary>
        /// When the text of the textBox URL changes, disable the submission control
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Empty</param>
        private void textBoxUrl_TextChanged(object sender, EventArgs e)
        {
            this.buttonTest.Enabled = this.textBoxUrl.Text.Length > 0;
            this.buttonOk.Enabled = false;
            this.labelFeedback.Text = "";
        }

        private void FormInputFavInfos_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ViewClosedEvent(this, EventArgs.Empty);
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            this.UrlSentEvent(this, new UrlSentEventArgs(this.textBoxUrl.Text));
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.FavInputSubmittedEvent(this, new FavSubmittedEventArgs(this.textBoxUrl.Text, this.textBoxName.Text));
            this.labelName.Focus();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
        public event FavSubmittedEvent FavInputSubmittedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event UrlSentEvent UrlSentEvent;
    }
}
