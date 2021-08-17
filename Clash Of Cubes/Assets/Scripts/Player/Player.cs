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

    public void AddStorage(Storage storage) {
        resources.storages.Add(storage);
        world.resources = resources;
    }

    public void AddCamp(Camp camp) {
        resources.supply.Add(camp);
        world.resources = resources;
    }

    public bool AddUnit(BaseUnit unit) {
        if (!resources.supply.Add(unit))
            return false;
        world.resources = resources;
        return true;
    }
}
