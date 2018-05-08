using AbstractFoatory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFoatory.Function
{
    public class Error : ICar
    {
        public void getCar()
        {
            Console.WriteLine("板车");
        }


        public void getCarInfo()
        {
            Console.WriteLine("称号：秋名山车神；姓名：不详；性别：不详；车辆属性：不详；技能：闪电连环漂移");
        }
    }
}
