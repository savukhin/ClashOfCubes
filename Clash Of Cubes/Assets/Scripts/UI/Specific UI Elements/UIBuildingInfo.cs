using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuildingInfo : MonoBehaviour
{
    public Text upgradeInfoText;
    public GameObject placer;
    public Button upgradeButton;
    public BaseBuilding building {
        set {
            if (_building != null)
                Destroy(_building.gameObject);
            
            _building = Instantiate(value, placer.transform);
            _building.transform.localPosition = Vector3.zero;
            
            if (_building.nextLevel == null) {
                upgradeButton.GetComponentInChildren<Text>().text = "Max level";
                upgradeButton.enabled = false;
            } else {
                upgradeButton.GetComponentInChildren<Text>().text = "Upgrade";
                upgradeButton.enabled = true;
            }
        }
    }

    private BaseBuilding _building;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
