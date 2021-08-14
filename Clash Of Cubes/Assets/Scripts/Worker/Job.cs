using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Job
{
    public Price price;
    public JobTime duration;
    [System.NonSerialized] public JobTime startTime;
    [System.NonSerialized] public JobTime endTime;
    public UnityEngine.Events.UnityEvent endEvent;

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

    public bool inProcess {
        get {
            if (endTime == null)
                return false;
            if (Time.time > endTime.ToFloat())
                return false;
            return true;
        }
    }

    IEnumerator EndJob() {
        Debug.Log("Wait for " + duration.ToFloat() + " Seconds");
        yield return new WaitForSeconds(duration.ToFloat());
        Debug.Log("END");
        endEvent.Invoke();
    }

    public void Launch() {
        startTime = JobTime.FromFloat(Time.time);
        endTime = duration + Time.time;
        runner.StartCoroutine(EndJob());
    }
}
