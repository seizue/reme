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

            InitializeInventoryControl();

            Tab_Indicator.Location = new Point(HomeLabel.Left,HomeLabel.Bottom + 5); // Add space below the label

            userControl_Inventory1 = new UserControl_Inventory();
            userControl_Inventory1.Visible = false; // Initially, hide the UserControl

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
    }
}
