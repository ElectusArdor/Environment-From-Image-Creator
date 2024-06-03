using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using UnityEngine;

/// <summary>
/// Singleton. Used for start/restart modeling.
/// </summary>
public class Starter : MonoBehaviour
{
    private static Starter instance;

    [SerializeField] private Transform envirinmentContainer;
    [SerializeField] private MapColorSettings mcs;
    [SerializeField] private string[] validImageExtensions;
    [SerializeField] private string[] validFileExtensions;

    private Starter() { }

    private void Awake()
    {
        instance = this;
    }

    public static Starter GetInstance() { return instance; }

    public void LoadMapFromFile(string path)
    {
        MapDecoder mc = CheckFilePath(path);
        if (mc != null)
        {
            LvlAssembler lvlCreator = new();
            lvlCreator.CreateEnvironment(mc.TryConvert(path), envirinmentContainer);
        }
        else ShowMessage.WrongFileExtension();
    }

    private MapDecoder CheckFilePath(string path)
    {
        if (validImageExtensions.Contains(Path.GetExtension(path)))
            return new Image2MapConverter(mcs);
        if (validFileExtensions.Contains(Path.GetExtension(path)))
            return new MapDeserializer(mcs);
        return null;
    }
}
