﻿using System;
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
using MetroFramework;
using MetroFramework.Forms;
using System.Net;

namespace reme
{
    public partial class Main : MetroFramework.Forms.MetroForm
    {

        private Color defaultColor = Color.FromArgb(71, 38, 38); // Default color of the tab indicator
        private Color clickedColor = Color.FromArgb(227, 103, 102); // Color when the button is clicked

        private UserControl_Inventory inventoryControl;
        private UserControl_DashBoard dashBoardControl;

        public Main()
        {
            InitializeComponent();
            LoadJsonData();
            InitializeInventoryControl();
            CalculateOverallTotal();
            LoadNameAndPreview();
            SetCurrentDate();
            CheckFiles();

            // Subscribe to events in the user control
            userControl_Inventory1.DataSaved += UserControl_Inventory_DataSaved;
        
           // Subscribe to the SelectionChanged event of the DataGridView
            OrderPreview.SelectionChanged += OrderPreview_SelectionChanged;

            userControl_Inventory1 = new UserControl_Inventory();
            userControl_Inventory1.Visible = false;

            // Attach click events to the buttons
            button_Inventory.Click += button_Inventory_Click;
            button_Home.Click += button_Home_Click;
            button_Dashboard.Click += button_Dashboard_Click;

            // Add the UserControl to the main panel's controls
            MainPanel.Controls.Add(userControl_Inventory1);

            // Subscribe to the SelectionChanged event of the DataGridView
            OrderPreview.SelectionChanged += OrderPreview_SelectionChanged;

            OrderPreview.RowPrePaint += OrderPreview_RowPrePaint;

            OrderPreview.CellPainting += OrderPreview_CellPainting;

        }

        private void InitializeInventoryControl()
        {
            // Create an instance of UserControl_Inventory
            inventoryControl = new UserControl_Inventory();

            // Set the data source for ORDER ComboBox
            comboBox_Order.DataSource = inventoryControl.OrderList;
            comboBox_Order.DisplayMember = "ORDER";
           
            // Attach KeyPress event handler to the MaskedTextBox
            maskedTextBox_Quantity.KeyPress += MaskedTextBox_Quantity_KeyPress;
            textBox_PhoneNo.KeyPress += textBox_PhoneNo_KeyPress;
        }

        private void MaskedTextBox_Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit or a control key (like backspace or delete)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If the key is not a digit or a control key, suppress the key press event
                e.Handled = true;
            }
        }


        private void UserControl_Inventory_DataSaved(object sender, EventArgs e)
        {
            // Handle the event raised by the user control
            // Update the main form as needed
            RefreshData(); // Example method to refresh data in the main form
        }

        private void RefreshData()
        {
            // Add logic to refresh or update data in the main form
            // For example, you might reload data from a file or database
       
        
            InitializeInventoryControl();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                var dataList = userControl_Inventory1.dataList;
                string selectedOrder = comboBox_Order.SelectedItem?.ToString();
                int selectedQuantity = Convert.ToInt32(maskedTextBox_Quantity.Text); // Change this line
                int selectedPrice = dataList.FirstOrDefault(item => item.ORDER == selectedOrder)?.PRICE ?? 0;
                int subtotal = selectedPrice * selectedQuantity;
                string name = textBox_Name.Text.Trim();
                string address = textBox_Address.Text.Trim();
                string phoneNo = textBox_PhoneNo.Text.Trim();

                SaveNameToJson(name);
                SaveAddressAndPhoneToJson(address, phoneNo);
                bool orderExists = false;
                foreach (DataGridViewRow row in OrderPreview.Rows)
                {
                    if (row.Cells["ORDER"].Value?.ToString() == selectedOrder)
                    {
                        // Update the existing order
                        int existingQuantity = Convert.ToInt32(row.Cells["QUANTITY"].Value);
                        int quantityDifference = selectedQuantity - existingQuantity;
                        row.Cells["QUANTITY"].Value = selectedQuantity; // Update the QUANTITY
                        row.Cells["SUBTOTAL"].Value = subtotal; // Update the SUBTOTAL based on new quantity and price

                        orderExists = true;
                        break;
                    }
                }

                if (!orderExists)
                {
                    // Add a new entry if the order doesn't exist
                    OrderPreview.Rows.Add(selectedOrder, selectedQuantity, subtotal);
                }

                UpdateOrdersJsonFile();
                LoadNameAndPreview();
                CalculateOverallTotal();
                LoadAddressAndPhoneFromJson();
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
                            OrderPreview.Rows.Add(order.ORDER, order.QUANTITY, order.SUBTOTAL, order.PRICE);
                        }
                    }
                    else
                    {
                      
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
                maskedTextBox_Quantity.Text = Convert.ToString(selectedRow.Cells["QUANTITY"].Value);

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
                maskedTextBox_Quantity.Text = "";

                // Clear the data in the JSON file
                File.WriteAllText("orders.json", "");
                File.WriteAllText("name.json", "");

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

        private void OrderPreview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the edited cell is in the QUANTITY column
            if (e.ColumnIndex == OrderPreview.Columns["QUANTITY"].Index)
            {
                DataGridViewRow editedRow = OrderPreview.Rows[e.RowIndex];

                CalculateOverallTotal();
            }
        }

        private void CalculateOverallTotal()
        {
            int overallTotal = 0;

            // Iterate through all rows except the last one (which contains the overall total)
            for (int i = 0; i < OrderPreview.Rows.Count - 1; i++)
            {
                int subtotal = 0;
                if (OrderPreview.Rows[i].Cells["SUBTOTAL"].Value != null)
                {
                    subtotal = Convert.ToInt32(OrderPreview.Rows[i].Cells["SUBTOTAL"].Value);
                    overallTotal += subtotal;
                }
            }

            // Set the overall total directly to the appropriate cell
            DataGridViewCell overallTotalCell = OrderPreview.Rows[OrderPreview.Rows.Count - 1].Cells["SUBTOTAL"];
            overallTotalCell.Value = overallTotal;

            // Set the name of the overall total cell to "TOTAL"
            DataGridViewCell totalNameCell = OrderPreview.Rows[OrderPreview.Rows.Count - 1].Cells["ORDER"];
            totalNameCell.Value = "Total Amount";

            // Adjust the height of the last row containing the overall total
            OrderPreview.Rows[OrderPreview.Rows.Count - 1].Height = 27; // Adjust the height as needed

        }

        private void OrderPreview_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Check if the current row is the last row
            if (e.RowIndex == OrderPreview.Rows.Count - 1)
            {
                // Change the back color of the entire row
                OrderPreview.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(193, 160, 160);
                OrderPreview.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(106, 56, 56);
            }
        }

        private void OrderPreview_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (!OrderPreview.Rows[e.RowIndex].IsNewRow && e.RowIndex != OrderPreview.Rows.Count - 1)
                {
                    // Exclude the divider border for the right of the last column
                    if (e.ColumnIndex < OrderPreview.Columns.Count - 1)
                    {
                        e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Single;
                    }
                    else
                    {
                        e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
                    }

                    // Exclude the divider border for the bottom of the last row
                    if (e.RowIndex < OrderPreview.Rows.Count - 1)
                    {
                        e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
                    }
                    else
                    {
                        e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                    }
                }
                else
                {
                    // Exclude the divider border for the header cell
                    e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                }
            }
        }

        private void SaveNameToJson(string name)
        {
            try
            {
                // Serialize the name to JSON
                string jsonData = JsonConvert.SerializeObject(name, Formatting.Indented);

                // Write JSON data to the file
                File.WriteAllText("name.json", jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving name to name.json: " + ex.Message);
            }
        }

        private string LoadNameFromJson()
        {
            try
            {
                if (File.Exists("name.json"))
                {
                    string jsonData = File.ReadAllText("name.json");

                    if (!string.IsNullOrWhiteSpace(jsonData))
                    {
                        // Deserialize JSON data
                        return JsonConvert.DeserializeObject<string>(jsonData);
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    MessageBox.Show("The name file does not exist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading name from name.json: " + ex.Message);
            }

            return null;
        }

        private void LoadNameAndPreview()
        {
            string loadedName = LoadNameFromJson();
            if (!string.IsNullOrEmpty(loadedName))
            {
                textBox_PreviewName.Text = loadedName;
            }    
           
        }

        private void SetCurrentDate()
        {
            // Get the current date and format it as per your requirement
            string currentDate = DateTime.Now.ToString("MM/dd/yyyy");

            // Set the formatted current date to the textBox_Date
            textBox_Date.Text = currentDate;
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            // Instantiate the Receipt form
            Receipt receiptForm = new Receipt();

            receiptForm.StyleManager = this.StyleManager;

            // Pass data from OrderPreview to GridPrintReceipt
            receiptForm.ReceiveDataFromMain(OrderPreview.Rows);

            // Pass the name from Main form to Receipt form
            receiptForm.TextBox_ReceiptName.Text = textBox_PreviewName.Text;
            receiptForm.TextBox_ReceiptAddress.Text = textBox_PreviewAddress.Text;
            receiptForm.TextBox_ReceiptPhoneNo.Text = textBox_PreviewPhoneNo.Text;
            // Show the Receipt form
            receiptForm.Show();       
        }

        private void button_Home_Click(object sender, EventArgs e)
        {
            // Set the location of the UserControl within the main panel
            userControl_Inventory1.Location = new Point(0, 0); // You may adjust the position
            userControl_Inventory1.Visible = false;
            userControl_DashBoard1.Visible = false;
          
            // Change the color of the labels
            button_Home.ForeColor = clickedColor;
            button_Inventory.ForeColor = defaultColor;
            button_Dashboard.ForeColor = defaultColor;
         
        }

        private void button_Inventory_Click(object sender, EventArgs e)
        {

            // Set the location of the UserControl within the main panel
            userControl_Inventory1.Location = new Point(0, 0); // You may adjust the position
            userControl_Inventory1.Visible = true;
            userControl_Inventory1.BringToFront();

            // Change the color of the labels
            button_Inventory.ForeColor = clickedColor;
            button_Home.ForeColor = defaultColor;
            button_Dashboard.ForeColor = defaultColor;
        }

        private void button_Dashboard_Click(object sender, EventArgs e)
        {
            // Set the location of the UserControl within the main panel
            userControl_DashBoard1.Location = new Point(0, 0); // You may adjust the position
            userControl_DashBoard1.Visible = true;
            userControl_DashBoard1.BringToFront();
            userControl_Inventory1.Visible = false;
          

            // Change the color of the labels
            button_Dashboard.ForeColor = clickedColor;
            button_Home.ForeColor = defaultColor;
            button_Inventory.ForeColor = defaultColor;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Clear all rows from the DataGridView
            OrderPreview.Rows.Clear();

            // Clear the text boxes and ComboBoxes
            textBox_Name.Text = "";
            textBox_PreviewName.Text = "";
            maskedTextBox_Quantity.Text = "";
            comboBox_Order.SelectedIndex = -1;
            

            // Clear the data in the JSON file
            File.WriteAllText("orders.json", "");
            File.WriteAllText("name.json", "");
        }

        private void CheckFiles()
        {
            string[] filesToCheck = { "data.json", "name.json", "orders.json", "inventory.json" };

            bool allFilesExist = true;

            foreach (string file in filesToCheck)
            {
                if (!File.Exists(file))
                {
                    allFilesExist = false;
                    break;
                }
            }

            if (allFilesExist)
            {
                panel_Status.BackColor = Color.MediumAquamarine;
            }
            else
            {
                panel_Status.BackColor = Color.DimGray;
            }
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {        
            InitializeInventoryControl();
            LoadJsonData();
            CalculateOverallTotal();
            LoadNameAndPreview();
            CheckFiles();
            userControl_DashBoard1.RefreshData();

            // Show a message box indicating successful refreshing
            MessageBox.Show("Data refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_Settings_Click(object sender, EventArgs e)
        {
            // Instantiate the Receipt form
            Settings settingsForm = new Settings();

            // Show the Receipt form
            settingsForm.Show();
        }

        private void SaveAddressAndPhoneToJson(string address, string phoneNo)
        {
            try
            {
                // Create an object to hold address and phone number
                var addressAndPhone = new { Address = address, PhoneNo = phoneNo };

                // Serialize the object to JSON
                string jsonData = JsonConvert.SerializeObject(addressAndPhone, Formatting.Indented);

                // Write JSON data to the file
                File.WriteAllText("address_phone.json", jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving address and phone number to address_phone.json: " + ex.Message);
            }
        }

        private void LoadAddressAndPhoneFromJson()
        {
            try
            {
                if (File.Exists("address_phone.json"))
                {
                    string jsonData = File.ReadAllText("address_phone.json");

                    if (!string.IsNullOrWhiteSpace(jsonData))
                    {
                        // Deserialize JSON data
                        var addressAndPhone = JsonConvert.DeserializeObject<dynamic>(jsonData);
                        string address = addressAndPhone.Address;
                        string phoneNo = addressAndPhone.PhoneNo;

                        // Set the loaded address and phone number to respective text boxes
                        textBox_PreviewAddress.Text = address;
                        textBox_PreviewPhoneNo.Text = phoneNo;
                    }
                    else
                    {
                        // Handle the case when JSON data is empty
                    }
                }
                else
                {
                    // If the file doesn't exist, create it with default values or leave it empty
                    File.WriteAllText("address_phone.json", "{}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading address and phone number from address_phone.json: " + ex.Message);
            }
        }

        private void textBox_PreviewName_TextChanged(object sender, EventArgs e)
        {
            // Convert the text to uppercase
            textBox_PreviewName.Text = textBox_PreviewName.Text.ToUpper();
            // Move the cursor to the end of the text to maintain the caret position
            textBox_PreviewName.SelectionStart = textBox_PreviewName.Text.Length;
        }

        private void textBox_PreviewAddress_TextChanged(object sender, EventArgs e)
        {
            textBox_PreviewAddress.Text = textBox_PreviewAddress.Text.ToUpper();
            textBox_PreviewAddress.SelectionStart = textBox_PreviewAddress.Text.Length;
        }

        private void textBox_PhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit or a control key (like backspace or delete)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If the key is not a digit or a control key, suppress the key press event
                e.Handled = true;
            }
        }
    }

}
