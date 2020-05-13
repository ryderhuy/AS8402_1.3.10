using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace InspSensor.Utility
{
    public class ResourceUtility
    {
        private static ResourceManager mResources;
        static ResourceUtility()
        {
            mResources = new ResourceManager("InspSensor.Utility.strings",
              System.Reflection.Assembly.GetExecutingAssembly());
        }
        public static string GetString(string resname)
        {
            string str = mResources.GetString(resname);
            if (str == null)
                str = "ERROR(" + resname + ")";
            return str;
        }
        public static string FormatString(string resname, string arg0)
        {
            try
            {
                return string.Format(GetString(resname), arg0);
            }
            catch (Exception)
            {
            }

            return "ERROR(" + resname + ")";
        }

        public static string FormatString(string resname, string arg0, string arg1)
        {
            try
            {
                return string.Format(GetString(resname), arg0, arg1);
            }
            catch (Exception)
            {
            }

            return "ERROR(" + resname + ")";
        }
    }
}
