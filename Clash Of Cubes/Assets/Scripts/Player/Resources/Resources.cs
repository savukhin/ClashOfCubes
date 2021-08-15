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
    public BaseResource Normalize() {
        BaseResource resource = this.MemberwiseClone() as BaseResource;
        if (resource.count < 0)
            resource.count = 0;
        return resource;
    }
    public BaseResource Clone() {
        BaseResource resource = new BaseResource();
        resource.name = name;
        resource.count = count;
        return resource;
    }
}

[System.Serializable]
public class LimitedResource : BaseResource
{
    // public int storage;
}

[System.Serializable]
public class GoldResource: LimitedResource {
    public GoldResource() {
        name = ResourceNamesEnum.Gold;
    }
}

[System.Serializable]
public class MetalResource: LimitedResource {
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
