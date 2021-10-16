using System;
using System.Collections.Generic;
using System.Text;

namespace ConsignmentShopLibrary
{
    public class Store
    {
        public Store()
        {
            //instatiating both Lists in the class before they are being used
            Vendors = new List<Vendor>();
            Items = new List<Item>();
        }
        public string Name { get; set; }

        //Here's were we didn't specify clearly our types
        // we have a property called Vendor of type vendor
        //public Vendor Vendors { get; set; }
        //if we implement that remember that Vendor was named singular
        //because each instance will be one vendor 
        //in our store we want to have more than one vendor that's why
        //the actual name is called vendors so the type isn't ofg
        //type Vendor but it is off a List of Vendors

        public List<Vendor> Vendors { get; set; }

        //concept is similiar for items
        public List<Item> Items { get; set; }
    }
  
}
