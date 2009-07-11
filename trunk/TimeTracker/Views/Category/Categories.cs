using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Mobile.Mvc;
using TimeTracker.Services.Contracts;

namespace TimeTracker.Views.Category
{
    public partial class Categories : ViewForm, IView<Activity>
    {
        public Categories()
        {
            InitializeComponent();
        }

        public bool ItemChanged { get; set; }

        private void Categories_Load(object sender, EventArgs e)
        {
            this.OnViewStateChanged("FillActivityGrid");
        }

        protected override void OnUpdateView(string key)
        {
            switch (key)
            {
                case "FillActivityGrid":
                    this.FillActivityGrid();
                    break;
                default:
                    break;
            }
        }

        private void FillActivityGrid()
        {
            this.lvwActivity.Items.Clear();
            IList<Activity> activities = (List<Activity>)this.ViewData["activities"];

            foreach (Activity activity in activities)
            {
                ListViewItem item = new ListViewItem(new string[] { activity.Description });
                item.Tag = activity.Id;
                this.lvwActivity.Items.Add(item);
            }
        }

        //private void btnRemove_Click(object sender, EventArgs e)
        //{
        //    if (this.lvwActivity.SelectedIndices.Count > 0)
        //    {
        //        if (MessageBox.Show("Do you want to delete this Activity and all related tasks?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        //        {
        //            this.ViewData["activityGuid"] = this.lvwActivity.Items[lvwActivity.SelectedIndices[0]].Tag;
        //            this.ItemChanged = true;
        //            this.OnViewStateChanged("RemoveActivity");
        //        }
        //    }
        //}

        private void mnuAdd_Click(object sender, EventArgs e)
        {
            Views.Category.Category categoryForm = new Views.Category.Category();
            Controllers.CategoryController categoryController = new Controllers.CategoryController(categoryForm);
            categoryForm.ShowDialog();
            this.ItemChanged = categoryForm.ItemChanged;

            this.OnViewStateChanged("FillActivityGrid");
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (this.lvwActivity.SelectedIndices.Count > 0)
            {
                if (MessageBox.Show("Do you want to delete this Activity and all related tasks?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.ViewData["activityGuid"] = this.lvwActivity.Items[lvwActivity.SelectedIndices[0]].Tag;
                    this.ItemChanged = true;
                    this.OnViewStateChanged("RemoveActivity");
                }
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
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