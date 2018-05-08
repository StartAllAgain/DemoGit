using AbstractFoatory.AbstractCarBackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFoatory.AbstractFun
{
    public class ImpHatchShoesFun : AbstractCarShoesModul
    {
        private string type = "皮鞋";
        private string color = "黑色";
        public override string Type
        {
            get { return type; }
        }

        public override string Color
        {
            get { return color; }

        }
    }
}
