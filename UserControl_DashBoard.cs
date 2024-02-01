﻿using Newtonsoft.Json;
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
using static reme.Receipt;

namespace reme
{
    public partial class UserControl_DashBoard : UserControl
    {
        private Color defaultColor = Color.FromArgb(71, 38, 38); // Default color of the tab indicator
        private Color clickedColor = Color.FromArgb(227, 103, 102); // Color when the button is clicked

        private int nextID = 1;
        private List<ReceiptEntry> receiptEntries = new List<ReceiptEntry>();
        private string jsonFilePath = "inventory.json";

        public UserControl_DashBoard()
        {
            InitializeComponent();
            LoadDataFromJson();

            // Attach click events to the buttons
            button_Chart.Click += button_Chart_Click;
            button_DB.Click += button_DB_Click;
        }

        private void LoadDataFromJson()
        {
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

        private void UpdateNextID()
        {
            if (receiptEntries.Count > 0)
            {
                nextID = receiptEntries.Max(entry => entry.ID) + 1;
            }
        }


        private void PopulateGrid()
        {
            if (GridInv != null)
            {
                GridInv.Rows.Clear();

                foreach (var entry in receiptEntries)
                {
                    foreach (var item in entry.Items)
                    {
                        string id = "0" + nextID++;
                        GridInv.Rows.Add(id, entry.DATE, entry.ReceiptName, item.Order, entry.TotalAmount);
                    }
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

            GridInv.Visible = false;

            // Change the color of the labels
            button_Chart.ForeColor = clickedColor;
            button_DB.ForeColor = defaultColor;
           
        }

        private void button_DB_Click(object sender, EventArgs e)
        {
            GridInv.Visible = true;

            GridInv.BringToFront();
            userControl_Chart1.Visible = false;

            // Change the color of the labels
            button_DB.ForeColor = clickedColor;
            button_Chart.ForeColor = defaultColor;
        }
    }
}
