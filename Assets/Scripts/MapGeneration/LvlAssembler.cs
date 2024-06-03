using UnityEngine;

public class LvlAssembler
{
    public void CreateEnvironment(string[,] map, Transform t)
    {
        Prefabs prefabs = Prefabs.GetInstance();
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for(int j = 0; j < map.GetLength(1); j++)
            {
                GameObject go = GameObject.Instantiate(prefabs.MapUnitsDict[ map[i,j] ]);
                go.transform.SetParent(t);
                go.transform.localPosition = new Vector3(i, 0, j);
            }
        }
    }
}
