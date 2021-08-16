using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseUIShopItem : MonoBehaviour
{
    [System.NonSerialized] public BaseUIShop shop;
    public Text priceText;
    public Job job;

    public GameObject placer;
    public BaseProduction prefab {
        get {
            return _production;
        }
        set {
            _production = value;
            Instantiate(value, placer.transform);
            job = value.productionJob;
            priceText.text = value.productionJob.price.ToString();
        }
    }

    public bool available {
        set {
            if (value) {
                print(this + "Available");
                GetComponent<Image>().color = new Color(1,1,1,1);
            } else {
                GetComponent<Image>().color = new Color(0,0,0,1);
            }
            GetComponent<Button>().enabled = value;
        }
    }

    private BaseProduction _production;

    public void Close() {
        shop.Close();
    }

    public void Buy()
    {
        shop.Buy(prefab);
    }
}
