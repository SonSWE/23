using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeShopWeb.Models
{
    public class dataProvider
    {
        private static dataProvider _ins;
        public static dataProvider Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new dataProvider();
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }

        public CoffeeShopWebEntities1 DB { get; set; }
        private dataProvider()
        {
            DB = new CoffeeShopWebEntities1();
        }
    }
}