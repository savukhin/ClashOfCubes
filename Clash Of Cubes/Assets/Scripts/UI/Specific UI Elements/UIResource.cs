using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResource : MonoBehaviour
{
    public Text text;
    public ProgressBar bar;
    public int count {
        get {
            return _current;
        }
        set {
            text.text = value.ToString();
            _current = value;
            if (bar)
                bar.current = value;
        }
    }

    public int max {
        get {
            return _max;
        }
        set {
            _max = value;
            if (bar)
                bar.max = value;
        }
    }

    private int _current = 0;
    private int _max = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
