using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    public GameObject blackPanel;
    public UIResource gold;
    public UIResource metal;
    public UIResource diamonds;
    
    public ResourceStack resources {
        set {
            gold.count = value.gold.count;
            metal.count = value.metal.count;
            diamonds.count = value.diamond.count;
            gold.max = value.goldCapacity.count;
            metal.max = value.metalCapacity.count;
            diamonds.max = 0;
        }
        get {
            ResourceStack resources = new ResourceStack();
            resources.gold.count = gold.count;
            resources.metal.count = metal.count;
            resources.diamond.count = diamonds.count;
            return resources;
        }
    }
}
