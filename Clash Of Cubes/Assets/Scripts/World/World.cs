using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public StandardMode standardMode;
    public BuilderMode builderMode;
    public Camera mainCamera;
    public enum ModesEnum {
        Standard = 1,
        Builder = 2
    }

    private BaseMode currentMode;

    void Start() {
        // if (mode == ModesEnum.Standard)
        currentMode = standardMode;
    }

    public void StartBuilder(BaseBuilding prefab) {
        // Destroy(currentMode);
        Vector3 position = Vector3.back;
        // currentMode = new BuilderMode(prefab, position);
        currentMode.Stop();
        // builderMode.building = Instantiate(prefab, position, Quaternion.identity);
        builderMode.Launch(this, prefab);
        currentMode = builderMode;
        // currentMode.Launch();
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
