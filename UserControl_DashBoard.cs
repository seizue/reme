using Newtonsoft.Json;
using System;
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
        private int nextID = 1;
        public UserControl_DashBoard()
        {
            InitializeComponent();
            LoadDataFromJson();
        }

        private void LoadDataFromJson()
        {
            string jsonFilePath = "inventory.json";

            if (System.IO.File.Exists(jsonFilePath))
            {
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);

                // Deserialize the JSON data into a list of ReceiptEntry objects
                List<ReceiptEntry> receiptEntries = JsonConvert.DeserializeObject<List<ReceiptEntry>>(jsonData);

                // Populate the GridInv DataGridView with the deserialized data
                PopulateGrid(receiptEntries);
            }
            else
            {
                MessageBox.Show("Inventory file not found.");
            }
        }

        public void PopulateGrid(List<ReceiptEntry> receiptEntries)
        {
            GridInv.Rows.Clear();
            nextID = 1; // Reset the ID counter

            foreach (var entry in receiptEntries)
            {
                foreach (var item in entry.Items)
                {
                    // Add a row to the GridInv DataGridView
                    GridInv.Rows.Add("INV_0" + nextID++, entry.DATE, entry.ReceiptName, item.Order, item.Quantity, entry.TotalAmount);
                }
            }
        }

    }
}
