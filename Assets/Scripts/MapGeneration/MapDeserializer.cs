using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDeserializer : MapDecoder
{
    public MapDeserializer(MapColorSettings mcs) : base(mcs) { }

    public override string[,] TryConvert(string path)
    {
        return null;
    }
}
