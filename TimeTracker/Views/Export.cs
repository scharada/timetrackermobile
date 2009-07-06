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
    public partial class Export : ViewForm
    {
        public Export()
        {
            InitializeComponent();
        }

        private void Export_Load(object sender, EventArgs e)
        {
            this.OnViewStateChanged("Load");
        }

        protected override void OnUpdateView(string key)
        {
            switch (key)
            {
                default:
                    break;
            }
        }

        private void OnExportStatusUpdated(object sender, DataEventArgs<string> e)
        {
            this.prgExport.Value = this.prgExport.Value + 1;
            this.lblExportStatus.Text = e.Value;
            this.lblExportStatus.Refresh();
        }

        private void OnTasksCount(object sender, DataEventArgs<int> e)
        {
            this.prgExport.Maximum = e.Value;
        }

        private void mnuCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuExport_Click(object sender, EventArgs e)
        {
            this.prgExport.Value = 0;
            this.lblExportStatus.Text = "Status";

            this.ViewData["ExportFrom"] = this.dtpFrom.Value;
            this.ViewData["ExportTo"] = this.dtpTo.Value;

            this.OnViewStateChanged("ExportTasks");
        }
    }
}