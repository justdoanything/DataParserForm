using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace DataParserForm
{
    class ExceltoInsertQuery
    {
        private Excel.Application excel = null;
        private Excel.Workbook wb = null;
        private Excel.Worksheet ws = null;

        public ExceltoInsertQuery()
        {
            
        }

        public void execute(string filePath, string tableName, Boolean autoOpen)
        {
            excel = new Excel.Application();
            wb = excel.Workbooks.Open(filePath);
            // excel.DisplayAlerts = false;
            string writeFilePath = filePath.Replace(Path.GetExtension(filePath), "") + "_INSERT.txt";
            FileIO file = new FileIO(MsgCode.FILE_IO_WRITE, writeFilePath);

            try
            {
                // 엑셀 파일에 첫번째 Sheet 열기
                ws = excel.Application.ActiveWorkbook.Sheets[1];

                // 첫번째 Sheet 안에 있는 데이터 추출
                Excel.Range range = ws.UsedRange;
                object[,] data = range.Value;

                // Insert문 헤더 작성
                String insertQueryHeader = "";
                insertQueryHeader += "INSERT INTO " + tableName + " (";
               
                // Insert문 KeyList 작성
                for(int cell = 1; cell <= data.GetLength(1); cell++)
                {
                    insertQueryHeader += data[1, cell];
                    if (cell != data.GetLength(1))
                        insertQueryHeader += ",";
                }
                insertQueryHeader += ") VALUES (";
                
                // Insert문 헤더로 각 Insert Query 추출
                for(int row = 2; row <= data.GetLength(0); row++)
                {
                    string insertRecord = insertQueryHeader;
                    for (int cell = 1; cell <= data.GetLength(1); cell++)
                    {
                        if(data[row, cell] == null 
                            || data[row, cell].Equals(@"\t") 
                            || data[row, cell].Equals(@"\n")
                            || data[row, cell].Equals(""))
                        {
                            insertRecord += "null";
                        }
                        else
                        {
                            insertRecord += data[row, cell];
                        }
                        if (cell != data.GetLength(1))
                            insertRecord += ",";
                    }
                    insertRecord += ");";
                    file.write(insertRecord);
                }

                // 파일 자동 열기
                if (autoOpen)
                    System.Diagnostics.Process.Start(writeFilePath);
            }
            catch(Exception e)
            {
                MessageBox.Show("Exception" + e.Message);
                this.Close();
            }
            finally
            {
                this.Close();
                file.Close();
            }
        }


        private void Close()
        {
            if (wb != null) { wb.Close(); wb = null; }
            if (ws != null) { ws = null; }
            if (excel != null) { excel.Quit(); excel = null; }
        }
    }
}
