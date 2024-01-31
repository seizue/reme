namespace reme
{
    partial class Receipt
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroTile_PrintReceipt = new MetroFramework.Controls.MetroTile();
            this.GridPrintReceipt = new MetroFramework.Controls.MetroGrid();
            this.ORDER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_ReceiptDate = new System.Windows.Forms.TextBox();
            this.textBox_ReceiptName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EnterNewItem_label = new System.Windows.Forms.Label();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_Print = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox_T = new System.Windows.Forms.TextBox();
            this.textBox_PrintTotalAmount = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.GridPrintReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel_Print.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTile_PrintReceipt
            // 
            this.metroTile_PrintReceipt.ActiveControl = null;
            this.metroTile_PrintReceipt.Location = new System.Drawing.Point(0, 493);
            this.metroTile_PrintReceipt.Name = "metroTile_PrintReceipt";
            this.metroTile_PrintReceipt.Size = new System.Drawing.Size(331, 63);
            this.metroTile_PrintReceipt.TabIndex = 215;
            this.metroTile_PrintReceipt.Text = "PRINT RECEIPT";
            this.metroTile_PrintReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile_PrintReceipt.UseSelectable = true;
            this.metroTile_PrintReceipt.Click += new System.EventHandler(this.metroTile_PrintReceipt_Click);
            // 
            // GridPrintReceipt
            // 
            this.GridPrintReceipt.AllowUserToResizeColumns = false;
            this.GridPrintReceipt.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            this.GridPrintReceipt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.GridPrintReceipt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridPrintReceipt.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.GridPrintReceipt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridPrintReceipt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridPrintReceipt.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.GridPrintReceipt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridPrintReceipt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.GridPrintReceipt.ColumnHeadersHeight = 37;
            this.GridPrintReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridPrintReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ORDER,
            this.QUANTITY,
            this.PRICE});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 10F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridPrintReceipt.DefaultCellStyle = dataGridViewCellStyle13;
            this.GridPrintReceipt.EnableHeadersVisualStyles = false;
            this.GridPrintReceipt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.GridPrintReceipt.GridColor = System.Drawing.Color.Silver;
            this.GridPrintReceipt.HighLightPercentage = 100F;
            this.GridPrintReceipt.Location = new System.Drawing.Point(8, 8);
            this.GridPrintReceipt.MultiSelect = false;
            this.GridPrintReceipt.Name = "GridPrintReceipt";
            this.GridPrintReceipt.ReadOnly = true;
            this.GridPrintReceipt.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridPrintReceipt.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.GridPrintReceipt.RowHeadersVisible = false;
            this.GridPrintReceipt.RowHeadersWidth = 45;
            this.GridPrintReceipt.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            this.GridPrintReceipt.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.GridPrintReceipt.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.GridPrintReceipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridPrintReceipt.Size = new System.Drawing.Size(285, 140);
            this.GridPrintReceipt.TabIndex = 16;
            this.GridPrintReceipt.UseCustomBackColor = true;
            this.GridPrintReceipt.UseCustomForeColor = true;
            this.GridPrintReceipt.UseStyleColors = true;
            // 
            // ORDER
            // 
            this.ORDER.HeaderText = "ORDER";
            this.ORDER.Name = "ORDER";
            this.ORDER.ReadOnly = true;
            // 
            // QUANTITY
            // 
            this.QUANTITY.HeaderText = "QUANTITY";
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.ReadOnly = true;
            // 
            // PRICE
            // 
            this.PRICE.HeaderText = "PRICE";
            this.PRICE.Name = "PRICE";
            this.PRICE.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel3.Location = new System.Drawing.Point(16, 157);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 3);
            this.panel3.TabIndex = 233;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(25, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 13);
            this.label5.TabIndex = 232;
            this.label5.Text = "Just scan the QR code below! ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::reme.Properties.Resources.four_squares_48px;
            this.pictureBox1.Location = new System.Drawing.Point(246, 381);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 231;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(25, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 13);
            this.label4.TabIndex = 230;
            this.label4.Text = "You can also pay your order using QR code";
            // 
            // textBox_ReceiptDate
            // 
            this.textBox_ReceiptDate.BackColor = System.Drawing.Color.White;
            this.textBox_ReceiptDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_ReceiptDate.Font = new System.Drawing.Font("Tahoma", 8F);
            this.textBox_ReceiptDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_ReceiptDate.Location = new System.Drawing.Point(98, 130);
            this.textBox_ReceiptDate.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.textBox_ReceiptDate.Name = "textBox_ReceiptDate";
            this.textBox_ReceiptDate.ReadOnly = true;
            this.textBox_ReceiptDate.Size = new System.Drawing.Size(187, 13);
            this.textBox_ReceiptDate.TabIndex = 229;
            this.textBox_ReceiptDate.Text = "SAMPLE";
            // 
            // textBox_ReceiptName
            // 
            this.textBox_ReceiptName.AcceptsReturn = true;
            this.textBox_ReceiptName.BackColor = System.Drawing.Color.White;
            this.textBox_ReceiptName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_ReceiptName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.textBox_ReceiptName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_ReceiptName.Location = new System.Drawing.Point(98, 109);
            this.textBox_ReceiptName.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.textBox_ReceiptName.Name = "textBox_ReceiptName";
            this.textBox_ReceiptName.ReadOnly = true;
            this.textBox_ReceiptName.Size = new System.Drawing.Size(187, 13);
            this.textBox_ReceiptName.TabIndex = 228;
            this.textBox_ReceiptName.Text = "SAMPLE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 8.75F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(40, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 14);
            this.label3.TabIndex = 227;
            this.label3.Text = "DATE :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.75F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(40, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 14);
            this.label2.TabIndex = 226;
            this.label2.Text = "NAME :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label1.Location = new System.Drawing.Point(20, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 225;
            this.label1.Text = "ORDER RECEIPT";
            // 
            // EnterNewItem_label
            // 
            this.EnterNewItem_label.AutoSize = true;
            this.EnterNewItem_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterNewItem_label.ForeColor = System.Drawing.Color.Black;
            this.EnterNewItem_label.Location = new System.Drawing.Point(219, 27);
            this.EnterNewItem_label.Name = "EnterNewItem_label";
            this.EnterNewItem_label.Size = new System.Drawing.Size(88, 16);
            this.EnterNewItem_label.TabIndex = 222;
            this.EnterNewItem_label.Text = "THANK YOU!\r\n";
            // 
            // PicLogo
            // 
            this.PicLogo.Image = global::reme.Properties.Resources.four_squares_48px;
            this.PicLogo.Location = new System.Drawing.Point(25, 3);
            this.PicLogo.Name = "PicLogo";
            this.PicLogo.Size = new System.Drawing.Size(48, 48);
            this.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicLogo.TabIndex = 221;
            this.PicLogo.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel2.Controls.Add(this.GridPrintReceipt);
            this.panel2.Location = new System.Drawing.Point(15, 166);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(301, 156);
            this.panel2.TabIndex = 219;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Location = new System.Drawing.Point(16, 372);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 3);
            this.panel1.TabIndex = 218;
            // 
            // panel_Print
            // 
            this.panel_Print.BackColor = System.Drawing.Color.White;
            this.panel_Print.Controls.Add(this.panel5);
            this.panel_Print.Controls.Add(this.panel4);
            this.panel_Print.Controls.Add(this.panel3);
            this.panel_Print.Controls.Add(this.PicLogo);
            this.panel_Print.Controls.Add(this.label5);
            this.panel_Print.Controls.Add(this.panel1);
            this.panel_Print.Controls.Add(this.pictureBox1);
            this.panel_Print.Controls.Add(this.panel2);
            this.panel_Print.Controls.Add(this.label4);
            this.panel_Print.Controls.Add(this.textBox_ReceiptDate);
            this.panel_Print.Controls.Add(this.EnterNewItem_label);
            this.panel_Print.Controls.Add(this.textBox_ReceiptName);
            this.panel_Print.Controls.Add(this.label3);
            this.panel_Print.Controls.Add(this.label2);
            this.panel_Print.Controls.Add(this.label1);
            this.panel_Print.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel_Print.Location = new System.Drawing.Point(0, 28);
            this.panel_Print.Name = "panel_Print";
            this.panel_Print.Size = new System.Drawing.Size(331, 457);
            this.panel_Print.TabIndex = 217;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel4.Location = new System.Drawing.Point(16, 67);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 3);
            this.panel4.TabIndex = 234;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.textBox_T);
            this.panel5.Controls.Add(this.textBox_PrintTotalAmount);
            this.panel5.Location = new System.Drawing.Point(15, 328);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(301, 38);
            this.panel5.TabIndex = 238;
            // 
            // textBox_T
            // 
            this.textBox_T.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.textBox_T.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_T.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_T.ForeColor = System.Drawing.Color.Black;
            this.textBox_T.Location = new System.Drawing.Point(21, 11);
            this.textBox_T.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.textBox_T.Multiline = true;
            this.textBox_T.Name = "textBox_T";
            this.textBox_T.ReadOnly = true;
            this.textBox_T.Size = new System.Drawing.Size(104, 20);
            this.textBox_T.TabIndex = 239;
            this.textBox_T.Text = "Total Amount";
            this.textBox_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_PrintTotalAmount
            // 
            this.textBox_PrintTotalAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.textBox_PrintTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_PrintTotalAmount.Font = new System.Drawing.Font("Sylfaen", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_PrintTotalAmount.ForeColor = System.Drawing.Color.Black;
            this.textBox_PrintTotalAmount.Location = new System.Drawing.Point(220, 7);
            this.textBox_PrintTotalAmount.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.textBox_PrintTotalAmount.Multiline = true;
            this.textBox_PrintTotalAmount.Name = "textBox_PrintTotalAmount";
            this.textBox_PrintTotalAmount.ReadOnly = true;
            this.textBox_PrintTotalAmount.Size = new System.Drawing.Size(59, 20);
            this.textBox_PrintTotalAmount.TabIndex = 238;
            this.textBox_PrintTotalAmount.Text = "0000";
            this.textBox_PrintTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.panel8.Location = new System.Drawing.Point(193, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(2, 35);
            this.panel8.TabIndex = 240;
            // 
            // Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 556);
            this.Controls.Add(this.panel_Print);
            this.Controls.Add(this.metroTile_PrintReceipt);
            this.MaximizeBox = false;
            this.Name = "Receipt";
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Right;
            ((System.ComponentModel.ISupportInitialize)(this.GridPrintReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel_Print.ResumeLayout(false);
            this.panel_Print.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTile metroTile_PrintReceipt;
        private MetroFramework.Controls.MetroGrid GridPrintReceipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_ReceiptDate;
        private System.Windows.Forms.TextBox textBox_ReceiptName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label EnterNewItem_label;
        private System.Windows.Forms.PictureBox PicLogo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_Print;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox textBox_T;
        private System.Windows.Forms.TextBox textBox_PrintTotalAmount;
    }
}