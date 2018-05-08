using AbstractFoatory.AbstractCar;
using AbstractFoatory.AbstractCarBackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFoatory.AbstractFun
{
    public class ImpHatchbackFun : AbstractCarBackModul
    {
        private string type = "Sport";
        private string color = "Red";
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
