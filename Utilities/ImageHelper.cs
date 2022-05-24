//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Drawing;
//using System.Drawing.Imaging;
//using System.IO;

//namespace BackOffice.Infrastructure.CrossCutting.Utilities
//{
//    public class ImageHelper
//    {
//        public static Image ResizeImage(int newWidth, int newHeight, Stream image)
//        {
//            return Resize(newWidth, newHeight, image);
//        }

//        public static Image ResizeImage(int newWidth, Stream image)
//        {
//            Image imgPhoto = Image.FromStream(image);

//            int sourceWidth = imgPhoto.Width;
//            int sourceHeight = imgPhoto.Height;


//            int newHeight = Convert.ToInt32((Convert.ToDecimal(newWidth) / Convert.ToDecimal(sourceWidth)) * Convert.ToDecimal(sourceHeight));


//            return Resize(newWidth, newHeight, image);
//        }

//        private static Image Resize(int newWidth, int newHeight, Stream image)
//        {
//            Image imgPhoto = Image.FromStream(image);

//            int sourceWidth = imgPhoto.Width;
//            int sourceHeight = imgPhoto.Height;

//            //Consider vertical pics
//            if (sourceWidth < sourceHeight)
//            {
//                int buff = newWidth;

//                newWidth = newHeight;
//                newHeight = buff;
//            }

//            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
//            float nPercent = 0, nPercentW = 0, nPercentH = 0;

//            nPercentW = ((float)newWidth / (float)sourceWidth);
//            nPercentH = ((float)newHeight / (float)sourceHeight);
//            if (nPercentH < nPercentW)
//            {
//                nPercent = nPercentH;
//                destX = System.Convert.ToInt16((newWidth -
//                          (sourceWidth * nPercent)) / 2);
//            }
//            else
//            {
//                nPercent = nPercentW;
//                destY = System.Convert.ToInt16((newHeight -
//                          (sourceHeight * nPercent)) / 2);
//            }

//            int destWidth = (int)(sourceWidth * nPercent);
//            int destHeight = (int)(sourceHeight * nPercent);

//            Bitmap bmPhoto = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);
//            try
//            {
//                bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
//            }
//            catch
//            {
//                bmPhoto.SetResolution(200, 200);
//            }

//            Graphics grPhoto = Graphics.FromImage(bmPhoto);
//            grPhoto.Clear(Color.Black);
//            grPhoto.InterpolationMode =
//                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

//            grPhoto.DrawImage(imgPhoto,
//                new Rectangle(destX, destY, destWidth, destHeight),
//                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
//                GraphicsUnit.Pixel);

//            grPhoto.Dispose();
//            imgPhoto.Dispose();
//            return bmPhoto;
//        }

//    }
//}
