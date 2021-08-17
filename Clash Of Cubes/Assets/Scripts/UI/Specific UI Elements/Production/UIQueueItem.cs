using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQueueItem : BaseUIShopItem
{
    public ProgressBar bar;

    void Update() {
        if (job.ended) {
            return;
        }

        if (!job.inProcess) {
            bar.min = 0;
            bar.max = 0;
            bar.current = 0;
            return;
        }

        bar.min = job.startTime.ToFloat();
        bar.max = job.endTime.ToFloat();
        bar.current = job.currentTime.ToFloat();
    }
}
