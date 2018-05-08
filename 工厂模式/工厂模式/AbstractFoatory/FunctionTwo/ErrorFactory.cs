using AbstractFoatory.Function;
using AbstractFoatory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFoatory.FunctionTwo
{
    public class ErrorFactory : IFactory
    {

        public ICar CreateCar()
        {
            return new Error();
        }
    }
}
