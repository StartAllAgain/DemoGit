using AbstractFoatory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFoatory.Function
{
    public class HatchbackCar : ICar
    {
        public void getCar()
        {
            Console.WriteLine("大Q吧");
        }


        public void getCarInfo()
        {
            Console.WriteLine("姓名：Hatchback;性别：女;优点：过弯速度快,灵活抄近路更简单。缺点：车小禁不起任何车的碰撞。");
        }
    }
}
