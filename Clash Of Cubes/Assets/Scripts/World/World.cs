using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public enum ModesEnum {
        Standard = 1,
        Builder = 2
    }

    public StandardMode standardMode;
    public BuilderMode builderMode;
    public Camera mainCamera;
    public UIRouter UI;
    
    public ResourceStack resources {
        get {
            return m_resources;
        }
        set {
            m_resources = value;
            UI.resources = value;
        }
    }

    private BaseMode currentMode;
    private ResourceStack m_resources;
    

    void Start() {
        currentMode = standardMode;
    }

    public void StartBuilder(BaseBuilding prefab) {
        Vector3 position = Vector3.back;
        currentMode.Stop();
        builderMode.Launch(this, prefab);
        currentMode = builderMode;
    }

    public void StopBuilder() {
        if (currentMode.GetType() != typeof(BuilderMode)) {
            print("You are not in builder mode!");
            return;
        }
        Destroy(currentMode);
        currentMode = Instantiate(standardMode);
    }

    public void SetStandardMode() {
        currentMode.Stop();
        standardMode.Launch();
        currentMode = standardMode;
    }
}
