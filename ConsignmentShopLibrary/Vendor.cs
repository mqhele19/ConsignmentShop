using System;
using System.Collections.Generic;
using System.Text;

namespace ConsignmentShopLibrary
{
    public class Vendor
    {
        //create an auto property and expand to a full property if its needed
        //shortcut for a property type prop and that gives you a snippert list for property 
        public string FistName { get; set; }
        public string LastName { get; set; }
        public double Commission { get; set; }

        public Vendor()
        {
            //we are setting a default value not declaring 
            //bcoz it already has been declared
                 Commission = .5;
        }
    }
}
