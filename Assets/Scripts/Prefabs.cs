using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Shared access point to all prefabs.
/// </summary>
public class Prefabs : MonoBehaviour
{
    private static Prefabs instance;

    [SerializeField] private GameObject emptySpaceUnit, wallUnit, foodUnit, waterUnit, organizm;

    private Dictionary<string, GameObject> mapUnitsDict;
    [HideInInspector] public Dictionary<string, GameObject> MapUnitsDict { get { return mapUnitsDict; } }

    private void Awake()
    {
        mapUnitsDict = new() { { "Empty", emptySpaceUnit }, { "Wall", wallUnit }, { "Food", foodUnit }, { "Water", waterUnit }, { "Organizm",  organizm } };
        instance = this;
    }

    private Prefabs() { }

    public static Prefabs GetInstance()
    {
        return instance;
    }
}
