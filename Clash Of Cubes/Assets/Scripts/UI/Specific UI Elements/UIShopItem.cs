using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopItem : MonoBehaviour
{
    public GameObject placer;
    public Text priceText;
    public Job job;
    public BaseBuilding prefab {
        get{
            return m_prefab;
        }
        set {
            m_prefab = value;
            Instantiate(value, placer.transform);
            job = value.buildJob;
            priceText.text = value.buildJob.price.ToString();
        }
    }
    public bool available {
        set {
            if (value)
                GetComponent<Image>().color = new Color(1,1,1,1);
            else
                GetComponent<Image>().color = new Color(0,0,0,1);
            GetComponent<Button>().enabled = value;
        }
    }

    [System.NonSerialized]
    public UIShop shop;
    private BaseBuilding m_prefab;

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
