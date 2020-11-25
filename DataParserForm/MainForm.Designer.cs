namespace DataParserForm
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFilePath = new System.Windows.Forms.Label();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.txtOpenFilePath = new System.Windows.Forms.TextBox();
            this.btnFileOpen = new System.Windows.Forms.Button();
            this.lblMethod = new System.Windows.Forms.Label();
            this.cbxMethodType = new System.Windows.Forms.ComboBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.lblTableName = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.ckbFileAutoOpen = new System.Windows.Forms.CheckBox();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(12, 20);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(104, 12);
            this.lblFilePath.TabIndex = 0;
            this.lblFilePath.Text = "Choose a File (*)";
            // 
            // OpenFile
            // 
            this.OpenFile.Filter = "Files|*.xlsx;*.csv;*.xls;*.txt|모든 파일|*.*";
            // 
            // txtOpenFilePath
            // 
            this.txtOpenFilePath.Location = new System.Drawing.Point(120, 17);
            this.txtOpenFilePath.Name = "txtOpenFilePath";
            this.txtOpenFilePath.Size = new System.Drawing.Size(276, 21);
            this.txtOpenFilePath.TabIndex = 1;
            // 
            // btnFileOpen
            // 
            this.btnFileOpen.Location = new System.Drawing.Point(410, 17);
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.Size = new System.Drawing.Size(75, 23);
            this.btnFileOpen.TabIndex = 2;
            this.btnFileOpen.Text = "Open";
            this.btnFileOpen.UseVisualStyleBackColor = true;
            this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(10, 47);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(86, 12);
            this.lblMethod.TabIndex = 3;
            this.lblMethod.Text = "Select Method";
            // 
            // cbxMethodType
            // 
            this.cbxMethodType.FormattingEnabled = true;
            this.cbxMethodType.Location = new System.Drawing.Point(120, 44);
            this.cbxMethodType.Name = "cbxMethodType";
            this.cbxMethodType.Size = new System.Drawing.Size(276, 20);
            this.cbxMethodType.TabIndex = 6;
            this.cbxMethodType.SelectedIndexChanged += new System.EventHandler(this.cbxMethodType_SelectedIndexChanged);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(321, 105);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 7;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(21, 74);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(95, 12);
            this.lblTableName.TabIndex = 8;
            this.lblTableName.Text = "Table Name (*)";
            this.lblTableName.Visible = false;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(120, 71);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(276, 21);
            this.txtTableName.TabIndex = 9;
            this.txtTableName.Visible = false;
            // 
            // ckbFileAutoOpen
            // 
            this.ckbFileAutoOpen.AutoSize = true;
            this.ckbFileAutoOpen.Checked = true;
            this.ckbFileAutoOpen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbFileAutoOpen.Location = new System.Drawing.Point(120, 108);
            this.ckbFileAutoOpen.Name = "ckbFileAutoOpen";
            this.ckbFileAutoOpen.Size = new System.Drawing.Size(117, 16);
            this.ckbFileAutoOpen.TabIndex = 10;
            this.ckbFileAutoOpen.Text = "Open Result File";
            this.ckbFileAutoOpen.UseVisualStyleBackColor = true;
            // 
            // Worker
            // 
            this.Worker.WorkerReportsProgress = true;
            this.Worker.WorkerSupportsCancellation = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(506, 145);
            this.Controls.Add(this.ckbFileAutoOpen);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.cbxMethodType);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.btnFileOpen);
            this.Controls.Add(this.txtOpenFilePath);
            this.Controls.Add(this.lblFilePath);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.TextBox txtOpenFilePath;
        private System.Windows.Forms.Button btnFileOpen;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.ComboBox cbxMethodType;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.CheckBox ckbFileAutoOpen;
        private System.ComponentModel.BackgroundWorker Worker;
    }
}

