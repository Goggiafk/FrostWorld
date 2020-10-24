using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Recepies
{
    Hammer,
    SolarPanel,
    Accum,
    Repair,
}

[System.Serializable]
public class Recipe
{
    public List<ResourceInfo> recepies;
    public Recepies rec;
}
