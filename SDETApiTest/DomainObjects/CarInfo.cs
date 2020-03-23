using System;
using System.Collections.Generic;
using System.Text;

namespace SDETApiTest.DomainObjects
{
    public sealed class CarInfo
    {
        public string make { get; set; }
        public string model {get; set; }
        public string year { get; set; }
        public string type { get; set; }
        public decimal zeroToSixty { get; set; }
        public float price { get; set; }

        public CarInfo(string make, string model, string year, string type, decimal zeroToSixty, float price)
        {
            this.make = make;
            this.model = model;
            this.type = type;
            this.year = year;
            this.zeroToSixty = zeroToSixty;
            this.price = price;

        }


        public override bool Equals(Object p)
        {
            //Check for null and compare run-time types.
            if ((p == null) || !this.GetType().Equals(p.GetType()))
            {
                return false;
            }
            else
            {
                CarInfo obj = (CarInfo)p;
                return make.Equals(obj.make) && this.model.Equals(obj.model) && this.year.Equals(obj.year) &&
                       type.Equals(obj.type) && this.price.Equals(obj.price) &&
                       this.zeroToSixty.Equals(obj.zeroToSixty);
            }
        }
    }
}