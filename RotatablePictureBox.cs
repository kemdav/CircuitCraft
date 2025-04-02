using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitCraft
{
    public class RotatablePictureBox : PictureBox
    {
        private float _rotationAngle;

        [Category("Appearance")]
        [Description("Rotation angle in degrees.")]
        [DefaultValue(0f)]
        public float RotationAngle
        {
            get { return _rotationAngle; }
            set
            {
                _rotationAngle = value;
                Invalidate(); 
            }
        }

        [Browsable(false)] 
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new PictureBoxSizeMode SizeMode
        {
            get { return base.SizeMode; }
            set { base.SizeMode = value; }
        }


        public RotatablePictureBox()
        {
            base.SizeMode = PictureBoxSizeMode.Normal;
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            Image img = this.Image;
            if (img == null)
            {
                base.OnPaintBackground(e);
                return; 
            }

            e.Graphics.Clear(this.BackColor);

            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality; // Can also help

            float cx = this.Width / 2f;
            float cy = this.Height / 2f;

            e.Graphics.TranslateTransform(cx, cy);
            e.Graphics.RotateTransform(this.RotationAngle);
            RectangleF drawRect = new RectangleF(
                                   -this.Width / 2f,  
                                   -this.Height / 2f,
                                   this.Width,        
                                   this.Height);
            e.Graphics.DrawImage(
            img,
            drawRect, 
            new RectangleF(0, 0, img.Width, img.Height),
            GraphicsUnit.Pixel);
            e.Graphics.ResetTransform();
        }
    }
}
