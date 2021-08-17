using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuildingActions : MonoBehaviour
{
    public Button info;
    public Button production;
    
    public void Activate(BaseBuilding building) {
        gameObject.SetActive(true);
        info.gameObject.SetActive(true);
        var factory = building as FactoryBuilding;
        if (factory != null) {
            production.gameObject.SetActive(true);
            return;
        }
        production.gameObject.SetActive(false);
    }

    public void Deactivate() {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
