using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceStack
{
    public List<Storage> storages = new List<Storage>();
    public Supply supply = new Supply();
    public DiamondResource diamond = new DiamondResource();

    public BaseResource gold {
        get {
            return SumStorages().gold;
        }
    }
    public BaseResource metal {
        get {
            return SumStorages().metal;
        }
    }
    public BaseResource goldCapacity {
        get {
            return SumStorages().goldCapacity;
        }
    }
    public BaseResource metalCapacity {
        get {
            return SumStorages().metalCapacity;
        }
    }

    private Storage SumStorages() {
        Storage result = new Storage();
        for (int i = 0; i < storages.Count; i++)
            result += storages[i];
        return result;
    }

    public static bool operator > (ResourceStack stack, Price price) {
        return stack.SumStorages() > price
                && stack.diamond.count > price.diamonds;
    }

    public static bool operator < (ResourceStack stack, Price price) {
        return stack.SumStorages() < price
                || stack.diamond.count < price.diamonds;
    }
    
    public static bool operator >= (ResourceStack stack, Price price) {
        return stack.SumStorages() >= price
                && stack.diamond.count >= price.diamonds;
    }

    public static bool operator <= (ResourceStack stack, Price price) {
        return stack.SumStorages() <= price
                || stack.diamond.count <= price.diamonds;
    }

    public static ResourceStack operator - (ResourceStack stack, Price price) {
        ResourceStack result = stack.MemberwiseClone() as ResourceStack;
        result.diamond.count -= price.diamonds;

        for (int i = 0; i < result.storages.Count; i++) {
            if (result.storages[i] > price) {
                result.storages[i] = (result.storages[i] - price).Normalize();
                break;
            }
            Storage newStorage = result.storages[i] - price;
            Price newPrice = price - result.storages[i];
            result.storages[i] = newStorage.Normalize();
            price = newPrice.Normalize();
        }
        return result;
    }

    public static ResourceStack operator + (ResourceStack stack, BaseResource resource) {
        ResourceStack result = stack.MemberwiseClone() as ResourceStack;
        for (int i = 0; i < result.storages.Count; i++) {
            if (result.storages[i].ExcessAdding(resource).count <= 0) {
                result.storages[i] += resource;
                break;
            }
            Storage newStorage = result.storages[i] + resource;
            BaseResource newResource = resource - result.storages[i];
            result.storages[i] = newStorage.Normalize();
            resource = newResource.Normalize();
        }
        return result;
    }
}
