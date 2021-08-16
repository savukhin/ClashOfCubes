using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionQueue
{
    public UnityEngine.Events.UnityEvent producedEvent = new UnityEngine.Events.UnityEvent();
    [System.NonSerialized] public Queue<BaseProduction> queue = new Queue<BaseProduction>();
    [System.NonSerialized] public BaseProduction current;
    public bool isWork = true;

    private void StartProduct(BaseProduction production) {
        current = production;
        current.productionJob.endEvent.AddListener(() => {
            producedEvent.Invoke();
        });
        current.productionJob.Launch();
    }

    public void Add(BaseProduction production) {
        if (current == null && queue.Count == 0) {
            StartProduct(production);
            return;
        } else if (current == null) {
            BaseProduction prod = queue.Dequeue();
            StartProduct(prod);
        }
        queue.Enqueue(production);
    }

    public bool Empty() {
        return queue.Count == 0 && current == null;
    }
}
