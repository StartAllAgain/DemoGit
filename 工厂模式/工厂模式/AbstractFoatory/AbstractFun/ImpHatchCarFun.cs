using AbstractFoatory.AbstractCarBackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFoatory.AbstractFun
{
    public class ImpHatchCarFun : AbstractCarModul
    {
        private string type = "IronBack";
        private string color = "White";

        public override string Color
        {
            get { return color; }
        }
        public override string Type
        {
            get { return type; }
        }


    }
}
