using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceNamesEnum {
    Gold = 1,
    Metal = 2,
    Diamond = 3,
}

[System.Serializable]
public class BaseResource
{
    public ResourceNamesEnum name;
    public int count = 0;
}

[System.Serializable]
public class GoldResource: BaseResource {
    public GoldResource() {
        name = ResourceNamesEnum.Gold;
    }
}

[System.Serializable]
public class MetalResource: BaseResource {
    public MetalResource() {
        name = ResourceNamesEnum.Metal;
    }
}

[System.Serializable]
public class DiamondResource: BaseResource {
    public DiamondResource() {
        name = ResourceNamesEnum.Diamond;
    }
}
