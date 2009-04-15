using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Mobile.Mvc;

namespace TimeTracker.Views
{
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