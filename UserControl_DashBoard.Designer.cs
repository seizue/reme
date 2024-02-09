namespace reme
{
    partial class UserControl_DashBoard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Border = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GridInv = new MetroFramework.Controls.MetroGrid();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Style2 = new System.Windows.Forms.Panel();
            this.panel_style1 = new System.Windows.Forms.Panel();
            this.button_ExportInv = new System.Windows.Forms.Button();
            this.button_Chart = new System.Windows.Forms.Button();
            this.button_History = new System.Windows.Forms.Button();
            this.userControl_Chart1 = new reme.UserControl_Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridInv)).BeginInit();
            this.SuspendLayout();
            // 
            // Border
            // 
            this.Border.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.Border.Location = new System.Drawing.Point(477, 7);
            this.Border.Name = "Border";
            this.Border.Size = new System.Drawing.Size(2, 18);
            this.Border.TabIndex = 203;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.userControl_Chart1);
            this.panel1.Controls.Add(this.GridInv);
            this.panel1.Location = new System.Drawing.Point(21, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 404);
            this.panel1.TabIndex = 206;
            // 
            // GridInv
            // 
            this.GridInv.AllowUserToResizeColumns = false;
            this.GridInv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GridInv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridInv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridInv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.GridInv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridInv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridInv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.GridInv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridInv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridInv.ColumnHeadersHeight = 37;
            this.GridInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridInv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DATE,
            this.NAME,
            this.ORDER,
            this.TOTAL});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 9.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridInv.DefaultCellStyle = dataGridViewCellStyle3;
            this.GridInv.EnableHeadersVisualStyles = false;
            this.GridInv.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.GridInv.GridColor = System.Drawing.Color.Silver;
            this.GridInv.Location = new System.Drawing.Point(5, 5);
            this.GridInv.Name = "GridInv";
            this.GridInv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridInv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GridInv.RowHeadersVisible = false;
            this.GridInv.RowHeadersWidth = 45;
            this.GridInv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GridInv.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.GridInv.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.GridInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridInv.Size = new System.Drawing.Size(758, 380);
            this.GridInv.TabIndex = 15;
            this.GridInv.UseCustomBackColor = true;
            this.GridInv.UseCustomForeColor = true;
            this.GridInv.UseStyleColors = true;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // DATE
            // 
            this.DATE.HeaderText = "DATE";
            this.DATE.Name = "DATE";
            // 
            // NAME
            // 
            this.NAME.HeaderText = "NAME";
            this.NAME.Name = "NAME";
            // 
            // ORDER
            // 
            this.ORDER.HeaderText = "ORDER";
            this.ORDER.Name = "ORDER";
            // 
            // TOTAL
            // 
            this.TOTAL.HeaderText = "TOTAL";
            this.TOTAL.Name = "TOTAL";
            // 
            // panel_Style2
            // 
            this.panel_Style2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(231)))), ((int)(((byte)(227)))));
            this.panel_Style2.Location = new System.Drawing.Point(679, 23);
            this.panel_Style2.Name = "panel_Style2";
            this.panel_Style2.Size = new System.Drawing.Size(35, 4);
            this.panel_Style2.TabIndex = 210;
            // 
            // panel_style1
            // 
            this.panel_style1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel_style1.Location = new System.Drawing.Point(613, 23);
            this.panel_style1.Name = "panel_style1";
            this.panel_style1.Size = new System.Drawing.Size(60, 4);
            this.panel_style1.TabIndex = 209;
            // 
            // button_ExportInv
            // 
            this.button_ExportInv.BackColor = System.Drawing.Color.White;
            this.button_ExportInv.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_ExportInv.FlatAppearance.BorderSize = 0;
            this.button_ExportInv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ExportInv.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ExportInv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_ExportInv.Image = global::reme.Properties.Resources.export_20px;
            this.button_ExportInv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ExportInv.Location = new System.Drawing.Point(718, 3);
            this.button_ExportInv.Name = "button_ExportInv";
            this.button_ExportInv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_ExportInv.Size = new System.Drawing.Size(84, 25);
            this.button_ExportInv.TabIndex = 208;
            this.button_ExportInv.Text = "       EXPORT";
            this.button_ExportInv.UseVisualStyleBackColor = false;
            this.button_ExportInv.Click += new System.EventHandler(this.button_ExportInv_Click);
            // 
            // button_Chart
            // 
            this.button_Chart.BackColor = System.Drawing.Color.White;
            this.button_Chart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_Chart.FlatAppearance.BorderSize = 0;
            this.button_Chart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Chart.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Chart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(103)))), ((int)(((byte)(102)))));
            this.button_Chart.Image = global::reme.Properties.Resources.increase_profits_24px1;
            this.button_Chart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Chart.Location = new System.Drawing.Point(364, 3);
            this.button_Chart.Name = "button_Chart";
            this.button_Chart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_Chart.Size = new System.Drawing.Size(107, 25);
            this.button_Chart.TabIndex = 205;
            this.button_Chart.Text = "SALES CHART";
            this.button_Chart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Chart.UseVisualStyleBackColor = false;
            this.button_Chart.Click += new System.EventHandler(this.button_Chart_Click);
            // 
            // button_History
            // 
            this.button_History.BackColor = System.Drawing.Color.White;
            this.button_History.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_History.FlatAppearance.BorderSize = 0;
            this.button_History.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_History.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_History.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_History.Image = global::reme.Properties.Resources.order_history_24px;
            this.button_History.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_History.Location = new System.Drawing.Point(485, 3);
            this.button_History.Name = "button_History";
            this.button_History.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_History.Size = new System.Drawing.Size(114, 25);
            this.button_History.TabIndex = 204;
            this.button_History.Text = "ORDER HISTORY";
            this.button_History.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_History.UseVisualStyleBackColor = false;
            this.button_History.Click += new System.EventHandler(this.button_DB_Click);
            // 
            // userControl_Chart1
            // 
            this.userControl_Chart1.BackColor = System.Drawing.Color.White;
            this.userControl_Chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_Chart1.Location = new System.Drawing.Point(0, 0);
            this.userControl_Chart1.Name = "userControl_Chart1";
            this.userControl_Chart1.Size = new System.Drawing.Size(768, 404);
            this.userControl_Chart1.TabIndex = 19;
            // 
            // UserControl_DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_Style2);
            this.Controls.Add(this.panel_style1);
            this.Controls.Add(this.button_ExportInv);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_Chart);
            this.Controls.Add(this.button_History);
            this.Controls.Add(this.Border);
            this.Name = "UserControl_DashBoard";
            this.Size = new System.Drawing.Size(814, 495);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridInv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Border;
        private System.Windows.Forms.Button button_History;
        private System.Windows.Forms.Button button_Chart;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroGrid GridInv;
        private System.Windows.Forms.Button button_ExportInv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
        private System.Windows.Forms.Panel panel_Style2;
        private System.Windows.Forms.Panel panel_style1;
        private UserControl_Chart userControl_Chart1;
    }
}
