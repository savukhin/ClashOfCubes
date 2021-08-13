using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardUIController : BaseUI
{
    public GameObject blackPanel;
    public UIResource gold;
    public UIResource metal;
    public UIResource diamonds;
    public UIShop shop;

    public void OpenShop() {
        blackPanel.gameObject.SetActive(true);
        shop.gameObject.SetActive(true);
    }

    public void CloseMenu() {
        blackPanel.SetActive(false);
        shop.gameObject.SetActive(false);
    }
}
