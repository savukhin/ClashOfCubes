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
            return int.Parse(text.text);
        }
        set {
            text.text = value.ToString();
            bar.current = value;
        }
    }

    public int max {
        get {
            return (int)bar.max;
        }
        set {
            bar.max = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
