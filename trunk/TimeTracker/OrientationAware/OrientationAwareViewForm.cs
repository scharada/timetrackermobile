using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Mobile.Mvc;
using Microsoft.WindowsMobile.Status;

namespace TimeTracker
{
    public class OrientationAwareViewForm : ViewForm
    {
        OrientationAwareHelper oaHelper;
        private SystemState displayRotationState = new SystemState(SystemProperty.DisplayRotation);

        public OrientationAwareViewForm()
        {
            this.Load += new System.EventHandler(this.OrientationAwareViewForm_Load);
            this.Resize += new EventHandler(OrientationAwareViewForm_Resize);
        }

        void OrientationAwareViewForm_Resize(object sender, EventArgs e)
        {
            Console.Write("ff");
        }

        private void displayRotationState_Changed(object sender, ChangeEventArgs args)
        {
            switch ((int)args.NewValue)
            {
                case 90:
                    oaHelper = new OrientationAwareHelper("TimeTracker.Views.AboutForm.H");
                    ArrangeControls();
                    break;
                case 0:
                    oaHelper = new OrientationAwareHelper("TimeTracker.Views.AboutForm.V");
                    ArrangeControls();
                    break;
                default:
                    break;
            }
        }

        private void ArrangeControls()
        {
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                int x, y;
                string temp = oaHelper.ReadResourceValue("$this." + control.Name);
                if (temp != string.Empty)
                {
                    string[] split = temp.Split(',');
                    x = int.Parse(split[0]);
                    y = int.Parse(split[1]);

                    control.Location = new System.Drawing.Point(x, y);
                }
            }
        }

        private void OrientationAwareViewForm_Load(object sender, EventArgs e)
        {
            displayRotationState.Changed += new ChangeEventHandler(displayRotationState_Changed);
        }
    }
}
