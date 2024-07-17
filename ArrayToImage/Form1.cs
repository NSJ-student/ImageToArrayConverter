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
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.LinkLabel;
using System.Xml.Linq;

namespace ArrayToImage
{
    public partial class Form1 : Form
    {
        OpenFileDialog open_dialog;
        Bitmap ArrayImage;
        BackgroundWorker worker;
        WorkArg workerArg;

        public Form1()
        {
            InitializeComponent();

            ArrayImage = null;

            open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Raw Files(*.raw)|*.raw";

            workerArg = new WorkArg();

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

            if ((width == 0) || (height == 0))
            {
                txtResultLog.Text = "image size is 0";
                return;
            }

            string[] lines = rtbArray.Lines;

            progWork.Value = 0;
            progWork.Maximum = 100;

            btnConvertImageToArray.Enabled = false;
            btnConvertBinToImage.Enabled = false;
            btnConvertArrayToImage.Enabled = false;

            workerArg.setProperty(WorkArg.WorkType.ARRAY_TO_IMAGE, lines, width, height);
            worker.RunWorkerAsync(workerArg);

        }

        private void btnConvertBinToImage_Click(object sender, EventArgs e)
        {
            int width = (int)nImageWidth.Value;
            int height = (int)nImageHeight.Value;

            if ((width == 0) || (height == 0))
            {
                txtResultLog.Text = "image size is 0";
                return;
            }

            if (DialogResult.OK != open_dialog.ShowDialog())
            {
                return;
            }

            progWork.Value = 0;
            progWork.Maximum = 100;

            btnConvertImageToArray.Enabled = false;
            btnConvertBinToImage.Enabled = false;
            btnConvertArrayToImage.Enabled = false;

            workerArg.setProperty(WorkArg.WorkType.BIN_TO_ARRAY, open_dialog.FileName, width, height);
            worker.RunWorkerAsync(workerArg);
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
                progWork.Value = 0;
                progWork.Maximum = 100;

                btnConvertImageToArray.Enabled = false;
                btnConvertBinToImage.Enabled = false;
                btnConvertArrayToImage.Enabled = false;

                workerArg.setProperty(WorkArg.WorkType.IMAGE_TO_ARRAY, dialog.FileName);
                worker.RunWorkerAsync(workerArg);
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            if(txtSaveImageName.Text == "")
            {
                txtResultLog.Text = "no save file name";
                return;
            }

            if(ArrayImage == null)
            {
                txtResultLog.Text = "no image array";
                return;
            }

            if ((ArrayImage.Width == 0) || (ArrayImage.Height == 0))
            {
                txtResultLog.Text = "no image array";
                return;
            }

            ArrayImage.Save(txtSaveImageName.Text);
        }

        // Worker Thread가 실제 하는 일
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            WorkArg args = (WorkArg)e.Argument;
            int width = args.Width;
            int height = args.Height;

            this.BeginInvoke(new Action(delegate {
                txtResultLog.Text = "";
            }));
            e.Result = false;

            if (args.Type == WorkArg.WorkType.IMAGE_TO_ARRAY)
            {
                if (args.FilePath == null)
                {
                    this.BeginInvoke(new Action(delegate {
                        txtResultLog.Text = "no file path";
                    }));
                    return;
                }

                Bitmap ReferenceImage;
                ReferenceImage = new Bitmap(args.FilePath);
                width = ReferenceImage.Width;
                height = ReferenceImage.Height;

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
                        worker.ReportProgress((row + 1) * 100 / height);
                        this.BeginInvoke(new Action(delegate {
                            rtbArray.AppendText(append);
                        }));
                    }

                    worker.ReportProgress(100);
                    args.Width = width;
                    args.Height = height;
                    e.Result = true;
                }
                catch (Exception ex)
                {
                    this.BeginInvoke(new Action(delegate {
                        txtResultLog.Text = ex.Message;
                    }));
                }
            }
            else if(args.Type == WorkArg.WorkType.ARRAY_TO_IMAGE)
            {
                if(args.Line == null)
                {
                    this.BeginInvoke(new Action(delegate {
                        txtResultLog.Text = "no array text";
                    }));
                    return;
                }

                try
                {
                    string[] lines = args.Line;
                    UInt32[] array = new UInt32[width * height];

                    int line_max = width * height;
                    if(line_max > lines.Length)
                    {
                        this.BeginInvoke(new Action(delegate {
                            txtResultLog.Text = "too short array";
                        }));
                        return;
                    }

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

                        if (line_count % width == 0)
                        {
                            worker.ReportProgress((line_count/width) * 100 / (height * 2));
                        }
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
                        worker.ReportProgress((line_count + row + 1) * 100 / (height*2));
                    }

                    worker.ReportProgress(100);
                    e.Result = true;
                }
                catch (Exception ex)
                {
                    this.BeginInvoke(new Action(delegate {
                        txtResultLog.Text = ex.Message;
                    }));
                }
            }
            else if (args.Type == WorkArg.WorkType.BIN_TO_ARRAY)
            {
                if (args.FilePath == null)
                {
                    this.BeginInvoke(new Action(delegate {
                        txtResultLog.Text = "no selected binary file";
                    }));
                    return;
                }

                try
                {
                    FileStream file = File.OpenRead(args.FilePath);
                    BinaryReader reader = new BinaryReader(file);

                    if (width*height*4 > file.Length)
                    {
                        this.BeginInvoke(new Action(delegate {
                            txtResultLog.Text = "too short binary file";
                        }));
                        return;
                    }
                    ArrayImage = new Bitmap(width, height);
                    for (int row = 0; row < height; row++)
                    {
                        for (int col = 0; col < width; col++)
                        {
                            int data = reader.ReadInt32();
                            Color color = Color.FromArgb((int)data);
                            ArrayImage.SetPixel(col, row, color);
                        }
                        worker.ReportProgress((row + 1) * 100 / height);
                    }

                    worker.ReportProgress(100);
                    e.Result = true;
                }
                catch (Exception ex)
                {
                    this.BeginInvoke(new Action(delegate {
                        txtResultLog.Text = ex.Message;
                    }));
                }
            }
        }

        // Progress 리포트 - UI Thread
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progWork.Value = e.ProgressPercentage;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result == true)
            {
                if (workerArg.Type == WorkArg.WorkType.IMAGE_TO_ARRAY)
                {
                    lblArrayCount.Text = "line count : " + rtbArray.Lines.Count<string>().ToString();
                    nImageWidth.Value = workerArg.Width;
                    nImageHeight.Value = workerArg.Height;
                }
                else if (workerArg.Type == WorkArg.WorkType.ARRAY_TO_IMAGE)
                {
                    pDisplay.Size = new Size(workerArg.Width, workerArg.Height);
                    pDisplay.Invalidate();
                }
                else if (workerArg.Type == WorkArg.WorkType.BIN_TO_ARRAY)
                {

                    pDisplay.Size = new Size(workerArg.Width, workerArg.Height);
                    pDisplay.Invalidate();
                }
            }

            btnConvertImageToArray.Enabled = true;
            btnConvertBinToImage.Enabled = true;
            btnConvertArrayToImage.Enabled = true;
        }

        private void nImageWidth_Enter(object sender, EventArgs e)
        {
            nImageWidth.Select(0, nImageWidth.Text.Length);
        }

        private void nImageHeight_Enter(object sender, EventArgs e)
        {
            nImageHeight.Select(0, nImageHeight.Text.Length);
        }

        private void nImageWidth_Click(object sender, EventArgs e)
        {
            nImageWidth.Select(0, nImageWidth.Text.Length);
        }

        private void nImageHeight_Click(object sender, EventArgs e)
        {
            nImageHeight.Select(0, nImageHeight.Text.Length);
        }
    }

    public class WorkArg
    {
        public enum WorkType
        {
            ARRAY_TO_IMAGE,
            IMAGE_TO_ARRAY,
            BIN_TO_ARRAY,
            UNKNOWN
        }
        WorkType _type;
        string _fileName;
        string[] _line;
        int _width;
        int _height;

        public WorkArg()
        {
            _type = WorkType.UNKNOWN;
            _width = 0;
            _height = 0;
        }
        public WorkType Type
        {
            get { return _type; }
        }
        public string FilePath
        {
            get { return _fileName; }
        }
        public string[] Line
        {
            get { return _line; }
        }
        public int Width
        {
            set { _width = value;}
            get { return _width; }
        }
        public int Height
        {
            set { _height = value;}
            get { return _height; }
        }
        public void setProperty(WorkType type, string path)
        {
            _type = type;
            _line = null;
            _fileName = path;
            _width = 0;
            _height = 0;
        }
        public void setProperty(WorkType type, string path, int width, int height)
        {
            _type = type;
            _line = null;
            _fileName = path;
            _width = width;
            _height = height;
        }
        public void setProperty(WorkType type, string[] line, int width, int height)
        {
            _type = type;
            _line = line;
            _fileName = null;
            _width = width;
            _height = height;
        }
    }
}
