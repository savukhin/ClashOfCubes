using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    public GameObject blackPanel;
    public List<UIResource> golds;
    public List<UIResource> metals;
    public List<UIResource> diamonds;
    public List<UISupply> supplies;
    
    public ResourceStack resources {
        set {
            foreach (var g in golds) {
                g.count = value.gold.count;
                g.max = value.goldCapacity.count;
            }
            foreach (var metal in metals) {
                metal.count = value.metal.count;
                metal.max = value.metalCapacity.count;
            }
            foreach (var diamond in diamonds) {
                diamond.count = value.diamond.count;
                diamond.max = 0;
            }
            foreach (var supply in supplies) {
                supply.current = value.supply.used;
                supply.max = value.supply.capacity;
            }
        }
    }
}
