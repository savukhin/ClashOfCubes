using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Camp
{
    public int capacity = 0;
    public List<BaseUnit> units = new List<BaseUnit>();
    public int used = 0;

    public int remains {
        get {
            return capacity - used;
        }
    }

    public bool Add(BaseUnit unit) {
        if (unit.supply > remains) {
            return false;
        }
        units.Add(unit);
        used += unit.supply;
        return true;
    }

    public static Camp operator + (Camp a, Camp b) {
        Camp camp = new Camp();
        camp.capacity = a.capacity + b.capacity;
        foreach (var unit in a.units)
            camp.Add(unit);
        foreach (var unit in b.units)
            camp.Add(unit);
        return camp;
    }
}
