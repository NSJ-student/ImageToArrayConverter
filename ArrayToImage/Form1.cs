using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using System.IO;

namespace ArrayToImage
{
    public partial class Form1 : Form
    {
        OpenFileDialog open_dialog;
        Bitmap ArrayImage;
        Bitmap ReferenceImage;
        BackgroundWorker worker;

        public Form1()
        {
            InitializeComponent();

            ArrayImage = null;
            ReferenceImage = null;

            open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Raw Files(*.raw)|*.raw";

            //Thread객체 생성
            worker = new BackgroundWorker();

            // 이벤트 핸들러 지정
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

            worker.WorkerReportsProgress = true;
        }

        private void pDisplay_Paint(object sender, PaintEventArgs e)
        {
            if(ArrayImage != null)
            {
                e.Graphics.DrawImage(ArrayImage, new Rectangle(0, 0, ArrayImage.Width, ArrayImage.Height));
            }
        }

        private void btnConvertArrayToImage_Click(object sender, EventArgs e)
        {
            int width = (int)nImageWidth.Value;
            int height = (int)nImageHeight.Value;

            if(width == 0)
            {
                return;
            }
            if(height == 0)
            {
                return;
            }

            string[] lines = rtbArray.Lines;
            UInt32[] array = new UInt32[width * height];

            int line_max = width * height;
            int line_count = 0;
            foreach (string line in lines)
            {
                string str_hex = line.Replace(",", "").Replace("0x", "").Replace(" ", "");

                array[line_count] = Convert.ToUInt32(str_hex, 16);
                if (array[line_count] == 0)
                {
                    continue;
                }

                line_count++;
                if (line_max <= line_count)
                {
                    break;
                }
            }

            ArrayImage = new Bitmap(width, height);
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    Color color = Color.FromArgb((int)array[col + row * width]);
                    ArrayImage.SetPixel(col, row, color);
                }
            }

            pDisplay.Size = new Size(width, height);
            pDisplay.Invalidate();
        }

        private void btnConvertBinToImage_Click(object sender, EventArgs e)
        {
            int width = (int)nImageWidth.Value;
            int height = (int)nImageHeight.Value;

            if (width == 0)
            {
                return;
            }
            if (height == 0)
            {
                return;
            }

            if (DialogResult.OK != open_dialog.ShowDialog())
            {
                return;
            }

            string FilePath = open_dialog.FileName;
            FileStream file = File.OpenRead(FilePath);
            BinaryReader reader = new BinaryReader(file);
            
            ArrayImage = new Bitmap(width, height);
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    int data = reader.ReadInt32();
                    Color color = Color.FromArgb(data);
                    ArrayImage.SetPixel(col, row, color);
                }
            }

            pDisplay.Size = new Size(width, height);
            pDisplay.Invalidate();
        }

        private void btnConvertImageToArray_Click(object sender, EventArgs e)
        {
            if(worker.IsBusy)
            {
                return;
            }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image File(*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg";
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                ReferenceImage = new Bitmap(dialog.FileName);

                progImageToArray.Value = 0;
                progImageToArray.Maximum = 100;

                btnConvertImageToArray.Enabled = false;

                worker.RunWorkerAsync();
            }
        }

        // Worker Thread가 실제 하는 일
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if(ReferenceImage == null)
            {
                return;
            }

            int width = ReferenceImage.Width;
            int height = ReferenceImage.Height;

            try
            {
                this.BeginInvoke(new Action(delegate {
                    rtbArray.Clear();
                }));
                for (int row = 0; row < height; row++)
                {
                    string append = "";
                    for (int col = 0; col < width; col++)
                    {
                        Color color = ReferenceImage.GetPixel(col, row);
                        int argb = color.ToArgb();

                        string str_argb = argb.ToString("X8");

                        append += "0x" + str_argb + ",\n";
                    }
                    worker.ReportProgress((row+1) * 100 / height);
                    this.BeginInvoke(new Action(delegate {
                        rtbArray.AppendText(append);
                    }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Progress 리포트 - UI Thread
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progImageToArray.Value = e.ProgressPercentage;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblArrayCount.Text = "line count : " + rtbArray.Lines.Count<string>().ToString();
            btnConvertImageToArray.Enabled = true;
        }

    }
}
