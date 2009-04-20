namespace TimeTracker
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Resources;
    using System.Reflection;

    public class OrientationAwareHelper
    {
        ResourceManager resourceManager;

        public OrientationAwareHelper(string file)
        {
            string resourceFile = file;
            string filePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            resourceManager = new ResourceManager(file, Assembly.GetExecutingAssembly());
        }

        public string ReadResourceValue(string key)
        {
            string resourceValue = string.Empty;
            try
            {
                resourceValue = resourceManager.GetString(key);
            }
            catch (Exception)
            {
                resourceValue = string.Empty;
            }
            return resourceValue;
        }
    }
}
