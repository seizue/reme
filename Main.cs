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

            // Subscribe to the ItemSaved event of the UserControl
            userControl_Inventory1.ItemSaved += UserControl_ItemSaved;

            // Subscribe to the SelectionChanged event of the DataGridView
            OrderPreview.SelectionChanged += OrderPreview_SelectionChanged;

            Tab_Indicator.Location = new Point(HomeLabel.Left, HomeLabel.Bottom + 5); // Add space below the label

            userControl_Inventory1 = new UserControl_Inventory();
            userControl_Inventory1.Visible = false; // Initially, hide the UserControl
            comboBox_Quantity.KeyPress += comboBox_Quantity_KeyPress;

            // Attach click events to your labels
            InventoryLabel.Click += InventoryLabel_Click;
            HomeLabel.Click += HomeLabel_Click;

            // Add the UserControl to the main panel's controls
            MainPanel.Controls.Add(userControl_Inventory1);

            // Subscribe to the SelectionChanged event of the DataGridView
            OrderPreview.SelectionChanged += OrderPreview_SelectionChanged;
        }

        private void InitializeInventoryControl()
        {
            // Create an instance of UserControl_Inventory
            inventoryControl = new UserControl_Inventory();

            // Set the data source for ORDER ComboBox
            comboBox_Order.DataSource = inventoryControl.OrderList;
            comboBox_Order.DisplayMember = "ORDER"; // Assuming "ORDER" is the property name representing the display value

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

        private void UserControl_ItemSaved(object sender, EventArgs e)
        {
            // Update the data source for comboBox_Order
            comboBox_Order.DataSource = null; // Clear the existing data source
            comboBox_Order.DataSource = inventoryControl.OrderList; // Set the updated data source
            comboBox_Order.DisplayMember = "ORDER"; // Set the display member
            comboBox_Order.ValueMember = "ORDER"; // Set the value member
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
                var dataList = userControl_Inventory1.dataList;
                string selectedOrder = comboBox_Order.SelectedItem?.ToString();
                int selectedQuantity = Convert.ToInt32(comboBox_Quantity.SelectedItem);
                int subtotal = dataList.FirstOrDefault(item => item.ORDER == selectedOrder)?.PRICE * selectedQuantity ?? 0;
                OrderItem newOrderItem = new OrderItem
                {
                    ORDER = selectedOrder,
                    QUANTITY = selectedQuantity,
                    SUBTOTAL = subtotal
                };

                List<OrderItem> existingOrders = LoadExistingOrders();
                existingOrders.Add(newOrderItem);
                string jsonData = JsonConvert.SerializeObject(existingOrders, Formatting.Indented);
                File.WriteAllText("orders.json", jsonData);
                LoadJsonData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }

        private List<OrderItem> LoadExistingOrders()
        {
            try
            {
                if (File.Exists("orders.json"))
                {
                    string jsonData = File.ReadAllText("orders.json");

                    // Check if the file is empty
                    if (!string.IsNullOrWhiteSpace(jsonData))
                    {
                        List<OrderItem> existingOrders = JsonConvert.DeserializeObject<List<OrderItem>>(jsonData);
                        return existingOrders;
                    }
                }

                // If the file is empty or doesn't exist, return an empty list
                return new List<OrderItem>();

             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading existing orders: " + ex.Message);
                return new List<OrderItem>();
            }
        }


        // Method to load JSON data into the DataGridView
        private void LoadJsonData()
        {

            try
            {
                if (File.Exists("orders.json"))
                {
                    string jsonData = File.ReadAllText("orders.json");

                    if (!string.IsNullOrWhiteSpace(jsonData))
                    {
                        // Deserialize JSON data to a list of OrderItem objects
                        List<OrderItem> orders = JsonConvert.DeserializeObject<List<OrderItem>>(jsonData);

                        // Clear existing rows from the DataGridView
                        OrderPreview.Rows.Clear();

                        // Populate the DataGridView with the deserialized data
                        foreach (var order in orders)
                        {
                            OrderPreview.Rows.Add(order.ORDER, order.QUANTITY, order.SUBTOTAL, order.NAME, order.PRICE);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The orders file is empty.");
                    }
                }
                else
                {
                    MessageBox.Show("The orders file does not exist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders from file: " + ex.Message);
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

        private void OrderPreview_SelectionChanged(object sender, EventArgs e)
        {
            // Check if any row is selected
            if (OrderPreview.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = OrderPreview.SelectedRows[0];

                // Retrieve the value of the ORDER column from the selected row
                string selectedOrder = Convert.ToString(selectedRow.Cells["ORDER"].Value);

                // Find the corresponding item in comboBox_Order items collection
                foreach (var item in comboBox_Order.Items)
                {
                    if (item.ToString() == selectedOrder)
                    {
                        // Set the found item as the selected item in comboBox_Order
                        comboBox_Order.SelectedItem = item;
                        break; // Exit the loop once found
                    }
                }

                // Set the selected quantity from the DataGridView
                comboBox_Quantity.SelectedItem = selectedRow.Cells["QUANTITY"].Value;

            }
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear all rows from the DataGridView
                OrderPreview.Rows.Clear();

                // Clear the text boxes and ComboBoxes
                textBox_Name.Text = "";
                comboBox_Order.SelectedIndex = -1;
                comboBox_Quantity.SelectedIndex = -1;

                // Clear the data in the JSON file
                File.WriteAllText("orders.json", "");

                MessageBox.Show("Entries cleared successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing entries: " + ex.Message);
            }
        }
    }
}
