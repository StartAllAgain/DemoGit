using AbstractFoatory.AbstractCar;
using AbstractFoatory.AbstractCarBackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFoatory
{
    public class CreateCar
    {
        private AbstractCarModul fanCar;
        private AbstractCarBackModul fanBackpack;
        private AbstractCarShoesModul fanShoes;
        public CreateCar(AbstractFactory equipment)
        {
            fanCar = equipment.CreateCar();
            fanCar = equipment.CreateCarType();
            fanBackpack = equipment.CreateBack();
            fanShoes = equipment.CreateShoes();
        }

        public void ReadyEquipment()
        {

            Console.WriteLine(string.Concat("老范开着" + fanCar.Color + "的" + fanCar.Type, "背着" + fanBackpack.Color + "的" + fanBackpack.Type, "穿着" + fanShoes.Color + "的" + fanShoes.Type));
        }
    }
}
