using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Price {
    public int gold;
    public int metal;
    public int diamonds;
    public float realMoney;

    public Price Clone() {
        Price price = new Price();
        price.gold = gold;
        price.metal = metal;
        price.diamonds = diamonds;
        price.realMoney = realMoney;
        return price;
    }

    public Price Normalize() {
        Price price = this.MemberwiseClone() as Price;
        if (price.gold < 0)
            price.gold = 0;
        if (price.metal < 0)
            price.metal = 0;
        if (price.diamonds < 0)
            price.diamonds = 0;
        if (price.realMoney < 0)
            price.realMoney = 0;
        return price;
    }

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
    public bool isWork {
        get {
            return _isWork;
        }
        set {
            _isWork = value;
            if (value == true) {
                Launch();
            }
        }
    }

    public bool isBuilding {
        get {
            return buildJob.inProcess;
        }
    }

    private bool _isWork = false;

    [System.NonSerialized] public Field field;

    protected virtual void Start() {
        if (isWork || isBuilding) {
            field.AddBuilding(this);
            bar.gameObject.SetActive(true);
        } else {
            bar.gameObject.SetActive(false);
        }
    }

    public void Choose() {
        field.Choose(this);
    }

    public void Build(bool instantly=false) {
        bar.gameObject.SetActive(true);
        buildJob.endEvent.AddListener(()=>{
            EndBuild();
        });

        buildJob.Launch();
        if (!instantly)
            StartCoroutine("BuildProcess");
    }

    private void EndBuild() {
        isWork = true;
        bar.gameObject.SetActive(false);
    }

    IEnumerator BuildProcess() {
        bar.min = buildJob.startTime.ToFloat();
        bar.max = buildJob.endTime.ToFloat();
        while (isBuilding) {
            bar.current = Time.time;
            yield return null;
        }
    }

    public virtual string UpgradeToString() {
        string result = "";
        if (nextLevel) {
            result += "Upgrade 1";
        } else {
            result += "Nothing to upgrade";
        }
        return result;
    }

    protected abstract void Launch();
    protected abstract void Stop();

}
