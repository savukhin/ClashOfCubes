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

    public static bool operator > (ResourceStack stack, Price price) {
        return stack.gold.count > price.gold
            && stack.metal.count > price.metal
            && stack.diamond.count > price.diamonds;
    }

    public static bool operator < (ResourceStack stack, Price price) {
        return stack.gold.count < price.gold
            && stack.metal.count < price.metal
            && stack.diamond.count < price.diamonds;
    }
    
    public static bool operator >= (ResourceStack stack, Price price) {
        return stack.gold.count >= price.gold
            && stack.metal.count >= price.metal
            && stack.diamond.count >= price.diamonds;
    }

    public static bool operator <= (ResourceStack stack, Price price) {
        return stack.gold.count <= price.gold
            && stack.metal.count <= price.metal
            && stack.diamond.count <= price.diamonds;
    }

    public static ResourceStack operator - (ResourceStack stack, Price price) {
        ResourceStack result = stack.MemberwiseClone() as ResourceStack;
        result.gold.count -= price.gold;
        result.metal.count -= price.metal;
        result.diamond.count -= price.diamonds;
        return result;
    }

    public static ResourceStack operator + (ResourceStack stack, BaseResource resource) {
        ResourceStack result = stack.MemberwiseClone() as ResourceStack;
        switch (resource.name)
        {
            case ResourceNamesEnum.Gold:
                result.gold.count += resource.count;
                break;
            case ResourceNamesEnum.Metal:
                result.metal.count += resource.count;
                break;
            case ResourceNamesEnum.Diamond:
                result.diamond.count += resource.count;
                break;
            default:
                break;
        }
        return result;
    }
}
