using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBuilding : BaseBuilding
{
    public ProductionQueue queue = new ProductionQueue();
    [SerializeField] private List<BaseProduction> _production;
    
    public List<BaseProduction> production {
        get {
            if (isWork)
                return _production;
            return null;
        }
    }

    protected override void Launch()
    {

    }

    public void Product(BaseProduction production) {
        if (!isWork)
            return;
        
        queue.Add(production);
    }
    
    protected override void Stop()
    {
        throw new System.NotImplementedException();
    }
}
