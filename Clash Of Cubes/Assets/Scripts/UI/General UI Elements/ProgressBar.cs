using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public GameObject handler;
    [SerializeField]
    private float m_max = 10;
    [SerializeField]
    private float m_min = 0;
    [SerializeField]
    private float m_current = 10;

    public float max {
        get {
            return m_max;
        }

        set {
            m_max = value;
            Refresh();
        }
    }

    public float min {
        get {
            return m_min;
        }

        set {
            m_min = value;
            Refresh();
        }
    }

    public float current {
        get {
            return m_current;
        }

        set {
            m_current = value;
            Refresh();
        }
    }

    private float width;

    void Refresh() {
        float diff = (max - min);
        float percent = 0;
        if (diff == 0 && current == min)
            percent = 0;
            // handler.transform.localScale = Vector3.one;
            // handler.transform.localPosition = new Vector3(width / 2f, 0f, 0f);
        else if (diff == 0)
            percent = 1;
        else
            percent = (current - min) / diff;

        handler.transform.localScale = new Vector3(percent, 1f, 1f);
        Vector3 pos = handler.transform.localPosition;
        pos.x = -width / 2f + percent * width / 2f;
        handler.transform.localPosition = pos;
    }

    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<RectTransform>().rect.width * GetComponent<RectTransform>().localScale.x;
        Refresh();
    }
}
