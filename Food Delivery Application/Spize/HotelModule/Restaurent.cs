using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spizy.HotelModule
{
    class Restaurent : IComparable

    {
        private string HotelName,HotelArea,HotelType;
        private long HotelPhone;
        private int HotelId;

        public Restaurent(int hotel_id,string hotel_name, long hotel_phone, string hotel_area, string hotel_type)
        {
            this.HotelId = hotel_id;
            this.HotelName = hotel_name;
            this.HotelPhone = hotel_phone;
            this.HotelArea = hotel_area;
            this.HotelType = hotel_type;
        }


        /*public Restaurent(int hotelId, string HotelName, long HotelPhone, string HotelArea)
        {
            this.HotelId = hotelId;
            this.HotelName = HotelName;
            this.HotelPhone = HotelPhone;
            this.HotelArea = HotelArea;            
        }*/


        public string Hotel_name { get => HotelName; set => HotelName = value; }
        public long Hotel_phone { get => HotelPhone; set => HotelPhone = value; }
        public string Hotel_area { get => HotelArea; set => HotelArea = value; }
        public string Hotel_type { get => HotelType; set => HotelType = value; }
        public int Hotel_id { get => HotelId; set => HotelId = value; }

        public int CompareTo(object obj)
        {
            Restaurent restaurent = (Restaurent)obj;
            return this.Hotel_id.CompareTo(restaurent.HotelId);
        }

        public override string ToString()
        {
            return string.Format(this.Hotel_id + " " +this.Hotel_name + " " + this.Hotel_phone + " " + this.Hotel_area + " " + this.Hotel_type);
        }

    }
}
