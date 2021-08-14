using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BaseResource
{
    public string name;
    public int count = 0;
}

[System.Serializable]
public class GoldResource: BaseResource {
    public GoldResource() {
        name = "Gold";
    }
}

[System.Serializable]
public class MetalResource: BaseResource {
    public MetalResource() {
        name = "Metal";
    }
}

[System.Serializable]
public class DiamondResource: BaseResource {
    public DiamondResource() {
        name = "Diamond";
    }
}
