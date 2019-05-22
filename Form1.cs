using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DTUtilities;
using LogDefault;
using SpreadsheetLight;
using System.Configuration;

namespace VizientImport
{
    public partial class Form1 : Form
    {

        private BindingSource bs = new BindingSource();
        private DataTable dTable = new DataTable();
        private Hashtable viz_ColName = new Hashtable();
        private Hashtable hemm_ColName = new Hashtable();
        private ArrayList required = new ArrayList();
        private const int MAXCOLS = 29;
        private int defaultRowCount = 5000;
        private char TAB = '\t';                    //Convert.ToChar(9);
        private string colNames = "";
        private string listAsString = "";
        private string currentFileName = "";
        private string currentPath = "";
        private string backupPath = "";
        private OpenFileDialog openFileDlog;
        private SaveFileDialog saveFileDlog;
        private static NameValueCollection ConfigData = null;
        DateTimeUtilities dtu = new DateTimeUtilities();
        private LogManager lm = LogManager.GetInstance();
        private bool changed = false;
        private bool trace = false;
        private int enteredRowCount = 0;

        public Form1()
        {
            if (trace)
                lm.Write("Form1.Constructor");
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            InitGrid();
            AddGridRows(1);
        }

        private void InitGrid()
        {
            if (trace)
                lm.Write("Form1.InitGrid");
            ConfigData = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
            AddGridRows(defaultRowCount);
            CreateColHeaders();
            lm.LogFilePath = ConfigData.Get("logFilePath");
            lm.LogFile = ConfigData.Get("logFileName");
            currentPath = ConfigData.Get("default_path");
            backupPath = ConfigData.Get("backup_path");
            trace = System.Convert.ToBoolean(ConfigData.Get("trace"));
        }


        /// <AddGridRows>
        /// Called from the form constructor, btnReset_Click() and btnAddRow_Click()
        /// </AddGridRows>
        /// <param name="rowCount"></param>
        private void AddGridRows(int rowCount)
        {
            if (trace)
                lm.Write("Form1.AddGridRows");
            dGrid.Rows.Add(rowCount);
            for (int x = 0; x < rowCount; x++)
            {
                // dGrid.Rows[x].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dGrid.Rows[x].HeaderCell.Value = (x + 1).ToString();
                foreach (DataGridViewCell cell in dGrid.Rows[x].Cells)
                {
                    cell.Value = "";
                }
            }
        }
        private void CreateGridViewCols()
        {
            if (trace)
                lm.Write("Form1.CreateGridViewCols");
            dGrid.Columns.Add((new DataGridViewColumn()).Name = "Action Code", "Action Code (A,C,D or R)");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "Manufacturer Item Number", "Manufacturer Item Number");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "Buyer Item Number", "Buyer Item Number");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "Distributor Item Number", "Distributor Item Number");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "UOM QTY1", "UOM QTY1");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "UOM Desc 1", "UOM Desc 1");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "GTIN 1", "GTIN 1");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "UOM QTY 2", "UOM QTY 2");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "UOM Desc 2", "UOM Desc 2");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "GTIN 2", "GTIN 2");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "UOM QTY 3", "UOM QTY 3");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "UOM Desc 3", "UOM Desc 3");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "GTIN 3", "GTIN 3");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "UOM QTY 4", "UOM QTY 4");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "UOM Desc 4", "UOM Desc 4");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "GTIN 4", "GTIN 4");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "Pricing UOM", "Pricing UOM");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "Pricing GTIN", "Pricing GTIN");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "Item Effective Date", "Item Effective Date");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "Item Expiration Date", "Item Expiration Date");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "Manu Price 1", "Manu Price 1");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "Alt Price 1 ", "Alt Price 1 (net distributor or indirect price)");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "Vendor Name", "Vendor Name");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "Vendor Code", "Vendor Code");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "Vendor Sequence", "Vendor Sequence");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "Vendor Cat No", "Vendor Catalog Number");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "Default Expense Code", "Default Expense Code");

            dGrid.Columns.Add((new DataGridViewColumn()).Name = "Consigned", "Consigned");
        }

        private void CreateColHeaders()
        {
            if (trace)
                lm.Write("Form1.CreateColHeaders");
            #region colHeaders
            //load the column name hashtable and build the colNames string
            int colNo = 0;
            hemm_ColName.Add(colNo, "Item Number");
            viz_ColName.Add(colNo, "Action Code (A,C,D or R)");
            colNames = viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Mfr Catalog Number");
            viz_ColName.Add(colNo, "Manufacturer Item Number");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Manufacturer Code");
            viz_ColName.Add(colNo, "Buyer Item Number");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Manufacturer Name (as the name appears in HEMM)");
            viz_ColName.Add(colNo, "Distributor Item Number");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Item Description");
            viz_ColName.Add(colNo, "Item Description");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Commodity/UNSPSC Code");
            viz_ColName.Add(colNo, "UOM QTY1");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Vendor Name");
            viz_ColName.Add(colNo, "UOM Desc 1");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Vendor Code");
            viz_ColName.Add(colNo, "GTIN 1");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Vendor Sequence");
            viz_ColName.Add(colNo, "UOM QTY 2");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Vendor Catalog Number");
            viz_ColName.Add(colNo, "UOM Desc 2");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Default Unit of Measure");
            viz_ColName.Add(colNo, "GTIN 2");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Package Sequence");
            viz_ColName.Add(colNo, "UOM QTY 3");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Unit of Measure");
            viz_ColName.Add(colNo, "UOM Desc 3");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Package Price");
            viz_ColName.Add(colNo, "GTIN 3");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Unit of Measure Quantity");
            viz_ColName.Add(colNo, "UOM QTY 4");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Unit of Measure Contains What Unit of Measure");
            viz_ColName.Add(colNo, "UOM Desc 4");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Default Expense Code");
            viz_ColName.Add(colNo, "GTIN 4");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Consigned");
            viz_ColName.Add(colNo, "Pricing UOM");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Corporation Account Number");
            viz_ColName.Add(colNo, "Pricing GTIN");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Additional CC (if going into an INV loc)");
            viz_ColName.Add(colNo, "Item Effective Date");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Additional GL (if going into an INV loc)");
            viz_ColName.Add(colNo, "Item Expiration Date");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Tax Jurisdiction (TAX or EXEMPT)");
            viz_ColName.Add(colNo, "Manu Price 1");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "MISC1");
            viz_ColName.Add(colNo, "Alt Price 1 (net distributor or indirect price)");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "MISC4 (if there's an IIDC Code)");
            viz_ColName.Add(colNo, "Vendor Name");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Supply Type");
            viz_ColName.Add(colNo, "Vendor Code");
            colNames += TAB + viz_ColName[colNo++].ToString();

            hemm_ColName.Add(colNo, "Interface Code");
            viz_ColName.Add(colNo, "Vendor Sequence");
            colNames += TAB + viz_ColName[colNo++].ToString();

            viz_ColName.Add(colNo, "Vendor Catalog Number");
            colNames += TAB + viz_ColName[colNo++].ToString();

            viz_ColName.Add(colNo, "Default Expense Code");
            colNames += TAB + viz_ColName[colNo++].ToString();

            viz_ColName.Add(colNo, "Consigned");
            colNames += TAB + viz_ColName[colNo].ToString();

            colNames += "||";
            #endregion
        }

        private void WriteColsHeaders()
        {
            if (trace)
                lm.Write("Form1.WriteColHeaders");
            File.AppendAllText(currentPath + currentFileName, colNames);  //CHANGE: WriteAllText      + ".csv"
        }

        private bool ParseItemList()
        {
            bool goodToGo = false;
            int colNo = 0;
            int rowNo = 0;
            //int colCount = 2;
            string cellValu = "";
            string qtu = "";
            string cellValue = "";
            string requiredCheck = "";
            DataGridViewRow row = null;
            if (trace)
                lm.Write("Form1.ParseItemList");
            if (dGrid.Rows.Count > 0)
            {
                if (dGrid.Columns.Count > 0)
                {
                    try
                    {
                        //foreach (DataGridViewRow row in dGrid.Rows)
                        for (; rowNo <= enteredRowCount + 1; rowNo++)      //CHANGE: 
                        {
                            row = dGrid.Rows[rowNo];
                            colNo = 0;
                            foreach (DataGridViewCell cell in row.Cells)
                            {                                
                                if (cell.Value != null)
                                {
                                    cellValue = cell.Value.ToString();

                                    if (++colNo <= MAXCOLS)
                                    {
                                        cellValue = VerifyUserInput(colNo, cellValue);
                                        if (colNo == 1 && cellValue.Trim() == "")
                                            break;
                                        cellValu = cellValue.Trim();
                                        if (colNo == 1)
                                            listAsString += cellValu;
                                        else
                                            listAsString += TAB + cellValu;
                                    }
                                }
                                else
                                {
                                    ////////////////////CheckRequiredField(rowNo, colNo);
                                    listAsString += ("." + TAB);
                                    colNo++;
                                }
                                //    if (colNo == MAXCOLS)
                                //{
                                //    listAsString += Environment.NewLine;
                                //}
                            }
                            listAsString += "||";
                            if (rowNo > enteredRowCount)
                                break;
                            //rowNo++;
                        }
                        //////////if(required.Count > 0)
                        //////////{
                        //////////    requiredCheck = "";
                        //////////    foreach (string r in required)
                        //////////    {
                        //////////        if(r.Length > 0)
                        //////////            requiredCheck += r + Environment.NewLine;
                        //////////    }
                        //////////    MessageBox.Show("These values are required:" + Environment.NewLine + requiredCheck, "Required Values Missing", MessageBoxButtons.OK);
                        //////////    required.Clear();
                        //////////}
                        //////////else 
                        //////////{
                        if (listAsString.Length > 0)
                        {
                            //listAsString = listAsString.Substring(0, listAsString.Length - 1); //remove the trailing comma
                            goodToGo = true;
                        }
                        //////////}
                    }
                    catch (Exception ex)
                    {
                        lm.Write("ParseItemList: " + ex.Message);

                    }
                }
            }
            return goodToGo;
        }

        private void CheckRequiredField(int rowNo, int colNo)
        {
            string reqdValue = "";
            if (trace)
                lm.Write("Form1.CheckRequiredField");
            switch (colNo)
            {
                case 0:
                    reqdValue = "Row " + ++rowNo + "  " + viz_ColName[colNo];
                    break;
                case 1:
                    reqdValue = "Row " + ++rowNo + "  " + viz_ColName[colNo];
                    break;
                case 4:
                    reqdValue = "Row " + ++rowNo + "  " + viz_ColName[colNo];
                    break;
                case 5:
                    reqdValue = "Row " + ++rowNo + "  " + viz_ColName[colNo];
                    break;
                case 6:
                    reqdValue = "Row " + ++rowNo + "  " + viz_ColName[colNo];
                    break;
                case 17:
                    reqdValue = "Row " + ++rowNo + "  " + viz_ColName[colNo];
                    break;
                case 19:
                    reqdValue = "Row " + ++rowNo + "  " + viz_ColName[colNo];
                    break;
                case 21:
                    reqdValue = "Row " + ++rowNo + "  " + viz_ColName[colNo];
                    break;
                case 23:
                    reqdValue = "Row " + ++rowNo + "  " + viz_ColName[colNo];
                    break;
                case 24:
                    reqdValue = "Row " + ++rowNo + "  " + viz_ColName[colNo];
                    break;
                case 25:
                    reqdValue = "Row " + ++rowNo + "  " + viz_ColName[colNo];
                    break;
                case 26:
                    reqdValue = "Row " + ++rowNo + "  " + viz_ColName[colNo];
                    break;
                case 27:
                    reqdValue = "Row " + ++rowNo + "  " + viz_ColName[colNo];
                    break;
                case 28:
                    reqdValue = "Row " + ++rowNo + "  " + viz_ColName[colNo];
                    break;
                case 29:
                    reqdValue = "Row " + ++rowNo + "  " + viz_ColName[colNo];
                    break;
            }

            required.Add(reqdValue);
        }

        private void RestoreGrid(string fileContents)
        {
            //this is used when opening a *.csv file --see ImportToGrid for Excel 
            if (trace)
                lm.Write("Form1.RestoreGrid");
            string[] savedData = fileContents.Split("||".ToCharArray());
            string[] rowData = new string[savedData.Length];
            string[] colData;
            string thisRow = "";
            int colNo = 0;
            int rowNo = 1;   //row[0] is the col header row
            bool endLoop = false;
            int colCount = 0;
            DataGridViewRow row = null;
            try
            {
                for (int x = 0, indx = 0; x < savedData.Length; x++)
                {
                    if (savedData[x].Equals(""))
                    {
                        continue;
                    }
                    else
                        rowData[indx++] = savedData[x];
                }
                AddGridRows(defaultRowCount);
                //foreach (DataGridViewRow row in dGrid.Rows) 
                for (; rowNo < rowData.Length; rowNo++)
                {
                    row = dGrid.Rows[rowNo - 1];
                    if (rowData[rowNo] != null)
                    {
                        thisRow = rowData[rowNo];

                        colData = thisRow.Trim().Split(TAB);
                        colCount = colData.Length;
                        if (!(colData[0].Trim().Length == 0 && colCount == 1))
                        {
                            for (colNo = 0; colNo < colCount; colNo++)
                            {
                                row.Cells[colNo].Value = colData[colNo];
                            }
                        }
                    }
                    //rowNo = 0;  
                }
                //upperRowLimit = rowNo;
                changed = true;
                enteredRowCount = CountRows();
            }
            catch (Exception ex)
            {
                lm.Write("RestoreGrid: " + ex.Message);
            }
        }

        private void CheckChanged()
        {
            if (trace)
                lm.Write("Form1.CheckChanged");
            if (changed)
            {
                DialogResult dLogRslt = MessageBox.Show("Do you want to save any changes you made?", "Save", MessageBoxButtons.YesNoCancel);
                if (dLogRslt == DialogResult.Yes)
                    btnSave_Click(new object(), new EventArgs());
                changed = false;
            }
        }

        private void dGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //int row = e.RowIndex;
            //if (upperRowLimit < row)
            //    upperRowLimit = row;
            if (trace)
                lm.Write("Form1.dGrid_CellMouseClick");
            changed = true;
        }

        private void dGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ////////int row = e.RowIndex;
            ////////if (upperRowLimit < row)
            ////////    upperRowLimit = row;

        }

        private void SetColHeaders(SLDocument sldVizImport)
        { //this is called from btnExport_Click
            if (trace)
                lm.Write("Form1.SetColHeaders");
            int row = 1;
            try
            {
                sldVizImport.SelectWorksheet("VizientImport");
                for (int col = 0; col < viz_ColName.Count; col++)
                {
                    sldVizImport.SetCellValue(row, col + 1, viz_ColName[col].ToString());
                }
                sldVizImport.SelectWorksheet("HEMMImport");
                for (int col = 0; col < hemm_ColName.Count; col++)
                {
                    sldVizImport.SetCellValue(row, col + 1, hemm_ColName[col].ToString());
                }
            }
            catch (Exception ex)
            {
                lm.Write("SetColHeaders " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (trace)
                lm.Write("Form1.btnSave_Click");
            string[] pathInfo;
            saveFileDlog = new SaveFileDialog();
            saveFileDlog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDlog.FilterIndex = 1;
            saveFileDlog.RestoreDirectory = true;
            saveFileDlog.FileName = "VIZIENT_IMPORT_";

            if (saveFileDlog.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                enteredRowCount = CountRows();               
                pathInfo = saveFileDlog.FileName.Split(@"\".ToCharArray());
                currentPath = "";
                currentFileName = pathInfo[pathInfo.Length - 1];
                for (int x = 0; x < pathInfo.Length - 1; x++)
                    currentPath += pathInfo[x] + @"\";
                int rowCount = enteredRowCount;
                if (changed)
                {
                    try
                    {
                        if (ParseItemList())
                        {
                            if (listAsString.Length > 0)
                            {
                                if (currentFileName.Length == 0)
                                {   //shouldn't ever get here, but just in case...
                                    currentFileName = "VIZIENT_IMPORT_" + dtu.DateTimeCoded() + ".csv";                                   
                                }
                                else if(File.Exists(currentPath + currentFileName))
                                {   //if a file by this name does exist, delete the old back up and create a new one
                                    if (File.Exists(backupPath + "bu" + currentFileName))
                                        File.Delete(backupPath + "bu" + currentFileName);
                                    File.Move(currentPath + currentFileName, backupPath + "bu" + currentFileName);
                                }
                                WriteColsHeaders();
                                File.AppendAllText(currentPath + currentFileName, listAsString);                                
                            }
                        }                       
                    }
                    catch (Exception ex)
                    {
                        lm.Write("btnSave_Click: " + ex.Message);
                    }
                }
                ClearGrid();
                //dGrid.Rows.Clear();
                //dGrid.Rows.Clear();
                ////dGrid = new DataGridView();
                ////CreateGridViewCols();
                //AddGridRows(defaultRowCount);
                //listAsString = "";
                //enteredRowCount = 0;
                //changed = false;
                //required.Clear();
            }
        }

        private void ClearGrid()
        {
            dGrid.Rows.Clear();
            dGrid.Rows.Clear();
            AddGridRows(defaultRowCount);
            listAsString = "";
            enteredRowCount = 0;
            changed = false;
            required.Clear();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (trace)
                lm.Write("Form1.btnRestore_Click");
            //restored = true;
            string[] fullPath;
            CheckChanged();
            dGrid.Rows.Clear();
            openFileDlog = new OpenFileDialog()
            {
                FileName = "",
                Filter = "CSV files (*.csv)|*.csv|Excel files(*.xlsx,*.xls)|*.xlsx;*.xls|All files (*.*)|*.*",
                FilterIndex = 3,
                Title = "Open a Vizient data file"
            };

            if (openFileDlog.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    currentFileName = openFileDlog.FileName;
                    if (currentFileName.Contains(".xls"))
                        ImportExcelFile(currentFileName);
                    else
                    {

                        StreamReader sr = new StreamReader(currentFileName);
                        fullPath = currentFileName.Split(@"\".ToCharArray());
                        currentFileName = fullPath[fullPath.Length - 1];
                        RestoreGrid(sr.ReadToEnd());
                        sr.Close();
                    }
                }
                catch (Exception ex)
                {
                    lm.Write("btnRestore_Click: " + ex.Message);
                    if (ex.Message.Contains("used by another process"))
                    {
                        MessageBox.Show("The file" + Environment.NewLine + currentFileName + Environment.NewLine + "is already open by another user.");
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (trace)
                lm.Write("Form1.btnQuit_Click");
            CheckChanged();
            Application.Exit();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (trace)
                lm.Write("Form1.btnNew_Click");
            CheckChanged();
            dGrid.Rows.Clear();
            AddGridRows(defaultRowCount);
            enteredRowCount = 0;
            currentFileName = ""; ;
        }

        private void ImportToGrid(string[] rowData, int colCount, int rowCount)
        {
            //this is used when opening an Excel file - see RestoreGrid for csv
            if (trace)
                lm.Write("Form1.ImportToGrid");
            string[] colData;
            string dataCheck = "";
            string thisRow = "";
            int rowNo = -1;   //row[0] is the col header row
            int gridColNo = 0;

            AddGridRows(defaultRowCount);
            DataGridViewRow row = null;
            try
            {
                foreach (string item in rowData)
                {
                    if (item.Length > 0)
                    {
                        if (rowNo >= 0)
                        {
                            row = dGrid.Rows[rowNo];
                            thisRow = RemoveNulls(item.Split("||".ToCharArray()));
                            colData = thisRow.Split("||".ToCharArray());
                            for (int colNo = 0; colNo < colData.Length; colNo++)
                            {
                                if (colData[colNo].Length > 0)
                                {
                                    if (colData[colNo] == ".")
                                        colData[colNo] = "";
                                    row.Cells[gridColNo++].Value = colData[colNo];
                                }
                            }
                        }
                        rowNo++;
                        gridColNo = 0;
                    }
                }
                changed = true;
                enteredRowCount = CountRows();
            }
            catch (Exception ex)
            {
                lm.Write("RestoreGrid: " + ex.Message);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (trace)
                lm.Write("Form1.btnImport_Click");
            Import imp = new Import();
            imp.Trace = trace;
            string[] fullPath;
            openFileDlog = new OpenFileDialog()
            {
                FileName = "",
                Filter = "CSV files (*.csv)|*.csv|Excel files(*.xlsx,*.xls)|*.xlsx;*.xls|All files (*.*)|*.*",
                Title = "Open a Vizient data file"
            };

            if (openFileDlog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    currentFileName = openFileDlog.FileName;
                    
                        ImportExcelFile(currentFileName);


                   
                }
                catch (Exception ex)
                {
                    lm.Write("btnRestore_Click: " + ex.Message);
                    if (ex.Message.Contains("used by another process"))
                    {
                        MessageBox.Show("The file" + Environment.NewLine + currentFileName + Environment.NewLine + "is already open by another user.");
                    }
                }
            }
            //   imp.TestFile();
            //string oneRow = "";
            //string[] rowData = imp.FileContents.Split("\r\n".ToCharArray());
            //ImportToGrid(rowData, imp.ColCount, imp.RowCount);

            //string[] colData;
            //int currentRow = 1;
            //foreach (string item in rowData)
            //{
            //    if (item.Length > 0)
            //    {
            ////oneRow = RemoveNulls(item.Split("||".ToCharArray()));
            //ImportToGrid(rowData,imp.ColCount, imp.RowCount);
            //}
            //}


            if (imp.ErrorMessage.Length > 0)
            {
                MessageBox.Show(imp.ErrorMessage);
            }
        }

        private void ImportExcelFile(string filePath)
        {
            if (trace)
                lm.Write("Form1.ImportExcelFile");
            Import imp = new Import();
            imp.Trace = trace;
            imp.ExcelFile(filePath);
            string[] rowData = imp.FileContents.Split("\r\n".ToCharArray());
            ImportToGrid(rowData, imp.ColCount, imp.RowCount);
        }

        private string RemoveNulls(string[] colData)
        {
            if (trace)
                lm.Write("Form1.RemoveNulls");
            string noNulls = "";
            int count = 0;

            foreach(string item in colData)
            {
                if(item.Length > 0)
                {
                    noNulls += item + "||";
                }
            }

            return noNulls;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (trace)
                lm.Write("Form1.btnExport_Click");
            //int rowNo = 0;
            int colNo = 0;
            int outPutRow = 2;  //row index for the output file
            int dgvRowCount = CountRows();  // enteredRowCount;  //actual number of rows in the dataGrid object
            SLDocument sldVizImport = new SLDocument(currentPath + "VizientImport" + ".xlsx");   //,"Sheet1"); //VizientImport
            sldVizImport.RenameWorksheet(SLDocument.DefaultFirstSheetName, "VizientImport");
            sldVizImport.RenameWorksheet("Sheet2", "HEMMImport"); //HEMMImport
            string cellValue = "";
            DataGridViewRow row = null;

            if (dGrid.Columns.Count > 0)
            {
                //sld.SetCellValue(rowNo, ++colNo, colName);
                //sld.SetCellValue(rowNo, ++colNo, element);
                try
                {
                    //foreach (DataGridViewRow row in dGrid.Rows)

                    for (int rowNo = 0; rowNo <= dgvRowCount + 1; rowNo++)
                    {
                        if (rowNo == 0)
                        {
                            SetColHeaders(sldVizImport);
                            //rowNo++;
                        }

                        row = dGrid.Rows[rowNo];
                        colNo = 1;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cellValue = cell.Value.ToString();
                            cellValue = VerifyUserInput(colNo, cellValue);
                            if (cellValue == "")
                            {
                                colNo++;
                                continue;
                            }
                            switch (colNo)
                            {  //cases 6 through 16 below format the UOM values on the spreadsheet
                               //the default case formats everything else
                                #region cases
                                case 6:     //QTY1
                                    sldVizImport.SelectWorksheet("VizientImport");
                                    sldVizImport.SetCellValue(rowNo + 2, colNo++, cellValue);
                                    sldVizImport.SelectWorksheet("HEMMImport");
                                    sldVizImport.SetCellValue(outPutRow, 12, "1");  //seq #
                                    break;
                                case 7:     //eg: CS
                                    sldVizImport.SelectWorksheet("VizientImport");
                                    sldVizImport.SetCellValue(rowNo + 2, colNo++, cellValue);
                                    sldVizImport.SelectWorksheet("HEMMImport");
                                    sldVizImport.SetCellValue(outPutRow, 13, cellValue);
                                    if (row.Cells[colNo + 2].Value.ToString() == "")
                                    {
                                        sldVizImport.SetCellValue(outPutRow, 15, "1");
                                        sldVizImport.SetCellValue(outPutRow, 16, cellValue);
                                    }
                                    break;
                                case 9:     //eg: QTY2                                            
                                    sldVizImport.SelectWorksheet("VizientImport");
                                    sldVizImport.SetCellValue(rowNo + 2, colNo++, cellValue);
                                    sldVizImport.SelectWorksheet("HEMMImport");
                                    sldVizImport.SetCellValue(outPutRow, 15, cellValue);
                                    break;
                                case 10:    //eg: BX                                            
                                    sldVizImport.SelectWorksheet("VizientImport");
                                    sldVizImport.SetCellValue(rowNo + 2, colNo++, cellValue);
                                    sldVizImport.SelectWorksheet("HEMMImport");
                                    sldVizImport.SetCellValue(outPutRow, 16, cellValue);
                                    sldVizImport.SetCellValue(++outPutRow, 12, "2");
                                    sldVizImport.SetCellValue(outPutRow, 13, cellValue);
                                    if (row.Cells[colNo + 2].Value.ToString() == "")
                                    {
                                        sldVizImport.SetCellValue(outPutRow, 15, "1");
                                        sldVizImport.SetCellValue(outPutRow, 16, cellValue);
                                    }
                                    break;
                                case 12:    //eg: QTY3
                                    sldVizImport.SelectWorksheet("VizientImport");
                                    sldVizImport.SetCellValue(rowNo + 2, colNo++, cellValue);
                                    sldVizImport.SelectWorksheet("HEMMImport");
                                    sldVizImport.SetCellValue(outPutRow, 15, cellValue);
                                    break;
                                case 13:    //eg: EA
                                    sldVizImport.SelectWorksheet("VizientImport");
                                    sldVizImport.SetCellValue(rowNo + 2, colNo++, cellValue);
                                    sldVizImport.SelectWorksheet("HEMMImport");
                                    sldVizImport.SetCellValue(outPutRow, 16, cellValue);
                                    sldVizImport.SetCellValue(++outPutRow, 12, "3");
                                    if (cellValue == "EA")
                                        sldVizImport.SetCellValue(outPutRow, 15, "1");
                                    else
                                        sldVizImport.SetCellValue(outPutRow, 15, cellValue);

                                    sldVizImport.SetCellValue(outPutRow, 13, cellValue);
                                    sldVizImport.SetCellValue(outPutRow, 16, cellValue);
                                    break;
                                case 15:    //eg: uom4 qty
                                    sldVizImport.SelectWorksheet("VizientImport");
                                    sldVizImport.SetCellValue(rowNo + 2, colNo++, cellValue);
                                    sldVizImport.SelectWorksheet("HEMMImport");
                                    if (cellValue.Length > 0)
                                    {
                                        sldVizImport.SetCellValue(outPutRow, 16, cellValue);
                                        sldVizImport.SetCellValue(++outPutRow, 12, "4");
                                        sldVizImport.SetCellValue(outPutRow, 15, cellValue);
                                    }
                                    break;
                                case 16:    //eg: uom4 name
                                    sldVizImport.SelectWorksheet("VizientImport");
                                    sldVizImport.SetCellValue(rowNo + 2, colNo++, cellValue);
                                    if (cellValue.Length > 0)
                                    {
                                        sldVizImport.SelectWorksheet("HEMMImport");
                                        sldVizImport.SetCellValue(outPutRow, 13, cellValue);
                                        sldVizImport.SetCellValue(outPutRow, 16, cellValue);
                                        sldVizImport.SetCellValue(outPutRow - 1, 16, cellValue);
                                    }
                                    break;
                                default:    //some other column
                                    sldVizImport.SelectWorksheet("VizientImport");
                                    sldVizImport.SetCellValue(rowNo + 2, colNo, cellValue); //CHANGE: colNo++
                                    sldVizImport.SelectWorksheet("HEMMImport");
                                    switch (colNo++)
                                    {
                                        case 2:
                                            sldVizImport.SetCellValue(outPutRow, 2, cellValue);
                                            break;
                                        case 3:
                                            sldVizImport.SetCellValue(outPutRow, 1, cellValue);
                                            break;
                                        case 24:
                                            sldVizImport.SetCellValue(outPutRow, 7, cellValue);
                                            break;
                                        case 25:
                                            sldVizImport.SetCellValue(outPutRow, 8, cellValue);
                                            break;
                                        case 26:
                                            sldVizImport.SetCellValue(outPutRow, 9, cellValue);
                                            break;
                                        case 27:
                                            sldVizImport.SetCellValue(outPutRow, 10, cellValue);
                                            break;
                                    }
                                    break;
                                    #endregion

                            }
                        }
                        outPutRow++;
                    }
                    sldVizImport.SelectWorksheet("VizientImport");
                    sldVizImport.SaveAs(currentPath + "VizientExport" + dtu.DateTimeCoded() + ".xlsx");
                    //       btnSave_Click(sender, e);
                    ClearGrid();
                }
                catch (Exception ex)
                {
                    lm.Write("btnExport: " + ex.Message);
                }

            }
        }

        private int CountRows()
        {
            if (trace)
                lm.Write("Form1.CountRows");
            string cellValu = "";
            int rowCount = 0;
            int filledCellCount = 0;
            DataGridViewCell cell;
            try
            {
                foreach (DataGridViewRow row in dGrid.Rows)
                {
                    for (int x = 0; x < row.Cells.Count; x++)
                    {
                        cell = row.Cells[x];
                        cellValu = cell.Value.ToString().Trim();
                        if (cellValu.Length > 0)
                        {
                            filledCellCount++;
                        }
                    }
                    if (filledCellCount > 0)
                    {
                        rowCount++;
                        filledCellCount = 0;
                    }
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                //a message containing "...object reference not set to an instance of an object..."
                //indictes that the cell value is null
                lm.Write("CountRows: " + rowCount + Environment.NewLine + ex.Message);
            }
            return rowCount;
        }

        private void dGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (trace)
                lm.Write("Form1.dGrid_RowEnter");
            enteredRowCount += CheckRow(dGrid.Rows[e.RowIndex]);
        }

        private int CheckRow(DataGridViewRow row)
        {
            if (trace)
                lm.Write("Form1.CheckRow");
            int count = 0;
            for (int i = 0; i < row.Cells.Count; i++)
            {
                if (row.Cells[i].Value != null)
                {
                    if (row.Cells[i].Value.ToString() != string.Empty)
                    {
                        count++;
                        break;
                    }
                }
            }
            return count;
        }

        private string VerifyUserInput(int colNo, string cellValue)
        {           
            if (trace)
                lm.Write("Form1.VerifyUserInput");
            switch (colNo)
            {
                case 5:     //Item Description
                    if (cellValue.Contains(","))
                        cellValue = cellValue.Replace(",", "");
                    if (cellValue.Contains("\""))
                        cellValue = RemoveChars("\"", cellValue);
                    break;
                case 18:    //Pricing UOM
                    if (cellValue.Contains(","))
                    {
                        if (cellValue.Contains("."))
                            cellValue.Replace(",", "");
                        else
                            cellValue = RemoveChars(",", cellValue, "dlrValu");
                    }
                    if (cellValue.Contains("$"))
                        cellValue = RemoveChars("$", cellValue);
                    break;
                case 19:    //Pricing GTIN
                    if (cellValue.Contains(","))
                    {
                        if (cellValue.Contains("."))
                            cellValue.Replace(",", "");
                        else
                            cellValue = RemoveChars(",", cellValue, "dlrValu");
                    }
                    if (cellValue.Contains("$"))
                        cellValue = RemoveChars("$", cellValue);
                    break;
                case 22:    //Manu Price 1
                    if (cellValue.Contains(","))
                    {
                        if (cellValue.Contains("."))
                            cellValue.Replace(",", "");
                        else
                            cellValue = RemoveChars(",", cellValue, "dlrValu");
                    }
                    if (cellValue.Contains("$"))
                        cellValue = RemoveChars("$", cellValue);
                    break;
                case 23:    //Alt Price 1
                    if (cellValue.Contains(","))
                    {
                        if (cellValue.Contains("."))
                            cellValue.Replace(",", "");
                        else
                            cellValue = RemoveChars(",", cellValue, "dlrValu");
                    }
                    if (cellValue.Contains("$"))
                        cellValue = RemoveChars("$", cellValue);
                    break;
                default:
                    cellValue.Replace(",", " ");
                    break;
            }
            return cellValue;
        }

        private string RemoveChars(string targetChar, string cellValu)
        {
            if (trace)
                lm.Write("Form1.RemoveChars");
            return RemoveChars(targetChar, cellValu, "");
        }

        private string RemoveChars(string targetChar, string cellValu, string type)
        {
            if (trace)
                lm.Write("Form1.RemoveChars - 3 params");
            string rtnStr = "";
            string[] valuParts = cellValu.Split(targetChar.ToCharArray());
            if (type == "dlrValu" && valuParts.Length == 2)
                rtnStr = valuParts[0] + "." + valuParts[1];
            else
            {
                if (valuParts.Length > 1)
                {
                    for (int x = 0; x < valuParts.Length; x++)
                        rtnStr += valuParts[x];
                }
            }
            if (type == "dlrValu")
            {
                rtnStr += " VERIFY";
            }
            return rtnStr;
        }

        private void dGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (trace)
                lm.Write("Form1.dGrid_RowsRemoved");
            //if(!restored)
            //    enteredRowCount -= e.RowCount;
            ResetRowHeaders();

        }

        private void ResetRowHeaders()
        {
            if (trace)
                lm.Write("Form1.ResetRowHeaders");
            int numberOfRows = dGrid.Rows.Count;
            for (int x = 0; x < numberOfRows; x++)
            {
                dGrid.Rows[x].HeaderCell.Value = (x + 1).ToString();
            }
        }
    }
}
