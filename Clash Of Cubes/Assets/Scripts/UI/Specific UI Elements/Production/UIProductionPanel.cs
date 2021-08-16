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

    public override void Buy(BaseProduction prefab) {
        var instance = scrollQueue
            .Add(queueItemPrefab.gameObject).GetComponent<UIQueueItem>();
        instance.prefab = prefab;
        
        instance.job.endEvent.AddListener(() => {
            scrollQueue.Remove(0);
            instance.active = false;
            queueItems.Dequeue();
        });

        factory.queue.Add(prefab);
        instance.active = true;
        queueItems.Enqueue(instance);
    }
}