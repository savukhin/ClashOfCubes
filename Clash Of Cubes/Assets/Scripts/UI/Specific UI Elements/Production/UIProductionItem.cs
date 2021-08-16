using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProductionItem : MonoBehaviour
{
    public GameObject placer;
    public Text priceText;
    public Job job;
    public BaseProduction prefab {
        get{
            return m_prefab;
        }
        set {
            m_prefab = value;
            Instantiate(value, placer.transform);
            job = value.productionJob;
            priceText.text = value.productionJob.price.ToString();
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
    public UIProductionPanel panel;
    private BaseProduction m_prefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Close() {
        panel.Close();
    }
    
    public void Buy()
    {
        panel.Buy(prefab);
    }
}
