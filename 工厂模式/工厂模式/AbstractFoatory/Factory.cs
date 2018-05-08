using AbstractFoatory.Function;
using AbstractFoatory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFoatory
{
    public class Factory
    {
        public enum CarType
        {
            SportCarType = 0,
            JeepCarType = 1,
            HatchbackCarType = 2,
            JackCarTyoe = 3
        }
        public ICar getCar(CarType CarType)
        {

            switch (CarType)
            {
                case CarType.SportCarType:
                    return new SportCar();
                case CarType.JeepCarType:
                    return new JeepCar();
                case CarType.HatchbackCarType:
                    return new HatchbackCar();
                default:
                    return new Error();
            }

        }
    }
}
