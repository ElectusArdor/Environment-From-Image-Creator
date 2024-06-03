using System;
using UnityEngine;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Collections.Generic;

public class Image2MapConverter : MapDecoder
{
    private Dictionary<PixelFormat, int> acceptablePixelFormats = new() {
        { PixelFormat.Format24bppRgb, 3 },
        { PixelFormat.Format32bppRgb, 4 },
        { PixelFormat.Format32bppArgb, 4 },
        { PixelFormat.Format32bppPArgb, 4 } };

    public Image2MapConverter(MapColorSettings mcs) : base(mcs) { }

    public override string[,] TryConvert(string path)
    {
        Bitmap bitmap = LoadImg(path);
        if (bitmap != null)
            return CreateArray(bitmap);
        else return null;
    }

    private Bitmap LoadImg(string path)
    {
        try
        {
            Bitmap imgBitmap = new Bitmap(path);
            return imgBitmap;
        }
        catch (Exception e) { Debug.LogException(e); }
        return null;
    }

    private BitmapDataStruct CopyDataFromMemory(Bitmap bitmap)
    {
        Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
        PixelFormat pixFormat = bitmap.PixelFormat;
        BitmapData imgBitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, pixFormat); // Locking an image dataset in memory
        IntPtr ptr = imgBitmapData.Scan0;

        int numBytes = imgBitmapData.Stride * imgBitmapData.Height;
        byte[] rgbValues = new byte[numBytes];                                          //  Create data array
        Marshal.Copy(ptr, rgbValues, 0, numBytes);                                      //  Copying dataset to array
        bitmap.UnlockBits(imgBitmapData);

        BitmapDataStruct bds = new BitmapDataStruct(rgbValues, imgBitmapData.Stride, imgBitmapData.Height, pixFormat);
        return bds;
    }

    private int? ByteOffset(PixelFormat pf)
    {
        if (acceptablePixelFormats.ContainsKey(pf))
            return acceptablePixelFormats[pf];
        return null;
    }

    private string[,] CreateArray(Bitmap bitmap)
    {
        BitmapDataStruct bitmapData = CopyDataFromMemory(bitmap);

        int? offset = ByteOffset(bitmapData.PixFormat);
        if (!offset.HasValue)
            return null;

        int mapWidth = bitmapData.MapStride / (int)offset;
        string[,] stringMap = new string[mapWidth, bitmapData.MapHeight];
        for (int j = 0; j < bitmapData.MapHeight; j++)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                int currentByte = bitmapData.MapStride * j + i * (int)offset;
                if (bitmapData.RGBValues[currentByte] > sensitivity)
                {
                    if (bitmapData.RGBValues[currentByte + 1] > sensitivity | bitmapData.RGBValues[currentByte + 2] > sensitivity)
                        stringMap[i, j] = whiteIs;
                    else stringMap[i, j] = blueIs;
                }
                else if (bitmapData.RGBValues[currentByte + 1] > sensitivity) stringMap[i, j] = greenIs;
                else if (bitmapData.RGBValues[currentByte + 2] > sensitivity) stringMap[i, j] = redIs;
                else stringMap[i, j] = blackIs;
            }
        }
        return stringMap;
    }
}

