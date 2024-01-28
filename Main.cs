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
            CalculateOverallTotal();

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
            {
                try
                {
                    var dataList = userControl_Inventory1.dataList;
                    string selectedOrder = comboBox_Order.SelectedItem?.ToString();
                    int selectedQuantity = Convert.ToInt32(comboBox_Quantity.SelectedItem);
                    int subtotal = dataList.FirstOrDefault(item => item.ORDER == selectedOrder)?.PRICE * selectedQuantity ?? 0;

                    bool orderExists = false;
                    foreach (DataGridViewRow row in OrderPreview.Rows)
                    {
                        if (row.Cells["ORDER"].Value?.ToString() == selectedOrder)
                        {
                            // Update the existing order
                            int existingQuantity = Convert.ToInt32(row.Cells["QUANTITY"].Value);
                            int quantityDifference = selectedQuantity - existingQuantity;
                            row.Cells["QUANTITY"].Value = selectedQuantity; // Update the QUANTITY
                            row.Cells["SUBTOTAL"].Value = dataList.FirstOrDefault(item => item.ORDER == selectedOrder)?.PRICE * selectedQuantity; // Update the SUBTOTAL

                            orderExists = true;
                            break;
                        }
                    }

                    if (!orderExists)
                    {
                        // Add a new entry if the order doesn't exist
                        OrderPreview.Rows.Add(selectedOrder, selectedQuantity, subtotal);
                    }

                    // Update the orders.json file
                    UpdateOrdersJsonFile();

                    CalculateOverallTotal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving data: " + ex.Message);
                }
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

        private void UpdateOrdersJsonFile()
        {

            {
                try
                {
                    // Get data from OrderPreview DataGridView and serialize it to JSON
                    List<OrderItem> orders = new List<OrderItem>();

                    foreach (DataGridViewRow row in OrderPreview.Rows)
                    {
                        if (row.Cells["ORDER"].Value != null && row.Cells["QUANTITY"].Value != null && row.Cells["SUBTOTAL"].Value != null)
                        {
                            OrderItem orderItem = new OrderItem
                            {
                                ORDER = row.Cells["ORDER"].Value.ToString(),
                                QUANTITY = Convert.ToInt32(row.Cells["QUANTITY"].Value),
                                SUBTOTAL = Convert.ToInt32(row.Cells["SUBTOTAL"].Value)
                            };

                            orders.Add(orderItem);
                        }

                        // Write JSON data to the file
                        string jsonData = JsonConvert.SerializeObject(orders, Formatting.Indented);
                        File.WriteAllText("orders.json", jsonData);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating orders.json file: " + ex.Message);
                }
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
                        MessageBox.Show("The Orders is empty.");
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

        private void OrderPreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check if any row is selected
                DataGridView.HitTestInfo hitTestInfo = OrderPreview.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0)
                {
                    // Select the row under the cursor
                    OrderPreview.Rows[hitTestInfo.RowIndex].Selected = true;

                    // Show context menu for deleting the row
                    ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                    contextMenuStrip.Items.Add("Delete").Click += (s, ev) =>
                    {
                        // Delete the selected row
                        if (OrderPreview.SelectedRows.Count > 0)
                        {
                            OrderPreview.Rows.RemoveAt(OrderPreview.SelectedRows[0].Index);

                            // Update the orders.json file after deletion
                            UpdateOrdersJsonFile();

                            // Update the Overall total
                            CalculateOverallTotal();
                        }
                    };

                    // Display the context menu at the cursor's position
                    contextMenuStrip.Show(OrderPreview, e.Location);
                }

                CalculateOverallTotal();
            }
        }





        private void UpdateSubtotal(DataGridViewRow row)
        {
            // Retrieve the quantity and price from the row's cells
            int quantity = Convert.ToInt32(row.Cells["QUANTITY"].Value);
            int price = Convert.ToInt32(row.Cells["PRICE"].Value); // Assuming you have a PRICE column

            // Calculate the subtotal based on the quantity and price
            int subtotal = quantity * price;

            // Update the SUBTOTAL cell with the calculated subtotal
            row.Cells["SUBTOTAL"].Value = subtotal;
        }

        private void OrderPreview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the edited cell is in the QUANTITY column
            if (e.ColumnIndex == OrderPreview.Columns["QUANTITY"].Index)
            {
                DataGridViewRow editedRow = OrderPreview.Rows[e.RowIndex];
                UpdateSubtotal(editedRow);
                CalculateOverallTotal();
            }
        }

        private void CalculateOverallTotal()
        {
            int overallTotal = 0;

            // Iterate through all rows and sum up SUBTOTAL values
            foreach (DataGridViewRow row in OrderPreview.Rows)
            {
                int subtotal = 0;
                if (row.Cells["SUBTOTAL"].Value != null)
                {
                    subtotal = Convert.ToInt32(row.Cells["SUBTOTAL"].Value);
                    overallTotal += subtotal;
                }
            }

            // Update the overall total in the last row
            if (OrderPreview.Rows.Count > 0)
            {
                DataGridViewRow lastRow = OrderPreview.Rows[OrderPreview.Rows.Count - 1];
                lastRow.Cells["SUBTOTAL"].Value = overallTotal;
            }
        }



        private void comboBox_Quantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }
    }

      
    

}
