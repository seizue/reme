using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;


namespace reme
{
    public partial class Main : MetroFramework.Forms.MetroForm
    {

        private Color defaultColor = Color.FromArgb(71, 38, 38); // Default color of the tab indicator
        private Color clickedColor = Color.FromArgb(160, 84, 84); // Color when the label is clicked

        private UserControl_Inventory inventoryControl;


        public Main()
        {
            InitializeComponent();
            LoadJsonData();
            InitializeInventoryControl();

            Tab_Indicator.Location = new Point(HomeLabel.Left,HomeLabel.Bottom + 5); // Add space below the label

            userControl_Inventory1 = new UserControl_Inventory();
            userControl_Inventory1.Visible = false; // Initially, hide the UserControl

            comboBox_Quantity.SelectedIndexChanged += comboBox_Quantity_SelectedIndexChanged;
            comboBox_Quantity.KeyPress += comboBox_Quantity_KeyPress;

            // Attach click events to your labels
            InventoryLabel.Click += InventoryLabel_Click;
            HomeLabel.Click += HomeLabel_Click;
          
            // Add the UserControl to the main panel's controls
            MainPanel.Controls.Add(userControl_Inventory1);
        }

        private void InitializeInventoryControl()
        {
            // Create an instance of UserControl_Inventory
            inventoryControl = new UserControl_Inventory();

            // Set the data source for ITEM ComboBox
            comboBox_Order.DataSource = inventoryControl.ItemList;
            comboBox_Order.DisplayMember = "ITEM";

            // Set the data source for Quantity ComboBox
            comboBox_Quantity.DataSource = inventoryControl.QuantityList;
        }

        private void InventoryLabel_Click(object sender, EventArgs e)
        {  
            // Move the tab indicator to the Inventory Label
            MoveTabIndicator(InventoryLabel);

            // Set the location of the UserControl within the main panel
            userControl_Inventory1.Location = new Point(0, 0); // You may adjust the position
            userControl_Inventory1.Visible = true;
            userControl_Inventory1.BringToFront();

            // Change the color of the labels
            InventoryLabel.ForeColor = clickedColor;
            HomeLabel.ForeColor = defaultColor;
        }

        private void HomeLabel_Click(object sender, EventArgs e)
        {
            // Move the tab indicator to the Home Label
            MoveTabIndicator(HomeLabel);

            // Set the location of the UserControl within the main panel
            userControl_Inventory1.Location = new Point(0, 0); // You may adjust the position
            userControl_Inventory1.Visible = false;

            // Change the color of the labels
            HomeLabel.ForeColor = clickedColor;
            InventoryLabel.ForeColor = defaultColor;
        }

        private void MoveTabIndicator(Control label)
        {
          
            // Move the tab indicator below and with the same width as the clicked label
            Tab_Indicator.Location = new Point(label.Left, label.Bottom + 5); // Add space below the label

            // Change the color of the tab indicator
            Tab_Indicator.BackColor = clickedColor;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected item, quantity, and name
                DataModel selectedItem = (DataModel)comboBox_Order.SelectedItem;
                int selectedQuantity = (int)comboBox_Quantity.SelectedItem;
                string name = textBox_Name.Text;

                // Calculate subtotal
                int subtotal = selectedItem.PRICE * selectedQuantity;

                // Add data to GridOrderPreview DataGridView
                OrderPreview.Rows.Add(selectedItem.ITEM, selectedQuantity, subtotal, name);

                // Load existing data from the JSON file
                List<OrderItem> orderItems;
                string jsonData = File.ReadAllText("orders.json");
                orderItems = JsonConvert.DeserializeObject<List<OrderItem>>(jsonData) ?? new List<OrderItem>();

                // Append the new item to the existing list
                orderItems.Add(new OrderItem
                {
                    ORDER = selectedItem.ITEM,
                    QUANTITY = selectedQuantity,
                    SUBTOTAL = subtotal,
                    NAME = name
                });

                // Serialize the updated list to JSON format
                jsonData = JsonConvert.SerializeObject(orderItems, Formatting.Indented);

                // Write the updated JSON data back to the file
                File.WriteAllText("orders.json", jsonData);

                MessageBox.Show("Data saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }

        // Method to load JSON data into the DataGridView
        private void LoadJsonData()
        {
            try
            {
                // Read JSON data from file
                string jsonData = File.ReadAllText("orders.json");

                // Deserialize JSON data to list of OrderItem objects
                List<OrderItem> orderItems = JsonConvert.DeserializeObject<List<OrderItem>>(jsonData);

                // Populate the DataGridView with deserialized data
                foreach (var item in orderItems)
                {
                    OrderPreview.Rows.Add(item.ORDER, item.QUANTITY, item.SUBTOTAL, item.NAME);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

      

        private void comboBox_Quantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            // Check if the selected item is not null and if it can be converted to an integer
            if (comboBox.SelectedItem != null && !int.TryParse(comboBox.SelectedItem.ToString(), out _))
            {
                // If the selected item is not a valid number, reset the selection
                comboBox.SelectedIndex = -1;
            }
        }

        private void comboBox_Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, Backspace, and Delete
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
