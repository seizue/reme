using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using static reme.Receipt;

namespace reme
{
    public partial class UserControl_DashBoard : UserControl
    {
        private Color defaultColor = Color.FromArgb(71, 38, 38); // Default color of the button fore color
        private Color clickedColor = Color.FromArgb(227, 103, 102); // Color when the button is clicked

        private int nextID = 1;
        private List<ReceiptEntry> receiptEntries = new List<ReceiptEntry>();
        private string jsonFilePath = "inventory.json";

        public UserControl_DashBoard()
        {
            InitializeComponent();
            LoadDataFromJson();
            LoadDataAndPopulateGrid(); // Load data and populate GridInv

            // Attach click events to the buttons
            button_Chart.Click += button_Chart_Click;
            button_History.Click += button_DB_Click;

            button_ExportInv.Visible = false;
            panel_style1.Visible = false;
            panel_Style2.Visible = false;
        }

        private void LoadDataFromJson()
        {
            try
            {
                string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "inventory.json");

                if (File.Exists(jsonFilePath))
                {
                    string jsonData = File.ReadAllText(jsonFilePath);

                    if (!string.IsNullOrWhiteSpace(jsonData))
                    {
                        receiptEntries = JsonConvert.DeserializeObject<List<ReceiptEntry>>(jsonData);
                        PopulateGrid();
                        UpdateNextID();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data from JSON: {ex.Message}");
            }
        }


        private void UpdateNextID()
        {
            if (receiptEntries.Count > 0)
            {
                nextID = receiptEntries.Max(entry => entry.ID) + 1;
            }
        }

        private void LoadDataAndPopulateGrid()
        {
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);

                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    receiptEntries = JsonConvert.DeserializeObject<List<ReceiptEntry>>(jsonData);
                    PopulateGrid(); // Populate the GridInv with the loaded data
                }
            }
        }

        private void PopulateGrid()
        {
            if (GridInv != null)
            {
                GridInv.Rows.Clear();

                foreach (var entry in receiptEntries)
                {
                    // Concatenate all orders for display
                    string orders = string.Join(", ", entry.Items.Select(item => item.Order));

                    // Populate GridInv with the entry details
                    string id = "0" + entry.ID;
                    GridInv.Rows.Add(id, entry.DATE, entry.ReceiptName, entry.Address, entry.Phone, orders, entry.TotalAmount);
                }
            }
            else
            {
                MessageBox.Show("GridInv is null.");
            }
        }


        private void SaveDataToJson()
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(receiptEntries, Formatting.Indented);
                File.WriteAllText(jsonFilePath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data to JSON: {ex.Message}");
            }
        }

        private void AddEntryToReceiptEntries(ReceiptEntry entry)
        {
            entry.ID = nextID++; // Assign the current value of nextID and then increment
            receiptEntries.Add(entry);
            SaveDataToJson();
        }

        private void button_ExportInv_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    ExportDataToCSV(folderBrowser.SelectedPath);
                }
            }

        }
        private void ExportDataToCSV(string filePath)
        {
            StringBuilder csvContent = new StringBuilder();

            // Add header line
            csvContent.AppendLine("ID,DATE,RECEIPT_NAME,ORDER,TOTAL_AMOUNT");

            // Iterate over each ReceiptEntry and append its data to the CSV content
            foreach (var entry in receiptEntries)
            {
                // Concatenate order items with spacing ","
                string orders = string.Join(", ", entry.Items.Select(item => item.Order));

                // Enclose the orders with double quotes
                orders = $"\"{orders}\"";

                // Format the line for the entry
                string line = $"{entry.ID},{entry.DATE},{entry.ReceiptName},{orders},{entry.TotalAmount}";

                // Append the formatted line to the CSV content
                csvContent.AppendLine(line);
            }

            // Append the current date to the filename
            string currentDate = DateTime.Now.ToString("yyyyMMdd");
            string filename = $"INVENTORY_DB_{currentDate}.csv";

            // Combine the custom filepath and generated filename
            string fullFilePath = Path.Combine(filePath, filename);

            try
            {
                // Write the CSV content to the specified file
                File.WriteAllText(fullFilePath, csvContent.ToString());

                MessageBox.Show($"Data exported to CSV successfully!\nFile saved at: {fullFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data to CSV: {ex.Message}");
            }
        }

        private void button_Chart_Click(object sender, EventArgs e)
        {
            // Set the location of the UserControl within the main panel
            userControl_Chart1.Location = new Point(0, 0); // You may adjust the position
            userControl_Chart1.Visible = true;
            userControl_Chart1.BringToFront();
            button_ExportInv.Visible = false;
            GridInv.Visible = false;
            panel_style1.Visible = false;
            panel_Style2.Visible = false;

            // Change the color of the labels
            button_Chart.ForeColor = clickedColor;
            button_History.ForeColor = defaultColor;
           
        }

        private void button_DB_Click(object sender, EventArgs e)
        {
            GridInv.Visible = true;
            button_ExportInv.Visible = true;
            panel_style1.Visible = true;
            panel_Style2.Visible = true;

            GridInv.BringToFront();
            userControl_Chart1.Visible = false;

            // Change the color of the labels
            button_History.ForeColor = clickedColor;
            button_Chart.ForeColor = defaultColor;
        }

        public void RefreshData()
        {
            LoadDataFromJson();
        }
    }
}
