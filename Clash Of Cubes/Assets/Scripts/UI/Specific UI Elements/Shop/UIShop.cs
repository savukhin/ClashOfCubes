using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : BaseUIShop
{
    public Shop shop;
    public GameObject content;

    void OnEnable() {
        CreateShelf();
        StartCoroutine("Appearance");
    }

    IEnumerable Appearance() {
        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateShelf();
    }

    private void CreateShelf() {
        if (showcaseCreated)
            return;
        List<BaseProduction> prod = new List<BaseProduction>();
        foreach (var item in shop.prefabs) {
            prod.Add(item.GetComponent<BaseProduction>());
        }
        this.production = prod;
    }

    public override void Buy(BaseProduction prefab) {
        shop.Buy(prefab as BaseBuilding);
        Close();
    }
}
