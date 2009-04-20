namespace TimeTracker.Views
{
    using System;
    using System.Mobile.Mvc;
    using System.Windows.Forms;

    public partial class AboutForm : ViewForm
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            this.OnViewStateChanged("Load");
        }

        protected override void OnUpdateView(string key)
        {
            switch (key)
            {
                case "Load":
                    this.lblVersionDesc.Text = this.ViewData["version"].ToString();
                    this.lblAuthorDesc.Text = this.ViewData["author"].ToString();
                    break;

                default:
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
              
    }
}