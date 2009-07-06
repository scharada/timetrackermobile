using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TimeTracker.Services.Contracts;
using System.Mobile.Mvc;

namespace TimeTracker.Views.Category
{
    public partial class Category : ViewForm, IView<Activity>
    {
        public Category()
        {
            InitializeComponent();
        }

        protected override void OnUpdateView(string key)
        {
            switch (key)
            {
                case "View":
                    break;
                case "Edit":
                    break;
                default:
                    break;
            }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            Activity activity = new Activity { Color = "", Description = this.txtCategory.Text.Trim(), Id = new Guid() };

            this.ViewData["activity"] = activity;
            this.OnViewStateChanged("AddActivity");
            this.Close();        
        }

        private void mnuBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region IView<Activity> Members

        public new Activity Model
        {
            get;
            set;
        }

        public new ViewDataDictionary<Activity> ViewData
        {
            get;
            set;
        }

        #endregion
    }
}