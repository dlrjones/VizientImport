using System;
using LogDefault;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace VizientImport
{
    class Convert
    {
        private LogManager lm = LogManager.GetInstance();
        private string filePath = "";
        private string fileName = "";
        private int rowCount = 0;
        private int colCount = 0;
        private bool trace = false;

        public bool Trace
        {
            set { trace = value; }
        }
        public string FilePath
        {
            set {filePath=value; }
        }
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public int RowCount
        {
            get { return rowCount; }
        }
        public int ColCount
        {
            get { return colCount; }
        }


        public void ConvertToCsv()
        {            
            string cellValu = "";
            string tempValu = "";
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath + fileName);     // + "VizientImportTest");//"Terumo.xls");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            rowCount = xlRange.Rows.Count;        
            colCount = xlRange.Columns.Count;
            if (trace)
                lm.Write("Convert.ConvertToCsv");
            try
            {
                for (int r = 1; r <= rowCount; r++)
                {
                    for (int c = 1; c <= colCount; c++)
                    {
                        //new line
                        if (c == 1)
                        {
                            Console.Write("\r\n");
                            if (cellValu.Length > 0)
                                cellValu += Environment.NewLine;
                        }

                        //write the value to the console
                        if (xlRange.Cells[r, c] != null && xlRange.Cells[r, c].Value2 != null)
                        {
                            tempValu = RemoveCommas(xlRange.Cells[r, c].Value2.ToString());
                            //Console.WriteLine(xlRange.Cells[r, c].Value2.ToString() + "\t");
                            //tempValu = RemoveCommas(xlRange.Cells[r, c].Value2.ToString());
                            //if (tempValu.Length == 0)
                            //    tempValu = "x";
                            //cellValu += tempValu + "|";
                        }
                        else
                            tempValu = ".";

                        Console.WriteLine(tempValu + "\t");
                        tempValu = RemoveCommas(tempValu);
                        cellValu += tempValu + "||";
                    }
                }
                fileName = "ImportFile.csv";
                File.WriteAllText(filePath +fileName, cellValu);
                xlApp.Workbooks.Close();
                   GC.Collect();
                //GC.WaitForPendingFinalizers();  
            }
            catch(Exception ex)
            {
                lm.Write("Convert.ConvertToCsv: " + ex.Message);
            }
        }

        private string RemoveCommas(string cellContents)
        {
            string noCommas = cellContents.Replace(",","");
            if (trace)
                lm.Write("Convert.RemoveCommas");
            return noCommas.Trim();

        }
        //https://code.msdn.microsoft.com/office/How-to-convert-an-Excel-9188263e
    }
}
