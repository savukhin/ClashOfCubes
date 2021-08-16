using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQueueItem : BaseUIShopItem
{
    public ProgressBar bar;
    public bool active = false;
    void Update() {
        if (!active)
            return;

        bar.min = job.startTime.ToFloat();
        bar.max = job.endTime.ToFloat();
        bar.current = Time.time;
    }
}
