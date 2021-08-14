using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRouter : MonoBehaviour
{
    public StandardUIController standard;
    public BuilderUIController builder;

    public ResourceStack resources {
        set {
            standard.resources = value;
            builder.resources = value;
        }
        get {
            return standard.resources;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
