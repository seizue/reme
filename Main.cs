using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reme
{
    public partial class Main : MetroFramework.Forms.MetroForm
    {
      
       
        public Main()
        {
            InitializeComponent();

           userControl_Inventory1 = new UserControl_Inventory();
           userControl_Inventory1.Visible = false; // Initially, hide the UserControl

            // Add the UserControl to the main panel's controls
            MainPanel.Controls.Add(userControl_Inventory1);
        }

        private void InventoryLabel_Click(object sender, EventArgs e)
        { 
               // Set the location of the UserControl within the main panel
               userControl_Inventory1.Location = new Point(0, 0); // You may adjust the position
               userControl_Inventory1.Visible = true;
               userControl_Inventory1.BringToFront();
        }

        private void HomeLabel_Click(object sender, EventArgs e)
        {
          
                // Set the location of the UserControl within the main panel
                userControl_Inventory1.Location = new Point(0, 0); // You may adjust the position
                userControl_Inventory1.Visible = false;
          
        }
    }
}
