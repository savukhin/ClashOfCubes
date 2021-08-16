using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent OnClick;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.gray, 10);
            
            if (Physics.Raycast(ray, out hit) 
                    && hit.collider.gameObject == this.gameObject) {
                OnClick.Invoke();
            }
        }
    }
}
