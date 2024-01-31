using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace reme
{
    public partial class Receipt : MetroFramework.Forms.MetroForm
    {


        // Ensure that textBox_ReceiptName is accessible from outside the form
        public TextBox TextBox_ReceiptName
        {
            get { return textBox_ReceiptName; }
            set { textBox_ReceiptName = value; }
        }

        public Receipt()
        {
            InitializeComponent();
            SetCurrentDate();         
        }

        private void SetCurrentDate()
        {
            // Get the current date and format it as per your requirement
            string currentDate = DateTime.Now.ToString("MM/dd/yyyy");

            // Set the formatted current date 
            textBox_ReceiptDate.Text = currentDate;
        }
        private void metroTile_PrintReceipt_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Capture the screenshot of the panel_Print
            Bitmap bitmap = new Bitmap(panel_Print.Width, panel_Print.Height);
            panel_Print.DrawToBitmap(bitmap, new Rectangle(0, 0, panel_Print.Width, panel_Print.Height));

            // Draw the screenshot on the print document's graphics object
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        public void ReceiveDataFromMain(DataGridViewRowCollection rows)
        {
            // Clear existing rows
            GridPrintReceipt.Rows.Clear();

            int overallTotal = 0; // Initialize the overall total

            // Copy data from OrderPreview to GridPrintReceipt
            foreach (DataGridViewRow row in rows)
            {
                // Check if the row is not the last row (which contains the "Total Amount")
                if (row.Cells["ORDER"].Value.ToString() != "Total Amount")
                {
                    // Add the row to GridPrintReceipt
                    GridPrintReceipt.Rows.Add(row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value).ToArray());

                    // Calculate subtotal and add it to the overall total
                    overallTotal += Convert.ToInt32(row.Cells["SUBTOTAL"].Value);
                }
            }

            // Set the overall total to the textBox_PrintTotalAmount
            textBox_PrintTotalAmount.Text = overallTotal.ToString();

        }

     


    }
}