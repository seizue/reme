using System;
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


namespace reme
{
    public partial class Settings : MetroFramework.Forms.MetroForm
    {
        private MetroFramework.Components.MetroStyleManager metroStyleManager;

        public static class AppSettings
        {
            public static int Theme { get; set; }
        }

        public Settings()
        {
            InitializeComponent();

            metroStyleManager = new MetroFramework.Components.MetroStyleManager();
            metroStyleManager.Owner = this;


            // Set a default theme if the saved value is invalid
            metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;

        }

        private void metroToggle_Button_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the theme when the toggle button changes state
            if (metroStyleManager.Theme == MetroFramework.MetroThemeStyle.Dark)
            {
                metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Light;
            }
            else
            {
                metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            }

         
        }
    }
}


