using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace NotebookForMe.Model.Utils
{
    public class Session
    {
        public static String get(String name) { return (String)ApplicationData.Current.RoamingSettings.Values[name]; }
        public static void set(String name, String obj) { ApplicationData.Current.RoamingSettings.Values[name] = obj; }
    }
}
