using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Service.Framework.Interface.Managers
{
    public class AssemblyLoad
    {
        public AssemblyLoad(string path)
        {
            string Url = System.Environment.CurrentDirectory;
            AggregateCatalog catalog = new AggregateCatalog();
            if (path.EndsWith(".dll"))
            {
                catalog.Catalogs.Add(new AssemblyCatalog(Url + path));
            }


        }
    }
}
