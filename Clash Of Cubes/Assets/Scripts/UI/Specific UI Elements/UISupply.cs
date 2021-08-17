using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISupply : MonoBehaviour
{
    public Text maxText;
    public Text currentText;

    private int _max;
    private int _current;

    public int current {
        set {
            _current = value;
            currentText.text = value.ToString();
        }
        get {
            return _current;
        }
    }

    public int max {
        set {
            _max = value;
            maxText.text = value.ToString();
        }
        get {
            return _max;
        }
    }
}
