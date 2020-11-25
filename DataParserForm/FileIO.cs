using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DataParserForm
{
    class FileIO
    {
        private StreamWriter writer = null;
        private StreamReader reader = null;

        public FileIO(string WR, string path)
        {
            try
            {
                if (WR.Equals(MsgCode.FILE_IO_READ))
                    reader = new StreamReader(path);
                else if (WR.Equals(MsgCode.FILE_IO_WRITE))
                    writer = new StreamWriter(path, false); //덮어쓰기
            }
            catch (Exception) { }

        }

        public void write(string line)
        {
            try
            {
                writer.WriteLine(line);
                writer.Flush();
            }
            catch (Exception e) 
            {
                MessageBox.Show("Exception : " + e.Message);
            }
        }

        public void Close()
        {
            if (writer != null) { writer.Close(); writer = null; }
            if (reader != null) { reader.Close(); reader = null; }
        }
    }
}
