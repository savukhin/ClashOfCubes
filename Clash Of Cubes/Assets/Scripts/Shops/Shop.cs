using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<GameObject> prefabs;
    public World world;

    public void Buy(BaseBuilding prefab) {
        world.StartBuilder(prefab);
    }
}
