using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardUIController : BaseUI
{
    [System.Serializable]
    public class Events {
        // public UnityEngine.Event closeMenu;
        public UnityEngine.Events.UnityEvent closeMenu;
    }
    public Events events;
    public UIShop shop;

    

    public void OpenShop() {
        blackPanel.gameObject.SetActive(true);
        shop.gameObject.SetActive(true);
    }

    public void CloseMenu() {
        events.closeMenu.Invoke();
    }
}
