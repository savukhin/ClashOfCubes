using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBuilding : BaseBuilding
{
    public Storage storage;
    protected override void Launch()
    {
        field.AddStorage(storage);
    }

    protected override void Stop()
    {
    }
}
