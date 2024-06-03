using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct OrganizmData : IInherited
{
    private Dictionary<string, float> inheritedStats;

    private float maxHP, maxStamina, maxIntelligence, maxMind, maxStrength, maxVelocity, maxSatiety;

    private float? baseMood, equilibrium, minSatiety;

    private float hp, stamina, intelligence, mind, strength, velocity, satiety, mood;

    public Dictionary<string, float> InheritedStats { get { return inheritedStats; } set { inheritedStats = value; } }

    public float MaxHP;
}
