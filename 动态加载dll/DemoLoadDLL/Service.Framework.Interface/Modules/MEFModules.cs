using Service.Framework.Interface.UI;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Service.Framework.Interface.Modules
{
    public class MEFModules
    {
        public ModulesManager ModulesManager { get; set; }

        [Import(typeof(Baseinterface))]
        public IEnumerable<Baseinterface> InterfaceView { get; set; }

        public bool IsRun { get; set; }

    }
}
