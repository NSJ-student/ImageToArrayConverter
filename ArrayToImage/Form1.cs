using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayToImage
{
    public partial class Form1 : Form
    {
        Bitmap TestImage;
        public Form1()
        {
            InitializeComponent();
            TestImage = null;
        }

        private void pDisplay_Paint(object sender, PaintEventArgs e)
        {
            if(TestImage != null)
            {
                e.Graphics.DrawImage(TestImage, new Rectangle(0, 0, TestImage.Width, TestImage.Height));
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

            TestImage = new Bitmap(width, height);
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    Color color = Color.FromArgb((int)array[col + row * width]);
                    TestImage.SetPixel(col, row, color);
                }
            }

            pDisplay.Size = new Size(width, height);
            pDisplay.Invalidate();
        }

        private void btnConvertImageToArray_Click(object sender, EventArgs e)
        {

        }
    }
}
