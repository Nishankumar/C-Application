using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spizy.FoodModule
{
    class Foods
    {
        private int FoodId;
        private string FoodName, FoodType;
        private double FoodCost;

        public Foods(int foodId, string foodName, string foodType, double foodCost)
        {
            this.FoodId = foodId;
            this.FoodName = foodName;
            this.FoodType = foodType;
            this.FoodCost = foodCost;
        }

        public int Food_Id { get => FoodId; set => FoodId = value; }
        public string Food_name { get => FoodName; set => FoodName = value; }
        public string Food_type { get => FoodType; set => FoodType = value; }
        public double Food_cost { get => FoodCost; set => FoodCost = value; }


        public override string ToString()
        {
            return string.Format("Id: {0} Name: {1} Type: {2} Cost: {3}", this.Food_Id, this.Food_name, this.Food_type, this.Food_cost);
        }
    }
}
