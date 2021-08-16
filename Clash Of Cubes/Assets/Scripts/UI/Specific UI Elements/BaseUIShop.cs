using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseUIShop : MonoBehaviour
{
    public BaseUIShopItem itemPrefab;
    public StandardUIController parent;
    public AdditiveScrollView showcase;

    private List<BaseUIShopItem> items = new List<BaseUIShopItem>();
    protected bool showcaseCreated = false;

    public List<BaseProduction> production {
        set {
            // if (showcaseCreated)
            //     return;
            // showcaseCreated = true;
            // print("Clear pls");
            showcase.Clear();
            foreach (var item in items)
            {
                Destroy(item.gameObject);
            }
            items = new List<BaseUIShopItem>();
            
            Vector3 previousPos = Vector3.zero;
            foreach (var item in value) {
                // Vector3 position = previousPos;
                
                // var instance = Instantiate(itemPrefab, position, Quaternion.identity,
                //     showcase.content.transform);
                var instance = showcase.Add(itemPrefab.gameObject)
                        .GetComponent<BaseUIShopItem>();

                // instance.transform.localPosition = position;
                // position.x += 120;
                // previousPos = position;

                instance.shop = this;
                instance.prefab = item;
                items.Add(instance);                
            }
            ColorItems();
        }
    }

    protected void ColorItems() {
        foreach (var item in items) {
            item.available = parent.UI.resources >= item.job.price;
        }
    }

    public void Close() {
        parent.CloseMenu();
    }

    public abstract void Buy(BaseProduction prefab);
}
