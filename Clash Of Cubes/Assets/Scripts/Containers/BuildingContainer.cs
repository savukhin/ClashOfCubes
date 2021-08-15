using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingContainer : MonoBehaviour
{
    [System.Serializable]
    public class Item {
        public BaseBuilding building;
        public string name;
    }

    public List<Item> buildings;

    private Dictionary<string, BaseBuilding> dict = new Dictionary<string, BaseBuilding>();

    void Start() {
        DontDestroyOnLoad(this);
        foreach (var item in buildings)
        {
            dict.Add(item.name, item.building);
        }
    }

    public BaseBuilding find(string name) {
        return dict[name];
    }
}
