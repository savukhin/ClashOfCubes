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

    public bool Produced(BaseProduction production) {
        var unit = production as BaseUnit;
        if (unit != null) {
            if (!field.AddUnit(unit)) {
                return false;
            }
            return true;
        }
        return false;
    }

    protected override void Launch()
    {
        queue.factory = this;
        // queue.producedEvent.RemoveAllListeners();
        // queue.producedEvent.AddListener(() => {
        //     Produced(queue.lastProduced);
        // });
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
