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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace reme
{
    public partial class UserControl_Inventory : UserControl
    {
        public BindingList<DataModel> ItemList
        {
            get { return dataList; }
        }

        public List<int> QuantityList
        {
            get { return Enumerable.Range(1, 20).ToList(); }
        }


        private BindingList<DataModel> dataList = new BindingList<DataModel>();

        public UserControl_Inventory()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Set up the DataGridView columns and bind it to the data list
            // Load data from JSON file
            if (File.Exists("data.json"))
            {
                string jsonData = File.ReadAllText("data.json");
                dataList = JsonConvert.DeserializeObject<BindingList<DataModel>>(jsonData);
            }

            // Set the DataGridView data source to the binding list
            GridOrderPreview.DataSource = dataList;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {

            // Get data from text boxes
            string item = textBox_Item.Text;
            int price;

            if (int.TryParse(textBox_Price.Text, out price))
            {
                // Create a new YourDataModel instance with auto-generated ID
                DataModel newData = new DataModel
                {
                    ITEM = item,
                    PRICE = price
                };

                // Add the new data to the existing list
                dataList.Add(newData);

                // Save the updated list to the JSON file
                SaveDataToJson();

                // Refresh the DataGridView after adding data
                GridOrderPreview.DataSource = null;
                GridOrderPreview.DataSource = dataList;

                // Clear the text boxes after adding data
                textBox_Item.Text = string.Empty;
                textBox_Price.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Invalid value for Price. Please enter a valid integer.");
            }
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
                textBox_Item.Text = dataList[selectedIndex].ITEM.ToString();
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
                csvContent.AppendLine($"{data.ID},{data.ITEM},{data.PRICE}");
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
