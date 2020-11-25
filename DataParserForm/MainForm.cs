using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DataParserForm
{
    public partial class MainForm : Form
    {
        private ProcessingForm processForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbxMethodType.Items.Add(MsgCode.METHOD_TYPE_eti);
            cbxMethodType.Items.Add(MsgCode.METHOD_TYPE_jte);
            cbxMethodType.Items.Add(MsgCode.METHOD_TYPE_wte);
            cbxMethodType.Items.Add(MsgCode.METHOD_TYPE_wti);
            cbxMethodType.SelectedIndex = 0;

            txtTableName.Text = "";
        }
        
        private Boolean CheckInput(string methodType)
        {
            bool result = true;

            if (txtOpenFilePath.Text.Equals(""))
            {
                MessageBox.Show("파일을 선택해주세요.");
                result = false;
            }
            else
            {
                if (methodType.Equals(MsgCode.METHOD_TYPE_eti) || methodType.Equals(MsgCode.METHOD_TYPE_wti))
                {
                    if (txtTableName.Text.Equals(""))
                    {
                        MessageBox.Show("테이블 이름을 입력해주세요.");
                        result = false;
                    }
                }
            }

            return result;
        }

        private bool CheckFileExtension(string fileFullPath)
        {
            string ext = Path.GetExtension(fileFullPath);

            if (ext.Equals(".xlsx") || ext.Equals(".csv") || ext.Equals(".xls") || ext.Equals(".txt"))
                return true;
            else
                return false;
        }

        private bool IsFileOpen(string path)
        {
            FileStream stream = null;

            try
            {
                stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (stream != null) { stream.Close(); stream = null; }
            }
            return true;
            
        }

        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            txtOpenFilePath.Text = "";
            DialogResult ds = OpenFile.ShowDialog();
            txtOpenFilePath.Text = OpenFile.FileName;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string filePath = OpenFile.FileName;
            string methodType = cbxMethodType.SelectedItem.ToString();
            string tableName = txtTableName.Text;
            Boolean autoOpen = ckbFileAutoOpen.Checked;

            if (CheckInput(methodType)) //파일은 선택했는지, 테이블 이름은 선택했는지 확인
            {
                if (!CheckFileExtension(filePath))  // 파일 확장자 확인
                {
                    MessageBox.Show("파일 확장자가 잘못됐습니다.\n엑셀 또는 txt 확장자를 선택해주세요.");
                }
                else
                {
                    if (!IsFileOpen(filePath))  // 파일이 열려있는지 확인
                    {
                        MessageBox.Show("파일이 이미 열려있습니다. 파일을 닫고 다시 선택해주세요.");
                    }
                    else
                    {
                        Worker.RunWorkerAsync();
                        
                        switch (methodType)
                        {
                            case MsgCode.METHOD_TYPE_eti:
                                ExceltoInsertQuery eti = new ExceltoInsertQuery();
                                eti.execute(filePath, tableName, autoOpen);
                                break;

                            case MsgCode.METHOD_TYPE_jte:
                                JSONToExcel jte = new JSONToExcel();
                                jte.execute(filePath, autoOpen);
                                break;

                            case MsgCode.METHOD_TYPE_wte:
                                WebmethodToExcel wte = new WebmethodToExcel();
                                wte.execute(filePath, autoOpen);
                                break;

                            case MsgCode.METHOD_TYPE_wti:
                                WebmethodToExcel wti_wte = new WebmethodToExcel();
                                ExceltoInsertQuery wti_eti = new ExceltoInsertQuery();
                                string excelFilePath = wti_wte.execute(filePath, false);
                                wti_eti.execute(excelFilePath, tableName, autoOpen);
                                break;

                            default:
                                break;
                        }
                        CheckForIllegalCrossThreadCalls = false;
                        processForm.Close();
                    }
                }
            }
        }

        private void cbxMethodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxMethodType.SelectedItem.Equals(MsgCode.METHOD_TYPE_eti)
                || cbxMethodType.SelectedItem.Equals(MsgCode.METHOD_TYPE_wti))
            {
                txtTableName.Text = "";
                lblTableName.Visible = true;
                txtTableName.Visible = true;
            }
            else
            {
                txtTableName.Text = "";
                lblTableName.Visible = false;
                txtTableName.Visible = false;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnExecute_Click(sender, e);
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            processForm = new ProcessingForm();
            processForm.ShowDialog();
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                string[] filePath = (string[])e.Data.GetData(DataFormats.FileDrop);
                txtOpenFilePath.Text = filePath[0];
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
