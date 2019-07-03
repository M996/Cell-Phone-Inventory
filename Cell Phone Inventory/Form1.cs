using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cell_Phone_Inventory
{
    // Create a List to hold Cellphone objects
    
    public partial class Form1 : Form
    {
        //List to hold Cellphone objects
        List<CellPhone> PhoneList = new List<CellPhone>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addPhoneButton_Click(object sender, EventArgs e)
        {
            // Create a Cellphone Object
            CellPhone myPhone = new CellPhone();

            //Get Phone Data

            GetPhoneData(myPhone);

            // Add a CellPhone object to the List of Objects
            PhoneList.Add(myPhone);

            // Add an entry to the ListBox
            phoneListBox.Items.Add(myPhone.Brand + " " + myPhone.Model + " " + myPhone.Price);

            // clear out Form
            brandTextBox.Clear();
            modelTextBox.Clear();
            priceTextBox.Clear();

            //Reset Focus
            brandTextBox.Focus();

        }

        private void GetPhoneData(CellPhone myPhone)
        {
            // variable to hold the price
            decimal price;

            // get the Phone's brand
            myPhone.Brand = brandTextBox.Text;
            myPhone.Model = modelTextBox.Text;
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                myPhone.Price = price;
            }
            else
            {
                MessageBox.Show("Invalid Price");
            }
            
        }

        

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void phoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get which item is selected
            int index = phoneListBox.SelectedIndex;

            // display that items price
            MessageBox.Show(PhoneList[index].Price.ToString("c"));
        }
    }
}
