using UnityEngine;

/// <summary>
/// Legend for decoding the image or byte array.
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObject/MapColorSettings")]
public class MapColorSettings : ScriptableObject
{
    private enum colorsMeaning { Empty, Wall, Water, Food, Organizm };

    [SerializeField] private byte sensitivity;
    [SerializeField] private colorsMeaning redIs;
    [SerializeField] private colorsMeaning greenIs;
    [SerializeField] private colorsMeaning blueIs;
    [SerializeField] private colorsMeaning blackIs;
    [SerializeField] private colorsMeaning whiteIs;

    public byte Sensitivity { get { return sensitivity; } }
    public string RedIs { get {  return redIs.ToString(); } }
    public string GreenIs { get { return greenIs.ToString(); } }
    public string BlueIs { get { return blueIs.ToString(); } }
    public string BlackIs { get { return blackIs.ToString(); } }
    public string WhiteIs { get { return whiteIs.ToString(); } }
}
