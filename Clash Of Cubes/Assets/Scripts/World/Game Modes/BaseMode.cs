using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMode : MonoBehaviour
{
    public BaseUI UI;

    // public BaseMode() : base() {
    //     UI.gameObject.SetActive(true);
    // }
    
    // ~BaseMode() {
    //     UI.gameObject.SetActive(false);
    // }

    public virtual void Launch() {
        UI.gameObject.SetActive(true);
    }

    public virtual void Stop() {
        UI.gameObject.SetActive(false);
    }
}
