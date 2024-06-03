public abstract class MapDecoder
{
    protected byte sensitivity;
    protected string redIs, greenIs, blueIs, blackIs, whiteIs;

    public MapDecoder(MapColorSettings mcs)
    {
        this.sensitivity = mcs.Sensitivity;
        this.redIs = mcs.RedIs;
        this.greenIs = mcs.GreenIs;
        this.blueIs = mcs.BlueIs;
        this.blackIs = mcs.BlackIs;
        this.whiteIs = mcs.WhiteIs;
    }

    /// <summary>
    /// Convert image to 
    /// </summary>
    /// <param name="path">Full file path</param>
    public abstract string[,] TryConvert(string path);
}
