using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseResource
{
    public string name;
    public int count = 0;
}

public class GoldResource: BaseResource {
    public GoldResource() {
        name = "Gold";
    }
}

public class MetalResource: BaseResource {
    public MetalResource() {
        name = "Metal";
    }
}

public class DiamondResource: BaseResource {
    public DiamondResource() {
        name = "Diamond";
    }
}
