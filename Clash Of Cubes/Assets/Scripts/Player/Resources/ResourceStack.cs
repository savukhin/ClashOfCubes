using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceStack
{
    [SerializeField]
    public GoldResource gold;
    public MetalResource metal;
    public DiamondResource diamond;
}
