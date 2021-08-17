using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Supply
{
    public List<Camp> camps = new List<Camp>();

    public int capacity {
        get {
            return SumCamps().capacity;
        }
    }

    public int used {
        get {
            return SumCamps().used;
        }
    }

    public int remains {
        get {
            return SumCamps().remains;
        }
    }

    public List<BaseUnit> units {
        get {
            return SumCamps().units;
        }
    }

    private Camp SumCamps() {
        Camp camp = new Camp();
        foreach (var c in camps) {
            camp += c;
        }
        return camp;
    }

    public void Add(Camp camp) {
        camps.Add(camp);
    }

    // Returns true if able to add
    public bool Add(BaseUnit unit) {
        foreach (var camp in camps)
        {
            if (camp.remains >= unit.supply) {
                camp.Add(unit);
                return true;
            }
        }
        return false;
    }
}
