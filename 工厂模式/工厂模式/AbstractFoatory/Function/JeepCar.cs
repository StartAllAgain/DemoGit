using AbstractFoatory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFoatory.Function
{
    public class JeepCar : ICar
    {
        public void getCar()
        {
            Console.WriteLine("雷诺");
        }


        public void getCarInfo()
        {
            Console.WriteLine("姓名：Jeep;性别：男;优点：过弯稳定，撞车不减速。缺点：太大太快走近路需要更多的技巧。");
        }
    }
}
