using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampBuilding : BaseBuilding
{
    public Camp camp;

    protected override void Launch()
    {
        field.AddCamp(camp);
        // throw new System.NotImplementedException();
    }

    protected override void Stop()
    {
        throw new System.NotImplementedException();
    }
}
