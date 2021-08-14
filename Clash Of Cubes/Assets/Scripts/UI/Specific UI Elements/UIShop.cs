using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{
    public Shop shop;
    public GameObject content;
    public UIShopItem itemPrefab;
    public StandardUIController parent;
    
    private bool shelfCreated = false;
    private List<UIShopItem> items = new List<UIShopItem>();

    void OnEnable() {
        CreateShelf();
        ColorItems();
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

    private bool CreateShelf() {
        if (shelfCreated)
            return false;
        shelfCreated = true;

        Vector3 previousPos = Vector3.zero;
        foreach (var item in shop.prefabs)
        {
            Vector3 position = previousPos;
            
            var instance = Instantiate(itemPrefab, position, Quaternion.identity,
                content.transform);

            instance.transform.localPosition = position;
            position.x += 120;
            previousPos = position;

            instance.shop = this;
            instance.prefab = item.GetComponent<BaseBuilding>();

            items.Add(instance);
        }
        return true;
    }

    private void ColorItems() {
        foreach (var item in items) {
            item.available = shop.world.resources > item.job.price;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy(BaseBuilding prefab) {
        shop.Buy(prefab);
    }

    public void Close() {
        parent.CloseMenu();
    }
}
