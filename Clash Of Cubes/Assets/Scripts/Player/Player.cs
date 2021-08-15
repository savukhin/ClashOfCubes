using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ResourceStack resources;
    public Client client;
    public World world;
    
    // Start is called before the first frame update
    void Start()
    {
        world.resources = resources;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeResource(BaseResource resource) {
        resources += resource;
        world.resources = resources;
    }
}
