namespace VizientImport
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnQuit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.dGrid = new System.Windows.Forms.DataGridView();
            this.ActionCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MfgItemNmbr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyerItemNmbr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DistribItemNmbr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Itemdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOMQty1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOMDesc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GTIN1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOMQty2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOMDesc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GTIN2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOMQty3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOMDesc3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GTIN3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOMQty4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOMDesc4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GTIN4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PricingGTIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemEffectiveDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MfgPrice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AltPrice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendCatNmbr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefaultExpenseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Consigned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.MistyRose;
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Location = new System.Drawing.Point(28, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(93, 41);
            this.btnQuit.TabIndex = 13;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Location = new System.Drawing.Point(1266, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(137, 48);
            this.panel1.TabIndex = 2;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNew.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(11, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(93, 41);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dGrid
            // 
            this.dGrid.AllowDrop = true;
            this.dGrid.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.OldLace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ActionCode,
            this.MfgItemNmbr,
            this.BuyerItemNmbr,
            this.DistribItemNmbr,
            this.Itemdesc,
            this.UOMQty1,
            this.UOMDesc1,
            this.GTIN1,
            this.UOMQty2,
            this.UOMDesc2,
            this.GTIN2,
            this.UOMQty3,
            this.UOMDesc3,
            this.GTIN3,
            this.UOMQty4,
            this.UOMDesc4,
            this.GTIN4,
            this.PriceUOM,
            this.PricingGTIN,
            this.ItemEffectiveDate,
            this.ItemExpirationDate,
            this.MfgPrice1,
            this.AltPrice1,
            this.VendorName,
            this.VendorCode,
            this.VendorSequence,
            this.VendCatNmbr,
            this.DefaultExpenseCode,
            this.Consigned});
            this.dGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.dGrid.Location = new System.Drawing.Point(-12, 65);
            this.dGrid.Name = "dGrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dGrid.RowHeadersWidth = 60;
            this.dGrid.RowTemplate.Height = 24;
            this.dGrid.Size = new System.Drawing.Size(1412, 588);
            this.dGrid.TabIndex = 3;
            this.dGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGrid_CellEnter);
            this.dGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dGrid_CellMouseClick);
            this.dGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dGrid_RowsRemoved);
            // 
            // ActionCode
            // 
            this.ActionCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionCode.DefaultCellStyle = dataGridViewCellStyle3;
            this.ActionCode.FillWeight = 115.9776F;
            this.ActionCode.HeaderText = "Action Code (A,C,D or R)";
            this.ActionCode.Name = "ActionCode";
            this.ActionCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ActionCode.Width = 148;
            // 
            // MfgItemNmbr
            // 
            this.MfgItemNmbr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MfgItemNmbr.FillWeight = 220.8122F;
            this.MfgItemNmbr.HeaderText = "Mfg Item Nmbr";
            this.MfgItemNmbr.MinimumWidth = 10;
            this.MfgItemNmbr.Name = "MfgItemNmbr";
            this.MfgItemNmbr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MfgItemNmbr.Width = 120;
            // 
            // BuyerItemNmbr
            // 
            this.BuyerItemNmbr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.BuyerItemNmbr.FillWeight = 94.93371F;
            this.BuyerItemNmbr.HeaderText = "Buyer Item Nmbr";
            this.BuyerItemNmbr.Name = "BuyerItemNmbr";
            this.BuyerItemNmbr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BuyerItemNmbr.Width = 136;
            // 
            // DistribItemNmbr
            // 
            this.DistribItemNmbr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DistribItemNmbr.FillWeight = 94.93371F;
            this.DistribItemNmbr.HeaderText = "Distrib Item Nmbr";
            this.DistribItemNmbr.Name = "DistribItemNmbr";
            this.DistribItemNmbr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DistribItemNmbr.Width = 102;
            // 
            // Itemdesc
            // 
            this.Itemdesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Itemdesc.FillWeight = 94.93371F;
            this.Itemdesc.HeaderText = "Item Desc";
            this.Itemdesc.Name = "Itemdesc";
            this.Itemdesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Itemdesc.Width = 83;
            // 
            // UOMQty1
            // 
            this.UOMQty1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.UOMQty1.FillWeight = 94.93371F;
            this.UOMQty1.HeaderText = "UOM Qty 1";
            this.UOMQty1.Name = "UOMQty1";
            this.UOMQty1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UOMQty1.Width = 78;
            // 
            // UOMDesc1
            // 
            this.UOMDesc1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.UOMDesc1.FillWeight = 94.93371F;
            this.UOMDesc1.HeaderText = "UOM Desc 1";
            this.UOMDesc1.Name = "UOMDesc1";
            this.UOMDesc1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UOMDesc1.Width = 84;
            // 
            // GTIN1
            // 
            this.GTIN1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.GTIN1.FillWeight = 94.93371F;
            this.GTIN1.HeaderText = "GTIN1";
            this.GTIN1.Name = "GTIN1";
            this.GTIN1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GTIN1.Width = 64;
            // 
            // UOMQty2
            // 
            this.UOMQty2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.UOMQty2.FillWeight = 94.93371F;
            this.UOMQty2.HeaderText = "UOM Qty 2";
            this.UOMQty2.Name = "UOMQty2";
            this.UOMQty2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UOMQty2.Width = 78;
            // 
            // UOMDesc2
            // 
            this.UOMDesc2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.UOMDesc2.FillWeight = 94.93371F;
            this.UOMDesc2.HeaderText = "UOM Desc 2";
            this.UOMDesc2.Name = "UOMDesc2";
            this.UOMDesc2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UOMDesc2.Width = 84;
            // 
            // GTIN2
            // 
            this.GTIN2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.GTIN2.FillWeight = 94.93371F;
            this.GTIN2.HeaderText = "GTIN2";
            this.GTIN2.Name = "GTIN2";
            this.GTIN2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GTIN2.Width = 64;
            // 
            // UOMQty3
            // 
            this.UOMQty3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.UOMQty3.FillWeight = 94.93371F;
            this.UOMQty3.HeaderText = "UOM Qty 3";
            this.UOMQty3.Name = "UOMQty3";
            this.UOMQty3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UOMQty3.Width = 78;
            // 
            // UOMDesc3
            // 
            this.UOMDesc3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.UOMDesc3.FillWeight = 94.93371F;
            this.UOMDesc3.HeaderText = "UOM Desc 3";
            this.UOMDesc3.Name = "UOMDesc3";
            this.UOMDesc3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UOMDesc3.Width = 84;
            // 
            // GTIN3
            // 
            this.GTIN3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.GTIN3.FillWeight = 94.93371F;
            this.GTIN3.HeaderText = "GTIN3";
            this.GTIN3.Name = "GTIN3";
            this.GTIN3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GTIN3.Width = 64;
            // 
            // UOMQty4
            // 
            this.UOMQty4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.UOMQty4.FillWeight = 94.93371F;
            this.UOMQty4.HeaderText = "UOM Qty 4";
            this.UOMQty4.Name = "UOMQty4";
            this.UOMQty4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UOMQty4.Width = 78;
            // 
            // UOMDesc4
            // 
            this.UOMDesc4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.UOMDesc4.FillWeight = 94.93371F;
            this.UOMDesc4.HeaderText = "UOM Desc 4";
            this.UOMDesc4.Name = "UOMDesc4";
            this.UOMDesc4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UOMDesc4.Width = 84;
            // 
            // GTIN4
            // 
            this.GTIN4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.GTIN4.FillWeight = 94.93371F;
            this.GTIN4.HeaderText = "GTIN4";
            this.GTIN4.Name = "GTIN4";
            this.GTIN4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GTIN4.Width = 64;
            // 
            // PriceUOM
            // 
            this.PriceUOM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PriceUOM.FillWeight = 94.93371F;
            this.PriceUOM.HeaderText = "Pricing UOM";
            this.PriceUOM.Name = "PriceUOM";
            this.PriceUOM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PricingGTIN
            // 
            this.PricingGTIN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PricingGTIN.FillWeight = 94.93371F;
            this.PricingGTIN.HeaderText = "Pricing GTIN";
            this.PricingGTIN.Name = "PricingGTIN";
            this.PricingGTIN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PricingGTIN.Width = 102;
            // 
            // ItemEffectiveDate
            // 
            this.ItemEffectiveDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ItemEffectiveDate.FillWeight = 94.93371F;
            this.ItemEffectiveDate.HeaderText = "Item Effective Date";
            this.ItemEffectiveDate.Name = "ItemEffectiveDate";
            this.ItemEffectiveDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ItemEffectiveDate.Width = 147;
            // 
            // ItemExpirationDate
            // 
            this.ItemExpirationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ItemExpirationDate.FillWeight = 94.93371F;
            this.ItemExpirationDate.HeaderText = "Item Expiration Date";
            this.ItemExpirationDate.Name = "ItemExpirationDate";
            this.ItemExpirationDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ItemExpirationDate.Width = 159;
            // 
            // MfgPrice1
            // 
            this.MfgPrice1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MfgPrice1.FillWeight = 94.93371F;
            this.MfgPrice1.HeaderText = "Mfg Price 1";
            this.MfgPrice1.Name = "MfgPrice1";
            this.MfgPrice1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MfgPrice1.Width = 83;
            // 
            // AltPrice1
            // 
            this.AltPrice1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AltPrice1.FillWeight = 94.93371F;
            this.AltPrice1.HeaderText = "Alt Price 1";
            this.AltPrice1.Name = "AltPrice1";
            this.AltPrice1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AltPrice1.Width = 77;
            // 
            // VendorName
            // 
            this.VendorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.VendorName.FillWeight = 94.93371F;
            this.VendorName.HeaderText = "Vendor Name";
            this.VendorName.Name = "VendorName";
            this.VendorName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VendorName.Width = 109;
            // 
            // VendorCode
            // 
            this.VendorCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.VendorCode.FillWeight = 94.93371F;
            this.VendorCode.HeaderText = "Vendor Code";
            this.VendorCode.Name = "VendorCode";
            this.VendorCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VendorCode.Width = 104;
            // 
            // VendorSequence
            // 
            this.VendorSequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.VendorSequence.FillWeight = 94.93371F;
            this.VendorSequence.HeaderText = "Vendor Sequence";
            this.VendorSequence.Name = "VendorSequence";
            this.VendorSequence.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VendorSequence.Width = 135;
            // 
            // VendCatNmbr
            // 
            this.VendCatNmbr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.VendCatNmbr.FillWeight = 94.93371F;
            this.VendCatNmbr.HeaderText = "Vendor Catalog Number";
            this.VendCatNmbr.Name = "VendCatNmbr";
            this.VendCatNmbr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VendCatNmbr.Width = 182;
            // 
            // DefaultExpenseCode
            // 
            this.DefaultExpenseCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DefaultExpenseCode.FillWeight = 94.93371F;
            this.DefaultExpenseCode.HeaderText = "Default Expense Code";
            this.DefaultExpenseCode.Name = "DefaultExpenseCode";
            this.DefaultExpenseCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DefaultExpenseCode.Width = 131;
            // 
            // Consigned
            // 
            this.Consigned.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Consigned.FillWeight = 94.93371F;
            this.Consigned.HeaderText = "Consigned";
            this.Consigned.Name = "Consigned";
            this.Consigned.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Consigned.Width = 96;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnRestore);
            this.panel2.Location = new System.Drawing.Point(766, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(472, 48);
            this.panel2.TabIndex = 3;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Honeydew;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(330, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(134, 41);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Create Vizient \r\n   Import File";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(218, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 41);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.Location = new System.Drawing.Point(115, 4);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(93, 41);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "Open...";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Honeydew;
            this.btnImport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImport.Location = new System.Drawing.Point(538, 8);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(93, 26);
            this.btnImport.TabIndex = 42;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Visible = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 650);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dGrid);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Vizient & HEMM Import Files";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MfgItemNmbr;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyerItemNmbr;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistribItemNmbr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Itemdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOMQty1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOMDesc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GTIN1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOMQty2;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOMDesc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn GTIN2;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOMQty3;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOMDesc3;
        private System.Windows.Forms.DataGridViewTextBoxColumn GTIN3;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOMQty4;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOMDesc4;
        private System.Windows.Forms.DataGridViewTextBoxColumn GTIN4;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn PricingGTIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemEffectiveDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemExpirationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MfgPrice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AltPrice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorSequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendCatNmbr;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefaultExpenseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Consigned;
    }
}

