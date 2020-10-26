#region .NET Base Class Namespace Imports
using System;
using System.Drawing;
using System.Drawing.Imaging;
#endregion

#region Compiled Technologies Assemblies
using CompiledTechnologies.Constructs;
#endregion

namespace CompiledTechnologies.Utilities
{
    public class CaptureUtility
    {
        #region *********************************** Public Methods ****************************************
        public Bitmap RotateImage(Bitmap image, PixelFormat pixelformat, float angle)
        {
            return RotateImage(image, pixelformat, new PointF((float)image.Width / 2, (float)image.Height / 2), angle);
        }
        public Bitmap RotateImage(Bitmap image, PixelFormat pixelformat, PointF offset, float angle)
        {
            if (image == null) { throw new ArgumentNullException(nameof(image)); }
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height, pixelformat);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            Graphics g = Graphics.FromImage(rotatedBmp);
            g.TranslateTransform(offset.X, offset.Y);
            g.RotateTransform(angle);
            g.TranslateTransform(-offset.X, -offset.Y);
            g.DrawImage(image, new PointF(0, 0));
            return rotatedBmp;
        }
        public Bitmap RotateImage(Bitmap image, PixelFormat pixelformat, PointF offset, byte bAngle)
        {
            float angle;
            if (image == null) { throw new ArgumentNullException(nameof(image)); }
            if (bAngle > 0xff / 2)
            {
                angle = (float)((bAngle - M280IMGDEF.IMG_ANGLE) * 0.1);
            }
            else if (bAngle == 0xff / 2)
            {
                angle = 0;
            }
            else
            {
                angle = -(float)((0xff / 2 - bAngle) * 0.1);
            }
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height, pixelformat);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            Graphics g = Graphics.FromImage(rotatedBmp);
            g.TranslateTransform(offset.X, offset.Y);
            g.RotateTransform(angle);
            g.TranslateTransform(-offset.X, -offset.Y);
            g.DrawImage(image, new PointF(0, 0));
            return rotatedBmp;
        }
        public byte ConverDEGtoByte(float angle)
        {
            byte byt;
            if (angle > 0)
            {
                if (Math.Round(angle * 10) > M280IMGDEF.IMG_ANGLE)
                {
                    byt = 0xff;
                }
                else
                {
                    byt = (byte)(M280IMGDEF.IMG_ANGLE + Math.Round(angle * 10));
                }
            }
            else
            {
                angle = Math.Abs(angle);
                if (Math.Round(angle * 10) > M280IMGDEF.IMG_ANGLE)
                {
                    byt = 0x0;
                }
                else
                {
                    byt = (byte)(M280IMGDEF.IMG_ANGLE - Math.Round(angle * 10));
                }
            }
            return byt;
        }
        #endregion
    }
}
