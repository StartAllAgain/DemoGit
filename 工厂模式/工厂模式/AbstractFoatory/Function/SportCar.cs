using AbstractFoatory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFoatory.Function
{
    public class SportCar : ICar
    {
        public void getCar()
        {
            Console.WriteLine("大黄蜂");
        }


        public void getCarInfo()
        {
            Console.WriteLine("姓名：Sport;性别：男;优点：直线加速快。缺点：过弯抓地力弱");
        }
    }
}
