using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitive = 1f;

    private Vector3 lastMousePosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
            lastMousePosition = Input.mousePosition;
        if (Input.GetMouseButton(0)) {
            Vector3 forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward).normalized;
            Vector3 right = Vector3.Scale(new Vector3(1, 0, 1), transform.right).normalized;
            Vector3 delta = -(Input.mousePosition - lastMousePosition);
            // transform.position += 0.01f * sensitive * (right * delta.x + forward * delta.y);
            // GetComponent<Rigidbody>().MovePosition(
            //     transform.position + 0.01f * sensitive * (right * delta.x + forward * delta.y)
            // );
            GetComponent<Rigidbody>().velocity = sensitive * (right * delta.x + forward * delta.y);

            lastMousePosition = Input.mousePosition;
        }
    }
}
