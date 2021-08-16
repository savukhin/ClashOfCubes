using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRouter : MonoBehaviour
{
    public StandardUIController standard;
    public BuilderUIController builder;
    [System.NonSerialized] public World world;

    public ResourceStack resources {
        set {
            standard.resources = value;
            builder.resources = value;
        }
        get {
            return world.resources;
        }
    }

    void Start() {
        standard.UI = this;
    }
    
    public void ChooseBuilding(BaseBuilding building) {
        standard.ChooseBuilding(building);
    }
}
