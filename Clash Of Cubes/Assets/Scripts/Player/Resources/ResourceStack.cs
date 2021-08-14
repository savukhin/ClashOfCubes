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
}
