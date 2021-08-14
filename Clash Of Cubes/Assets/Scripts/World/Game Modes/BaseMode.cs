using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ModeInterface {
    public void Launch();
    public void Stop();
}

public class BaseMode : MonoBehaviour, ModeInterface
{
    public BaseUI UI;

    public virtual void Launch() {
        UI.gameObject.SetActive(true);
    }

    public virtual void Stop() {
        UI.gameObject.SetActive(false);
    }
}
