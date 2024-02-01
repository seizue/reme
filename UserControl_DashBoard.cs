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
using static reme.Receipt;

namespace reme
{
    public partial class UserControl_DashBoard : UserControl
    {
        private int nextID = 1;
        private List<ReceiptEntry> receiptEntries = new List<ReceiptEntry>();
        private string jsonFilePath = "inventory.json";
        public UserControl_DashBoard()
        {
            InitializeComponent();
            LoadDataFromJson();
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


    }
}
