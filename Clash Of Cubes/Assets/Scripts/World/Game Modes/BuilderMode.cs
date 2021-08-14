using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderMode : BaseMode
{
    public Field field;
    private BaseBuilding m_building;
    private World world;

    public BaseBuilding building  {
        get {
            return m_building;
        }
        set {
            m_building = value;
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

    public void Build() {
        // print("Ability to built = " + field.AbleToBuild(building));
        
        print("Ability to built = " + field.MakeBusyForBuilding(building));
        world.SetStandardMode();
    }

    public void Cancel() {
        Destroy(building);
        world.SetStandardMode();
    }

    public override void Stop()
    {
        base.Stop();
        field.gameObject.SetActive(false);
        StopAllCoroutines();
    }
}
