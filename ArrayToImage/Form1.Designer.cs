
namespace ArrayToImage
{
    partial class Form1
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
            this.pDisplay = new System.Windows.Forms.Panel();
            this.rtbArray = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtResultLog = new System.Windows.Forms.TextBox();
            this.progWork = new System.Windows.Forms.ProgressBar();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.txtSaveImageName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConvertBinToImage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConvertArrayToImage = new System.Windows.Forms.Button();
            this.btnConvertImageToArray = new System.Windows.Forms.Button();
            this.lblArrayCount = new System.Windows.Forms.Label();
            this.nImageHeight = new System.Windows.Forms.NumericUpDown();
            this.nImageWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nImageHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nImageWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // pDisplay
            // 
            this.pDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDisplay.Location = new System.Drawing.Point(240, 12);
            this.pDisplay.Name = "pDisplay";
            this.pDisplay.Size = new System.Drawing.Size(441, 380);
            this.pDisplay.TabIndex = 0;
            this.pDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pDisplay_Paint);
            // 
            // rtbArray
            // 
            this.rtbArray.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbArray.Location = new System.Drawing.Point(0, 0);
            this.rtbArray.Name = "rtbArray";
            this.rtbArray.Size = new System.Drawing.Size(234, 323);
            this.rtbArray.TabIndex = 0;
            this.rtbArray.Text = "";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.txtResultLog);
            this.panel2.Controls.Add(this.progWork);
            this.panel2.Controls.Add(this.btnSaveImage);
            this.panel2.Controls.Add(this.txtSaveImageName);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.lblArrayCount);
            this.panel2.Controls.Add(this.nImageHeight);
            this.panel2.Controls.Add(this.nImageWidth);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rtbArray);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 678);
            this.panel2.TabIndex = 2;
            // 
            // txtResultLog
            // 
            this.txtResultLog.BackColor = System.Drawing.SystemColors.Control;
            this.txtResultLog.ForeColor = System.Drawing.Color.Red;
            this.txtResultLog.Location = new System.Drawing.Point(15, 639);
            this.txtResultLog.Name = "txtResultLog";
            this.txtResultLog.ReadOnly = true;
            this.txtResultLog.Size = new System.Drawing.Size(188, 21);
            this.txtResultLog.TabIndex = 11;
            // 
            // progWork
            // 
            this.progWork.Location = new System.Drawing.Point(15, 555);
            this.progWork.Name = "progWork";
            this.progWork.Size = new System.Drawing.Size(188, 23);
            this.progWork.TabIndex = 5;
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(127, 598);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(66, 23);
            this.btnSaveImage.TabIndex = 7;
            this.btnSaveImage.Text = "SAVE";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // txtSaveImageName
            // 
            this.txtSaveImageName.Location = new System.Drawing.Point(21, 600);
            this.txtSaveImageName.Name = "txtSaveImageName";
            this.txtSaveImageName.Size = new System.Drawing.Size(100, 21);
            this.txtSaveImageName.TabIndex = 6;
            this.txtSaveImageName.Text = "test.bmp";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConvertBinToImage);
            this.groupBox2.Location = new System.Drawing.Point(15, 491);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 56);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "V4L2 TEST";
            // 
            // btnConvertBinToImage
            // 
            this.btnConvertBinToImage.Location = new System.Drawing.Point(7, 20);
            this.btnConvertBinToImage.Name = "btnConvertBinToImage";
            this.btnConvertBinToImage.Size = new System.Drawing.Size(171, 23);
            this.btnConvertBinToImage.TabIndex = 4;
            this.btnConvertBinToImage.Text = "Binary to Image";
            this.btnConvertBinToImage.UseVisualStyleBackColor = true;
            this.btnConvertBinToImage.Click += new System.EventHandler(this.btnConvertBinToImage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConvertArrayToImage);
            this.groupBox1.Controls.Add(this.btnConvertImageToArray);
            this.groupBox1.Location = new System.Drawing.Point(15, 401);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 84);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TDA4VM TEST";
            // 
            // btnConvertArrayToImage
            // 
            this.btnConvertArrayToImage.Location = new System.Drawing.Point(6, 20);
            this.btnConvertArrayToImage.Name = "btnConvertArrayToImage";
            this.btnConvertArrayToImage.Size = new System.Drawing.Size(171, 23);
            this.btnConvertArrayToImage.TabIndex = 3;
            this.btnConvertArrayToImage.Text = "Array to Image";
            this.btnConvertArrayToImage.UseVisualStyleBackColor = true;
            this.btnConvertArrayToImage.Click += new System.EventHandler(this.btnConvertArrayToImage_Click);
            // 
            // btnConvertImageToArray
            // 
            this.btnConvertImageToArray.Location = new System.Drawing.Point(6, 49);
            this.btnConvertImageToArray.Name = "btnConvertImageToArray";
            this.btnConvertImageToArray.Size = new System.Drawing.Size(171, 23);
            this.btnConvertImageToArray.TabIndex = 6;
            this.btnConvertImageToArray.Text = "Image to Array";
            this.btnConvertImageToArray.UseVisualStyleBackColor = true;
            this.btnConvertImageToArray.Click += new System.EventHandler(this.btnConvertImageToArray_Click);
            // 
            // lblArrayCount
            // 
            this.lblArrayCount.AutoSize = true;
            this.lblArrayCount.Location = new System.Drawing.Point(13, 555);
            this.lblArrayCount.Name = "lblArrayCount";
            this.lblArrayCount.Size = new System.Drawing.Size(0, 12);
            this.lblArrayCount.TabIndex = 8;
            // 
            // nImageHeight
            // 
            this.nImageHeight.Location = new System.Drawing.Point(66, 364);
            this.nImageHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nImageHeight.Name = "nImageHeight";
            this.nImageHeight.Size = new System.Drawing.Size(120, 21);
            this.nImageHeight.TabIndex = 2;
            this.nImageHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nImageHeight.Value = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nImageHeight.Click += new System.EventHandler(this.nImageHeight_Click);
            this.nImageHeight.Enter += new System.EventHandler(this.nImageHeight_Enter);
            // 
            // nImageWidth
            // 
            this.nImageWidth.Location = new System.Drawing.Point(66, 336);
            this.nImageWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nImageWidth.Name = "nImageWidth";
            this.nImageWidth.Size = new System.Drawing.Size(120, 21);
            this.nImageWidth.TabIndex = 1;
            this.nImageWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nImageWidth.Value = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.nImageWidth.Click += new System.EventHandler(this.nImageWidth_Click);
            this.nImageWidth.Enter += new System.EventHandler(this.nImageWidth_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 678);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pDisplay);
            this.Name = "Form1";
            this.Text = "Array-Image Converter";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nImageHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nImageWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pDisplay;
        private System.Windows.Forms.RichTextBox rtbArray;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown nImageHeight;
        private System.Windows.Forms.NumericUpDown nImageWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConvertArrayToImage;
        private System.Windows.Forms.Button btnConvertImageToArray;
        private System.Windows.Forms.ProgressBar progWork;
        private System.Windows.Forms.Label lblArrayCount;
        private System.Windows.Forms.Button btnConvertBinToImage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.TextBox txtSaveImageName;
        private System.Windows.Forms.TextBox txtResultLog;
    }
}

