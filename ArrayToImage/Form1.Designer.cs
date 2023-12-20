
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
            this.btnConvertImageToArray = new System.Windows.Forms.Button();
            this.btnConvertArrayToImage = new System.Windows.Forms.Button();
            this.nImageHeight = new System.Windows.Forms.NumericUpDown();
            this.nImageWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progImageToArray = new System.Windows.Forms.ProgressBar();
            this.lblArrayCount = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
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
            this.rtbArray.Size = new System.Drawing.Size(234, 381);
            this.rtbArray.TabIndex = 1;
            this.rtbArray.Text = "";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.lblArrayCount);
            this.panel2.Controls.Add(this.progImageToArray);
            this.panel2.Controls.Add(this.btnConvertImageToArray);
            this.panel2.Controls.Add(this.btnConvertArrayToImage);
            this.panel2.Controls.Add(this.nImageHeight);
            this.panel2.Controls.Add(this.nImageWidth);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rtbArray);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 599);
            this.panel2.TabIndex = 2;
            // 
            // btnConvertImageToArray
            // 
            this.btnConvertImageToArray.Location = new System.Drawing.Point(15, 529);
            this.btnConvertImageToArray.Name = "btnConvertImageToArray";
            this.btnConvertImageToArray.Size = new System.Drawing.Size(171, 23);
            this.btnConvertImageToArray.TabIndex = 5;
            this.btnConvertImageToArray.Text = "Image to Array";
            this.btnConvertImageToArray.UseVisualStyleBackColor = true;
            this.btnConvertImageToArray.Click += new System.EventHandler(this.btnConvertImageToArray_Click);
            // 
            // btnConvertArrayToImage
            // 
            this.btnConvertArrayToImage.Location = new System.Drawing.Point(15, 454);
            this.btnConvertArrayToImage.Name = "btnConvertArrayToImage";
            this.btnConvertArrayToImage.Size = new System.Drawing.Size(171, 23);
            this.btnConvertArrayToImage.TabIndex = 5;
            this.btnConvertArrayToImage.Text = "Array to Image";
            this.btnConvertArrayToImage.UseVisualStyleBackColor = true;
            this.btnConvertArrayToImage.Click += new System.EventHandler(this.btnConvertArrayToImage_Click);
            // 
            // nImageHeight
            // 
            this.nImageHeight.Location = new System.Drawing.Point(66, 427);
            this.nImageHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nImageHeight.Name = "nImageHeight";
            this.nImageHeight.Size = new System.Drawing.Size(120, 21);
            this.nImageHeight.TabIndex = 4;
            this.nImageHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nImageHeight.Value = new decimal(new int[] {
            360,
            0,
            0,
            0});
            // 
            // nImageWidth
            // 
            this.nImageWidth.Location = new System.Drawing.Point(66, 399);
            this.nImageWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nImageWidth.Name = "nImageWidth";
            this.nImageWidth.Size = new System.Drawing.Size(120, 21);
            this.nImageWidth.TabIndex = 4;
            this.nImageWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nImageWidth.Value = new decimal(new int[] {
            480,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width :";
            // 
            // progImageToArray
            // 
            this.progImageToArray.Location = new System.Drawing.Point(15, 500);
            this.progImageToArray.Name = "progImageToArray";
            this.progImageToArray.Size = new System.Drawing.Size(171, 23);
            this.progImageToArray.TabIndex = 7;
            // 
            // lblArrayCount
            // 
            this.lblArrayCount.AutoSize = true;
            this.lblArrayCount.Location = new System.Drawing.Point(13, 555);
            this.lblArrayCount.Name = "lblArrayCount";
            this.lblArrayCount.Size = new System.Drawing.Size(0, 12);
            this.lblArrayCount.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 599);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pDisplay);
            this.Name = "Form1";
            this.Text = "Array-Image Converter";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.ProgressBar progImageToArray;
        private System.Windows.Forms.Label lblArrayCount;
    }
}

