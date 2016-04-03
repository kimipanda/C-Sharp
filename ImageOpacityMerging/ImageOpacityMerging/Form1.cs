using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImageOpacityMerging
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pic3.Image = OpacityAndMerging(pic1.Image, pic2.Image);
        }

        private Image OpacityAndMerging(Image pic1, Image pic2)
        {
            ColorMatrix Matrix = new ColorMatrix();

            Rectangle rect = new Rectangle(0, 0, pic1.Width, pic1.Height);

            // Opacity Setting
            Matrix.Matrix33 = 0.5f;

            using (Graphics g = Graphics.FromImage(pic1))
            using (ImageAttributes Attributes = new ImageAttributes())
            {
                Attributes.SetColorMatrix(Matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                g.DrawImage(pic2, rect, 0, 0, pic2.Width, pic2.Height, GraphicsUnit.Pixel, Attributes);
            }

            return pic1;
        }
    }
}
