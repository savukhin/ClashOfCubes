using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShop : MonoBehaviour
{
    public Shop shop;
    public GameObject content;
    public UIShopItem itemPrefab;
    public StandardUIController parent;

    void OnEnable() {
        StartCoroutine("Appearance");
    }

    IEnumerable Appearance() {
        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
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
