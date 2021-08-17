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
        GameObject toDelete = items[index];
        float dx = toDelete.gameObject.GetComponent<RectTransform>().sizeDelta.x;
        nextPosition.x -= dx;
        for (int i = index; i < items.Count; i++) {
            items[i].transform.localPosition -= new Vector3(dx, 0, 0);
        }
        items.Remove(toDelete);
        Destroy(toDelete);
    }

    public void Clear() {
        nextPosition = Vector3.zero;
        items = new List<GameObject>();
    }
}
