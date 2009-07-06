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
    public partial class CategoriesSelect : ViewForm, IView<Activity>
    {
        public CategoriesSelect()
        {
            InitializeComponent();
        }

        [PublishEvent("OnCategorySelectedChanged")]
        public event EventHandler<DataEventArgs<Guid>> OnCategorySelectedChangedEvent;

        private void CategoriesSelect_Load(object sender, EventArgs e)
        {
            this.OnViewStateChanged("FillActivityGrid");
        }

        public bool SelectionDone
        {
            get;
            set;
        }

        public Guid SelectedId 
        { 
            get; 
            set; 
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

        private void mnuSelect_Click(object sender, EventArgs e)
        {
            if (lvwActivity.SelectedIndices.Count > 0)
            {
                if (OnCategorySelectedChangedEvent != null)
                {
                    OnCategorySelectedChangedEvent(this, new DataEventArgs<Guid>(new Guid(this.lvwActivity.Items[this.lvwActivity.SelectedIndices[0]].Tag.ToString())));
                    this.SelectionDone = true;
                    this.SelectedId = new Guid(this.lvwActivity.Items[this.lvwActivity.SelectedIndices[0]].Tag.ToString());
                }

                this.Close();
            }
        }
    }
}