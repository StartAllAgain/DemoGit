using AbstractFoatory;
using AbstractFoatory.AbstractCar;
using AbstractFoatory.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FactoryModel
{
    class Program
    {
        ////简单工厂模式
        //static void Main(string[] args)
        //{
        //    ICar Car;
        //    Factory factory = new Factory();
        //    Car = factory.getCar(AbstractFoatory.Factory.CarType.HatchbackCarType);
        //    Car.getCar();
        //    Console.Read();
        //}

        //工厂方法模式
        static void Main(string[] args)
        {
            //调用的类地址。
            string factoryType = "AbstractFoatory.FunctionTwo.SportFactory";
            //调用dll名称。
            string dllName = "AbstractFoatory.dll";
            var currentAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            string codeBase = currentAssembly.CodeBase.ToLower().Replace(currentAssembly.ManifestModule.Name.ToLower(), string.Empty);
            IFactory factory = Assembly.LoadFrom(Path.Combine(codeBase, dllName)).CreateInstance(factoryType, true) as IFactory;
            ICar car = factory.CreateCar();
            car.getCarInfo();
            car.getCar();

            Console.Read();
        }

        //抽象工厂模式
        static void Main(string[] args)
        {
            string assemblyName = "AbstractFoatory";// ConfigurationManager.AppSettings["assemblyName"];
            string fullTypeName = string.Concat("AbstractFoatory.FunctionThere", ".", "HatchbackAbstract"/*ConfigurationManager.AppSettings["typename"]*/);
            AbstractFactory factory = (AbstractFactory)Assembly.Load(assemblyName).CreateInstance(fullTypeName);
            CreateCar equipment = new CreateCar(factory);
            equipment.ReadyEquipment();
            Console.Read();
        }
    }
}
