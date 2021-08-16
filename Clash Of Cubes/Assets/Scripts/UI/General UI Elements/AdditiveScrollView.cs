using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdditiveScrollView : MonoBehaviour
{
    public ScrollRect scrollRect;

    private List<GameObject> items = new List<GameObject>();
    private Vector3 nextPosition = Vector3.zero;

    public GameObject Add(GameObject gameObject) {
        var instance = Instantiate(gameObject, scrollRect.content);
        instance.transform.localPosition = nextPosition;

        var rectTransform = gameObject.GetComponent<RectTransform>();
        nextPosition.x += rectTransform.sizeDelta.x;

        items.Add(instance);
        return instance;
    }

    public void Remove(int index) {
        // Destroy(items[index]);
        for (int i = index; i < items.Count - 1; i++) {
            items[i + 1].GetComponent<RectTransform>().position 
                = items[i].GetComponent<RectTransform>().position;
            items[i] = items[i + 1];
        }
        items.Capacity--;
    }

    public void Clear() {
        nextPosition = Vector3.zero;
        items = new List<GameObject>();
    }
}
