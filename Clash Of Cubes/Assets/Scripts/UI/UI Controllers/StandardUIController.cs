using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandardUIController : BaseUI
{
    [System.Serializable]
    public class Events {
        public UnityEngine.Events.UnityEvent closeMenu;
    }
    public Events events;
    public UIShop shop;
    public UIBuildingActions buildingActionsPanel;
    public UIBuildingInfo buildingInfo;
    public UIProductionPanel productionPanel;
    [System.NonSerialized] public UIRouter UI;

    public void OpenShop() {
        blackPanel.gameObject.SetActive(true);
        shop.gameObject.SetActive(true);
    }

    public void CloseMenu() {
        events.closeMenu.Invoke();
    }

    public void ChooseBuilding(BaseBuilding building) {
        if (building == null) {
            // buildingActionsPanel.SetActive(false);
            buildingActionsPanel.Deactivate();
            return;
        }
        // buildingActionsPanel.SetActive(true);
        buildingActionsPanel.Activate(building);
        buildingInfo.building = building;
        if (building.GetType() == typeof(FactoryBuilding)) {
            var factory = building as FactoryBuilding;
            productionPanel.production = factory.production;
            productionPanel.factory = factory;
        }
    }

    public bool Buy(BaseProduction production) {
        return UI.Buy(production);
    }
}
