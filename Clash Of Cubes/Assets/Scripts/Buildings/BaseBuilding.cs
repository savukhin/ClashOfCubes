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

    [System.NonSerialized] public Field field;

    void Start() {
        field.AddBuilding(this);
    }

    public void Choose() {
        field.Choose(this);
    }

    public void Build() {
        buildJob.Launch();
        StartCoroutine("BuildProcess");
    }

    IEnumerator BuildProcess() {
        bar.min = buildJob.startTime.ToFloat();
        bar.max = buildJob.endTime.ToFloat();
        while (isBuilding) {
            bar.current = Time.time;
            yield return null;
        }
        Destroy(bar);
    }

    public string UpgradeToString() {
        string result = "";
        if (nextLevel) {
            result += "Upgrade 1";
        } else {
            result += "Nothing to upgrade";
        }
        return result;
    }
}
