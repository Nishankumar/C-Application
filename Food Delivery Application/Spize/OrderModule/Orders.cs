using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spizy.UserModule;
using Spizy.HotelModule;
using Spizy.FoodModule;

namespace Spizy.OrderModule
{
    class Orders
    {
        private int OrderId,FoodQuantity;
        private User UserDetails;
        private Restaurent RestaurentDetails;
        private Foods FoodsDetails;

        public Orders(int orderId, int foodQuantity, Foods foodsDetails)
        {
            OrderId = orderId;
            FoodQuantity = foodQuantity;
            FoodsDetails = foodsDetails;
        }

        public Orders(int orderId, int foodQuantity, Restaurent restaurentDetails, Foods foodsDetails)
        {
            OrderId = orderId;
            FoodQuantity = foodQuantity;
            RestaurentDetails = restaurentDetails;
            FoodsDetails = foodsDetails;
        }

        public int OrderId1 { get => OrderId; set => OrderId = value; }
        public int FoodQuantity1 { get => FoodQuantity; set => FoodQuantity = value; }
        internal User UserDetails1 { get => UserDetails; set => UserDetails = value; }
        internal Restaurent RestaurentDetails1 { get => RestaurentDetails; set => RestaurentDetails = value; }
        internal Foods FoodsDetails1 { get => FoodsDetails; set => FoodsDetails = value; }

        public override string ToString()
        {
            return string.Format("Order Id: {0} \nQuantity: {1} \nFood Details: {2}", this.OrderId,this.FoodQuantity,this.FoodsDetails.ToString());
        }
    }
}
