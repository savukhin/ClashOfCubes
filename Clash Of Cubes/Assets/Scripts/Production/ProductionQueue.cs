using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionQueue
{
    public UnityEngine.Events.UnityEvent producedEvent = new UnityEngine.Events.UnityEvent();
    public UnityEngine.Events.UnityEvent stopEvent = new UnityEngine.Events.UnityEvent();
    public UnityEngine.Events.UnityEvent resumeEvent = new UnityEngine.Events.UnityEvent();
    [System.NonSerialized] public Queue<BaseProduction> queue = new Queue<BaseProduction>();
    [System.NonSerialized] public BaseProduction current;
    public BaseProduction lastProduced;
    public FactoryBuilding factory;
    public bool isWork = true;

    private class CoroutineHolder : MonoBehaviour { }
 
    private static CoroutineHolder _runner;
    private static CoroutineHolder runner {
        get {
            if (_runner == null) {
                _runner = new GameObject("Static Corotuine Runner").AddComponent<CoroutineHolder>();
            }
            return _runner;
        }
    }

    IEnumerator TryProduce(BaseProduction production) {
        lastProduced = current;
        while(factory.Produced(production) == false)
            yield return null;
        current = null;
        Next();
        producedEvent.Invoke();
    }

    private void StartProduct(BaseProduction production) {
        current = production;
        current.productionJob.endEvent.AddListener(() => {
            runner.StartCoroutine(TryProduce(current));
        });
        current.productionJob.Launch();
    }

    private void Next() {
        if (queue.Count > 0)
            StartProduct(queue.Dequeue());
    }

    public void Add(BaseProduction production) {
        if (current == null && queue.Count == 0) {
            StartProduct(production);
            return;
        } else if (current == null) {
            Next();
        }
        queue.Enqueue(production);
    }

    public bool Empty() {
        return queue.Count == 0 && current == null;
    }
}
