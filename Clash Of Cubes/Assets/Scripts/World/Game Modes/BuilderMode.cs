using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderMode : BaseMode
{
    public Field field;
    private BaseBuilding _building;
    private World world;

    public BaseBuilding building  {
        get {
            return _building;
        }
        set {
            _building = value;
        }
    }

    IEnumerator ProjectBuilding() {
        for (;;) {
            building.transform.position = field.PlaceBuilding(building);
            yield return null;
        }
    }

    public void Launch(World world, BaseBuilding prefab)
    {
        base.Launch();
        field.gameObject.SetActive(true);
        this.world = world;
        building = Instantiate(prefab, field.PlaceBuilding(prefab), Quaternion.identity);
        StartCoroutine("ProjectBuilding");
    }

    IEnumerator DeniedBuildingAnimation() {
        building.transform.localScale = Vector3.one;

        float duration = 0.1f;
        Vector3 deltaScale = Vector3.one * 0.05f;
        for (float time = 0; time < duration; time += Time.deltaTime) {
            building.transform.localScale += deltaScale;
            yield return null;
        }
        for (float time = 0; time < duration; time += Time.deltaTime) {
            building.transform.localScale -= deltaScale;
            yield return null;
        }

        building.transform.localScale = Vector3.one;
    }

    public void Build() {
        if (field.Build(building)) {
            world.Buy(building.buildJob.price);
            world.SetStandardMode();
        } else {
            print("Unable to Build!");
            StartCoroutine("DeniedBuildingAnimation");
        }
    }

    public void Cancel() {
        Destroy(building.gameObject);
        world.SetStandardMode();
    }

    public override void Stop()
    {
        base.Stop();
        field.gameObject.SetActive(false);
        StopAllCoroutines();
    }
}
