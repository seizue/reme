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

namespace reme
{
    public partial class Receipt : MetroFramework.Forms.MetroForm
    {
        public Receipt()
        {
            InitializeComponent();
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

      
    }
}
