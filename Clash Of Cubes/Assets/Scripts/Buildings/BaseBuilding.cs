using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Price {
    public int gold;
    public int metal;
    public int diamonds;
    public float realMoney;
}

public abstract class BaseBuilding : MonoBehaviour
{
    public Vector2 shape;
    public Price price;
}
