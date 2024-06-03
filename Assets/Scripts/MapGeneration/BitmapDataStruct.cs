using System;
using System.Drawing.Imaging;

/// <summary>
/// Contains byte array of rgb values, heigt and width of image.
/// </summary>
[Serializable]
public struct BitmapDataStruct
{
    private byte[] rgbValues;
    private int mapStride, mapHeight;
    private PixelFormat pixFormat;

    public byte[] RGBValues { get { return rgbValues; } private set { rgbValues = value; } }
    public int MapStride { get { return mapStride; } private set { mapStride = value; } }
    public int MapHeight { get {  return mapHeight; } private set {  mapHeight = value; } }
    public PixelFormat PixFormat { get { return pixFormat; } private set { pixFormat = value; } }

    public BitmapDataStruct(byte[] rgbValues, int mapStride, int mapHeight, PixelFormat pixelFormat)
    {
        this.rgbValues = rgbValues;
        this.mapStride = mapStride;
        this.mapHeight = mapHeight;
        this.pixFormat = pixelFormat;
    }
}
