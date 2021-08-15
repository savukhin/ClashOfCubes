using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Storage
{
    public GoldResource gold = new GoldResource();
    public MetalResource metal = new MetalResource();
    public GoldResource goldCapacity = new GoldResource();
    public MetalResource metalCapacity = new MetalResource();

    public Storage Zero() {
        var storage = this.MemberwiseClone() as Storage;
        storage.gold.count = 0;
        storage.metal.count = 0;
        return storage;
    }

    public Storage Normalize() {
        Storage storage = this.MemberwiseClone() as Storage;
        gold = gold.Normalize() as GoldResource;
        metal = metal.Normalize() as MetalResource;
        return storage;
    }

    public BaseResource ExcessAdding(BaseResource resource) {
        BaseResource result = resource.Clone() as BaseResource;
        switch (resource.name)
        {
            case ResourceNamesEnum.Gold:
                result.count = resource.count - (this.goldCapacity.count - this.gold.count);
                break;
            case ResourceNamesEnum.Metal:
                result.count = resource.count - (this.metal.count - this.metal.count);
                break;
            default:
                break;
        }
        return result;
    }

    public static bool operator > (Storage storage, Price price) {
        return storage.gold.count > price.gold
            && storage.metal.count > price.metal;
    }

    public static bool operator < (Storage storage, Price price) {
        return storage.gold.count < price.gold
            || storage.metal.count < price.metal;
    }
    
    public static bool operator >= (Storage storage, Price price) {
        return storage.gold.count >= price.gold
            && storage.metal.count >= price.metal;
    }

    public static bool operator <= (Storage storage, Price price) {
        return storage.gold.count <= price.gold
            && storage.metal.count <= price.metal;
    }

    public static Storage operator - (Storage storage, Price price) {
        Storage result = storage.MemberwiseClone() as Storage;
        result.gold.count -= price.gold;
        result.metal.count -= price.metal;
        return result;
    }

    public static Price operator - (Price price, Storage storage) {
        Price result = price.Clone();
        result.gold -= storage.gold.count;
        result.metal -= storage.metal.count;
        return result;
    }
    public static BaseResource operator - (BaseResource resource, Storage storage) {
        BaseResource result = resource.Clone();
        switch (resource.name)
        {
            case ResourceNamesEnum.Gold:
                result.count -= storage.gold.count;
                break;
            case ResourceNamesEnum.Metal:
                result.count -= storage.metal.count;
                break;
            default:
                break;
        }
        return result;
    }

    public static Storage operator + (Storage storage, BaseResource resource) {
        Storage result = storage.MemberwiseClone() as Storage;
        switch (resource.name)
        {
            case ResourceNamesEnum.Gold:
                result.gold.count 
                    = Mathf.Clamp(result.gold.count + resource.count, 0, result.goldCapacity.count);
                break;
            case ResourceNamesEnum.Metal:
                result.metal.count 
                    = Mathf.Clamp(result.metal.count + resource.count, 0, result.metalCapacity.count);
                break;
            default:
                break;
        }
        return result;
    }

    public static Storage operator + (Storage storage1, Storage storage2) {
        Storage result = new Storage();
        result.goldCapacity.count = storage1.goldCapacity.count + storage2.goldCapacity.count;
        result.metalCapacity.count = storage1.metalCapacity.count + storage2.metalCapacity.count;
        result.gold.count = storage1.gold.count + storage2.gold.count;
        result.metal.count = storage1.metal.count + storage2.metal.count;
        return result;
    }
}
