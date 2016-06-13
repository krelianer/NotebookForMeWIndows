using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookForMe.Model.Utils
{
    static class MobileConnection
    {
        public static MobileServiceClient get() { return new MobileServiceClient("https://notebookforme.azurewebsites.net"); }
    }
}
