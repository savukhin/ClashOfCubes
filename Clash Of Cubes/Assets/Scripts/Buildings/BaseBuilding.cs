using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Price {
    public int gold;
    public int metal;
    public int diamonds;
    public float realMoney;

    public override string ToString()
    {
        string res = "";
        if (gold != 0)
            res += gold + " gold ";
        if (metal != 0)
            res += metal + " metal ";
        if (diamonds != 0)
            res += diamonds + " diamonds ";
        if (realMoney != 0)
            res += realMoney + " griven ";
        if (res == "")
            res = "Free!";
        return res;
    }
}

public abstract class BaseBuilding : MonoBehaviour
{
    public Job buildJob;
    public Vector2 shape;
    public BaseBuilding nextLevel;
    public ProgressBar bar;

    public bool isBuilding {
        get {
            return buildJob.inProcess;
        }
    }

    public void Build() {
        buildJob.Launch();
        StartCoroutine("BuildProcess");
    }

    IEnumerator BuildProcess() {
        bar.min = buildJob.startTime.ToFloat();
        bar.max = buildJob.endTime.ToFloat();
        print("min = " + bar.min + " start time " + buildJob.startTime.ToFloat() + " " + buildJob.startTime.ToString());
        print("max = " + bar.max);
        while (isBuilding) {
            bar.current = Time.time;
            print("current = " + Time.time);
            yield return null;
        }
        Destroy(bar);
        print("Building " + this + " was builded");
    }
}
