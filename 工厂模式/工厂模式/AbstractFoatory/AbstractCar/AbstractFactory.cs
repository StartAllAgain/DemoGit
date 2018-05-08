using AbstractFoatory.AbstractCarBackage;
using AbstractFoatory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFoatory.AbstractCar
{
    /// <summary>
    /// 抽象方法类
    /// </summary>
    public abstract class AbstractFactory
    {
        public abstract AbstractCarModul CreateCar();

        public abstract AbstractCarModul CreateCarType();
        public abstract AbstractCarBackModul CreateBack();

        public abstract AbstractCarShoesModul CreateShoes();

    }
}
