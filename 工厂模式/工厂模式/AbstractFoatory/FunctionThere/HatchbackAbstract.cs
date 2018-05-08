using AbstractFoatory.AbstractCar;
using AbstractFoatory.AbstractCarBackage;
using AbstractFoatory.AbstractFun;
using AbstractFoatory.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFoatory.FunctionThere
{
    public class HatchbackAbstract : AbstractFactory
    {
        public override AbstractCarModul CreateCar()
        {
            return new ImpHatchCarFun();
        }
        public override AbstractCarModul CreateCarType()
        {
            return new ImpHatchCarFun();
        }
        public override AbstractCarBackModul CreateBack()
        {
            return new ImpHatchbackFun();
        }

        public override AbstractCarShoesModul CreateShoes()
        {
            return new ImpHatchShoesFun();
        }
    }
}
