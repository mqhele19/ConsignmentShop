using System;
using System.Collections.Generic;
using System.Text;

namespace ConsignmentShopLibrary
{
    public class Item
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public bool Sold { get; set; }
        public bool PayDistributed { get; set; }
        
        //note that the vendor does not have a squiggly because 
        //we created our classes in a way that
        //the Vendor class was created first so that
        //we can call it as a type
        public Vendor Owner { get; set; }

        //This is a full property without a backing source
        //that means we don't have a private variable that we are going to use
        // as a strorage for this property. The reason why we don't
        //have that private variable is because this property is just a read-only property
        //that uses other properties and puts them together.
        public string Display 
        {
            get 
            {
                //string.format allows us to mash multiple items together easily 
                //the curly brace o and 1 are place holders. The title and price will be inserted to 0 & 1 respectively
                return string.Format("{0} - ${1}", Title, Price);

            
            }
        
        
        }


    }
}
