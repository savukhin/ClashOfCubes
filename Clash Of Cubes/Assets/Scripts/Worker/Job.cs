using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Job
{
    public Price price;
    public JobTime duration;
    [System.NonSerialized] public JobTime startTime;
    [System.NonSerialized] public JobTime currentTime;
    [System.NonSerialized] public JobTime endTime;
    public UnityEngine.Events.UnityEvent endEvent;

    private bool _freezed = false;
    private bool _ended = false;

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

    public bool ended {
        get {
            return _ended;
        }
    }

    public bool freezed {
        get {
            return _freezed;
        }
        set {
            _freezed = value;
            runner.StopAllCoroutines();
            if (value == true && inProcess) {
                runner.StartCoroutine(ProcessJob());
            }
        }
    }

    public bool inProcess {
        get {
            if (endTime == null || ended)
                return false;
            return true;
        }
    }

    IEnumerator ProcessJob() {
        yield return null;
        while (currentTime.ToFloat() < endTime.ToFloat()) {
            currentTime += Time.deltaTime;
            yield return null;
        }
        _ended = true;
        endEvent.Invoke();
    }

    public void Launch(bool instantly=false) {
        _ended = false;
        startTime = JobTime.FromFloat(Time.time);
        currentTime = startTime;
        if (instantly)
            duration = JobTime.Zero;
            
        endTime = duration + startTime.ToFloat();
        runner.StartCoroutine(ProcessJob());
    }
}
