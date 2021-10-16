using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentShopUI
{
    public partial class ConsignmentShop : Form
    {
        //so we wnt som items and vendors but where do we storethat information ? in order for this form to have data which is what we want
        //bcoz we want e listbox to display e list of items we can't declare our info inside a method bcoz once we hit the end of that method 
        //the data gets destroyed. so we go on ahead and create one object called store and initialize it. This is bcoz we dont wnt to create a list
        //of vendors and a list of vendors its redundant

        //we are gettin an error bcoz STore is not referenced. We havent connected the library to the user interface in anyway therefore the
        //user interface cannot see the information in the library to solve that we need to go to our Consignment UI and add the ConsignmentSop
        //Library as a reference
        //Ctrl + . add the using library namespace its a shortcut for us to just access the class and not have
        //declare it everytime we want to use it 
        private Store store = new Store();

        private List<Item> shoppingCartData = new List<Item>();

        //Adding a binding source a feature that will connect the
        //list code and the actual list box
        //note again that it should be declared at form level
        //not at individual method level
        BindingSource itemsBinding = new BindingSource();

        BindingSource cartBinding = new BindingSource();

        public ConsignmentShop()
        {
            InitializeComponent();
            SetupData();
            
            //this line of code links our items to binding source
            //items binding
            itemsBinding.DataSource = store.Items;

            //next is to link the linkbox to the binding source as well
            //this puts the binding source in the between our list of and 
            //listbox itself
            itemsListBox.DataSource = itemsBinding;

            //finally we need to give the ListBox something to display
            //a display member a value member 
            //what that is ,it's the content which is going to show up
            //in the itemsListBox
            //so we want something descriptive that will show this is the item and this is the price
            //but we don't have a specific property that shows both the item and the name of the item and 
            //that's what the display member and value memebr are looking for they want in qoutes one property they can display 
            //we need to go back to our class Item and add a property that can be dispalyed showing both the title and price

            itemsListBox.DisplayMember = "Display";
            itemsListBox.ValueMember = "Display";

            //this time the binding source is directly linked to the form
            //instead of inside an instance
           
            cartBinding.DataSource = shoppingCartData;
            //So we have the Data source for the binding source. So the data source for 
            //our cart binding is our list and the data source for our list box is our cart binding. 

            //So now we have wired up our second List Box 
            shoppingCartListBox.DisplayMember = "Display";
            shoppingCartListBox.ValueMember = "Display";


        }

        private void ConsignmentShop_Load(object sender, EventArgs e)
        {

        }

        //create a new pvt () cold setup data.>>creates dummy data for us to use
        private void SetupData() 
        {
            /*//two different ways we can add a vendor to our store

            //method 1 create a vendor object 
            Vendor demoVendor = new Vendor();// we have created an object Vendor called demoVendor 
            //then we add the info we need
            demoVendor.FistName = "Mqhele";
            demoVendor.LastName = "Mguni";
            demoVendor.Commission = .5;

            //then we have the demoVendor we can add to our list of vendor
            store.Vendors.Add(demoVendor);
            //in essence we create one vendor object and we insatiate it it with new vendor 
            //we add the 3 items it needs 
            //and the we finally add that item to the list
            //if we want to add more than one item we wil copy everything except the defination and paste it again

            demoVendor = new Vendor();
            //note we have already declared the demo vendor variable once so we don't 
            //need to declare it again but if we re-instatiate again we can create a new person
            //when we say this >> new Vendor

            demoVendor.FistName = "Fortune ";
            demoVendor.LastName = "Makaringe";
            demoVendor.Commission = .5;
            // we will have two people in our list
            //but there is an easier way


            demoVendor = new Vendor();
            */


            //store.Vendors.Add(new Vendor { FistName = "Mqhele", LastName = "Mguni", Commission = .5 });
            //store.Vendors.Add(new Vendor { FistName = "Fortune", LastName = "Makaringe", Commission = .5 }); ;
            //after the .Add method we can create a new instance of Vendor then open
            //curly braces ,what those curly braces do is the allow to populate the 
            //initial object with it's values and adds it our list all in one line

            //after setting up the default commission in the Vendor class inside the constructor
            //there's no need to manually insert the comission manually for every Vendor
            store.Vendors.Add(new Vendor { FistName = "Mqhele", LastName = "Mguni"});
            store.Vendors.Add(new Vendor { FistName = "Fortune", LastName = "Makaringe"}); ;

            //we want to add and relate a person from a Vendors List 
            //to our owner, what we can do is store.Vendors[0]
            //using index 0 means we have selected 1 
            store.Items.Add(new Item
            {
                Title = "Moby Dick",
                Description = "A book about a whale",
                Price = 4.50M,//don't forget that with money it's declared as type decimal add M so that its converted properly to a decimal
                Owner = store.Vendors[0]
            });

            store.Items.Add(new Item
            {
                Title = "A tale of two cities",
                Description = "A book about a revolution",
                Price = 3.80M,//don't forget that with money it's declared as type decimal add M so that its converted properly to a decimal
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item
            {
                Title = "Harry Potter",
                Description = "A book about a boy",
                Price = 5.20M,//don't forget that with money it's declared as type decimal add M so that its converted properly to a decimal
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item
            {
                Title = "Jane Erye",
                Description = "A book about a girl ",
                Price = 5.20M,//don't forget that with money it's declared as type decimal add M so that its converted properly to a decimal
                Owner = store.Vendors[0]
            });

            store.Name = "Seconds are Better";




        }

        private void addToCart_Click(object sender, EventArgs e)
        {
            //Steps
            //Figure uot what is selected in the items List
            //Copy that item to the items cart
            //Do we remove the item from the items List? = no

            //step 1
            //Figure uot what is selected in the items List
            //so with this item we areputting selected item into a temporary variable
            //we had to use (Item) 'item params' to indicate that the item in this ListBox is of 
            //type item
            Item selectedItem = (Item)itemsListBox.SelectedItem;

            //MessageBox.Show(selectedItem.Title);

            //step 2
            //Copy that item to the items cart
            //
            shoppingCartData.Add(selectedItem);
            //as it stands the code can't populate the items listBox
            //the only riizn for that we need to tell this data binding to referesh
            //to tell the data source that the info has changed we need to tell it 
            //to reset bindings and we have to pass in a boolean saying whether or not th type of the
            //list has changed. In this instance the schema hasn't changed so we pass in false
            //we pass in true if the we wanted to change the entire list to be something different. E.g a
            //different type of List e.g. from Items to Vendors. 
            //But for now if we need to modify our list in any way we will call


            //listBox1.DataSource = null;
            cartBinding.DataSource = null;
            //cartBinding.ResetBindings(false);

            //cartBinding.ResetBindings(false);

           

            //This adds an interesiting wrinkle if we
            //select an item and select add to cart multiple times it adds
            //that selected item multiple times and add it to the shopping cart
            //multiple times.The problem with that is this is a consignement shop typically it has
            //one type of each item. If we have multiple of a certain item we create three instances of that
            //item and add to the list. If we had 3 Harry Potters we'd create 3 items called Harry Potter book 1
            // and each of those to the list. 
            //Approach 1 
            //we could modify that by taking items out of our list or not displaying them once they are added
            //to the shopping cart.



        }

        private void makePurchase_Click(object sender, EventArgs e)
        {
            //Mark each item the cart as sold
            //Clear the cart

            foreach (Item item in shoppingCartData)
            {
                item.Sold = true;
            }

            shoppingCartData.Clear();

            cartBinding.ResetBindings(false);
        }
    }
}
