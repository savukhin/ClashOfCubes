using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProductionPanel : BaseUIShop
{
    public AdditiveScrollView scrollQueue;
    public FactoryBuilding factory;
    public UIQueueItem queueItemPrefab;

    private Queue<UIQueueItem> queueItems = new Queue<UIQueueItem>();

    void Start() {
        factory.queue.producedEvent.AddListener(() => {
            scrollQueue.Remove(0);
            queueItems.Dequeue();
        });
    }

    public override void Buy(BaseProduction prefab) {
        if (parent.Buy(prefab) == false)
            return;

        var instance = scrollQueue
            .Add(queueItemPrefab.gameObject).GetComponent<UIQueueItem>();
        var unit = Instantiate(prefab);
        instance.prefab = unit;

        factory.queue.Add(unit);
        queueItems.Enqueue(instance);
    }
}
