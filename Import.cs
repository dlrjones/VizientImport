using System;
using System.IO;
using LogDefault;

namespace VizientImport
{
    public class Import
    {
        private LogManager lm = LogManager.GetInstance();        
        private string errorMessage = "";
        private int rowCount = 0;
        private int colCount = 0;
        //private string filePath = @"C:\xlsx2csv\";
        //private string fileName = "ImportFile.csv";
        private string fileContents = "";

        public string ErrorMessage
        {
            get { return errorMessage; }
        }

        public string FileContents
        {
            get { return fileContents; }
        }
        public int RowCount
        {
            get { return rowCount; }
        }
        public int ColCount
        {
            get { return colCount; }
        }

        public void ExcelFile(string fullPath)
        {
            Convert cnv = new Convert();
            string[] path;
            string filePath = "";
            string fileName = "";

            path = fullPath.Split(@"\".ToCharArray());
            fileName = path[path.Length - 1];
            for(int x = 0; x < path.Length - 1; x++)
            {
                filePath += path[x] + @"\";
            }
            cnv.FilePath = filePath;
            cnv.FileName = fileName;
            cnv.ConvertToCsv();
            fileName = cnv.FileName;
            rowCount = cnv.RowCount;
            colCount = cnv.ColCount;
            try
            {
                StreamReader sr = new StreamReader(filePath + fileName);
                fileContents = sr.ReadToEnd();              
            }
            catch(Exception ex)
            {
                errorMessage = "Import.ExcelFile: " + ex.Message;
                lm.Write(errorMessage);                
            }           
        }
    
        private int CountRows()
        {
            string cellValu = "";
            int x = 1;
            try
            {
                for(; x < 1000000000; x++)
                {
                    if (cellValu.Length == 0)
                        break;
                }
                
            }            
            catch (Exception ex)
            {
                lm.Write("CountRows: " + ex.Message);
            }
            return x - 2; //minus one for the header row and one for the last count in the loop
        }


    }
}
