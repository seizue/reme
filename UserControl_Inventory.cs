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


namespace reme
{
    public partial class UserControl_Inventory : UserControl
    {
        public BindingList<DataModel> dataList = new BindingList<DataModel>();

        public event EventHandler DataSaved;


        public List<int> QuantityList
        {
            get { return Enumerable.Range(1, 20).ToList(); }
        }
    
        public List<string> OrderList
        {
            get
            {
                return dataList.Select(item => item.ORDER).ToList();
            }
        }

        public UserControl_Inventory()
        {
            InitializeComponent();
            InitializeDataGridView();         
        }

        private void InitializeDataGridView()
        {
            try
            {
                // Load data from JSON file if it exists and contains data
                if (File.Exists("data.json"))
                {
                    string jsonData = File.ReadAllText("data.json");
                    if (!string.IsNullOrWhiteSpace(jsonData))
                    {
                        dataList = JsonConvert.DeserializeObject<BindingList<DataModel>>(jsonData);
                    }
                }

                // Initialize an empty list if data loading fails or if the file doesn't exist
                if (dataList == null)
                {
                    dataList = new BindingList<DataModel>();
                }

                // Set the DataGridView data source to the binding list
                GridOrderPreview.DataSource = dataList;
            }
            catch (Exception ex)
            {
                // Handle deserialization errors or other exceptions
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }


    
        private void button_Save_Click(object sender, EventArgs e)
        {

            try
            {
                string item = textBox_Item.Text;
                int price;

                if (int.TryParse(textBox_Price.Text, out price))
                {
                    DataModel newData = new DataModel
                    {
                        ORDER = item,
                        PRICE = price
                    };

                    // Add the new data to the existing list
                    dataList.Add(newData);

                    // Save the updated list to the JSON file
                    SaveDataToJson();

             
                    // Clear the text boxes after adding data
                    textBox_Item.Text = string.Empty;
                    textBox_Price.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Invalid value for Price. Please enter a valid integer.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
          
        }

        protected virtual void OnDataSaved(EventArgs e)
        {
            DataSaved?.Invoke(this, e);
        }

        private void SaveDataToJson()
        {
            // Update the IDs based on the current order in dataList
            for (int i = 0; i < dataList.Count; i++)
            {
                dataList[i].ID = i + 1;
            }

            // Serialize the data list to JSON
            string jsonData = JsonConvert.SerializeObject(dataList, Formatting.Indented);

            // Save the JSON data to a file
            File.WriteAllText("data.json", jsonData);

     
            OnDataSaved(EventArgs.Empty);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            // Check if any row is selected
            if (GridOrderPreview.SelectedRows.Count > 0)
            {
                // Get the selected row index
                int selectedIndex = GridOrderPreview.SelectedRows[0].Index;

                // Remove the selected row from the dataList
                dataList.RemoveAt(selectedIndex);

                // Save the updated list to the JSON file
                SaveDataToJson();

                // Refresh the DataGridView after deleting data
                GridOrderPreview.DataSource = null;
                GridOrderPreview.DataSource = dataList;
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            // Check if any row is selected
            if (GridOrderPreview.SelectedRows.Count > 0)
            {
                // Get the selected row index
                int selectedIndex = GridOrderPreview.SelectedRows[0].Index;

                // Populate text boxes with data from the selected row
                textBox_Item.Text = dataList[selectedIndex].ORDER.ToString();
                textBox_Price.Text = dataList[selectedIndex].PRICE.ToString();
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void button_Export_Click(object sender, EventArgs e)
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
            csvContent.AppendLine("ID,ITEM,PRICE");

            // Add data lines
            foreach (DataModel data in dataList)
            {
                csvContent.AppendLine($"{data.ID},{data.ORDER},{data.PRICE}");
            }

            // Append the current date to the filename
            string currentDate = DateTime.Now.ToString("yyyyMMdd");
            string filename = $"MENU_ITEMS_{currentDate}.csv";

            // Combine the custom filepath and generated filename
            string fullFilePath = Path.Combine(filePath, filename);

            // Write the CSV content to the specified file
            File.WriteAllText(fullFilePath, csvContent.ToString());

            MessageBox.Show($"Data exported to CSV successfully!\nFile saved at: {fullFilePath}");
        }
    }
}
