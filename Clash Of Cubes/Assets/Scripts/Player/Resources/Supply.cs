using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supply : LimitedResource
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
}
