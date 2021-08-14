using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopItem : MonoBehaviour
{
    public GameObject placer;
    public Text priceText;
    public BaseBuilding prefab;

    [System.NonSerialized]
    public UIShop shop;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Close() {
        shop.Close();
    }
    
    public void Buy()
    {
        shop.Buy(prefab);
    }
}
